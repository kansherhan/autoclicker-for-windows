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
            this.RecordButton = new System.Windows.Forms.Button();
            this.StartScenerClicker = new System.Windows.Forms.Button();
            this.DelateButton = new System.Windows.Forms.Button();
            this.ListBoxRecord = new System.Windows.Forms.ListBox();
            this.StartSingleClicker = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTimer
            // 
            this.MainTimer.Interval = 1;
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // RecordButton
            // 
            this.RecordButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.RecordButton.Location = new System.Drawing.Point(6, 55);
            this.RecordButton.Name = "RecordButton";
            this.RecordButton.Size = new System.Drawing.Size(92, 30);
            this.RecordButton.TabIndex = 2;
            this.RecordButton.Text = "Запись";
            this.RecordButton.UseVisualStyleBackColor = true;
            this.RecordButton.Click += new System.EventHandler(this.RecordSceneButton_Click);
            // 
            // StartScenerClicker
            // 
            this.StartScenerClicker.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.StartScenerClicker.Location = new System.Drawing.Point(6, 19);
            this.StartScenerClicker.Name = "StartScenerClicker";
            this.StartScenerClicker.Size = new System.Drawing.Size(92, 30);
            this.StartScenerClicker.TabIndex = 1;
            this.StartScenerClicker.Tag = "1";
            this.StartScenerClicker.Text = "Начать";
            this.StartScenerClicker.UseVisualStyleBackColor = true;
            this.StartScenerClicker.Click += new System.EventHandler(this.StartClicker_Click);
            // 
            // DelateButton
            // 
            this.DelateButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DelateButton.Location = new System.Drawing.Point(6, 91);
            this.DelateButton.Name = "DelateButton";
            this.DelateButton.Size = new System.Drawing.Size(92, 30);
            this.DelateButton.TabIndex = 4;
            this.DelateButton.Text = "Удалить";
            this.DelateButton.UseVisualStyleBackColor = true;
            this.DelateButton.Click += new System.EventHandler(this.DeleteSceneButton_Click);
            // 
            // ListBoxRecord
            // 
            this.ListBoxRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBoxRecord.FormattingEnabled = true;
            this.ListBoxRecord.Location = new System.Drawing.Point(104, 19);
            this.ListBoxRecord.Name = "ListBoxRecord";
            this.ListBoxRecord.Size = new System.Drawing.Size(136, 147);
            this.ListBoxRecord.TabIndex = 7;
            // 
            // StartSingleClicker
            // 
            this.StartSingleClicker.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.StartSingleClicker.Location = new System.Drawing.Point(6, 19);
            this.StartSingleClicker.Name = "StartSingleClicker";
            this.StartSingleClicker.Size = new System.Drawing.Size(103, 30);
            this.StartSingleClicker.TabIndex = 1;
            this.StartSingleClicker.Tag = "0";
            this.StartSingleClicker.Text = "Начать";
            this.StartSingleClicker.UseVisualStyleBackColor = true;
            this.StartSingleClicker.Click += new System.EventHandler(this.StartClicker_Click);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button3.Location = new System.Drawing.Point(6, 55);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(103, 30);
            this.button3.TabIndex = 4;
            this.button3.Text = "Настройд";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.SettingSingleClicker_Button);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.StartSingleClicker);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Location = new System.Drawing.Point(12, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(115, 188);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Одиночный клик";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ListBoxRecord);
            this.groupBox2.Controls.Add(this.StartScenerClicker);
            this.groupBox2.Controls.Add(this.DelateButton);
            this.groupBox2.Controls.Add(this.RecordButton);
            this.groupBox2.Location = new System.Drawing.Point(133, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(246, 188);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Сценарный кликкер";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(390, 215);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto Clicker";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Closed_Form);
            this.Load += new System.EventHandler(this.Loaded_Form);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.Button RecordButton;
        private System.Windows.Forms.Button StartScenerClicker;
        private System.Windows.Forms.Button DelateButton;
        private System.Windows.Forms.ListBox ListBoxRecord;
        private System.Windows.Forms.Button StartSingleClicker;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

