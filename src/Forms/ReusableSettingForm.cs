using AutoClicker.Data;
using System;
using System.Windows.Forms;

namespace AutoClicker.Forms
{
    public partial class ReusableSettingForm : FormBase
    {
        public Click ClickSettings { get; private set; }

        public ReusableSettingForm(Click click)
        {
            InitializeComponent();

            ClickSettings = click;

            var values = Enum.GetNames(typeof(MouseType));

            MouseTypeComboBox.Items.AddRange(values);

            MouseTypeComboBox.SelectedIndex = (int)click.MouseType;
            IntervalNumeric.Value = click.Interval;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            var type = (MouseType)MouseTypeComboBox.SelectedIndex;

            if (type != MouseType.None)
            {
                ClickSettings.MouseType = type;
                ClickSettings.Interval = (int)IntervalNumeric.Value;

                DialogResult = DialogResult.OK;
                Close();
            }
            else MessageBox.Show("Mouse type not was be none.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
