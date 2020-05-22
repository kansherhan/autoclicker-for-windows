using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using Settings = AutoClicker.Properties.Settings;

namespace AutoCliker
{
    public partial class Main : Form
    {
        private const string nameFolder = "Save";

        private Random random = new Random();

        private Data data;

        private ProgramStage programStage;
        private ProgramStage ProgramStage
        {
            get => programStage;
            set
            {
                programStage = value;

                switch (value)
                {
                    case ProgramStage.Working:
                        this.Enabled = false;
                        break;

                    case ProgramStage.Recording:
                        foreach (var control in Controls)
                        {
                            (control as Control).Enabled = false;
                        }

                        RecordButton.Enabled = true;
                        break;

                    case ProgramStage.None:
                        this.Enabled = true;

                        foreach (var control in Controls)
                        {
                            (control as Control).Enabled = true;
                        }
                        break;
                }

                if (value != ProgramStage.None) MainTimer.Interval = (int)data.Interval;
                MainTimer.Enabled = (value != ProgramStage.None) ? true : false;

                UpdateListRecords();
            }
        }

        public Main()
        {
            InitializeComponent();
        }

        private void Loaded_Form(object sender, EventArgs e)
        {
            programStage = ProgramStage.None;

            this.Location = Settings.Default.LocationForm;
            this.Size = Settings.Default.SizeForm;
            this.MainTimer.Interval = Settings.Default.Interval;
            
            UpdateListRecords();
        }

        private void Closed_Form(object sender, FormClosedEventArgs e)
        {
            Settings.Default.LocationForm = this.Location;
            Settings.Default.SizeForm = this.Size;
            Settings.Default.Interval = this.MainTimer.Interval;

            Settings.Default.Save();
        }

        private void UpdateListRecords()
        {
            ListBoxRecord.Items.Clear();

            if (Directory.Exists(nameFolder))
            {
                string[] files = Directory.GetFiles(nameFolder);

                ListBoxRecord.Items.AddRange(files);
            }
            else Directory.CreateDirectory(nameFolder);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            int select = ListBoxRecord.SelectedIndex;
            if (select < 0) return;

            string path = ListBoxRecord.Items[select].ToString();

            if (File.Exists(path))
            {
                data = Data.Open(path);

                ProgramStage = ProgramStage.Working;
            }
        }

        private void RecordButton_Click(object sender, EventArgs e)
        {
            if (ProgramStage == ProgramStage.None)
            {
                RecordButton.Text = "Stop";

                data = new Data((int)IntervalNumeric.Value);

                ProgramStage = ProgramStage.Recording;
            }
            else
            {
                RecordButton.Text = "Record";
                ProgramStage = ProgramStage.None;

                if (data.ClickDatas.Count <= 0)
                {
                    MessageBox.Show("What save!");
                    return;
                }

                Data.Save(ref data);
                UpdateListRecords();
            }
        }

        private void DelateButton_Click(object sender, EventArgs e)
        {
            int select = ListBoxRecord.SelectedIndex;

            if (select >= 0)
            {
                File.Delete(ListBoxRecord.Items[select].ToString());
            }

            UpdateListRecords();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            switch (ProgramStage)
            {
                case ProgramStage.Working:
                    ProgramWorking();
                    break;

                case ProgramStage.Recording:
                    ProgramRecording();
                    break;

                default:
                    ProgramStage = ProgramStage.None;
                    break;
            }
        }

        private void ProgramRecording()
        {
            var mouse = Clicker.IsMouseDown();

            if (mouse != Mouse.None)
            {
                data.AddData(mouse, Cursor.Position);
            }

            data.Ticked();
        }

        private void ProgramWorking()
        {
            if (data.IntervalCount < data.IntervalIndex)
            {
                ProgramStage = ProgramStage.None;
                MessageBox.Show("Program finished you work");
                return;
            }

            foreach (var click in data.ClickDatas)
            {
                if (click.Tick == data.IntervalIndex)
                {
                    Cursor.Position = (Point)click.CursorPosition;
                    Clicker.MouseCliked(click.Mouse, click.CursorPosition);
                }
            }

            data.Ticked();
        }
    }
}