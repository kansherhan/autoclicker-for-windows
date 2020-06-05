using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using Settings = AutoClicker.Properties.Settings;

namespace AutoClicker
{
    public partial class MainForm : Form
    {
        public static string SaveFolder => "Save";

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
                
                MainTimer.Enabled = (value != ProgramStage.None) ? true : false;

                UpdateListRecords();
            }
        }

        private TypeWorkingClicker TypeWorkingClicker;

        private ClickForm clickForm;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Loaded_Form(object sender, EventArgs e)
        {
            programStage = ProgramStage.None;

            InstallSettings();

            clickForm = new ClickForm();
            clickForm.GetDataClickes += GetDataClickes;

            UpdateListRecords();
        }

        private void Closed_Form(object sender, FormClosedEventArgs e)
        {
            SavingSettings();
        }

        private void InstallSettings()
        {
            this.Location = Settings.Default.LocationForm;
        }

        private void SavingSettings()
        {
            Settings.Default.LocationForm = this.Location;
            Settings.Default.Save();
        }

        private void GetDataClickes(ClickData[] obj)
        {
            data = new Data(obj);
        }

        private void UpdateListRecords()
        {
            ListBoxRecord.Items.Clear();

            if (Directory.Exists(SaveFolder))
            {
                string[] files = Directory.GetFiles(SaveFolder);

                ListBoxRecord.Items.AddRange(files);
            }
            else Directory.CreateDirectory(SaveFolder);
        }

        private void StartClicker_Click(object sender, EventArgs e)
        {
            var typeWork = (TypeWorkingClicker)Convert.ToInt32((sender as Button).Tag);

            switch (typeWork)
            {
                case TypeWorkingClicker.Single:
                    SingleWorkingClicker();
                    break;

                case TypeWorkingClicker.Scene:
                    SceneWorkingClicker();
                    break;
            }
        }

        private void SceneWorkingClicker()
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

        private void SingleWorkingClicker()
        {
            if (data?.ClickDatas.Count > 0)
            {
                ProgramStage = ProgramStage.Working;
            }
        }

        private void RecordSceneButton_Click(object sender, EventArgs e)
        {
            if (ProgramStage == ProgramStage.None)
            {
                RecordButton.Text = "Stop";

                data = new Data();

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

        private void DeleteSceneButton_Click(object sender, EventArgs e)
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
            switch (typeWork)
            {
                case TypeWorkingClicker.Single:
                    break;
                case TypeWorkingClicker.Scene:
                    break;
            }

            if (data.LastInterval != null)
            {
                if (data.LastInterval < data.IntervalIndex)
                {
                    ProgramStage = ProgramStage.None;
                    MessageBox.Show("Program finished you work");
                    return;
                }
            }

            foreach (var click in data.ClickDatas)
            {
                if (click.Milisecond == data.IntervalIndex)
                {
                    Cursor.Position = (Point)click.CursorPosition;
                    Clicker.MouseCliked(click.Mouse, click.CursorPosition);
                }
            }

            data.Ticked();
        }

        private void SettingSingleClicker_Button(object sender, EventArgs e) => clickForm.Show();
    }
}