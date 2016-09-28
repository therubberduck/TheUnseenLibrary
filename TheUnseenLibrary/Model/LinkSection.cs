using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUnseenLibrary.Database;

namespace TheUnseenLibrary.Model
{
    public class LinkSection : Section
    {
        public long ChildPageId
        {
            get { return ChildId; }
        }

        public Page Page
        {
            get { return ChildPage; }
        }

        public LinkSection(DbInterface db, long sectionId, int index, string title, long childId, string text) : base(db, sectionId, index, title, childId, text)
        {
        }
    }
}
