using System;
using System.Configuration;

namespace Prototipo2
{
    public static class Db
    {
        public static string ConnString
        {
            get
            {
                // Try AppSettings first (if present), otherwise fallback to Docker connection used in project
                string cfg = ConfigurationManager.AppSettings["MySqlConnection"];
                if (!string.IsNullOrWhiteSpace(cfg)) return cfg;

                return "server=127.0.0.1;port=3307;database=prototipo2_db;uid=appuser;pwd=apppass123;SslMode=none;";
            }
        }
    }
}
