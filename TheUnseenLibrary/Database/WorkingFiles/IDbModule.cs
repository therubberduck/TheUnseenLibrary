using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUnseenLibrary.Database.WorkingFiles
{
    public interface IDbModule
    {
        string TableName { get; }
        DbColumn[] AllColumns { get; }
    }
}
