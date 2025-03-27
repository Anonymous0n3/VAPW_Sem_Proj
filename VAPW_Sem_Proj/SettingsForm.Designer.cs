namespace VAPW_Sem_Proj
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnColorDefault = new Button();
            btnColorTurnLeft = new Button();
            btnColorTurnRight = new Button();
            btnColorAccelerationTop = new Button();
            btnCancel = new Button();
            btnSave = new Button();
            label5 = new Label();
            btnColorAccelerationLow = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(70, 15);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(127, 25);
            label1.TabIndex = 0;
            label1.Text = "Default Colour";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(70, 90);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(139, 25);
            label2.TabIndex = 1;
            label2.Text = "Left Turn Colour";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(70, 178);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(152, 25);
            label3.TabIndex = 2;
            label3.Text = "Right Turn Colour";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(70, 277);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(200, 25);
            label4.TabIndex = 3;
            label4.Text = "Acceleration Colour Top";
            // 
            // btnColorDefault
            // 
            btnColorDefault.Location = new Point(278, 8);
            btnColorDefault.Margin = new Padding(4, 5, 4, 5);
            btnColorDefault.Name = "btnColorDefault";
            btnColorDefault.Size = new Size(107, 38);
            btnColorDefault.TabIndex = 4;
            btnColorDefault.Text = "Change";
            btnColorDefault.UseVisualStyleBackColor = true;
            btnColorDefault.Click += buttonColorRoute_Click;
            // 
            // btnColorTurnLeft
            // 
            btnColorTurnLeft.Location = new Point(278, 83);
            btnColorTurnLeft.Margin = new Padding(4, 5, 4, 5);
            btnColorTurnLeft.Name = "btnColorTurnLeft";
            btnColorTurnLeft.Size = new Size(107, 38);
            btnColorTurnLeft.TabIndex = 5;
            btnColorTurnLeft.Text = "Change";
            btnColorTurnLeft.UseVisualStyleBackColor = true;
            btnColorTurnLeft.Click += buttonColorLeftTurn_Click;
            // 
            // btnColorTurnRight
            // 
            btnColorTurnRight.Location = new Point(278, 171);
            btnColorTurnRight.Margin = new Padding(4, 5, 4, 5);
            btnColorTurnRight.Name = "btnColorTurnRight";
            btnColorTurnRight.Size = new Size(107, 38);
            btnColorTurnRight.TabIndex = 6;
            btnColorTurnRight.Text = "Change\r\n";
            btnColorTurnRight.UseVisualStyleBackColor = true;
            btnColorTurnRight.Click += buttonColorRightTurn_Click;
            // 
            // btnColorAccelerationTop
            // 
            btnColorAccelerationTop.Location = new Point(278, 270);
            btnColorAccelerationTop.Margin = new Padding(4, 5, 4, 5);
            btnColorAccelerationTop.Name = "btnColorAccelerationTop";
            btnColorAccelerationTop.Size = new Size(107, 38);
            btnColorAccelerationTop.TabIndex = 7;
            btnColorAccelerationTop.Text = "Change\r\n";
            btnColorAccelerationTop.UseVisualStyleBackColor = true;
            btnColorAccelerationTop.Click += buttonColorAccelerationTop_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(17, 692);
            btnCancel.Margin = new Padding(4, 5, 4, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(107, 38);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += buttonCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(979, 692);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(147, 38);
            btnSave.TabIndex = 9;
            btnSave.Text = "Save and Exit";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += buttonOK_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(70, 377);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(203, 25);
            label5.TabIndex = 10;
            label5.Text = "Acceleration Colour Low";
            // 
            // btnColorAccelerationLow
            // 
            btnColorAccelerationLow.Location = new Point(278, 370);
            btnColorAccelerationLow.Margin = new Padding(4, 5, 4, 5);
            btnColorAccelerationLow.Name = "btnColorAccelerationLow";
            btnColorAccelerationLow.Size = new Size(107, 38);
            btnColorAccelerationLow.TabIndex = 11;
            btnColorAccelerationLow.Text = "Change\r\n";
            btnColorAccelerationLow.UseVisualStyleBackColor = true;
            btnColorAccelerationLow.Click += buttonColorAccelerationLow_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(btnColorAccelerationLow);
            Controls.Add(label5);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(btnColorAccelerationTop);
            Controls.Add(btnColorTurnRight);
            Controls.Add(btnColorTurnLeft);
            Controls.Add(btnColorDefault);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "SettingsForm";
            Text = "SettingsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnColorDefault;
        private Button btnColorTurnLeft;
        private Button btnColorTurnRight;
        private Button btnColorAccelerationTop;
        private Button btnCancel;
        private Button btnSave;
        private Label label5;
        private Button btnColorAccelerationLow;
    }
}