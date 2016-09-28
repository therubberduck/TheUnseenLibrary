using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheUnseenLibrary.Database;
using TheUnseenLibrary.Model;
using TheUnseenLibrary.UI;

namespace TheUnseenLibrary
{
    public partial class PageForm : Form
    {
        private DbInterface _db ;
        private Page _page;

        private List<long> _navigationStack;
        private int _navigationIndex;

        public PageForm(DbInterface db, Page page)
        {
            InitializeComponent();

            _db = db;
            _page = page;

            Initialize();
        }

        public PageForm(DbInterface db, long pageId)
        {
            InitializeComponent();

            _db = db;
            _page = db.Pages.Get(pageId);

            Initialize();
        }

        public void Initialize()
        {
            _navigationStack = new List<long> {_page.PageId};
            _navigationIndex = 0;

            SetupSections();
        }

        public void ChangePageTo(long pageId)
        {
            _page = _db.Pages.Get(pageId);

            int index = _navigationIndex + 1;
            int count = _navigationStack.Count - index;
            _navigationStack.RemoveRange(index, count); //Remove any pages on the stack after our current index
            _navigationStack.Add(_page.PageId); //Add the new page to the stack
            _navigationIndex++; //Increase index by 1

            ClearSections();
            SetupSections();
        }

        private void SetupSections()
        {
            foreach (var section in _page.Sections)
            {
                if (section is LinkSection)
                {
                    LinkSection linkSection = (LinkSection)section;

                    var cell = new LinkSectionCell(_db, linkSection.ChildPageId, this);
                    cell.SetTitle(linkSection.Title);
                    flwPanel.Controls.Add(cell);
                }
                else if (section is PageSection)
                {
                    PageSection pageSection = (PageSection)section;

                    var cell = new PageSectionCell(_db, pageSection.Page, this);
                    flwPanel.Controls.Add(cell);
                }
                else
                {
                    TextSection textSection = (TextSection)section;

                    var cell = new TextSectionCell();
                    cell.SetLabels(textSection.Title, textSection.Body);
                    flwPanel.Controls.Add(cell);
                }
            }
        }

        private void ClearSections()
        {
            flwPanel.Controls.Clear();
        }

        //
        // Menu Strip Items
        //

        private void tsmiBack_Click(object sender, EventArgs e)
        {
            if (_navigationIndex > 0)
            {
                _navigationIndex--;
                long pageId = _navigationStack[_navigationIndex];

                _page = _db.Pages.Get(pageId);

                ClearSections();
                SetupSections();
            }
        }

        private void tsmiForward_Click(object sender, EventArgs e)
        {
            if (_navigationIndex < _navigationStack.Count - 1)
            {
                _navigationIndex++;
                long pageId = _navigationStack[_navigationIndex];

                _page = _db.Pages.Get(pageId);

                ClearSections();
                SetupSections();
            }
        }
    }
}
