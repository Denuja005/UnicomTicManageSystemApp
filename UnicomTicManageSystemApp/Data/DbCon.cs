using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;//slite database access namespace

namespace UnicomTicManageSystemApp.Data
{
    public static class DbCon// static class -object ilama direct ah call panalam
    {
        private static string connectionString = "Data Source=UNICOMticDB.db;Version=3;";//db connection path

        public static SQLiteConnection GetConnection()
        {
            var conn = new SQLiteConnection(connectionString);
            conn.Open();
            return conn;
        }
    }
}
