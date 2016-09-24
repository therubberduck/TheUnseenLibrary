using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUnseenLibrary.Database.WorkingFiles;

namespace TheUnseenLibrary.Database.Modules
{
    public class DbConnections : DbModule
    {
        public override string TableName => "Connections";

        public override DbColumn[] AllColumns => new[]
        {
            new DbColumn(Id, DbColumn.Integer, true),
            new DbColumn(EntityId1, DbColumn.Integer),
            new DbColumn(EntityId2, DbColumn.Integer)
        };
        
        public const string EntityId1 = "EntityId1";
        public const string EntityId2 = "EntityId2";

        public DbConnections(DbInterface dbInterface, SqLiteDb db) : base(dbInterface, db)
        {
        }
    }
}
