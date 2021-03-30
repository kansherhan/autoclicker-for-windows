namespace AutoClicker.UserControls
{
    partial class ReusableUserControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ClickListViewContentMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RenameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DelateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IterationNumeric = new System.Windows.Forms.NumericUpDown();
            this.IterationLabel = new System.Windows.Forms.Label();
            this.stringListBox1 = new AutoClicker.Controls.StringListBox();
            this.StartButton = new AutoClicker.Controls.DarkButton();
            this.CreateOrEditButton = new AutoClicker.Controls.DarkButton();
            this.ClickListViewContentMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IterationNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // ClickListViewContentMenuStrip
            // 
            this.ClickListViewContentMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RenameToolStripMenuItem,
            this.DelateToolStripMenuItem,
            this.UpdateToolStripMenuItem});
            this.ClickListViewContentMenuStrip.Name = "RecordListViewContentMenuStrip";
            this.ClickListViewContentMenuStrip.Size = new System.Drawing.Size(118, 70);
            // 
            // RenameToolStripMenuItem
            // 
            this.RenameToolStripMenuItem.Name = "RenameToolStripMenuItem";
            this.RenameToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.RenameToolStripMenuItem.Text = "Rename";
            // 
            // DelateToolStripMenuItem
            // 
            this.DelateToolStripMenuItem.Name = "DelateToolStripMenuItem";
            this.DelateToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.DelateToolStripMenuItem.Text = "Delate";
            // 
            // UpdateToolStripMenuItem
            // 
            this.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem";
            this.UpdateToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.UpdateToolStripMenuItem.Text = "Update";
            // 
            // IterationNumeric
            // 
            this.IterationNumeric.Location = new System.Drawing.Point(6, 25);
            this.IterationNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.IterationNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.IterationNumeric.Name = "IterationNumeric";
            this.IterationNumeric.Size = new System.Drawing.Size(127, 20);
            this.IterationNumeric.TabIndex = 2;
            this.IterationNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // IterationLabel
            // 
            this.IterationLabel.AutoSize = true;
            this.IterationLabel.ForeColor = System.Drawing.Color.White;
            this.IterationLabel.Location = new System.Drawing.Point(3, 9);
            this.IterationLabel.Name = "IterationLabel";
            this.IterationLabel.Size = new System.Drawing.Size(48, 13);
            this.IterationLabel.TabIndex = 3;
            this.IterationLabel.Text = "Iteration:";
            // 
            // stringListBox1
            // 
            this.stringListBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(55)))), ((int)(((byte)(63)))));
            this.stringListBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.stringListBox1.ForeColor = System.Drawing.Color.White;
            this.stringListBox1.Items = null;
            this.stringListBox1.Location = new System.Drawing.Point(156, 0);
            this.stringListBox1.Name = "stringListBox1";
            this.stringListBox1.Size = new System.Drawing.Size(494, 400);
            this.stringListBox1.TabIndex = 5;
            this.stringListBox1.Text = "stringListBox1";
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(42)))), ((int)(((byte)(47)))));
            this.StartButton.FlatAppearance.BorderSize = 0;
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.ForeColor = System.Drawing.Color.White;
            this.StartButton.Location = new System.Drawing.Point(6, 51);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(97, 23);
            this.StartButton.TabIndex = 4;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // CreateOrEditButton
            // 
            this.CreateOrEditButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(42)))), ((int)(((byte)(47)))));
            this.CreateOrEditButton.FlatAppearance.BorderSize = 0;
            this.CreateOrEditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateOrEditButton.ForeColor = System.Drawing.Color.White;
            this.CreateOrEditButton.Location = new System.Drawing.Point(6, 80);
            this.CreateOrEditButton.Name = "CreateOrEditButton";
            this.CreateOrEditButton.Size = new System.Drawing.Size(97, 23);
            this.CreateOrEditButton.TabIndex = 1;
            this.CreateOrEditButton.Text = "Create or edit";
            this.CreateOrEditButton.UseVisualStyleBackColor = false;
            this.CreateOrEditButton.Click += new System.EventHandler(this.CreateOrEditButton_Click);
            // 
            // ReusableUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(55)))), ((int)(((byte)(63)))));
            this.Controls.Add(this.stringListBox1);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.IterationLabel);
            this.Controls.Add(this.IterationNumeric);
            this.Controls.Add(this.CreateOrEditButton);
            this.Name = "ReusableUserControl";
            this.Size = new System.Drawing.Size(650, 400);
            this.ClickListViewContentMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IterationNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controls.DarkButton CreateOrEditButton;
        private System.Windows.Forms.NumericUpDown IterationNumeric;
        private System.Windows.Forms.Label IterationLabel;
        private Controls.DarkButton StartButton;
        private System.Windows.Forms.ContextMenuStrip ClickListViewContentMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem RenameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DelateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpdateToolStripMenuItem;
        private Controls.StringListBox stringListBox1;
    }
}
