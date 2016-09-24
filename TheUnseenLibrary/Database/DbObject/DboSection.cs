using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUnseenLibrary.Database.DbObject
{
    public class DboSection
    {
        private DbInterface _db;

        public long SectionId { get; set; }
        public long PageId { get; set; }

        public string SectionType { get; set; }
        public int Index { get; set; }

        protected long ChildId { get; set; }
        protected string Text { get; set; }

        public DboSection(DbInterface db, long sectionId, long pageId, string sectionType, int index, long childId, string text)
        {
            _db = db;
            SectionId = sectionId;
            PageId = pageId;
            SectionType = sectionType;
            Index = index;
            ChildId = childId;
            Text = text;
        }
    }
}
