using System;
using System.Collections;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using MySql.Data.MySqlClient;

namespace Prototipo2
{
    public static class BookSeeder
    {
        // Ajusta conexión si cambias credenciales/puerto
        private static string ConnStr = "server=127.0.0.1;port=3307;database=prototipo2_db;uid=appuser;pwd=apppass123;SslMode=none;";

        // query ejemplo: "subject:programming" o "inauthor:Orwell" o "intitle:Harry Potter"
        public static void SeedFromGoogleBooks(string query, int maxResults = 40)
        {
            try
            {
                string url = $"https://www.googleapis.com/books/v1/volumes?q={Uri.EscapeDataString(query)}&maxResults={maxResults}";
                using (var wc = new WebClient { Encoding = Encoding.UTF8 })
                {
                    string json = wc.DownloadString(url);
                    var jss = new JavaScriptSerializer();
                    var root = jss.DeserializeObject(json) as IDictionary<string, object>;

                    if (root == null || !root.ContainsKey("items"))
                    {
                        System.Windows.Forms.MessageBox.Show("No se encontraron items en la respuesta.");
                        return;
                    }

                    var items = root["items"] as object[];
                    int inserted = 0;

                    using (var conn = new MySqlConnection(ConnStr))
                    {
                        conn.Open();

                        foreach (var o in items)
                        {
                            var item = o as IDictionary<string, object>;
                            if (item == null || !item.ContainsKey("volumeInfo")) continue;

                            var info = item["volumeInfo"] as IDictionary<string, object>;

                            string titulo = info.ContainsKey("title") ? info["title"]?.ToString() ?? "" : "";
                            string autores = "";
                            if (info.ContainsKey("authors"))
                            {
                                var a = info["authors"] as object[];
                                autores = string.Join(", ", a.Select(x => x.ToString()));
                            }
                            string categoria = "";
                            if (info.ContainsKey("categories"))
                            {
                                var c = info["categories"] as object[];
                                categoria = c.Length > 0 ? c[0].ToString() : "";
                            }

                            string isbn = null;
                            if (info.ContainsKey("industryIdentifiers"))
                            {
                                var ids = info["industryIdentifiers"] as object[];
                                foreach (var idObj in ids)
                                {
                                    var idDic = idObj as IDictionary<string, object>;
                                    string type = idDic["type"]?.ToString() ?? "";
                                    string idVal = idDic["identifier"]?.ToString() ?? "";
                                    if (type.IndexOf("ISBN", StringComparison.OrdinalIgnoreCase) >= 0)
                                    {
                                        isbn = idVal;
                                        break;
                                    }
                                }
                            }
                            if (string.IsNullOrWhiteSpace(isbn))
                            {
                                // si no tiene ISBN, construir uno pseudo para evitar nulls
                                isbn = "NOISBN-" + Guid.NewGuid().ToString().Substring(0, 8);
                            }

                            // stock simple: aleatorio 1-5
                            int stock = new Random().Next(1, 6);

                            // Evitar insertar duplicados por ISBN
                            string checkQ = "SELECT COUNT(1) FROM libros WHERE ISBN = @isbn";
                            using (var chk = new MySqlCommand(checkQ, conn))
                            {
                                chk.Parameters.AddWithValue("@isbn", isbn);
                                var exists = Convert.ToInt32(chk.ExecuteScalar());
                                if (exists > 0) continue;
                            }

                            string insQ = "INSERT INTO libros (Titulo, Autor, Categoria, ISBN, Stock) VALUES (@t, @a, @c, @i, @s)";
                            using (var cmd = new MySqlCommand(insQ, conn))
                            {
                                cmd.Parameters.AddWithValue("@t", titulo);
                                cmd.Parameters.AddWithValue("@a", autores);
                                cmd.Parameters.AddWithValue("@c", categoria);
                                cmd.Parameters.AddWithValue("@i", isbn);
                                cmd.Parameters.AddWithValue("@s", stock);
                                cmd.ExecuteNonQuery();
                                inserted++;
                            }
                        } // foreach
                        conn.Close();
                    } // using conn

                    System.Windows.Forms.MessageBox.Show($"Proceso completado. Libros insertados: {inserted}");
                }
            }
            catch (WebException wex)
            {
                System.Windows.Forms.MessageBox.Show("Error al conectar a Google Books: " + wex.Message);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error en BookSeeder: " + ex.Message);
            }
        }
    }
}