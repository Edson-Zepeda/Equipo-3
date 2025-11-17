using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Configuration;
using Prototipo2.Logging;
using Prototipo2.Data;

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
            return cs != null ? cs.ConnectionString : SqliteHelper.ConnectionString;
        }

        private void VentanaInicio_Load(object sender, EventArgs e)
        {
            SQLiteConnection conn = null;
            SQLiteCommand cmd = null;
            try
            {
                string connectionString = GetConnStr();
                conn = new SQLiteConnection(connectionString);
                conn.Open();

                cmd = new SQLiteCommand("SELECT COUNT(1) FROM usuarios WHERE Usuario = @u", conn);
                cmd.Parameters.AddWithValue("@u", "Administrador");
                object cres = cmd.ExecuteScalar();
                int count = 0;
                bool needInsert = !(cres != null && int.TryParse(cres.ToString(), out count) && count > 0);

                if (needInsert)
                {
                    string hashed = PasswordHelper.HashPassword("Admin1");
                    using (var ins = new SQLiteCommand("INSERT INTO usuarios (Usuario, Clave, EsAdmin) VALUES (@u, @c, @e)", conn))
                    {
                        ins.Parameters.AddWithValue("@u", "Administrador");
                        ins.Parameters.AddWithValue("@c", hashed);
                        ins.Parameters.AddWithValue("@e", 1);
                        try
                        {
                            ins.ExecuteNonQuery();
                            SimpleLogger.Info("Usuario Administrador creado por defecto.");
                        }
                        catch (SQLiteException)
                        {
                            // Silenciar si la tabla no existe
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SimpleLogger.Error("Error en VentanaInicio_Load: " + ex.Message);
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                if (conn != null)
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                    conn.Dispose();
                }
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            string UsuarioIng = TxtUsuario.Text, ClaveIng = TxtClave.Text;

            string connectionString = GetConnStr();
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            SQLiteCommand cmd = null;
            SQLiteDataReader reader = null;

            try
            {
                connection.Open();

                string query = "SELECT ID, Clave, EsAdmin FROM usuarios WHERE Usuario = @Usuario";
                cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.AddWithValue("@Usuario", UsuarioIng);

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    string claveGuardada = reader["Clave"].ToString();
                    bool esAdminGuardado = Convert.ToInt32(reader["EsAdmin"]) != 0;

                    if (PasswordHelper.VerifyPassword(ClaveIng, claveGuardada))
                    {
                        this.EsAdmin = esAdminGuardado;
                        this.UsuarioID = id;
                        SimpleLogger.Info($"Usuario '{UsuarioIng}' autenticado correctamente (hash). ID={id}.");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        return;
                    }

                    if (string.Equals(claveGuardada, ClaveIng, StringComparison.Ordinal))
                    {
                        reader.Close();
                        reader.Dispose();
                        reader = null;

                        string nuevoHash = PasswordHelper.HashPassword(ClaveIng);
                        using (var upd = new SQLiteCommand("UPDATE usuarios SET Clave = @c WHERE ID = @id", connection))
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
            catch (SQLiteException ex)
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
                if (connection.State == ConnectionState.Open)
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
