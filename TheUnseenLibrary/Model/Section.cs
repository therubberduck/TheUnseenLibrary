using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUnseenLibrary.Database;
using TheUnseenLibrary.Database.DbObject;

namespace TheUnseenLibrary.Model
{
    public class Section : DboSection
    {
        public const string LinkSection = "LinkSection";
        public const string PageSection = "PageSection";
        public const string TextSection = "TextSection";

        public Section(DbInterface db, long sectionId, long pageId, string sectionType, int index, long childId, string text) : base(db, sectionId, pageId, sectionType, index, childId, text)
        {
        }
    }
}
