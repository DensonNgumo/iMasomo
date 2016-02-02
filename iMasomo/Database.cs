using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SQLite;

namespace iMasomo
{
    public static class Database
    {
        private static string dbConnectionString = @"Data Source=iMasomoDB.db;Version=3;";
        private  static SQLiteConnection sqliteConn;

       
        public static void OpenDatabase()
        {
            try
            {
                sqliteConn = new SQLiteConnection(dbConnectionString);
                sqliteConn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void CloseDatabase()
        {
            sqliteConn.Close();
        }
        public static SQLiteConnection GetDatabaseConnection()
        {
            return sqliteConn;
        }
    }
}
