using AutoClicker.Utils;
using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace AutoClicker.Controls
{
    public class StringListBox : Control
    {
        private const int padding = 10;

        public TextBox searchTextBox;
        public ListView listView;

        public string SelectItem
        {
            get
            {
                if (listView.SelectedIndices.Count > 0)
                {
                    return listView.SelectedItems.OfType<ListViewItem>().First().Text;
                }
                else return null;
            }
        }

        public string[] Items
        {
            get => items;
            set
            {
                ClearItems();

                items = value;

                AddItems(value);
            }
        }

        private string[] items;

        public StringListBox()
        {
            BackColor = Colors.Gray;
            ForeColor = Color.White;

            searchTextBox = new TextBox()
            {
                BorderStyle = BorderStyle.None,
                Size = new Size(Width - padding * 2, 30),
                ForeColor = Color.White,
                BackColor = Colors.DarkGray
            };

            listView = new ListView()
            {
                View = View.List,
                BorderStyle = BorderStyle.None,
                ForeColor = Color.White,
                BackColor = Colors.DarkGray,
                MultiSelect = false
            };

            searchTextBox.TextChanged += SearchTextBox_TextChanged;

            Controls.Add(searchTextBox);
            Controls.Add(listView);
        }

        private void AddItems(IEnumerable<string> texts)
        {
            if (texts != null)
            {
                foreach (var text in texts)
                {
                    AddItem(text);
                }
            }
        }

        private void AddItem(string text) => listView.Items.Add(text);

        private void ClearItems() => listView.Clear();

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (searchTextBox.TextLength > 0)
            {
                var pattern = searchTextBox.Text;

                var inputs = listView
                    .Items
                    .OfType<ListViewItem>()
                    .GroupBy(g => g.Text)
                    .Select(s => s.Key)
                    .ToArray();

                ClearItems();
                AddItems(inputs.Where(x => x.Contains(pattern)));
            }
            else
            {
                ClearItems();
                AddItems(items);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            searchTextBox.Location = new Point(padding, 15 + (int)Font.Size);
            searchTextBox.Size = new Size(Width - padding * 2, searchTextBox.Height);

            listView.Location = new Point(padding, searchTextBox.Top + 25);
            listView.Size = new Size(Width - padding * 2, Height - listView.Top - 10);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var graphics = e.Graphics;

            graphics.DrawString("Search:", Font, Brushes.White, padding, 5);
        }
    }
}
