using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Configuration;
using Prototipo2.Logging;

namespace Prototipo2
{
    public partial class VentanaInicio : Form
    {
        public bool EsAdmin { get; private set; }
        public int UsuarioID { get; private set; }

        int InicioSesionFallida = 0;
        const int MAX_INTENTOS = 3;
        public VentanaInicio()
        {
            InitializeComponent();
        }

        private static string GetConnStr()
        {
            var cs = ConfigurationManager.ConnectionStrings["Prototipo2"]; 
            return cs != null ? cs.ConnectionString : "server=127.0.0.1;port=3307;database=prototipo2_db;uid=appuser;pwd=apppass123;";
        }

        private void VentanaInicio_Load(object sender, EventArgs e)
        {
            // Asegurar que exista un usuario por defecto "Administrador" con clave "Admin1".
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlCommand ins = null;
            try
            {
                string connectionString = GetConnStr();
                conn = new MySqlConnection(connectionString);
                conn.Open();

                cmd = new MySqlCommand("SELECT id, Clave FROM usuarios WHERE Usuario = @u", conn);
                cmd.Parameters.AddWithValue("@u", "Administrador");
                var res = cmd.ExecuteScalar();
                bool needInsert = false;

                using (var chk = new MySqlCommand("SELECT COUNT(1) FROM usuarios WHERE Usuario = @u", conn))
                {
                    chk.Parameters.AddWithValue("@u", "Administrador");
                    object cres = chk.ExecuteScalar();
                    int count = 0;
                    if (!(cres != null && int.TryParse(cres.ToString(), out count) && count > 0))
                    {
                        needInsert = true;
                    }
                }

                if (needInsert)
                {
                    string hashed = PasswordHelper.HashPassword("Admin1");
                    ins = new MySqlCommand("INSERT INTO usuarios (Usuario, Clave, EsAdmin) VALUES (@u, @c, @e)", conn);
                    ins.Parameters.AddWithValue("@u", "Administrador");
                    ins.Parameters.AddWithValue("@c", hashed);
                    ins.Parameters.AddWithValue("@e", true);
                    try
                    {
                        ins.ExecuteNonQuery();
                        SimpleLogger.Info("Usuario Administrador creado por defecto.");
                    }
                    catch (MySqlException)
                    {
                        // Silenciar si la tabla no existe
                    }
                }
            }
            catch (Exception ex)
            {
                SimpleLogger.Error("Error en VentanaInicio_Load: " + ex.Message);
            }
            finally
            {
                if (ins != null) ins.Dispose();
                if (cmd != null) cmd.Dispose();
                if (conn != null)
                {
                    if (conn.State == System.Data.ConnectionState.Open) conn.Close();
                    conn.Dispose();
                }
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            string UsuarioIng = TxtUsuario.Text, ClaveIng = TxtClave.Text;

            string connectionString = GetConnStr();
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;

            try
            {
                connection.Open();

                string query = "SELECT ID, Clave, EsAdmin FROM usuarios WHERE Usuario = @Usuario";
                cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Usuario", UsuarioIng);

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int id = reader.GetInt32("ID");
                    string claveGuardada = reader.GetString("Clave");
                    bool esAdminGuardado = reader.GetBoolean("EsAdmin");

                    // Si la contraseña almacenada está en formato hash salt$hash
                    if (PasswordHelper.VerifyPassword(ClaveIng, claveGuardada))
                    {
                        this.EsAdmin = esAdminGuardado;
                        this.UsuarioID = id;
                        SimpleLogger.Info($"Usuario '{UsuarioIng}' autenticado correctamente (hash). ID={id}.");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        return;
                    }

                    // Si no coincide el hash pero la contraseña almacenada coincide en texto plano, migramos
                    if (string.Equals(claveGuardada, ClaveIng, StringComparison.Ordinal))
                    {
                        // cerrar reader para ejecutar UPDATE
                        reader.Close();
                        reader.Dispose();
                        reader = null;

                        string nuevoHash = PasswordHelper.HashPassword(ClaveIng);
                        using (var upd = new MySqlCommand("UPDATE usuarios SET Clave = @c WHERE ID = @id", connection))
                        {
                            upd.Parameters.AddWithValue("@c", nuevoHash);
                            upd.Parameters.AddWithValue("@id", id);
                            upd.ExecuteNonQuery();
                        }

                        SimpleLogger.Info($"Migrada contraseña a hash para usuario '{UsuarioIng}', ID={id}.");

                        this.EsAdmin = esAdminGuardado;
                        this.UsuarioID = id;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        return;
                    }

                    // no coincide
                    SimpleLogger.Error($"Intento de login fallido para usuario '{UsuarioIng}'. Contraseña inválida.");
                    MessageBox.Show("Contraseña invalida");
                    ManejarIntentoFallido();
                }
                else
                {
                    SimpleLogger.Error($"Intento de login fallido: usuario '{UsuarioIng}' inexistente.");
                    MessageBox.Show("Usuario inexistente");
                    ManejarIntentoFallido();
                }
            }
            catch (MySqlException ex)
            {
                SimpleLogger.Error("No se pudo conectar a la base de datos: " + ex.Message);
                MessageBox.Show("No se pudo conectar a la base de datos: " + ex.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }
                if (cmd != null) cmd.Dispose();
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
                connection.Dispose();
            }

        }

        private void ManejarIntentoFallido()
        {
            InicioSesionFallida++;
            if (InicioSesionFallida >= MAX_INTENTOS)
            {
                SimpleLogger.Error("Se ha alcanzado el límite de intentos de login.");
                MessageBox.Show("Se ha alcanzado el límite de intentos.", "Bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
            }
        }

        private void ChkMostrarContra_CheckedChanged(object sender, EventArgs e)
        {
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
            TxtUsuario.Text = "Administrador";
            TxtClave.Text = "Admin1";
        }
    }
}
