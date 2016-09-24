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
        public LinkSection(DbInterface db, long sectionId, long pageId, string sectionType, int index, long childId, string text) : base(db, sectionId, pageId, sectionType, index, childId, text)
        {
        }
    }
}
