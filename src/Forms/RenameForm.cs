using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace AutoClicker.Forms
{
    public partial class RenameForm : FormBase
    {
        public string Filename => FilenameTextBox.Text;

        public RenameForm() => InitializeComponent();

        public RenameForm(string oldFilename) : this()
        {
            FilenameTextBox.Text = oldFilename;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (Filename.Length > 0)
            {
                if (Regex.IsMatch(Filename, "^[0-9-a-z-A-Z-_]{1,}$"))
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else MessageBox.Show("Only: number, buk, down beek space", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else MessageBox.Show("Filename is emtry.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void CloseButton_Click(object sender, EventArgs e) => Close();
    }
}
