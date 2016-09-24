using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUnseenLibrary.Database.WorkingFiles;
using TheUnseenLibrary.Model;

namespace TheUnseenLibrary.Database.Modules
{
    public class DbContainers : DbObjectModule<Container>
    {
        public override string TableName => "Containers";

        public override DbColumn[] AllColumns => new[]
        {
            new DbColumn(Id, DbColumn.Integer, true),
            new DbColumn(Name, DbColumn.Text),
            new DbColumn(Description, DbColumn.Text)
        };

        public const string Name = "Name";
        public const string Description = "Description";

        public DbContainers(DbInterface dbInterface, SqLiteDb db) : base(dbInterface, db)
        {
        }

        protected override Container MakeObject(object[] dbObject)
        {
            throw new NotImplementedException();
        }
    }
}
