using System;
using System.Drawing;
using System.Windows.Forms;

namespace VAPW_Sem_Proj
{
    public partial class SettingsForm : Form
    {

        private Color colorDefault;
        private Color colorTurnLeft;
        private Color colorTurnRight;
        private Color colorAccelerationTop;
        private Color colorAccelerationLow;

        public SettingsForm()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            colorDefault = Properties.Settings.Default.ColorDefault;
            colorTurnLeft = Properties.Settings.Default.ColorTurnLeft;
            colorTurnRight = Properties.Settings.Default.ColorTurnRight;
            colorAccelerationTop = Properties.Settings.Default.ColorAccelerationTop;
            colorAccelerationLow = Properties.Settings.Default.ColorAccelerationLow;

            btnColorDefault.BackColor = Properties.Settings.Default.ColorDefault;
            btnColorTurnLeft.BackColor = Properties.Settings.Default.ColorTurnLeft;
            btnColorTurnRight.BackColor = Properties.Settings.Default.ColorTurnRight;
            btnColorAccelerationTop.BackColor = Properties.Settings.Default.ColorAccelerationTop;
            btnColorAccelerationLow.BackColor = Properties.Settings.Default.ColorAccelerationLow;
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.ColorDefault = colorDefault;
            Properties.Settings.Default.ColorTurnLeft = colorTurnLeft;
            Properties.Settings.Default.ColorTurnRight = colorTurnRight;
            Properties.Settings.Default.ColorAccelerationTop = colorAccelerationTop;
            Properties.Settings.Default.ColorAccelerationLow = colorAccelerationLow;
            Properties.Settings.Default.Save();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            SaveSettings();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonColorRoute_Click(object sender, EventArgs e)
        {
            PickColor(btnColorDefault);
        }

        private void buttonColorLeftTurn_Click(object sender, EventArgs e)
        {
            PickColor(btnColorTurnLeft);
        }

        private void buttonColorRightTurn_Click(object sender, EventArgs e)
        {
            PickColor(btnColorTurnRight);
        }

        private void buttonColorAccelerationTop_Click(object sender, EventArgs e)
        {
            PickColor(btnColorAccelerationTop);
        }

        private void buttonColorAccelerationLow_Click(object sender, EventArgs e)
        {
            PickColor(btnColorAccelerationLow);
        }

        private void PickColor(Button button)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = button.BackColor;
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    button.BackColor = colorDialog.Color;

                    // Okamžité uložení barvy do Settings.settings
                    if (button == btnColorDefault)
                        colorDefault = colorDialog.Color;
                    else if (button == btnColorTurnLeft)
                        colorTurnLeft = colorDialog.Color;
                    else if (button == btnColorTurnRight)
                        colorTurnRight = colorDialog.Color;
                    else if (button == btnColorAccelerationTop)
                        colorAccelerationTop = colorDialog.Color;
                    else if (button == btnColorAccelerationLow)
                        colorAccelerationLow = colorDialog.Color;
                }
            }
        }
    }
}
