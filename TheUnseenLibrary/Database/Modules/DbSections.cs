using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUnseenLibrary.Database.DbObject;
using TheUnseenLibrary.Database.WorkingFiles;
using TheUnseenLibrary.Model;

namespace TheUnseenLibrary.Database.Modules
{
    public class DbSections :DbObjectModule<Section>
    {
        public override string TableName => "Sections";

        public override DbColumn[] AllColumns => new[]
        {
            new DbColumn(Id, DbColumn.Integer, true),
            new DbColumn(PageId, DbColumn.Integer),
            new DbColumn(Type, DbColumn.Text),
            new DbColumn(SectionIndex, DbColumn.Integer),
            new DbColumn(Title, DbColumn.Text),
            new DbColumn(ChildId, DbColumn.Integer),
            new DbColumn(Text, DbColumn.Text)
        };

        public const string PageId = "PageId";
        public const string Type = "Type";
        public const string SectionIndex = "SectionIndex";
        public const string Title = "Title";
        public const string ChildId = "ChildId";
        public const string Text = "Text";

        public DbSections(DbInterface dbInterface, SqLiteDb db) : base(dbInterface, db)
        {
        }

        public long CreateLink(long pageId, int index, string title, long childId)
        {
            return Db.Insert(TableName,
                new[] { PageId, Type, SectionIndex, Title, ChildId },
                new object[] { pageId, DboSection.LinkSection, index, title, childId });
        }

        public long CreatePage(long pageId, int index, long childId)
        {
            return Db.Insert(TableName,
                new[] { PageId, Type, SectionIndex, ChildId },
                new object[] { pageId, DboSection.PageSection, index, childId });
        }

        public long CreateText(long pageId, int index, string title, string text)
        {
            return Db.Insert(TableName,
                new[] { PageId, Type, SectionIndex, Title, Text },
                new object[] { pageId, DboSection.TextSection, index, title, text });
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
            DbResultReader reader = new DbResultReader(dbObject);
            var id = reader.ReadLong();
            reader.SkipColumn();
            var type = reader.ReadString();
            var index = reader.ReadInt();
            string title = reader.ReadString();
            var childId = reader.ReadLong();
            string text = reader.ReadString();

            Section section = null;
            if (type.Equals(DboSection.LinkSection))
            {
                section = new LinkSection(DbInterface, id, index, title, childId, text);
            }
            else if (type.Equals(DboSection.PageSection))
            {
                section = new PageSection(DbInterface, id, index, title, childId, text);
            }
            else if (type.Equals(DboSection.TextSection))
            {
                section = new TextSection(DbInterface, id, index, title, childId, text);
            }
            return section;
        }
    }
}
