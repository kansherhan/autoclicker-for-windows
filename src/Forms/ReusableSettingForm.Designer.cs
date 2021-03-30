namespace AutoClicker.Forms
{
    partial class ReusableSettingForm
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
            this.ClickSettingHeader = new AutoClicker.Controls.HeaderPanel();
            this.OkButton = new AutoClicker.Controls.DarkButton();
            this.MouseTypeComboBox = new System.Windows.Forms.ComboBox();
            this.IntervalNumeric = new System.Windows.Forms.NumericUpDown();
            this.IntervalLabel = new System.Windows.Forms.Label();
            this.MouseTypeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.IntervalNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // ClickSettingHeader
            // 
            this.ClickSettingHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(22)))), ((int)(((byte)(27)))));
            this.ClickSettingHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.ClickSettingHeader.DrawIcon = false;
            this.ClickSettingHeader.Location = new System.Drawing.Point(0, 0);
            this.ClickSettingHeader.Name = "ClickSettingHeader";
            this.ClickSettingHeader.Size = new System.Drawing.Size(330, 30);
            this.ClickSettingHeader.TabIndex = 0;
            this.ClickSettingHeader.Text = "Click Setting";
            // 
            // OkButton
            // 
            this.OkButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(42)))), ((int)(((byte)(47)))));
            this.OkButton.FlatAppearance.BorderSize = 0;
            this.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkButton.ForeColor = System.Drawing.Color.White;
            this.OkButton.Location = new System.Drawing.Point(246, 137);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(72, 23);
            this.OkButton.TabIndex = 1;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = false;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // MouseTypeComboBox
            // 
            this.MouseTypeComboBox.FormattingEnabled = true;
            this.MouseTypeComboBox.Location = new System.Drawing.Point(12, 99);
            this.MouseTypeComboBox.Name = "MouseTypeComboBox";
            this.MouseTypeComboBox.Size = new System.Drawing.Size(306, 21);
            this.MouseTypeComboBox.TabIndex = 2;
            this.MouseTypeComboBox.Text = "Mouse type";
            // 
            // IntervalNumeric
            // 
            this.IntervalNumeric.Location = new System.Drawing.Point(12, 54);
            this.IntervalNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.IntervalNumeric.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.IntervalNumeric.Name = "IntervalNumeric";
            this.IntervalNumeric.Size = new System.Drawing.Size(306, 20);
            this.IntervalNumeric.TabIndex = 3;
            this.IntervalNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // IntervalLabel
            // 
            this.IntervalLabel.AutoSize = true;
            this.IntervalLabel.Location = new System.Drawing.Point(8, 38);
            this.IntervalLabel.Name = "IntervalLabel";
            this.IntervalLabel.Size = new System.Drawing.Size(45, 13);
            this.IntervalLabel.TabIndex = 4;
            this.IntervalLabel.Text = "Interval:";
            // 
            // MouseTypeLabel
            // 
            this.MouseTypeLabel.AutoSize = true;
            this.MouseTypeLabel.Location = new System.Drawing.Point(8, 83);
            this.MouseTypeLabel.Name = "MouseTypeLabel";
            this.MouseTypeLabel.Size = new System.Drawing.Size(65, 13);
            this.MouseTypeLabel.TabIndex = 5;
            this.MouseTypeLabel.Text = "Mouse type:";
            // 
            // ReusableSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(330, 172);
            this.Controls.Add(this.MouseTypeLabel);
            this.Controls.Add(this.IntervalLabel);
            this.Controls.Add(this.IntervalNumeric);
            this.Controls.Add(this.MouseTypeComboBox);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.ClickSettingHeader);
            this.Name = "ReusableSettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReusableSettingForm";
            ((System.ComponentModel.ISupportInitialize)(this.IntervalNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.HeaderPanel ClickSettingHeader;
        private Controls.DarkButton OkButton;
        private System.Windows.Forms.ComboBox MouseTypeComboBox;
        private System.Windows.Forms.NumericUpDown IntervalNumeric;
        private System.Windows.Forms.Label IntervalLabel;
        private System.Windows.Forms.Label MouseTypeLabel;
    }
}