using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUnseenLibrary.Database.Modules;
using TheUnseenLibrary.Database.WorkingFiles;

namespace TheUnseenLibrary.Database
{
    public class DbInterface
    {
        public readonly DbConnections Connections;
        public readonly DbContainers Containers;
        public readonly DbPages Pages;
        public readonly DbSections Sections;

        private readonly SqLiteDb _db;

        public DbInterface()
        {
            _db = new SqLiteDb();

            Connections = new DbConnections(this, _db);
            Containers = new DbContainers(this, _db);
            Pages = new DbPages(this, _db);
            Sections = new DbSections(this, _db);

            DbUpdater.CheckForDbSchemaUpdates(_db, Connections, Containers, Pages, Sections);
        }

        public void UpdateDbSchema()
        {
            _db.ReloadDb();
            DbUpdater.CheckForDbSchemaUpdates(_db, Connections, Containers, Pages, Sections);
        }

        public void ClearDb()
        {
            _db.CreateTables(new IDbModule[] { Connections, Containers, Pages, Sections });
            Connections.ClearTable();
            Containers.ClearTable();
            Pages.ClearTable();
            Sections.ClearTable();
        }
    }
}
