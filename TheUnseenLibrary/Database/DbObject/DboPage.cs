using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUnseenLibrary.Model;

namespace TheUnseenLibrary.Database.DbObject
{
    public class DboPage
    {
        private DbInterface _db;

        public long PageId { get; set; }

        protected long ParentId;
        private Page _parent;
        public Page Parent {
            get
            {
                if (_parent == null && ParentId != -1)
                {
                    _parent = _db.Pages.Get(ParentId);
                }
                return _parent;
            }
            set { _parent = value; }
        }

        public string Name { get; set; }

        private List<Section> _sections;
        public List<Section> Sections
        {
            get
            {
                if (_sections == null)
                {
                    _sections = _db.Sections.GetSectionsForPageId(PageId);
                }
                return _sections;
            }
            set { _sections = value; }
        }

        public DboPage(DbInterface db, long pageId, long parentId, string name)
        {
            _db = db;
            PageId = pageId;
            ParentId = parentId;
            Name = name;
        }
    }
}
