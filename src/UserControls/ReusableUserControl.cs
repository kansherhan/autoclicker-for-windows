using AutoClicker.Data;
using AutoClicker.Forms;
using AutoClicker.Utils;
using AutoClicker.Worker.Reusable;
using System;
using System.Windows.Forms;

namespace AutoClicker.UserControls
{
    public partial class ReusableUserControl : UserControl
    {
        private readonly Form currentForm;

        public ReusableUserControl(Form currentForm)
        {
            InitializeComponent();

            this.currentForm = currentForm;

            UpdateClickListViewItems();
        }

        private void UpdateClickListViewItems()
        {
            var files = IOFile.GetFiles(IOFile.ReusableSaveFolder, true);

            stringListBox1.Items = files;
        }

        private void CreateOrEditButton_Click(object sender, EventArgs e)
        {
            var filename = stringListBox1.SelectItem;
            ReusableClickForm clickForm;

            if (filename != null)
            {
                var clickList = ClickList.Open(IOFile.GetJsonFilePath(IOFile.ReusableSaveFolder, filename));

                clickForm = new ReusableClickForm(filename, clickList);
            }
            else
            {
                clickForm = new ReusableClickForm();
            }

            currentForm.WindowState = FormWindowState.Minimized;

            if (clickForm.ShowDialog() == DialogResult.OK)
            {
                UpdateClickListViewItems();
            }

            currentForm.WindowState = FormWindowState.Normal;
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            var filename = stringListBox1.SelectItem;

            if (filename != null)
            {
                var clickList = ClickList.Open(IOFile.GetJsonFilePath(IOFile.ReusableSaveFolder, filename));

                var worker = new ClickerReusableWorker(clickList, (int)IterationNumeric.Value, 100);
            }
        }
    }
}
