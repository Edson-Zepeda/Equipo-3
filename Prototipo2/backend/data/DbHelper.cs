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
        private static string rutaBD; 

        static AyudanteBD()
        {
            ConnectionStringSettings cfg = ConfigurationManager.ConnectionStrings["Prototipo2"];
            if (cfg != null && !string.IsNullOrEmpty(cfg.ConnectionString))
            {
                cadenaConexion = cfg.ConnectionString;
            }
            else
            {
                rutaBD = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "prototipo2.db");
                cadenaConexion = "Data Source=" + rutaBD + ";Version=3;";

            }
            try
            {
                if (string.IsNullOrEmpty(rutaBD))
                {
                    string[] partes = cadenaConexion.Split(';');
                    foreach (string parte in partes)
                    { 
                        if (parte.TrimStart().StartsWith("Data Source", StringComparison.OrdinalIgnoreCase) || parte.TrimStart().StartsWith("DataSource", StringComparison.OrdinalIgnoreCase))
                        {
                            string[] kv = parte.Split('=');
                            if (kv.Length == 2) rutaBD = kv[1];
                        }
                    }
                }

                if (!File.Exists(rutaBD)) SQLiteConnection.CreateFile(rutaBD);

                using (SQLiteConnection cnInit = new SQLiteConnection(cadenaConexion))
                {
                    cnInit.Open();
                    string rutaEsquema = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sql", "schema_sqlite.sql");
                    if (File.Exists(rutaEsquema))
                    {
                        string sqlScript = File.ReadAllText(rutaEsquema);
                        using (SQLiteCommand cmd = new SQLiteCommand(sqlScript, cnInit))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string sqlFallback = @"PRAGMA foreign_keys = ON;

CREATE TABLE IF NOT EXISTS usuarios (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  Usuario TEXT NOT NULL UNIQUE,
  Clave TEXT NOT NULL,
  EsAdmin INTEGER NOT NULL DEFAULT 0
);

CREATE TABLE IF NOT EXISTS libros (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  nombre TEXT NOT NULL,
  autor TEXT,
  categoria TEXT,
  isbn TEXT UNIQUE,
  precio REAL,
  fecha_publicacion DATETIME,
  stock INTEGER DEFAULT 0
);

CREATE TABLE IF NOT EXISTS ventas (
  id_venta INTEGER PRIMARY KEY AUTOINCREMENT,
  fecha DATETIME NOT NULL,
  id_usuario INTEGER,
  total_venta REAL NOT NULL,
  FOREIGN KEY (id_usuario) REFERENCES usuarios(id)
);

CREATE TABLE IF NOT EXISTS detalle_ventas (
  id_detalle INTEGER PRIMARY KEY AUTOINCREMENT,
  id_venta INTEGER NOT NULL,
  id_libro INTEGER NOT NULL,
  cantidad INTEGER NOT NULL,
  precio_unitario_venta REAL NOT NULL,
  subtotal REAL NOT NULL,
  FOREIGN KEY (id_venta) REFERENCES ventas(id_venta) ON DELETE CASCADE,
  FOREIGN KEY (id_libro) REFERENCES libros(id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS ventas_full (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  venta_id INTEGER NOT NULL,
  fecha DATETIME NOT NULL,
  usuario_id INTEGER,
  libro_id INTEGER,
  nombre_libro TEXT,
  autor_libro TEXT,
  cantidad INTEGER NOT NULL,
  precio_unitario REAL NOT NULL,
  subtotal_linea REAL NOT NULL,
  total_venta REAL NOT NULL,
  FOREIGN KEY (venta_id) REFERENCES ventas(id_venta) ON DELETE CASCADE,
  FOREIGN KEY (usuario_id) REFERENCES usuarios(id),
  FOREIGN KEY (libro_id) REFERENCES libros(id)
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
  FOREIGN KEY (socio_id) REFERENCES usuarios(id),
  FOREIGN KEY (ejemplar_id) REFERENCES ejemplares(id)
);

CREATE TABLE IF NOT EXISTS auditoria (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  usuario_id INTEGER NULL,
  accion TEXT NOT NULL,
  entidad TEXT NOT NULL,
  entidad_id INTEGER NULL,
  fecha DATETIME NOT NULL DEFAULT (CURRENT_TIMESTAMP),
  detalle TEXT,
  FOREIGN KEY (usuario_id) REFERENCES usuarios(id)
);";
                        using (SQLiteCommand cmd = new SQLiteCommand(sqlFallback, cnInit))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch {  }
        }

        public static string CadenaConexion
        {
            get { return cadenaConexion; }
        }

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
                try { tx?.Rollback(); } catch { }
            }
            finally
            {
                tx?.Dispose();
                if (cn != null)
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                    cn.Dispose();
                }
            }
        }

        public static DataSet ObtenerDataSetConAdapter(string consulta, SQLiteParameter[] parametros)
        {
            DataSet ds = new DataSet();
            SQLiteConnection cn = null;
            SQLiteDataAdapter da = null;
            try
            {
                cn = new SQLiteConnection(cadenaConexion);
                cn.Open();
                da = new SQLiteDataAdapter(consulta, cn);
                if (parametros != null)
                {
                    for (int i = 0; i < parametros.Length; i++)
                    {
                        da.SelectCommand.Parameters.Add(parametros[i]);
                    }
                }
                da.Fill(ds);
            }
            catch { }
            finally
            {
                da?.Dispose();
                if (cn != null)
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                    cn.Dispose();
                }
            }
            return ds;
        }

        public static DataTable ObtenerDataTableDesdeReader(string consulta, SQLiteParameter[] parametros)
        {
            DataTable dt = new DataTable();
            SQLiteConnection cn = null;
            SQLiteCommand cmd = null;
            SQLiteDataReader rdr = null;
            try
            {
                cn = new SQLiteConnection(cadenaConexion);
                cn.Open();
                cmd = new SQLiteCommand(consulta, cn);
                if (parametros != null)
                {
                    for (int i = 0; i < parametros.Length; i++)
                    {
                        cmd.Parameters.Add(parametros[i]);
                    }
                }
                rdr = cmd.ExecuteReader();

                int campos = rdr.FieldCount;
                for (int c = 0; c < campos; c++)
                {
                    string colNombre = rdr.GetName(c);
                    Type colTipo = rdr.GetFieldType(c);
                    dt.Columns.Add(new DataColumn(colNombre, colTipo));
                }

                while (rdr.Read())
                {
                    DataRow row = dt.NewRow();
                    for (int c = 0; c < campos; c++)
                    {
                        object val = rdr.GetValue(c);
                        row[c] = val == DBNull.Value ? DBNull.Value : val;
                    }
                    dt.Rows.Add(row);
                }
            }
            catch { }
            finally
            {
                rdr?.Close(); rdr?.Dispose();
                cmd?.Dispose();
                if (cn != null)
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                    cn.Dispose();
                }
            }
            return dt;
        }
    }
}
