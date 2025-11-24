using System;
using System.Windows.Forms;
using System.Data.SQLite;
using Prototipo2.Data;

namespace Prototipo2
{
    // Programa principal de Windows Forms.
    // - Prepara el entorno visual.
    // - Abre/crea la base de datos (SQLite) y siembra datos iniciales.
    // - Muestra la ventana de inicio de sesión y, si todo va bien,
    //   abre el menú principal pasando el rol y el id del usuario logueado.
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Nota para principiantes: este bloque valida que la BD exista y tenga datos mínimos.
            // Si algo falla, solo lo ignoramos (estilo principiante) para que la app no se caiga.
            SQLiteConnection cn = null;

            try
            {
                cn = new SQLiteConnection(AyudanteBD.CadenaConexion);
                cn.Open();
                BookSeeder.Seed(cn); // Inserta libros de ejemplo si faltan.
            }
            catch
            {
                // error al inicializar bd (lo dejamos pasar)
            }
            finally
            {
                if (cn != null)
                {
                    if (cn.State == System.Data.ConnectionState.Open)
                    {
                        cn.Close();
                    }

                    cn.Dispose();
                }
            }

            // Mostramos el login. Si devuelve OK, entonces el usuario se autenticó.
            var loginForm = new VentanaInicio();

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Es común pasar datos del usuario a la pantalla principal.
                bool esAdmin = loginForm.EsAdmin;
                int usuarioID = loginForm.UsuarioID;

                Application.Run(new VentanaMenu(esAdmin, usuarioID));
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
