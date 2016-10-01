using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TheUnseenLibrary.Database;
using TheUnseenLibrary.Model;
using TheUnseenLibrary.Presenter;
using TheUnseenLibrary.UI.Base;
using TheUnseenLibrary.UI.CustomViews;

namespace TheUnseenLibrary.UI
{
    public interface IPageForm
    {
        void SetTitle(string title);
        void HideTitle();
        void ShowTitle();
        void SetSections(List<Section> sections);
        void Show();
    }

    public class PageForm : BaseForm, IPageForm
    {
        private Menu _menu;
        private Label _lblTitle;
        private PageFlowPanel _flwPanelSections;

        public PageForm()
        {
            CreateControls();
            LayoutControls();
            SetAppearance();
            SetupControls();
        }

        private void CreateControls()
        {
            Name = "PageForm";

            _menu = new Menu(this);
            _menu.Name = "menu";
            _menu.TabIndex = 0;
            this.Controls.Add(_menu);

            _lblTitle = this.AddLabel("lblTitle", 1);

            _flwPanelSections = this.AddPageFlowPanel("flwPanel", 2);
        }

        private void LayoutControls()
        {
            SuspendLayout();
            _menu.SuspendLayout();
            _flwPanelSections.SuspendLayout();

            ClientSize = new Size(1000, 1000);
            AutoScaleMode = AutoScaleMode.Font;

            //
            // Menu
            //
            _menu.Location = new Point(0, 0);
            _menu.Size = new Size(1000, 64);
            _menu.AnchorTopAndSides();

            //
            // lblTitle
            //
            _lblTitle.Location = new Point(10, 64);
            _lblTitle.Size = new Size(1000, 40);
            _lblTitle.AnchorTopAndSides();

            // 
            // flwPanelSections
            // 
            _flwPanelSections.Location = new Point(0, 104);
            _flwPanelSections.Size = new Size(1000, 896);
            _flwPanelSections.AnchorAllSides();

            ResumeLayout(false);
            _menu.ResumeLayout(false);
            _flwPanelSections.ResumeLayout(false);
        }

        private void SetAppearance()
        {
            Text = "Page";
            BackColor = Color.White;

            _lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            _lblTitle.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            _lblTitle.Text = "Title";
        }

        private void SetupControls()
        {
            _flwPanelSections.AutoScroll = true;
        }

        public void SetTitle(string title)
        {
            _lblTitle.Text = title;
        }

        public void HideTitle()
        {
            _lblTitle.Hide();

            _flwPanelSections.Location = new Point(0, 64);
            _flwPanelSections.Size = new Size(1000, 936);
        }

        public void ShowTitle()
        {
            if (!_lblTitle.Visible)
            {
                _lblTitle.Show();

                _flwPanelSections.Location = new Point(0, 104);
                _flwPanelSections.Size = new Size(1000, 896);
            }
        }

        public void SetSections(List<Section> sections)
        {
            _flwPanelSections.SetSections(sections);
        }
    }
}
