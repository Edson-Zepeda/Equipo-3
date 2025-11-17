using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Prototipo2.Data
{
    public static class DbHelper
    {
        private static readonly string _connStr;

        static DbHelper()
        {
            var cs = ConfigurationManager.ConnectionStrings["Prototipo2"];
            _connStr = cs != null ? cs.ConnectionString : "server=127.0.0.1;port=3307;database=prototipo2_db;uid=appuser;pwd=apppass123;";
        }

        public static string ConnectionString => _connStr;

        public static MySqlConnection OpenConnection()
        {
            var cn = new MySqlConnection(_connStr);
            cn.Open();
            return cn;
        }

        // Execute a set of DB operations inside a transaction. Commits on success, rolls back on exception.
        public static void ExecuteInTransaction(Action<MySqlConnection, MySqlTransaction> action)
        {
            MySqlConnection cn = null;
            MySqlTransaction tx = null;
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
