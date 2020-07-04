using AutoClicker.Data.Click;
using AutoClicker.States;
using System;
using System.IO;
using System.Windows.Forms;

namespace AutoClicker
{
    public partial class MainForm : Form
    {
        public static Random Random = new Random();

        private AState state;

        public MainForm()
        {
            InitializeComponent();

            UpdateListRecords();
        }

        private void StartClickerButton_Click(object sender, EventArgs e)
        {
            int select = RecordListBox.SelectedIndex;

            if (select < 0) return;

            string path = RecordListBox.Items[select].ToString();

            if (File.Exists(path))
            {
                state = new WorkingState(Datas.Open(path));

                MainTimer.Start();
            }
        }

        private void RecordingButton_Click(object sender, EventArgs e)
        {
            if (state?.IsFinish != true || state.EState != EState.Recording)
            {
                RecordingButton.Text = "Stop";

                state = new RecordingState();

                MainTimer.Start();
            }
            else
            {
                RecordingButton.Text = "Record";

                state.OnFinish();
            }

            UpdateListRecords();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int select = RecordListBox.SelectedIndex;

            if (select >= 0)
            {
                File.Delete(RecordListBox.Items[select].ToString());
            }

            UpdateListRecords();
        }

        private void UpdateListRecords()
        {
            RecordListBox.Items.Clear();

            if (Directory.Exists("Save"))
            {
                string[] files = Directory.GetFiles("Save");

                RecordListBox.Items.AddRange(files);
            }
            else Directory.CreateDirectory("Save");
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            state.Work();

            if (state.IsFinish)
            {
                MainTimer.Stop();
            }
        }
    }
}