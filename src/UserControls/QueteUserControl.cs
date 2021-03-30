using AutoClicker.Data;
using AutoClicker.Utils;
using AutoClicker.Worker;
using System;
using System.IO;
using System.Windows.Forms;
using AutoClicker.Forms;
using System.Diagnostics;
using AutoClicker.Worker.Quete;

namespace AutoClicker.UserControls
{
    public partial class QueteUserControl : UserControl
    {
        private bool isRecording;

        private readonly Form currentForm;

        private WorkerBase worker;
        private WorkerBase Worker
        {
            get => worker;
            set
            {
                value.Finished += Worker_Finished;
                worker = value;
            }
        }

        private bool IsRecordSelect => RecordListView.SelectedItems.Count > 0;

        public QueteUserControl(Form current)
        {
            if (current != null)
            {
                InitializeComponent();

                isRecording = false;

                this.currentForm = current;
                this.currentForm.Activated += Current_Activated;

                UpdateRecordListViewItems();
            }
            else
            {
                throw new Exception("Form is not exists.");
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (IsRecordSelect)
            {
                var filename = RecordListView.SelectedItems[0].Text;
                var path = GetFilePath(filename);

                if (File.Exists(path))
                {
                    var data = ClickList.Open(path);

                    Worker = new ClickerQueteWorker(data, QueteTimer.Interval);

                    QueteTimer.Start();

                    StartButton.Enabled = false;
                    RecordButton.Enabled = false;

                    currentForm.WindowState = FormWindowState.Minimized;
                }
                else
                {
                    MessageBox.Show("File not found.");
                    UpdateRecordListViewItems();
                }
            }
            else
            {
                MessageBox.Show("Select item.");
            }
        }

        private void RecordingButton_Click(object sender, EventArgs e)
        {
            if (Worker == null || Worker.WorkerType != WorkerType.Recorder || Worker.IsFinish == true)
            {
                RecordButton.Text = "Stop";

                Worker = new RecorderQueteWorker(QueteTimer.Interval);

                QueteTimer.Start();

                isRecording = true;

                ButtonVisibleChange(false);

                RecordButton.Enabled = true;

                currentForm.WindowState = FormWindowState.Minimized;
            }
            else
            {
                RecordButton.Text = "Record";

                Worker.Stop();

                ButtonVisibleChange(true);

                isRecording = false;

                currentForm.WindowState = FormWindowState.Normal;

                UpdateRecordListViewItems();
            }
        }

        private void RenameButton_Click(object sender, EventArgs e)
        {
            if (IsRecordSelect)
            {
                var oldFilename = RecordListView.SelectedItems[0].Text;
                var renameForm = new RenameForm(oldFilename);

                if (renameForm.ShowDialog() == DialogResult.OK)
                {
                    var path = GetFilePath(oldFilename);

                    var processInfo = new ProcessStartInfo("cmd", $"/c rename \"{path}\" \"{renameForm.Filename}.json\"")
                    {
                        CreateNoWindow = false,
                        WindowStyle = ProcessWindowStyle.Hidden
                    };

                    Process.Start(processInfo);

                    RecordListView.Items[RecordListView.SelectedIndices[0]].Text = renameForm.Filename;
                }
            }
        }

        private void DeleteRecordButton_Click(object sender, EventArgs e)
        {
            if (IsRecordSelect)
            {
                var filename = RecordListView.SelectedItems[0].Text;
                var path = GetFilePath(filename);

                File.Delete(path);

                UpdateRecordListViewItems();
            }
        }

        private void QueteTimer_Tick(object sender, EventArgs e)
        {
            if (Worker != null && !Worker.IsFinish)
            {
                Worker.Work();
            }
            else
            {
                QueteTimer.Stop();
            }
        }

        private void Worker_Finished(object sender, EventArgs e)
        {
            QueteTimer.Stop();

            ButtonVisibleChange(true);

            currentForm.WindowState = FormWindowState.Normal;

            if (currentForm.CanFocus)
            {
                currentForm.TopMost = true;

                currentForm.Focus();

                currentForm.TopMost = false;
            }
        }

        private void Current_Activated(object sender, EventArgs e)
        {
            if (isRecording && Worker.WorkerType == WorkerType.Recorder)
            {
                RecordingButton_Click(RecordButton, new EventArgs());
            }
        }

        private string GetFilePath(string filename) => Path.Combine(IOFile.QueueSaveFolder, filename + ".json");

        private void ButtonVisibleChange(bool enable)
        {
            StartButton.Enabled = enable;
            RecordButton.Enabled = enable;
        }

        private void UpdateRecordListViewItems()
        {
            RecordListView.Items.Clear();

            var files = IOFile.GetFiles(IOFile.QueueSaveFolder, true);

            foreach (var file in files)
            {
                RecordListView.Items.Add(file);
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e) => UpdateRecordListViewItems();
    }
}
