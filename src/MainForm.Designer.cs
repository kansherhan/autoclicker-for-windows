namespace AutoClicker
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.RecordListBox = new System.Windows.Forms.ListBox();
            this.StartClickerButton = new System.Windows.Forms.Button();
            this.DelateButton = new System.Windows.Forms.Button();
            this.RecordingButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MainTimer
            // 
            this.MainTimer.Interval = 1;
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // RecordListBox
            // 
            this.RecordListBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RecordListBox.FormattingEnabled = true;
            this.RecordListBox.Location = new System.Drawing.Point(128, 12);
            this.RecordListBox.Name = "RecordListBox";
            this.RecordListBox.Size = new System.Drawing.Size(244, 238);
            this.RecordListBox.TabIndex = 11;
            // 
            // StartClickerButton
            // 
            this.StartClickerButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StartClickerButton.Location = new System.Drawing.Point(12, 12);
            this.StartClickerButton.Name = "StartClickerButton";
            this.StartClickerButton.Size = new System.Drawing.Size(110, 30);
            this.StartClickerButton.TabIndex = 8;
            this.StartClickerButton.Tag = "1";
            this.StartClickerButton.Text = "Start";
            this.StartClickerButton.UseVisualStyleBackColor = true;
            this.StartClickerButton.Click += new System.EventHandler(this.StartClickerButton_Click);
            // 
            // DelateButton
            // 
            this.DelateButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DelateButton.Location = new System.Drawing.Point(12, 84);
            this.DelateButton.Name = "DelateButton";
            this.DelateButton.Size = new System.Drawing.Size(110, 30);
            this.DelateButton.TabIndex = 10;
            this.DelateButton.Text = "Delete record";
            this.DelateButton.UseVisualStyleBackColor = true;
            this.DelateButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // RecordingButton
            // 
            this.RecordingButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RecordingButton.Location = new System.Drawing.Point(12, 48);
            this.RecordingButton.Name = "RecordingButton";
            this.RecordingButton.Size = new System.Drawing.Size(110, 30);
            this.RecordingButton.TabIndex = 9;
            this.RecordingButton.Text = "Recording";
            this.RecordingButton.UseVisualStyleBackColor = true;
            this.RecordingButton.Click += new System.EventHandler(this.RecordingButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(384, 262);
            this.Controls.Add(this.RecordListBox);
            this.Controls.Add(this.StartClickerButton);
            this.Controls.Add(this.DelateButton);
            this.Controls.Add(this.RecordingButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 300);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto Clicker";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.ListBox RecordListBox;
        private System.Windows.Forms.Button StartClickerButton;
        private System.Windows.Forms.Button DelateButton;
        private System.Windows.Forms.Button RecordingButton;
    }
}

