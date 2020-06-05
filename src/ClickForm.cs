using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AutoClicker
{
    public partial class ClickForm : Form
    {
        public Action<ClickData[]> GetDataClickes { get; set; }

        public List<ClickData> ClickDatas = new List<ClickData>();

        private Bitmap bitmap = Properties.Resources.Plus;

        public ClickForm()
        {
            InitializeComponent();
        }

        private void Loaded_Form(object sender, EventArgs e)
        {
            ClickDatas = new List<ClickData>();

            this.Location = new Point();
            this.Size = Screen.PrimaryScreen.Bounds.Size;
        }

        private void ClickForm_MouseDown(object sender, MouseEventArgs e)
        {
            var position = new Point(e.X, e.Y);

            AddNewImageInControls(position);

            ClickDatas.Add(new ClickData(position, e.Button == MouseButtons.Left ? Mouse.LeftMouse : Mouse.RightMouse));
        }

        private void AddNewImageInControls(Point position)
        {
            var pictureBox = new PictureBox
            {
                BackgroundImage = bitmap,
                BackgroundImageLayout = ImageLayout.Zoom,
                Size = new Size(32, 32),
                Location = new Point(position.X - 16, position.Y - 16)
            };

            this.Controls.Add(pictureBox);
        }

        private void ClickForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.S)
                {
                    if (ClickDatas.Count > 0)
                    {
                        GetDataClickes.Invoke(ClickDatas.ToArray());
                        this.Hide();
                    }
                }
            }
        }
    }
}
