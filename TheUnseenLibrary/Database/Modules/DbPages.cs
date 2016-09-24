using System;
using TheUnseenLibrary.Database.WorkingFiles;
using TheUnseenLibrary.Model;

namespace TheUnseenLibrary.Database.Modules
{
    public class DbPages : DbObjectModule<Page>
    {

        public override string TableName => "Pages";

        public override DbColumn[] AllColumns => new[]
        {
            new DbColumn(Id, DbColumn.Integer, true),
            new DbColumn(ParentPageId, DbColumn.Integer),
            new DbColumn(Name, DbColumn.Text)
        };

        public const string ParentPageId = "ParentPageId";
        public const string Name = "Name";

        public DbPages(DbInterface dbInterface, SqLiteDb db) : base(dbInterface, db)
        {
        }

        public int Create(string name, int parentId)
        {
            return Db.Insert(TableName,
                new[] { ParentPageId, Name },
                new object[] { parentId, name });
    }

        protected override Page MakeObject(object[] dbObject)
        {
            var id = (long)dbObject[0];
            var parentPageId = (long)dbObject[1];
            var name = (string)dbObject[2];

            var page = new Page(DbInterface, id, parentPageId, name);

            return page;
        }
    }
}
