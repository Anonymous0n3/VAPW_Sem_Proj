using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System.Configuration;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using VAPW_Sem_Proj.Component;
using VAPW_Sem_Proj.Data;
using VAPW_Sem_Proj.Data.Models;

namespace VAPW_Sem_Proj
{
    public partial class Form1 : Form
    {
        private VAPW_PS_DrivesContext dbContext;
        // Uložené výpočty pro další použití (např. v MouseClick)
        private double minLat, maxLat, minLon, maxLon;
        private double scale;
        private double padding = 20;

        public Form1()
        {
            InitializeComponent();
            LoadPanelNames(getPanels());
            dbContext = new VAPW_PS_DrivesContext(ConfigurationManager.ConnectionStrings["Pripojeni"].ConnectionString);

            // Získání rozlišení hlavní obrazovky
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            // Nastavení velikosti na polovinu rozlišení
            this.Size = new Size((screenWidth * 3) / 4, (screenHeight * 3) / 4);

            // Zakázání změny velikosti
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

        }

        private void LoadPanelNames(List<UserControl1> panels)
        {
            foreach (UserControl1 panel in panels)
            {
                customPanelBox.Items.Add(panel.Name);
            }
        }

        private List<UserControl1> getPanels()
        {
            List<UserControl1> panels = new List<UserControl1>();
            foreach (Control control in driveTable.Controls)
            {
                if (control is UserControl1 userControl1)
                {
                    panels.Add(userControl1);
                }
            }
            return panels;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var recordings = dbContext.Recordings.ToList();
            drives.DataSource = recordings;
            drives.DisplayMember = "StartDateTime"; // nebo třeba "UIID", co chceš zobrazit
            drives.ValueMember = "Id";

            // Volitelně: nastavíme výchozí výběr
            if (drives.Items.Count > 0)
                drives.SelectedIndex = 0;
        }

        private List<DriveData> currentDriveData = new();

        private void drives_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = drives.SelectedItem as Recordings;
            if (selected != null)
            {
                currentDriveData = dbContext.DriveData
                    .Where(d => d.RecordingId == selected.Id)
                    .OrderBy(d => d.TimeFromStartSeconds)
                    .ToList();


                if (customPanelBox.SelectedItem != null) invalidate_Panel();

            }
        }

        private void driveDraw_Paint(object sender, PaintEventArgs e)
        {
            if (currentDriveData == null || currentDriveData.Count < 2)
            {
                e.Graphics.DrawString("Žádná data k vykreslení.", this.Font, Brushes.Red, new PointF(10, 10));
                return;
            }

            var validPoints = currentDriveData
                .Where(p => p.LatRec.HasValue && p.LonRec.HasValue)
                .ToList();

            if (validPoints.Count < 2)
            {
                e.Graphics.DrawString("Nedostatek platných bodů (LatRec/LonRec).", this.Font, Brushes.Red, new PointF(10, 30));
                return;
            }

            // Uložíme rozsah souřadnic jako třída-level proměnné
            minLat = validPoints.Min(p => p.LatRec.Value);
            maxLat = validPoints.Max(p => p.LatRec.Value);
            minLon = validPoints.Min(p => p.LonRec.Value);
            maxLon = validPoints.Max(p => p.LonRec.Value);
            float topSpeed = validPoints.Max(p => p.SpeedRec.Value);

            double latRange = maxLat - minLat;
            double lonRange = maxLon - minLon;

            if (latRange == 0 || lonRange == 0)
            {
                e.Graphics.DrawString("Rozsah souřadnic je nulový.", this.Font, Brushes.Red, new PointF(10, 50));
                return;
            }

            double panelWidth = driveDraw1.Width - 2 * padding;
            double panelHeight = driveDraw1.Height - 2 * padding;

            double scaleX = panelWidth / lonRange;
            double scaleY = panelHeight / latRange;
            scale = Math.Min(scaleX, scaleY); // ukládáme do pole

            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // === 1. ZÁKLADNÍ TRASA ===
            PointF? prevPoint = null;
            if (!turnButton.Checked && !speedButton.Checked)
            {
                for (int i = 0; i < validPoints.Count; i++)
                {
                    var point = validPoints[i];
                    double x = (point.LonRec.Value - minLon) * scale + padding;
                    double y = (maxLat - point.LatRec.Value) * scale + padding;
                    var currentPoint = new PointF((float)x, (float)y);

                    g.FillEllipse(new SolidBrush(Properties.Settings.Default.ColorDefault), currentPoint.X - 2, currentPoint.Y - 2, 4, 4);

                    if (prevPoint != null)
                    {
                        g.DrawLine(new Pen(Properties.Settings.Default.ColorDefault, 2), prevPoint.Value, currentPoint);
                    }

                    prevPoint = currentPoint;
                }
            }
            // === 2. ZVÝRAZNĚNÍ ÚSEKŮ PODLE REŽIMU ===
            prevPoint = null;
            for (int i = 0; i < validPoints.Count; i++)
            {
                var point = validPoints[i];
                double x = (point.LonRec.Value - minLon) * scale + padding;
                double y = (maxLat - point.LatRec.Value) * scale + padding;
                var currentPoint = new PointF((float)x, (float)y);

                if (prevPoint != null)
                {
                    Pen pen;

                    if (turnButton.Checked)
                    {
                        int? dir = point.CurveTurnDirection;
                        if (dir < 0)
                            pen = new Pen(Properties.Settings.Default.ColorTurnLeft, 2);
                        else if (dir > 0)
                            pen = new Pen(Properties.Settings.Default.ColorTurnRight, 2);
                        else pen = new Pen(Properties.Settings.Default.ColorDefault, 2);
                    }
                    else if (speedButton.Checked)
                    {
                        float acc = point.SpeedRec.Value;
                        pen = new Pen(SpeedToColor(acc, topSpeed), 2);
                    }
                    else
                    {
                        continue;
                    }

                    g.DrawLine(pen, prevPoint.Value, currentPoint);
                }

                prevPoint = currentPoint;
            }

            // Debug info
            e.Graphics.DrawString("Trasa vykreslena", this.Font, Brushes.DarkGreen, new PointF(10, 10));
        }

        private Color SpeedToColor(float speed, float maxSpeed)
        {
            // Pomalá modrá → rychlá červená
            Color colorLow = Properties.Settings.Default.ColorAccelerationLow;
            Color colorTop = Properties.Settings.Default.ColorAccelerationTop;

            // Normalizace rychlosti mezi 0 a 1
            float t = Math.Clamp(speed / maxSpeed, 0f, 1f);

            // Interpolace mezi barvami
            int red = (int)(colorLow.R + t * (colorTop.R - colorLow.R));
            int green = (int)(colorLow.G + t * (colorTop.G - colorLow.G));
            int blue = (int)(colorLow.B + t * (colorTop.B - colorLow.B));

            // Interpolace průhlednosti (50 při 0 km/h, 255 při maxSpeed)
            int alpha = (int)(50 + t * (255 - 50));

            return Color.FromArgb(alpha, red, green, blue);
        }

        private void turnButton_CheckedChanged(object sender, EventArgs e)
        {
            invalidate_Panel();
        }

        private void speedButton_CheckedChanged(object sender, EventArgs e)
        {
            invalidate_Panel();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            OpenSettings();
        }

        private void OpenSettings()
        {
            using (SettingsForm settingsForm = new SettingsForm())
            {
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    // Příklad – pokud chceš něco ihned přenést po zavření nastavení
                    // např. překreslit driveDraw panel nebo aplikovat barvy
                    ColorDialog colorDialog = new ColorDialog();
                    invalidate_Panels() ; // překreslí trasu

                    // Můžeš zde rovnou uložit barvy pro pozdější použití při vykreslení
                }
            }
        }

        private void ShowDrivePointDetails(DriveData point)
        {
            if (point == null) return;

            labelSpeed.Text = $"Rychlost: {point.SpeedRec?.ToString("0.0")} km/h";
            labelRoll.Text = $"Náklon: {point.Roll.ToString("0.0")}°";

            string accText;
            if (point.Ax > 0)
                accText = "Zrychluje";
            else if (point.Ax < 0)
                accText = "Brzdí";
            else
                accText = "Konstantní rychlost";

            labelAcc.Text = $"Stav: {accText}";

            rollPanel.Invalidate(); // překreslí grafický model motocyklu
        }

        private DriveData selectedDrivePoint;

        private void rollPanel_Paint(object sender, PaintEventArgs e)
        {
            if (selectedDrivePoint == null) return;

            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            float width = rollPanel.Width;
            float height = rollPanel.Height;

            // Střed panelu
            PointF center = new PointF(width / 2, height / 2);

            // Délka ručičky
            float needleLength = Math.Min(width, height) / 2 - 10;

            // Úhel náklonu (v stupních) → převedeme na radiány
            float rollAngleDegrees = selectedDrivePoint.Roll;
            float angleRad = (float)(-(rollAngleDegrees * Math.PI / 180));

            // Výpočet koncového bodu ručičky
            PointF endPoint = new PointF(
                center.X + (float)(Math.Sin(-angleRad) * needleLength),
                center.Y + (float)(-Math.Cos(angleRad) * needleLength)
            );

            // Vykreslení základního kruhu
            g.DrawEllipse(Pens.Gray, center.X - needleLength, center.Y - needleLength, needleLength * 2, needleLength * 2);

            // Vykreslení ručičky
            using (Pen needlePen = new Pen(Color.DarkRed, 3))
            {
                g.DrawLine(needlePen, center, endPoint);
            }

            // Volitelně popisky (např. -90°, 0°, +90°)
            using (Font f = new Font(FontFamily.GenericSansSerif, 8))
            {
                g.DrawString("-90°", f, Brushes.Black, center.X - needleLength - 10, center.Y - 8);
                g.DrawString("0°", f, Brushes.Black, center.X - 10, center.Y - needleLength - 15);
                g.DrawString("+90°", f, Brushes.Black, center.X + needleLength - 25, center.Y - 8);
            }
        }

        private void driveDraw_MouseClick(object sender, MouseEventArgs e)
        {
            if (currentDriveData == null || currentDriveData.Count == 0) return;

            var validPoints = currentDriveData.Where(p => p.LatRec.HasValue && p.LonRec.HasValue).ToList();

            DriveData? closestPoint = null;
            double minDist = double.MaxValue;
            PointF? clickPos = e.Location;

            foreach (var point in validPoints)
            {
                double x = (point.LonRec.Value - minLon) * scale + padding;
                double y = (maxLat - point.LatRec.Value) * scale + padding;

                double dist = Math.Pow(x - clickPos.Value.X, 2) + Math.Pow(y - clickPos.Value.Y, 2);
                if (dist < minDist)
                {
                    minDist = dist;
                    closestPoint = point;
                }
            }

            if (closestPoint != null)
            {
                selectedDrivePoint = closestPoint;
                ShowDrivePointDetails(closestPoint);
                rollPanel.Invalidate();
            }
        }

        private void invalidate_Panel() 
        {
            // Překreslení panelu
            string currentPanel = customPanelBox.SelectedItem.ToString();
            foreach (UserControl1 panel in getPanels())
            {
                if (panel.Name.Equals(currentPanel))
                {
                    panel.Invalidate();
                }
            }
        }

        private void invalidate_Panels() 
        {
            foreach (UserControl1 panel in getPanels())
            {
                    panel.Invalidate();
            }
        }
    }
}
