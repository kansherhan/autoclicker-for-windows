using AutoClicker.Forms;
using AutoClicker.UserControls;
using AutoClicker.Utils;
using System.Windows.Forms;

namespace AutoClicker
{
    public partial class MainForm : FormBase
    {
        public MainForm()
        {
            InitializeComponent();

            IOFile.CreateSaveFolders();

            CreateMenuItems();
        }

        private void CreateMenuItems()
        {
            var quete = new QueteUserControl(this);
            var reusable = new ReusableUserControl(this);

            ContainerPanel.Controls.Add(quete);
            ContainerPanel.Controls.Add(reusable);

            MenuPanel.SelectIndexChanged += MenuPanel_SelectIndexChanged;
            MenuPanel.AddButton(ContainerPanel.Controls.Count);
        }

        private void MenuPanel_SelectIndexChanged(int index)
        {
            foreach (Control control in ContainerPanel.Controls)
            {
                control.Visible = false;
            }

            ContainerPanel.Controls[index].Visible = true;
        }
    }
}
