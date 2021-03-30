using AutoClicker.Utils;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AutoClicker.Forms
{
    public partial class FormBase : Form
    {
        private const int CS_DROPSHADOW = 0x00020000;

        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        public FormBase()
        {
            InitializeComponent();

            BackColor = Colors.Gray;
        }

        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;

                DwmIsCompositionEnabled(ref enabled);

                return enabled == 1;
            }
            else return false;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;

                if (CheckAeroEnabled())
                {
                    cp.ClassStyle |= CS_DROPSHADOW;
                }

                return cp;
            }
        }
    }
}
