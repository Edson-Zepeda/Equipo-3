using System;
using System.Data.SQLite;
using System.IO;

namespace Prototipo2.Data
{
    public static class SqliteHelper
    {
        private static readonly string _dbPath;
        private static readonly string _connStr;

        static SqliteHelper()
        {
            _dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "prototipo2.db");
            _connStr = $"Data Source={_dbPath};Version=3;";
            EnsureDatabase();
        }

        public static string ConnectionString => _connStr;

        public static SQLiteConnection OpenConnection()
        {
            var cn = new SQLiteConnection(_connStr);
            cn.Open();
            return cn;
        }

        private static void EnsureDatabase()
        {
            try
            {
                if (!File.Exists(_dbPath))
                {
                    SQLiteConnection.CreateFile(_dbPath);
                }
            }
            catch
            {
                // ignore
            }
        }
    }
}
