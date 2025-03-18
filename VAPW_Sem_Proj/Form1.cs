using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System.Configuration;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
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
            dbContext = new VAPW_PS_DrivesContext(ConfigurationManager.ConnectionStrings["Pripojeni"].ConnectionString);

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

                MessageBox.Show($"Načteno {currentDriveData.Count} bodů pro záznam ID {selected.Id}");

                driveDraw.Invalidate(); // překresli
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

            double latRange = maxLat - minLat;
            double lonRange = maxLon - minLon;

            if (latRange == 0 || lonRange == 0)
            {
                e.Graphics.DrawString("Rozsah souřadnic je nulový.", this.Font, Brushes.Red, new PointF(10, 50));
                return;
            }

            double panelWidth = driveDraw.Width - 2 * padding;
            double panelHeight = driveDraw.Height - 2 * padding;

            double scaleX = panelWidth / lonRange;
            double scaleY = panelHeight / latRange;
            scale = Math.Min(scaleX, scaleY); // ukládáme do pole

            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // === 1. ZÁKLADNÍ TRASA ===
            PointF? prevPoint = null;
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
                        pen = new Pen(SpeedToColor(acc), 2);
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

        private Color SpeedToColor(float speed)
        {
            // Pomalá modrá → rychlá červená 30 km/h
            Color color = Properties.Settings.Default.ColorAcceleration;
            var argb = color.ToArgb();
            int red = (argb >> 16) & 0xFF;
            int green = (argb >> 8) & 0xFF;
            int blue = argb & 0xFF;

            int alpha = (int)(50 + (speed / 30.0) * (255 - 50));
            return Color.FromArgb(alpha, red, green, blue);
        }

        private void turnButton_CheckedChanged(object sender, EventArgs e)
        {
            driveDraw.Invalidate();
        }

        private void speedButton_CheckedChanged(object sender, EventArgs e)
        {
            driveDraw.Invalidate();
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
                    driveDraw.Invalidate(); // překreslí trasu

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

            PointF center = new PointF(width / 2, height / 2);
            float rollAngleDegrees = selectedDrivePoint.Roll;

            try
            {
                using (Image bikeImage = Image.FromFile("C:\\Users\\42077\\source\\repos\\VAPW_Sem_Proj\\VAPW_Sem_Proj\\img\\motorcycle.jpg"))
                {
                    // Určení velikosti obrázku (zmenšení podle panelu)
                    int imageSize = Math.Min(rollPanel.Width, rollPanel.Height) / 2;
                    Rectangle destRect = new Rectangle((int)(center.X - imageSize / 2), (int)(center.Y - imageSize / 2), imageSize, imageSize);

                    // Vytvoření transformační matice pro otočení obrázku
                    using (Matrix matrix = new Matrix())
                    {
                        matrix.RotateAt(-rollAngleDegrees, center);
                        g.Transform = matrix;

                        // Vykreslení obrázku
                        g.DrawImage(bikeImage, destRect);
                    }

                    // Reset transformace
                    g.ResetTransform();
                }
            }
            catch (Exception ex)
            {
                g.DrawString("Chyba načtení obrázku", this.Font, Brushes.Red, new PointF(10, 10));
            }

            using (Font f = new Font(FontFamily.GenericSansSerif, 8))
            {
                g.DrawString("-90°", f, Brushes.Black, center.X - width / 2 + 10, center.Y);
                g.DrawString("0°", f, Brushes.Black, center.X - 10, center.Y - height / 2 + 10);
                g.DrawString("+90°", f, Brushes.Black, center.X + width / 2 - 25, center.Y);
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

    }
}
