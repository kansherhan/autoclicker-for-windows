namespace AutoCliker
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.RecordButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.DelateButton = new System.Windows.Forms.Button();
            this.ListBoxRecord = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.IntervalNumeric = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.IntervalNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTimer
            // 
            this.MainTimer.Interval = 1000;
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // RecordButton
            // 
            this.RecordButton.Location = new System.Drawing.Point(9, 48);
            this.RecordButton.Name = "RecordButton";
            this.RecordButton.Size = new System.Drawing.Size(75, 30);
            this.RecordButton.TabIndex = 2;
            this.RecordButton.Text = "Record";
            this.RecordButton.UseVisualStyleBackColor = true;
            this.RecordButton.Click += new System.EventHandler(this.RecordButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(9, 12);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 30);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // DelateButton
            // 
            this.DelateButton.Location = new System.Drawing.Point(9, 84);
            this.DelateButton.Name = "DelateButton";
            this.DelateButton.Size = new System.Drawing.Size(75, 30);
            this.DelateButton.TabIndex = 4;
            this.DelateButton.Text = "Delete";
            this.DelateButton.UseVisualStyleBackColor = true;
            this.DelateButton.Click += new System.EventHandler(this.DelateButton_Click);
            // 
            // ListBoxRecord
            // 
            this.ListBoxRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBoxRecord.FormattingEnabled = true;
            this.ListBoxRecord.Location = new System.Drawing.Point(90, 12);
            this.ListBoxRecord.Name = "ListBoxRecord";
            this.ListBoxRecord.Size = new System.Drawing.Size(431, 303);
            this.ListBoxRecord.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(6, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Interval";
            // 
            // IntervalNumeric
            // 
            this.IntervalNumeric.Location = new System.Drawing.Point(9, 142);
            this.IntervalNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.IntervalNumeric.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.IntervalNumeric.Name = "IntervalNumeric";
            this.IntervalNumeric.Size = new System.Drawing.Size(75, 20);
            this.IntervalNumeric.TabIndex = 9;
            this.IntervalNumeric.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(533, 330);
            this.Controls.Add(this.IntervalNumeric);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ListBoxRecord);
            this.Controls.Add(this.DelateButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.RecordButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(381, 270);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto Clicker";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Closed_Form);
            this.Load += new System.EventHandler(this.Loaded_Form);
            ((System.ComponentModel.ISupportInitialize)(this.IntervalNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.Button RecordButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button DelateButton;
        private System.Windows.Forms.ListBox ListBoxRecord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown IntervalNumeric;
    }
}

