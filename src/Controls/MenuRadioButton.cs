using AutoClicker.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AutoClicker.Controls
{
    internal class MenuRadioButton : RadioButton
    {
        public static readonly Size DefaultButtonSize = new Size(60, 60);

        public Image BackImage { get; set; }

        public event Action<int> Actived;

        private readonly int index;

        public MenuRadioButton()
        {
            index = 0;

            Size = DefaultButtonSize;

            Appearance = Appearance.Button;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
        }

        public MenuRadioButton(int index) : this() => this.index = index;

        protected override void OnCheckedChanged(EventArgs e)
        {
            base.OnCheckedChanged(e);

            if (Checked) Actived?.Invoke(index);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            Size = DefaultButtonSize;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var graphics = e.Graphics;

            if (Checked)
            {
                graphics.Clear(Colors.Gray);

                graphics.FillRectangle(new SolidBrush(Colors.BlueLight), new Rectangle(0, 0, 5, Height));
            }
            else graphics.Clear(Colors.DarkGray);

            if (BackImage != null)
            {
                graphics.DrawImage(BackImage, new Rectangle(new Point(15, 15), new Size(35, 35)));
            }
            else graphics.DrawString("No image", Font, Brushes.Red, 5, 25);
        }
    }
}
