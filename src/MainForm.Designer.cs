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
            this.StartButton = new System.Windows.Forms.Button();
            this.DeleteRecordButton = new System.Windows.Forms.Button();
            this.RecordingButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MainTimer
            // 
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // RecordListBox
            // 
            this.RecordListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RecordListBox.FormattingEnabled = true;
            this.RecordListBox.Location = new System.Drawing.Point(146, 10);
            this.RecordListBox.Name = "RecordListBox";
            this.RecordListBox.Size = new System.Drawing.Size(453, 264);
            this.RecordListBox.TabIndex = 11;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(10, 10);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(130, 30);
            this.StartButton.TabIndex = 8;
            this.StartButton.Tag = "1";
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartClickerButton_Click);
            // 
            // DeleteRecordButton
            // 
            this.DeleteRecordButton.Location = new System.Drawing.Point(10, 82);
            this.DeleteRecordButton.Name = "DeleteRecordButton";
            this.DeleteRecordButton.Size = new System.Drawing.Size(130, 30);
            this.DeleteRecordButton.TabIndex = 10;
            this.DeleteRecordButton.Text = "Delete record";
            this.DeleteRecordButton.UseVisualStyleBackColor = true;
            this.DeleteRecordButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // RecordingButton
            // 
            this.RecordingButton.Location = new System.Drawing.Point(10, 46);
            this.RecordingButton.Name = "RecordingButton";
            this.RecordingButton.Size = new System.Drawing.Size(130, 30);
            this.RecordingButton.TabIndex = 9;
            this.RecordingButton.Text = "Recording";
            this.RecordingButton.UseVisualStyleBackColor = true;
            this.RecordingButton.Click += new System.EventHandler(this.RecordingButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(613, 302);
            this.Controls.Add(this.RecordListBox);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.DeleteRecordButton);
            this.Controls.Add(this.RecordingButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoClicker";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.ListBox RecordListBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button DeleteRecordButton;
        private System.Windows.Forms.Button RecordingButton;
    }
}

