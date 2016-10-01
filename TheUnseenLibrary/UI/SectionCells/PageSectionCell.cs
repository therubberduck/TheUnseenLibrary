using System.Drawing;
using System.Windows.Forms;
using TheUnseenLibrary.Database;
using TheUnseenLibrary.Model;
using TheUnseenLibrary.Presenter;
using TheUnseenLibrary.UI.Base;
using TheUnseenLibrary.UI.CustomViews;

namespace TheUnseenLibrary.UI.SectionCells
{
    public class PageSectionCell : BaseUserControl
    {
        private readonly Page _page;

        private PageFlowPanel _flwLayoutPanel;

        public PageSectionCell(Page page)
        {
            _page = page;

            AddControls();
            LayoutControls();
            SetupSections();
        }

        private void AddControls()
        {
            Name = "PageSectionCell";

            _flwLayoutPanel = this.AddPageFlowPanel("FlwLayoutPanel", 0);
        }

        private void LayoutControls()
        {
            SuspendLayout();

            Dock = DockStyle.Fill;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            
            _flwLayoutPanel.Dock = DockStyle.Fill;
            _flwLayoutPanel.AutoSize = true;
            _flwLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            ResumeLayout(false);
        }

        private void SetupSections()
        {
            var label = new Label();
            label.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
            label.Text = _page.Name;
            _flwLayoutPanel.Controls.Add(label);

            _flwLayoutPanel.SetSections(_page.Sections);
        }
    }
}
