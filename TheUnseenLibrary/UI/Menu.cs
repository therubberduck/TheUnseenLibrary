using System;
using System.Drawing;
using System.Windows.Forms;
using TheUnseenLibrary.Events;
using TheUnseenLibrary.Presenter;
using TheUnseenLibrary.UI.Base;
using EventHandler = TheUnseenLibrary.Events.EventHandler;

namespace TheUnseenLibrary.UI
{
    public class Menu : UserControl
    {
        private PageForm _form;

        private MenuStrip _menu1;
        private ToolStripMenuItem _menuItemFile;

        private Panel _pnlIconStrip;
        private Button _btnBack;
        private Button _btnForward;
        private TextBox _txtSearch;
        private Button _btnEdit;

        public Menu(PageForm form)
        {
            _form = form;

            CreateControls();
            LayoutControls();
            SetAppearance();
            SetupControls();
        }

        private void CreateControls()
        {
            
            _menu1 = this.AddMenuStrip("Menu1", 0);
            _menu1.SuspendLayout();

            _menuItemFile = _menu1.AddMenuItem("MenuItemFile");

            _pnlIconStrip = this.AddPanel("PnlIconStrip", 1);
            _pnlIconStrip.SuspendLayout();
            
            _btnBack = _pnlIconStrip.AddButton("BtnBack", 2);
            _btnForward = _pnlIconStrip.AddButton("BtnForward", 3);
            _txtSearch = _pnlIconStrip.AddTextBox("TxtSearch", 0);
            _btnEdit = _pnlIconStrip.AddButton("BtnEdit", 1);
        }

        private void LayoutControls()
        {
            Size = new Size(1000, 64);

            // 
            // menuStrip1
            // 
            _form.MainMenuStrip = _menu1;
            _menu1.Location = new Point(0, 0);
            _menu1.Size = new Size(1000, 24);

            // 
            // MenuItemFile
            // 
            _menuItemFile.Size = new Size(50, 29);

            // 
            // menuStrip2
            // 
            _pnlIconStrip.Location = new Point(0, 24);
            _pnlIconStrip.Size = new Size(1000, 40);
            _pnlIconStrip.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);

            // 
            // BtnBack
            // 
            _btnBack.Location = new Point(5, 5);
            _btnBack.Size = new Size(30, 30);

            // 
            // BtnForward
            // 
            _btnForward.Location = new Point(45, 5);
            _btnForward.Size = new Size(30, 30);

            //
            // TxtSearch
            //
            _txtSearch.Location = new Point(85, 10);
            _txtSearch.Size = new Size(90, 30);

            // 
            // BtnEdit
            // 
            _btnEdit.Location = new Point(965, 5);
            _btnEdit.Size = new Size(30, 30);
            _btnEdit.AnchorTopRight();

            _menu1.ResumeLayout(false);
            _pnlIconStrip.ResumeLayout(false);
        }

        private void SetAppearance()
        {
            BackColor = SystemColors.MenuBar;

            // 
            // menuStrip1
            // 
            _menu1.ImageScalingSize = new Size(24, 24);
            _menu1.Text = "menuStrip1";

            // 
            // MenuItemFile
            // 
            _menuItemFile.Text = "File";

            // 
            // menuStrip2
            // 

            _pnlIconStrip.BackColor = Color.LightGray;

            // 
            // MenuItemBack
            // 
            _btnBack.BackgroundImage = Image.FromFile("Resources/back-icon.png");
            _btnBack.BackgroundImageLayout = ImageLayout.Stretch;

            // 
            // MenuItemForward
            // 
            _btnForward.BackgroundImage = Image.FromFile("Resources/forward-icon.png");
            _btnForward.BackgroundImageLayout = ImageLayout.Stretch;

            // 
            // BtnEdit
            //
            _btnEdit.BackgroundImage = Image.FromFile("Resources/edit-icon.png");
            _btnEdit.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void SetupControls()
        {

            // 
            // MenuItemBack
            // 
            _btnBack.Click += ButtonBack_Click;

            // 
            // MenuItemForward
            // 
            _btnForward.Click += ButtonForward_Click;
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            EventHandler.Instance.SendNavigateBackwardsEvent();
        }

        private void ButtonForward_Click(object sender, EventArgs e)
        {
            EventHandler.Instance.SendNavigateForwardEvent();
        }
    }
}
