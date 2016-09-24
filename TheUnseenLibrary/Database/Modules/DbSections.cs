using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUnseenLibrary.Database.WorkingFiles;
using TheUnseenLibrary.Model;

namespace TheUnseenLibrary.Database.Modules
{
    public class DbSections :DbObjectModule<Section>
    {
        public override string TableName => "Containers";

        public override DbColumn[] AllColumns => new[]
        {
            new DbColumn(Id, DbColumn.Integer, true),
            new DbColumn(PageId, DbColumn.Integer),
            new DbColumn(Type, DbColumn.Text),
            new DbColumn(SectionIndex, DbColumn.Integer),
            new DbColumn(ChildId, DbColumn.Integer),
            new DbColumn(Text, DbColumn.Text)
        };

        public const string PageId = "PageId";
        public const string Type = "Type";
        public const string SectionIndex = "SectionIndex";
        public const string ChildId = "ChildId";
        public const string Text = "Text";

        public DbSections(DbInterface dbInterface, SqLiteDb db) : base(dbInterface, db)
        {
        }

        public List<Section> GetSectionsForPageId(long pageId)
        {
            string otherClauses = "WHERE " + PageId + " = " + pageId;
            otherClauses += " ORDER BY " + SectionIndex;
            var results = Db.Select(TableName, AllColumnNames, otherClauses);

            var returnList = new List<Section>();
            foreach (object[] o in results)
            {
                var resultObject = MakeObject(o);
                returnList.Add(resultObject);
            }
            return returnList;
        } 

        protected override Section MakeObject(object[] dbObject)
        {
            var id = (long)dbObject[0];
            var pageId = (int)dbObject[1];
            var type = (string)dbObject[2];
            var index = (int)dbObject[3];
            var childId = (int)dbObject[4];
            var text = (string)dbObject[5];

            Section section = null;
            if (type.Equals(Section.LinkSection))
            {
                section = new LinkSection(DbInterface, id, pageId, type, index, childId, text);
            }
            else if (type.Equals(Section.PageSection))
            {
                section = new PageSection(DbInterface, id, pageId, type, index, childId, text);
            }
            else if (type.Equals(Section.TextSection))
            {
                section = new TextSection(DbInterface, id, pageId, type, index, childId, text);
            }
            return section;
        }
    }
}
