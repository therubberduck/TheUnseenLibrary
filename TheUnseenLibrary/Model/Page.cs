using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUnseenLibrary.Database;
using TheUnseenLibrary.Database.DbObject;

namespace TheUnseenLibrary.Model
{
    public class Page : DboPage
    {
        public Page(DbInterface db, long pageId, long parentId, string name) : base(db, pageId, parentId, name)
        {
        }
    }
}
