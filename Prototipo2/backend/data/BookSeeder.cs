using System;
using System.Data.SQLite;

namespace Prototipo2.Data
{
    public static class BookSeeder
    {
        public static void Seed(SQLiteConnection cn)
        {
            try
            {
                using (var cmdCount = new SQLiteCommand("SELECT COUNT(1) FROM libros", cn))
                {
                    long count = 0;
                    object o = cmdCount.ExecuteScalar();
                    if (o != null && long.TryParse(o.ToString(), out count) && count >= 50) return; 
                }

                string insertSql = "INSERT INTO libros (nombre, autor, categoria, isbn, precio, fecha_publicacion, stock) VALUES (@nombre,@autor,@cat,@isbn,@precio,@fecha,@stock)";
                using (var cmd = new SQLiteCommand(insertSql, cn))
                {

                    using (var tx = cn.BeginTransaction())
                    {
                        Random rnd = new Random();
                        string[] categorias = {"Tecnología","Novela","Historia","Ciencia","Arte"};
                        for (int i = 1; i <= 50; i++)
                        {
                            cmd.Parameters.Clear();
                            string nombre = "Libro " + i;
                            string autor = "Autor " + i;
                            string cat = categorias[i % categorias.Length];
                            string isbn = "ISBN" + i.ToString("00000");
                            decimal precio = Math.Round((decimal)(rnd.NextDouble() * 450 + 50), 2);
                            DateTime fecha = DateTime.Now.AddDays(-rnd.Next(0, 365));
                            int stock = rnd.Next(5, 100);

                            cmd.Parameters.AddWithValue("@nombre", nombre);
                            cmd.Parameters.AddWithValue("@autor", autor);
                            cmd.Parameters.AddWithValue("@cat", cat);
                            cmd.Parameters.AddWithValue("@isbn", isbn);
                            cmd.Parameters.AddWithValue("@precio", precio);
                            cmd.Parameters.AddWithValue("@fecha", fecha);
                            cmd.Parameters.AddWithValue("@stock", stock);
                            cmd.ExecuteNonQuery();
                        }
                        tx.Commit();
                    }
                }
            }
            catch { }
        }
    }
}
