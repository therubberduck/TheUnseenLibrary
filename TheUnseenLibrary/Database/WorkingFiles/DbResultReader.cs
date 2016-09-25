using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUnseenLibrary.Database.WorkingFiles
{
    public class DbResultReader
    {
        private readonly object[] _columnsResult;
        private int _i;

        public DbResultReader(object[] columnsResult)
        {
            _columnsResult = columnsResult;
            _i = 0;
        }

        public int ReadInt()
        {
            int result = _columnsResult[_i] is DBNull ? -1 : Convert.ToInt32(_columnsResult[_i]);
            _i++;
            return result;
        }

        public long ReadLong()
        {
            long result = _columnsResult[_i] is DBNull ? -1 : (long)_columnsResult[_i];
            _i++;
            return result;
        }

        public string ReadString()
        {
            string result = _columnsResult[_i] is DBNull ? null : (string)_columnsResult[_i];
            _i++;
            return result;
        }

        public void SkipColumn()
        {
            _i++;
        }

        public string ReadString(DbModule module, string columnName)
        {
            for (int i = 0; i < module.AllColumnNames.Length; i++)
            {
                if (module.AllColumnNames[i].Equals(columnName))
                {
                    return _columnsResult[i] is DBNull ? null : (string)_columnsResult[i];
                }
            }
            return null;
        }
    }
}
