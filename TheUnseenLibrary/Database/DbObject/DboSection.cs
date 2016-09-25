using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUnseenLibrary.Model;

namespace TheUnseenLibrary.Database.DbObject
{
    public class DboSection
    {
        public const string LinkSection = "LinkSection";
        public const string PageSection = "PageSection";
        public const string TextSection = "TextSection";

        private DbInterface _db;

        public long SectionId { get; set; }

        public int Index { get; set; }

        public string Title { get; set; }

        protected long ChildId { get; set; }
        protected string Text { get; set; }


        private Page _childPage;
        protected Page ChildPage
        {
            get
            {
                if (_childPage == null)
                {
                    _childPage = _db.Pages.Get(ChildId);
                }
                return _childPage;
            }
            set { _childPage = value; }
        }

        public DboSection(DbInterface db, long sectionId, int index, string title, long childId, string text)
        {
            _db = db;
            SectionId = sectionId;
            Index = index;
            Title = title;
            ChildId = childId;
            Text = text;
        }
    }
}
