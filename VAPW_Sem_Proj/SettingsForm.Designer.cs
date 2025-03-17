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
            btnColorAcceleration = new Button();
            btnCancel = new Button();
            btnSave = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 9);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 0;
            label1.Text = "Default Colour";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 54);
            label2.Name = "label2";
            label2.Size = new Size(93, 15);
            label2.TabIndex = 1;
            label2.Text = "Left Turn Colour";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(49, 107);
            label3.Name = "label3";
            label3.Size = new Size(101, 15);
            label3.TabIndex = 2;
            label3.Text = "Right Turn Colour";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(49, 166);
            label4.Name = "label4";
            label4.Size = new Size(112, 15);
            label4.TabIndex = 3;
            label4.Text = "Acceleration Colour";
            // 
            // btnColorDefault
            // 
            btnColorDefault.Location = new Point(183, 5);
            btnColorDefault.Name = "btnColorDefault";
            btnColorDefault.Size = new Size(75, 23);
            btnColorDefault.TabIndex = 4;
            btnColorDefault.Text = "Change";
            btnColorDefault.UseVisualStyleBackColor = true;
            btnColorDefault.Click += buttonColorRoute_Click;
            // 
            // btnColorTurnLeft
            // 
            btnColorTurnLeft.Location = new Point(183, 50);
            btnColorTurnLeft.Name = "btnColorTurnLeft";
            btnColorTurnLeft.Size = new Size(75, 23);
            btnColorTurnLeft.TabIndex = 5;
            btnColorTurnLeft.Text = "Change";
            btnColorTurnLeft.UseVisualStyleBackColor = true;
            btnColorTurnLeft.Click += buttonColorLeftTurn_Click;
            // 
            // btnColorTurnRight
            // 
            btnColorTurnRight.Location = new Point(183, 103);
            btnColorTurnRight.Name = "btnColorTurnRight";
            btnColorTurnRight.Size = new Size(75, 23);
            btnColorTurnRight.TabIndex = 6;
            btnColorTurnRight.Text = "Change\r\n";
            btnColorTurnRight.UseVisualStyleBackColor = true;
            btnColorTurnRight.Click += buttonColorRightTurn_Click;
            // 
            // btnColorAcceleration
            // 
            btnColorAcceleration.Location = new Point(183, 162);
            btnColorAcceleration.Name = "btnColorAcceleration";
            btnColorAcceleration.Size = new Size(75, 23);
            btnColorAcceleration.TabIndex = 7;
            btnColorAcceleration.Text = "Change\r\n";
            btnColorAcceleration.UseVisualStyleBackColor = true;
            btnColorAcceleration.Click += buttonColorAcceleration_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(12, 415);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += buttonCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(685, 415);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(103, 23);
            btnSave.TabIndex = 9;
            btnSave.Text = "Save and Exit";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += buttonOK_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(btnColorAcceleration);
            Controls.Add(btnColorTurnRight);
            Controls.Add(btnColorTurnLeft);
            Controls.Add(btnColorDefault);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
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
        private Button btnColorAcceleration;
        private Button btnCancel;
        private Button btnSave;
    }
}