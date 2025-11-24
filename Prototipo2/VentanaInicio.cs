using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;
using Prototipo2.Data;

namespace Prototipo2
{
    // Ventana de inicio de sesión.
    // - Verifica/crea el usuario "Administrador" al cargar.
    // - Valida usuario/clave usando hash (PasswordHelper).
    // - Si la clave antiguamente estaba en texto plano, la migra a hash al primer login.
    public partial class VentanaInicio : Form
    {
        public bool EsAdmin { get; private set; }
        public int UsuarioID { get; private set; }

        int InicioSesionFallida = 0; // para bloquear tras varios intentos fallidos
        const int MAX_INTENTOS = 3;

        public VentanaInicio()
        {
            InitializeComponent();
        }

        private string ObtenerCadena()
        {
            // Cadena desde AyudanteBD (lee App.config o usa una por defecto)
            return AyudanteBD.CadenaConexion;
        }

        private void VentanaInicio_Load(object sender, EventArgs e)
        {
            // Al abrir, nos aseguramos de que exista el usuario admin con clave hasheada.
            SQLiteConnection conn = null;
            SQLiteCommand cmd = null;
            SQLiteCommand ins = null;

            try
            {
                string connectionString = ObtenerCadena();
                conn = new SQLiteConnection(connectionString);
                conn.Open();

                // ¿Ya existe el usuario Administrador?
                cmd = new SQLiteCommand("SELECT COUNT(1) FROM usuarios WHERE Usuario = @u", conn);
                cmd.Parameters.AddWithValue("@u", "Administrador");
                object cres = cmd.ExecuteScalar();

                int count = 0;
                bool needInsert = true;

                if (cres != null)
                {
                    if (int.TryParse(cres.ToString(), out count))
                    {
                        if (count > 0)
                        {
                            needInsert = false;
                        }
                    }
                }

                // Si no existe, lo creamos con clave por defecto "Admin1" (hash)
                if (needInsert)
                {
                    string hashed = PasswordHelper.HashPassword("Admin1");

                    ins = new SQLiteCommand("INSERT INTO usuarios (Usuario, Clave, EsAdmin) VALUES (@u, @c, @e)", conn);
                    ins.Parameters.AddWithValue("@u", "Administrador");
                    ins.Parameters.AddWithValue("@c", hashed);
                    ins.Parameters.AddWithValue("@e", 1);

                    try
                    {
                        ins.ExecuteNonQuery();
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
            finally
            {
                if (ins != null)
                {
                    ins.Dispose();
                }

                if (cmd != null)
                {
                    cmd.Dispose();
                }

                if (conn != null)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                    conn.Dispose();
                }
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            // Valida credenciales. Nota: se intenta hash y, como compatibilidad, texto plano.
            string UsuarioIng = TxtUsuario.Text;
            string ClaveIng = TxtClave.Text;

            SQLiteConnection connection = null;
            SQLiteCommand cmd = null;
            SQLiteDataReader reader = null;

            try
            {
                connection = new SQLiteConnection(ObtenerCadena());
                connection.Open();

                string query = "SELECT ID, Clave, EsAdmin FROM usuarios WHERE Usuario = @Usuario";
                cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.AddWithValue("@Usuario", UsuarioIng);

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int id = 0;
                    try
                    {
                        id = Convert.ToInt32(reader["ID"]);
                    }
                    catch
                    {
                    }

                    string claveGuardada = "";
                    try
                    {
                        claveGuardada = reader["Clave"].ToString();
                    }
                    catch
                    {
                    }

                    int esAdminInt = 0;
                    try
                    {
                        esAdminInt = Convert.ToInt32(reader["EsAdmin"]);
                    }
                    catch
                    {
                    }

                    bool esAdminGuardado = esAdminInt != 0;

                    // Verificación con hash (lo correcto).
                    bool validaHash = PasswordHelper.VerifyPassword(ClaveIng, claveGuardada);

                    if (validaHash)
                    {
                        EsAdmin = esAdminGuardado;
                        UsuarioID = id;
                        DialogResult = DialogResult.OK;
                        Close();
                        return;
                    }

                    // Compatibilidad: si estaba en texto plano, actualizamos a hash ahora.
                    if (claveGuardada == ClaveIng)
                    {
                        reader.Close();
                        reader.Dispose();
                        reader = null;

                        string nuevoHash = PasswordHelper.HashPassword(ClaveIng);
                        SQLiteCommand upd = new SQLiteCommand("UPDATE usuarios SET Clave = @c WHERE ID = @id", connection);
                        upd.Parameters.AddWithValue("@c", nuevoHash);
                        upd.Parameters.AddWithValue("@id", id);

                        try
                        {
                            upd.ExecuteNonQuery();
                        }
                        catch
                        {
                        }

                        upd.Dispose();

                        EsAdmin = esAdminGuardado;
                        UsuarioID = id;
                        DialogResult = DialogResult.OK;
                        Close();
                        return;
                    }

                    MessageBox.Show("Contraseña invalida");
                    ManejarIntentoFallido();
                }
                else
                {
                    MessageBox.Show("Usuario inexistente");
                    ManejarIntentoFallido();
                }
            }
            catch (SQLiteException ex)
            {
                // Mensaje claro si hay problemas de conexión con SQLite.
                MessageBox.Show("No se pudo conectar a la base de datos: " + ex.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }

                if (cmd != null)
                {
                    cmd.Dispose();
                }

                if (connection != null)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }

                    connection.Dispose();
                }
            }
        }

        private void ManejarIntentoFallido()
        {
            // Bloquea la app al exceder el máximo (comportamiento simple, estilo principiante).
            InicioSesionFallida = InicioSesionFallida + 1;

            if (InicioSesionFallida >= MAX_INTENTOS)
            {
                MessageBox.Show("Se ha alcanzado el límite de intentos.", "Bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
            }
        }

        private void ChkMostrarContra_CheckedChanged(object sender, EventArgs e)
        {
            // Muestra u oculta la contraseña en la caja de texto.
            if (ChkMostrarContra.Checked)
            {
                TxtClave.UseSystemPasswordChar = false;
            }
            else
            {
                TxtClave.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Botón rápido para autocompletar admin por defecto (útil en pruebas).
            TxtUsuario.Text = "Administrador";
            TxtClave.Text = "Admin1";
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
