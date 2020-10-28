using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataRyn
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
        void ResetConnection();
      
    }
}
