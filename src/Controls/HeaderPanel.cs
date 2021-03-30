using AutoClicker.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AutoClicker.Controls
{
    public class HeaderPanel : Control
    {
        public bool DrawIcon
        {
            get => drawIcon;
            set
            {
                drawIcon = value;

                Refresh();
            }
        }

        private bool drawIcon;
        private bool windowDrag;

        private Form form;

        private readonly Image icon;

        private DarkButton ExitButton;

        private Point LastMousePosition;

        public HeaderPanel()
        {
            DrawIcon = true;

            icon = Properties.Resources.ClickImage;

            ExitButton = new DarkButton()
            {
                Size = new Size(20, 20),
                BackgroundImage = Properties.Resources.HeaderCloseButtonImage,
                BackgroundImageLayout = ImageLayout.Zoom,
                BackColor = Colors.Dark
            };

            ExitButton.Click += ExitButton_Click;

            Controls.Add(ExitButton);

            Dock = DockStyle.Top;
            BackColor = Colors.Dark;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (form != null) form.Close();
            else FindForm().Close();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (form == null)
            {
                form = FindForm();

                if (form == null)
                {
                    throw new Exception("Form is not exists.");
                }
            }

            windowDrag = true;

            LastMousePosition = Cursor.Position - (Size)form.Location;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (windowDrag)
            {
                form.Location = Cursor.Position - (Size)LastMousePosition;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            windowDrag = false;
        }

        protected override void OnDockChanged(EventArgs e)
        {
            base.OnDockChanged(e);

            Dock = DockStyle.Top;
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);

            BackColor = Colors.Dark;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            Height = 30;

            ExitButton.Location = new Point(Width - ExitButton.Width - 5, 5);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var graphics = e.Graphics;

            var PositionXTitle = 5;

            if (drawIcon && icon != null)
            {
                PositionXTitle = 30;

                graphics.DrawImage(icon, new Rectangle(new Point(5, 5), new Size(20, 20)));
            }

            graphics.DrawString(Text, Font, Brushes.White, new Point(PositionXTitle, (int)((Height - Font.Size) / 2)));
        }
    }
}
