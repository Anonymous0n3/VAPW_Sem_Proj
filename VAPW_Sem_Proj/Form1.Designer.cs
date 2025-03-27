namespace VAPW_Sem_Proj
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            customPanelBox = new ComboBox();
            btnSettings = new Button();
            speedButton = new RadioButton();
            turnButton = new RadioButton();
            drives = new ComboBox();
            panel2 = new Panel();
            labelAcc = new Label();
            labelRoll = new Label();
            labelSpeed = new Label();
            rollPanel = new Panel();
            driveTable = new TableLayoutPanel();
            driveDraw3 = new VAPW_Sem_Proj.Component.UserControl1();
            driveDraw2 = new VAPW_Sem_Proj.Component.UserControl1();
            driveDraw1 = new VAPW_Sem_Proj.Component.UserControl1();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            driveTable.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel2, 2, 0);
            tableLayoutPanel1.Controls.Add(driveTable, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(customPanelBox);
            panel1.Controls.Add(btnSettings);
            panel1.Controls.Add(speedButton);
            panel1.Controls.Add(turnButton);
            panel1.Controls.Add(drives);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(154, 444);
            panel1.TabIndex = 2;
            // 
            // customPanelBox
            // 
            customPanelBox.FormattingEnabled = true;
            customPanelBox.Location = new Point(3, 107);
            customPanelBox.Margin = new Padding(2);
            customPanelBox.Name = "customPanelBox";
            customPanelBox.Size = new Size(129, 23);
            customPanelBox.TabIndex = 4;
            // 
            // btnSettings
            // 
            btnSettings.Location = new Point(3, 421);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(75, 23);
            btnSettings.TabIndex = 3;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += buttonSettings_Click;
            // 
            // speedButton
            // 
            speedButton.AutoSize = true;
            speedButton.Location = new Point(9, 57);
            speedButton.Name = "speedButton";
            speedButton.Size = new Size(70, 19);
            speedButton.TabIndex = 2;
            speedButton.TabStop = true;
            speedButton.Text = "Rychlost";
            speedButton.UseVisualStyleBackColor = true;
            speedButton.CheckedChanged += speedButton_CheckedChanged;
            // 
            // turnButton
            // 
            turnButton.AutoSize = true;
            turnButton.Location = new Point(9, 32);
            turnButton.Name = "turnButton";
            turnButton.Size = new Size(70, 19);
            turnButton.TabIndex = 1;
            turnButton.TabStop = true;
            turnButton.Text = "Zatáčení";
            turnButton.UseVisualStyleBackColor = true;
            turnButton.CheckedChanged += turnButton_CheckedChanged;
            // 
            // drives
            // 
            drives.FormattingEnabled = true;
            drives.Location = new Point(3, -3);
            drives.Name = "drives";
            drives.Size = new Size(121, 23);
            drives.TabIndex = 0;
            drives.SelectedIndexChanged += drives_SelectedIndexChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(labelAcc);
            panel2.Controls.Add(labelRoll);
            panel2.Controls.Add(labelSpeed);
            panel2.Controls.Add(rollPanel);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(643, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(154, 444);
            panel2.TabIndex = 4;
            // 
            // labelAcc
            // 
            labelAcc.AutoSize = true;
            labelAcc.Location = new Point(58, 189);
            labelAcc.Name = "labelAcc";
            labelAcc.Size = new Size(38, 15);
            labelAcc.TabIndex = 3;
            labelAcc.Text = "label3";
            // 
            // labelRoll
            // 
            labelRoll.AutoSize = true;
            labelRoll.Location = new Point(58, 93);
            labelRoll.Name = "labelRoll";
            labelRoll.Size = new Size(38, 15);
            labelRoll.TabIndex = 2;
            labelRoll.Text = "label2";
            // 
            // labelSpeed
            // 
            labelSpeed.AutoSize = true;
            labelSpeed.Location = new Point(58, 11);
            labelSpeed.Name = "labelSpeed";
            labelSpeed.Size = new Size(38, 15);
            labelSpeed.TabIndex = 1;
            labelSpeed.Text = "label1";
            // 
            // rollPanel
            // 
            rollPanel.Dock = DockStyle.Bottom;
            rollPanel.Location = new Point(0, 240);
            rollPanel.Margin = new Padding(1);
            rollPanel.Name = "rollPanel";
            rollPanel.Padding = new Padding(2);
            rollPanel.Size = new Size(154, 204);
            rollPanel.TabIndex = 0;
            rollPanel.Paint += rollPanel_Paint;
            // 
            // driveTable
            // 
            driveTable.AutoScroll = true;
            driveTable.AutoSize = true;
            driveTable.ColumnCount = 3;
            driveTable.ColumnStyles.Add(new ColumnStyle());
            driveTable.ColumnStyles.Add(new ColumnStyle());
            driveTable.ColumnStyles.Add(new ColumnStyle());
            driveTable.Controls.Add(driveDraw3, 2, 0);
            driveTable.Controls.Add(driveDraw2, 1, 0);
            driveTable.Controls.Add(driveDraw1, 0, 0);
            driveTable.Dock = DockStyle.Fill;
            driveTable.Location = new Point(162, 2);
            driveTable.Margin = new Padding(2);
            driveTable.Name = "driveTable";
            driveTable.RowCount = 1;
            driveTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            driveTable.Size = new Size(476, 446);
            driveTable.TabIndex = 5;
            // 
            // driveDraw3
            // 
            driveDraw3.Dock = DockStyle.Fill;
            driveDraw3.Location = new Point(318, 2);
            driveDraw3.Margin = new Padding(2);
            driveDraw3.Name = "driveDraw3";
            driveDraw3.Size = new Size(156, 442);
            driveDraw3.TabIndex = 8;
            driveDraw3.Load += MainForm_Load;
            driveDraw3.Paint += driveDraw_Paint;
            driveDraw3.MouseClick += driveDraw_MouseClick;
            // 
            // driveDraw2
            // 
            driveDraw2.Dock = DockStyle.Fill;
            driveDraw2.Location = new Point(160, 2);
            driveDraw2.Margin = new Padding(2);
            driveDraw2.Name = "driveDraw2";
            driveDraw2.Size = new Size(154, 442);
            driveDraw2.TabIndex = 7;
            driveDraw2.Load += MainForm_Load;
            driveDraw2.Paint += driveDraw_Paint;
            driveDraw2.MouseClick += driveDraw_MouseClick;
            // 
            // driveDraw1
            // 
            driveDraw1.Dock = DockStyle.Fill;
            driveDraw1.Location = new Point(2, 2);
            driveDraw1.Margin = new Padding(2);
            driveDraw1.Name = "driveDraw1";
            driveDraw1.Size = new Size(154, 442);
            driveDraw1.TabIndex = 6;
            driveDraw1.Load += MainForm_Load;
            driveDraw1.Paint += driveDraw_Paint;
            driveDraw1.MouseClick += driveDraw_MouseClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Form1";
            Load += MainForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            driveTable.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private RadioButton speedButton;
        private RadioButton turnButton;
        private ComboBox drives;
        private Panel panel2;
        private Panel rollPanel;
        private Label labelAcc;
        private Label labelRoll;
        private Label labelSpeed;
        private Button btnSettings;
        private TableLayoutPanel driveTable;
        private Component.UserControl1 driveDraw2;
        private Component.UserControl1 driveDraw1;
        private ComboBox customPanelBox;
        private Component.UserControl1 driveDraw3;
    }
}
