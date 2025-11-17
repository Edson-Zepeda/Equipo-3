using System;
using System.Configuration;
using System.Data.SQLite;

namespace Prototipo2.Data
{
    public static class DbHelper
    {
        private static readonly string _connStr;

        static DbHelper()
        {
            _connStr = SqliteHelper.ConnectionString;
        }

        public static string ConnectionString => _connStr;

        public static SQLiteConnection OpenConnection()
        {
            var cn = new SQLiteConnection(_connStr);
            cn.Open();
            return cn;
        }

        // Execute a set of DB operations inside a transaction. Commits on success, rolls back on exception.
        public static void ExecuteInTransaction(Action<SQLiteConnection, SQLiteTransaction> action)
        {
            SQLiteConnection cn = null;
            SQLiteTransaction tx = null;
            try
            {
                cn = OpenConnection();
                tx = cn.BeginTransaction();
                action(cn, tx);
                tx.Commit();
            }
            catch
            {
                try { tx?.Rollback(); } catch { }
                throw;
            }
            finally
            {
                if (tx != null) tx.Dispose();
                if (cn != null)
                {
                    if (cn.State == System.Data.ConnectionState.Open) cn.Close();
                    cn.Dispose();
                }
            }
        }
    }
}
