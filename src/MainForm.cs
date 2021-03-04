using AutoClicker.Data;
using AutoClicker.Worker;
using System;
using System.IO;
using System.Windows.Forms;

namespace AutoClicker
{
    public partial class MainForm : Form
    {
        private bool isRecording;

        private AbstractWorker worker;
        private AbstractWorker Worker
        {
            get => worker;
            set
            {
                value.Finished += Worker_Finished;
                worker = value;
            }
        }

        private int RecordListSelectItemIndex => RecordListBox.SelectedIndex;

        public MainForm()
        {
            InitializeComponent();

            isRecording = false;

            UpdateRecordList();
        }

        private void StartClickerButton_Click(object sender, EventArgs e)
        {
            if (RecordListSelectItemIndex >= 0)
            {
                var path = RecordListBox.Items[RecordListSelectItemIndex].ToString();

                if (File.Exists(path))
                {
                    var data = ClickData.Open(path);

                    Worker = new ClickerWorker(data, MainTimer.Interval);

                    MainTimer.Start();

                    StartButton.Enabled = false;
                    RecordingButton.Enabled = false;
                    DeleteRecordButton.Enabled = false;

                    WindowState = FormWindowState.Minimized;
                }
            }
        }

        private void RecordingButton_Click(object sender, EventArgs e)
        {
            if (Worker == null || Worker.WorkerType != WorkerType.Recorder || Worker.IsFinish == true)
            {
                RecordingButton.Text = "Stop";

                Worker = new RecorderWorker(MainTimer.Interval);

                MainTimer.Start();

                isRecording = true;

                StartButton.Enabled = false;
                DeleteRecordButton.Enabled = false;

                WindowState = FormWindowState.Minimized;
            }
            else
            {
                RecordingButton.Text = "Record";

                Worker.Finish();

                isRecording = false;

                StartButton.Enabled = true;
                DeleteRecordButton.Enabled = true;
            }

            UpdateRecordList();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (RecordListSelectItemIndex >= 0)
            {
                File.Delete(RecordListBox.Items[RecordListSelectItemIndex].ToString());

                UpdateRecordList();
            }
        }

        private void UpdateRecordList()
        {
            RecordListBox.Items.Clear();

            if (Directory.Exists(ClickData.SaveFolderPath))
            {
                string[] files = Directory.GetFiles(ClickData.SaveFolderPath);

                RecordListBox.Items.AddRange(files);
            }
            else Directory.CreateDirectory(ClickData.SaveFolderPath);
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            if (!Worker.IsFinish)
            {
                Worker.Work();
            }
            else
            {
                MainTimer.Stop();
            }
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (isRecording && Worker.WorkerType == WorkerType.Recorder)
            {
                RecordingButton_Click(RecordingButton, new EventArgs());
            }
        }

        private void Worker_Finished(object sender, EventArgs e)
        {
            MainTimer.Stop();

            StartButton.Enabled = true;
            RecordingButton.Enabled = true;
            DeleteRecordButton.Enabled = true;

            WindowState = FormWindowState.Normal;
        }
    }
}