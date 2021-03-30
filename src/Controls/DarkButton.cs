using AutoClicker.Utils;
using System.Drawing;
using System.Windows.Forms;

namespace AutoClicker.Controls
{
    public class DarkButton : Button
    {
        public DarkButton()
        {
            BackColor = Colors.DarkGray;
            ForeColor = Color.White;

            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
        }
    }
}
