using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace UnicomTicManageSystemApp.Data
{
    public static class DbCon
    {
        private static string connectionString = "Data Source=UNICOMticDB.db;Version=3;";

        public static SQLiteConnection GetConnection()
        {
            var conn = new SQLiteConnection(connectionString);
            conn.Open();
            return conn;
        }
    }
}
