using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUnseenLibrary.Database.Modules;
using TheUnseenLibrary.Database.WorkingFiles;

namespace TheUnseenLibrary.Database
{
    public static class DbUpdater
    {
        private const long CurrentVersion = 1;

        public static void CheckForDbSchemaUpdates(SqLiteDb db, DbConnections connections, DbContainers containers, DbPages pages, DbSections sections)
        {
            long version = db.GetVersion();

            if (version == 0)
            {
                db.CreateTables(new IDbModule[] { connections, containers, pages, sections });
            }

            db.SetVersion(CurrentVersion);
        }
    }
}
