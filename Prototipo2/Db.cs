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
                // Prefer ConnectionStrings Prototipo2
                var cs = ConfigurationManager.ConnectionStrings["Prototipo2"];
                if (cs != null && !string.IsNullOrWhiteSpace(cs.ConnectionString)) return cs.ConnectionString;

                // Fallback AppSettings entry
                string cfg = ConfigurationManager.AppSettings["MySqlConnection"];
                if (!string.IsNullOrWhiteSpace(cfg)) return cfg;

                // Default to local SQLite file
                return "Data Source=prototipo2.db;Version=3;";
            }
        }
    }
}
