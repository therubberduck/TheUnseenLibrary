using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheUnseenLibrary.Database;
using TheUnseenLibrary.Model;

namespace TheUnseenLibrary.UI
{
    public partial class PageSectionCell : UserControl
    {
        private DbInterface _db;
        private Page _page;
        private PageForm _parentForm;

        public PageSectionCell(DbInterface db, Page page, PageForm parentForm)
        {
            InitializeComponent();

            _db = db;
            _page = page;
            _parentForm = parentForm;

            SetupSections();
        }

        private void SetupSections()
        {
            var label = new Label();
            label.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
            label.Text = _page.Name;
            flwLayoutPanel.Controls.Add(label);

            foreach (var section in _page.Sections)
            {
                if (section is LinkSection)
                {
                    LinkSection linkSection = (LinkSection)section;

                    var cell = new LinkSectionCell(_db, linkSection.ChildPageId, _parentForm);
                    cell.SetTitle(linkSection.Title);
                    flwLayoutPanel.Controls.Add(cell);
                }
                else if (section is PageSection)
                {
                    PageSection pageSection = (PageSection)section;

                    var cell = new PageSectionCell(_db, pageSection.Page, _parentForm);
                    flwLayoutPanel.Controls.Add(cell);
                }
                else
                {
                    TextSection textSection = (TextSection)section;

                    var cell = new TextSectionCell();
                    cell.SetLabels(textSection.Title, textSection.Body);
                    flwLayoutPanel.Controls.Add(cell);
                }
            }
        }
    }
}
