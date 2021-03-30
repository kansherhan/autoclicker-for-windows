using System;
using System.Drawing;
using System.Windows.Forms;

namespace AutoClicker.Controls
{
    public class MenuPanel : Control
    {
        public event Action<int> SelectIndexChanged;

        private int selectIndex = 0;

        public void AddButton(Image[] images)
        {
            foreach (var img in images)
            {
                AddButton(img);
            }
        }

#if DEBUG
        public void AddButton(int count)
        {
            for (int i = 0; i < count; i++)
            {
                AddButton(image: null);
            }
        }
#endif

        private void AddButton(Image image)
        {
            var count = Controls.Count;

            var button = new MenuRadioButton(count)
            {
                Location = new Point(0, count * MenuRadioButton.DefaultButtonSize.Height),
                BackImage = image
            };

            button.Checked = count == 0;

            button.Actived += MenuButton_Actived;

            Controls.Add(button);
        }

        private void MenuButton_Actived(int index)
        {
            if (selectIndex != index)
            {
                selectIndex = index;
                SelectIndexChanged?.Invoke(index);
            }
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);

            BackColor = Color.FromArgb(32, 42, 47);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            Width = MenuRadioButton.DefaultButtonSize.Width;
        }
    }
}
