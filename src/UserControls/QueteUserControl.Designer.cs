using AutoClicker.Utils;

namespace AutoClicker.UserControls
{
    partial class QueteUserControl
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
            this.QueteTimer = new System.Windows.Forms.Timer(this.components);
            this.RecordListView = new System.Windows.Forms.ListView();
            this.RecordListViewContentMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RenameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DelateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RecordPanel = new System.Windows.Forms.Panel();
            this.RecordButton = new AutoClicker.Controls.DarkButton();
            this.StartButton = new AutoClicker.Controls.DarkButton();
            this.RecordListViewContentMenuStrip.SuspendLayout();
            this.RecordPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // QueteTimer
            // 
            this.QueteTimer.Tick += new System.EventHandler(this.QueteTimer_Tick);
            // 
            // RecordListView
            // 
            this.RecordListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RecordListView.BackColor = System.Drawing.Color.White;
            this.RecordListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RecordListView.ContextMenuStrip = this.RecordListViewContentMenuStrip;
            this.RecordListView.Location = new System.Drawing.Point(5, 5);
            this.RecordListView.MultiSelect = false;
            this.RecordListView.Name = "RecordListView";
            this.RecordListView.Size = new System.Drawing.Size(640, 351);
            this.RecordListView.TabIndex = 18;
            this.RecordListView.UseCompatibleStateImageBehavior = false;
            this.RecordListView.View = System.Windows.Forms.View.List;
            // 
            // RecordListViewContentMenuStrip
            // 
            this.RecordListViewContentMenuStrip.AutoSize = false;
            this.RecordListViewContentMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpdateToolStripMenuItem,
            this.RenameToolStripMenuItem,
            this.DelateToolStripMenuItem});
            this.RecordListViewContentMenuStrip.Name = "RecordListViewContentMenuStrip";
            this.RecordListViewContentMenuStrip.ShowImageMargin = false;
            this.RecordListViewContentMenuStrip.Size = new System.Drawing.Size(160, 92);
            // 
            // RenameToolStripMenuItem
            // 
            this.RenameToolStripMenuItem.Name = "RenameToolStripMenuItem";
            this.RenameToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.RenameToolStripMenuItem.Text = "Rename";
            this.RenameToolStripMenuItem.Click += new System.EventHandler(this.RenameButton_Click);
            // 
            // DelateToolStripMenuItem
            // 
            this.DelateToolStripMenuItem.Checked = true;
            this.DelateToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DelateToolStripMenuItem.Name = "DelateToolStripMenuItem";
            this.DelateToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.DelateToolStripMenuItem.Text = "Delate";
            this.DelateToolStripMenuItem.Click += new System.EventHandler(this.DeleteRecordButton_Click);
            // 
            // UpdateToolStripMenuItem
            // 
            this.UpdateToolStripMenuItem.AutoSize = false;
            this.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem";
            this.UpdateToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.UpdateToolStripMenuItem.Text = "Update";
            this.UpdateToolStripMenuItem.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // RecordPanel
            // 
            this.RecordPanel.BackColor = System.Drawing.Color.White;
            this.RecordPanel.Controls.Add(this.RecordListView);
            this.RecordPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.RecordPanel.Location = new System.Drawing.Point(0, 39);
            this.RecordPanel.Name = "RecordPanel";
            this.RecordPanel.Size = new System.Drawing.Size(650, 361);
            this.RecordPanel.TabIndex = 19;
            // 
            // RecordButton
            // 
            this.RecordButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(42)))), ((int)(((byte)(47)))));
            this.RecordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RecordButton.ForeColor = System.Drawing.Color.White;
            this.RecordButton.Location = new System.Drawing.Point(509, 3);
            this.RecordButton.Name = "RecordButton";
            this.RecordButton.Size = new System.Drawing.Size(136, 30);
            this.RecordButton.TabIndex = 21;
            this.RecordButton.Text = "Record";
            this.RecordButton.UseVisualStyleBackColor = false;
            this.RecordButton.Click += new System.EventHandler(this.RecordingButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(42)))), ((int)(((byte)(47)))));
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.ForeColor = System.Drawing.Color.White;
            this.StartButton.Location = new System.Drawing.Point(3, 3);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(136, 30);
            this.StartButton.TabIndex = 20;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // QueteUserControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(55)))), ((int)(((byte)(63)))));
            this.Controls.Add(this.RecordButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.RecordPanel);
            this.Name = "QueteUserControl";
            this.Size = new System.Drawing.Size(650, 400);
            this.RecordListViewContentMenuStrip.ResumeLayout(false);
            this.RecordPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer QueteTimer;
        private System.Windows.Forms.ListView RecordListView;
        private System.Windows.Forms.ContextMenuStrip RecordListViewContentMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem RenameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DelateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpdateToolStripMenuItem;
        private System.Windows.Forms.Panel RecordPanel;
        private Controls.DarkButton StartButton;
        private Controls.DarkButton RecordButton;
    }
}
