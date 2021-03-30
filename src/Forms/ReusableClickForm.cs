using AutoClicker.Data;
using AutoClicker.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AutoClicker.Forms
{
    public partial class ReusableClickForm : Form
    {
        private bool editMode;

        private readonly string filename;

        private readonly ClickList clickList;
        private readonly Image clickImage;

        public ReusableClickForm()
        {
            InitializeComponent();

            editMode = false;

            clickList = new ClickList();
            clickImage = Properties.Resources.ClickImage;

            Size = Screen.PrimaryScreen.Bounds.Size;
            Location = new Point(0, 0);
        }

        public ReusableClickForm(string filename, ClickList clickList) : this()
        {
            this.filename = filename;
            this.clickList = clickList;
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            if (clickList.Count > 0 && clickImage != null)
            {
                var graphics = e.Graphics;

                for (int i = 0; i < clickList.Count; i++)
                {
                    var click = clickList[i];
                    var clickPoint = new Point(click.Cursor.X - clickImage.Width / 2, click.Cursor.Y - clickImage.Height / 2);

                    graphics.DrawImage(clickImage, new Rectangle(clickPoint, clickImage.Size));
                }
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.E)
            {
                editMode = !editMode;

                if (editMode) BackColor = Color.Gray;
                else BackColor = Color.White;

                Invalidate();
            }
            else if (e.KeyData == Keys.S)
            {
                var filename = string.Empty;

                if (string.IsNullOrWhiteSpace(this.filename))
                {
                    filename = DateTime.Now.ToString(IOFile.DateTimeFormat);
                }
                else
                {
                    filename = this.filename;
                }

                var path = $"{IOFile.ReusableSaveFolder}/{filename}.json";

                clickList.Save(path);

                DialogResult = DialogResult.OK;

                Close();
            }
            else if (e.KeyData == Keys.Escape) Close();
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (editMode)
            {
                var index = GetSelectClickIndex();

                if (index >= 0)
                {
                    var click = clickList[index];

                    var settingForm = new ReusableSettingForm(click);

                    TopMost = false;

                    if (settingForm.ShowDialog() == DialogResult.OK)
                    {
                        clickList[index] = settingForm.ClickSettings;
                    }

                    TopMost = true;
                }
            }
            else
            {
                if (e.Button == MouseButtons.Left)
                {
                    var click = new Click(100, MouseType.LeftMouse, Cursor.Position);

                    if (!clickList.Clicks.Contains(click))
                    {
                        clickList.Clicks.Add(click);

                        Invalidate();
                    }
                }
                else if (e.Button == MouseButtons.Right)
                {
                    var index = GetSelectClickIndex();

                    if (index >= 0)
                    {
                        clickList.Clicks.RemoveAt(index);

                        Invalidate();
                    }
                }
            }
        }

        private int GetSelectClickIndex()
        {
            var cursor = Cursor.Position;

            var index = 0;
            var minDistance = double.MaxValue;

            for (int i = 0; i < clickList.Count; i++)
            {
                var click = clickList[i].Cursor;

                var x = Math.Pow(cursor.X - click.X, 2);
                var y = Math.Pow(cursor.Y - click.Y, 2);

                var distance = Math.Sqrt(x + y);

                if (distance < minDistance)
                {
                    index = i;
                    minDistance = distance;
                }
            }

            if (minDistance < 15.0)
            {
                return index;
            }
            else return -1;
        }
    }
}
