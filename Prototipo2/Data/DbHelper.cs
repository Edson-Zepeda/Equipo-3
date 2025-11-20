using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace Prototipo2.Data
{
    public static class AyudanteBD
    {
        private static readonly string cadenaConexion;
        private static readonly string rutaArchivoBD;

        static AyudanteBD()
        {
            System.Configuration.ConnectionStringSettings cs = ConfigurationManager.ConnectionStrings["Prototipo2"];
            if (cs != null && !string.IsNullOrEmpty(cs.ConnectionString))
            {
                cadenaConexion = cs.ConnectionString;
            }
            else
            {
                rutaArchivoBD = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "prototipo2.db");
                cadenaConexion = "Data Source=" + rutaArchivoBD + ";Version=3;";
            }
            try
            {
                if (string.IsNullOrEmpty(rutaArchivoBD))
                {
                    string[] parts = cadenaConexion.Split(';');
                    foreach (string p in parts)
                    {
                        if (p.TrimStart().StartsWith("Data Source", StringComparison.OrdinalIgnoreCase) || p.TrimStart().StartsWith("DataSource", StringComparison.OrdinalIgnoreCase))
                        {
                            string[] kv = p.Split('=');
                            if (kv.Length == 2) rutaArchivoBD = kv[1];
                        }
                    }
                }

                bool necesitaCrear = !File.Exists(rutaArchivoBD);
                if (necesitaCrear)
                {
                    SQLiteConnection.CreateFile(rutaArchivoBD);
                }

                using (SQLiteConnection cn = new SQLiteConnection(cadenaConexion))
                {
                    cn.Open();
                    string rutaEsquema = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sql", "schema_sqlite.sql");
                    if (File.Exists(rutaEsquema))
                    {
                        string sql = File.ReadAllText(rutaEsquema);
                        using (SQLiteCommand cmd = new SQLiteCommand(sql, cn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string fallback = @"PRAGMA foreign_keys = ON;

CREATE TABLE IF NOT EXISTS usuarios (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  Usuario TEXT NOT NULL UNIQUE,
  Clave TEXT NOT NULL,
  EsAdmin INTEGER NOT NULL DEFAULT 0
);
 
  nombre TEXT NOT NULL,
  autor TEXT,
  categoria TEXT,
  isbn TEXT UNIQUE,
  precio REAL,
  fecha_publicacion DATETIME,
  stock INTEGER DEFAULT 0
);

CREATE TABLE IF NOT EXISTS ejemplares (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  libro_id INTEGER NOT NULL,
  codigo_barra TEXT NOT NULL UNIQUE,
  estado TEXT NOT NULL DEFAULT 'DISPONIBLE',
  ubicacion TEXT,
  FOREIGN KEY (libro_id) REFERENCES libros(id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS prestamos (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  socio_id INTEGER NOT NULL,
  ejemplar_id INTEGER NOT NULL,
  fecha_prestamo DATETIME NOT NULL DEFAULT (CURRENT_TIMESTAMP),
  fecha_vencimiento DATETIME NOT NULL,
  fecha_devolucion DATETIME NULL,
  estado TEXT NOT NULL,
  FOREIGN KEY (socio_id) REFERENCES socios(id),
  FOREIGN KEY (ejemplar_id) REFERENCES ejemplares(id)
);

CREATE TABLE IF NOT EXISTS auditoria (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  usuario_id INTEGER NULL,
  accion TEXT NOT NULL,
  entidad TEXT NOT NULL,
  entidad_id INTEGER NULL,
  fecha DATETIME NOT NULL DEFAULT (CURRENT_TIMESTAMP),
  detalle TEXT
);
";
                        using (SQLiteCommand cmd = new SQLiteCommand(fallback, cn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch
            {
                // Ignorar errores en la inicialización de la BD
            }
        }

        public static string CadenaConexion => cadenaConexion;

        public static SQLiteConnection AbrirConexion()
        {
            SQLiteConnection cn = new SQLiteConnection(cadenaConexion);
            cn.Open();
            return cn;
        }

        public static void EjecutarEnTransaccion(Action<SQLiteConnection, SQLiteTransaction> accion)
        {
            SQLiteConnection cn = null;
            SQLiteTransaction tx = null;
            try
            {
                cn = AbrirConexion();
                tx = cn.BeginTransaction();
                accion(cn, tx);
                tx.Commit();
            }
            catch
            {
                try { if (tx != null) tx.Rollback(); } catch { }
                // No volvemos a lanzar la excepción: el usuario pidió no usar 'throw'
                return;
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

        // ADO.NET example: fill a DataSet using SQLiteDataAdapter (shows DataSet, DataTable, DbDataAdapter usage)
        public static DataSet ObtenerDataSetConAdapter(string consulta, SQLiteParameter[] parametros)
        {
            DataSet ds = new DataSet();
            SQLiteConnection conexion = null;
            SQLiteDataAdapter adapter = null;
            try
            {
                conexion = new SQLiteConnection(cadenaConexion);
                conexion.Open();
                adapter = new SQLiteDataAdapter(consulta, conexion);
                if (parametros != null)
                {
                    for (int i = 0; i < parametros.Length; i++)
                    {
                        adapter.SelectCommand.Parameters.Add(parametros[i]);
                    }
                }
                adapter.Fill(ds);
            }
            catch
            {
                // manejar error si es necesario
            }
            finally
            {
                if (adapter != null) adapter.Dispose();
                if (conexion != null)
                {
                    if (conexion.State == ConnectionState.Open) conexion.Close();
                    conexion.Dispose();
                }
            }
            return ds;
        }

        // ADO.NET example: build DataTable manually from SQLiteDataReader (uses IDbCommand, IDataReader, DataTable, DataRow)
        public static DataTable ObtenerDataTableDesdeReader(string consulta, SQLiteParameter[] parametros)
        {
            DataTable tabla = new DataTable();
            SQLiteConnection conexion = null;
            SQLiteCommand cmd = null;
            SQLiteDataReader reader = null;
            try
            {
                conexion = new SQLiteConnection(cadenaConexion);
                conexion.Open();
                cmd = new SQLiteCommand(consulta, conexion);
                if (parametros != null)
                {
                    for (int i = 0; i < parametros.Length; i++)
                    {
                        cmd.Parameters.Add(parametros[i]);
                    }
                }
                reader = cmd.ExecuteReader();

                // crear columnas
                int fieldCount = reader.FieldCount;
                for (int c = 0; c < fieldCount; c++)
                {
                    string name = reader.GetName(c);
                    Type type = reader.GetFieldType(c);
                    DataColumn col = new DataColumn(name, type);
                    tabla.Columns.Add(col);
                }

                // leer filas
                while (reader.Read())
                {
                    DataRow row = tabla.NewRow();
                    for (int c = 0; c < fieldCount; c++)
                    {
                        object val = reader.GetValue(c);
                        if (val == DBNull.Value)
                        {
                            row[c] = DBNull.Value;
                        }
                        else
                        {
                            row[c] = val;
                        }
                    }
                    tabla.Rows.Add(row);
                }
            }
            catch
            {
                // manejar error si es necesario
            }
            finally
            {
                if (reader != null) { reader.Close(); reader.Dispose(); }
                if (cmd != null) cmd.Dispose();
                if (conexion != null) { if (conexion.State == ConnectionState.Open) conexion.Close(); conexion.Dispose(); }
            }

            return tabla;
        }

    }
}
