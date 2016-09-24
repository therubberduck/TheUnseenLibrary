using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUnseenLibrary.Database.WorkingFiles
{
    public abstract class DbModule : IDbModule
    {
        protected DbInterface DbInterface;
        protected SqLiteDb Db;

        public abstract string TableName { get; }
        public abstract DbColumn[] AllColumns { get; }
        public string[] AllColumnNames { get; }
        public const string Id = "Id";

        protected DbModule(DbInterface dbInterface, SqLiteDb db)
        {
            DbInterface = dbInterface;
            Db = db;
            AllColumnNames = new string[AllColumns.Length];
            for (int i = 0; i < AllColumns.Length; i++)
            {
                AllColumnNames[i] = AllColumns[i].Name;
            }
        }

        public List<int> GetAllIds()
        {
            var ids = new List<int>();

            var result = Db.Select(TableName, new[] { Id });
            foreach (object[] o in result)
            {
                var dbId = (int)(long)o[0];
                ids.Add(dbId);
            }
            return ids;
        }

        public void Remove(int id)
        {
            Db.Delete(TableName, Id, id);
        }

        public void ClearTable()
        {
            Db.ClearTable(TableName);
        }

        protected int GetInt(object dbObject)
        {
            return (int)(long)dbObject;
        }
    }
}
