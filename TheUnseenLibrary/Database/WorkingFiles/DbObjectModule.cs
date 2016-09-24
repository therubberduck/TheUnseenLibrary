using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUnseenLibrary.Database.WorkingFiles
{
    public abstract class DbObjectModule<T> : DbModule
    {
        public DbObjectModule(DbInterface dbInterface, SqLiteDb db) : base(dbInterface, db)
        {
        }

        public List<T> GetAll()
        {
            var returnList = new List<T>();

            var result = Db.Select(TableName, AllColumnNames);
            foreach (object[] o in result)
            {
                var resultObject = MakeObject(o);
                returnList.Add(resultObject);
            }
            return returnList;
        }

        public T Get(long id)
        {
            object[] result = Db.Select(TableName, AllColumnNames, Id, id);
            if (!result.Any())
            {
                return default(T);
            }

            var o = (object[])result[0];
            var returnObject = MakeObject(o);
            return returnObject;
        }

        protected abstract T MakeObject(object[] dbObject);
    }
}
