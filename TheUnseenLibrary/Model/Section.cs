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
        public Section(DbInterface db, long sectionId, int index, string title, long childId, string text) : base(db, sectionId, index, title, childId, text)
        {
        }
    }
}
