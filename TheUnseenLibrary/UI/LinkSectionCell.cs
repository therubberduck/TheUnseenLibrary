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

namespace TheUnseenLibrary.UI
{
    public partial class LinkSectionCell : UserControl
    {
        private DbInterface _db;
        private long _pageId;
        private PageForm _parentForm;

        public LinkSectionCell(DbInterface db, long pageId, PageForm parentForm)
        {
            InitializeComponent();

            _db = db;
            _pageId = pageId;
            _parentForm = parentForm;
        }

        public void SetTitle(string title)
        {
            lblTitle.Text = title;
        }

        private void LinkSectionCell_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PageForm newPage = new PageForm(_db, _pageId);
                newPage.Show();
            }
            else
            {
                _parentForm.ChangePageTo(_pageId);
            }
        }
    }
}
