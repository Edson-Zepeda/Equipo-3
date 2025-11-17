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
using System.Globalization;
using System.Configuration;
using Prototipo2.Logging;
using Prototipo2.Data;

namespace Prototipo2
{
    public partial class VentanaUsuarios : Form
    {
        private int idModificar;
        private ProgressBar _progress;

        private static string GetConnStr()
        {
            var cs = ConfigurationManager.ConnectionStrings["Prototipo2"];
            return cs != null ? cs.ConnectionString : SqliteHelper.ConnectionString;
        }

        private class UsuarioRow
        {
            public int Id;
            public string Usuario;
            public bool EsAdmin;
        }

        public VentanaUsuarios()
        {
            InitializeComponent();
        }

        private async void VentanaUsuarios_Load(object sender, EventArgs e)
        {
            LvRegistros.View = View.Details;
            LvRegistros.FullRowSelect = true;
            LvRegistros.GridLines = true;

            LvRegistros.Columns.Add("ID", 60);
            LvRegistros.Columns.Add("Usuario", 200);
            LvRegistros.Columns.Add("Es Admin", 100);

            _progress = new ProgressBar();
            _progress.Style = ProgressBarStyle.Marquee;
            _progress.MarqueeAnimationSpeed = 30;
            _progress.Visible = false;
            _progress.Height = 12;
            _progress.Dock = DockStyle.Bottom;
            Controls.Add(_progress);

            await CargarUsuariosAsync();
            ConfigurarEstado("inicio");
        }

        private void ShowProgress(bool show)
        {
            if (_progress != null)
                _progress.Visible = show;
            UseWaitCursor = show;
            Cursor.Current = show ? Cursors.WaitCursor : Cursors.Default;
            foreach (Control c in Controls) c.Enabled = !show || c == _progress;
        }

        private List<UsuarioRow> ConsultarUsuariosInterno(string termino, bool exacta)
        {
            string connectionString = GetConnStr();
            string query = "";
            string selectBase = "SELECT id, Usuario, EsAdmin FROM usuarios ";

            if (string.IsNullOrEmpty(termino))
            {
                query = selectBase;
            }
            else
            {
                if (exacta)
                {
                    query = selectBase + "WHERE Usuario = @termino";
                }
                else
                {
                    query = selectBase + "WHERE Usuario LIKE @termino";
                    termino = "%" + termino + "%";
                }
            }

            SQLiteConnection connection = null;
            SQLiteCommand cmd = null;
            SQLiteDataReader reader = null;
            var lista = new List<UsuarioRow>();

            try
            {
                connection = new SQLiteConnection(connectionString);
                connection.Open();
                cmd = new SQLiteCommand(query, connection);
                if (!string.IsNullOrEmpty(termino))
                {
                    cmd.Parameters.AddWithValue("@termino", termino);
                }

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var row = new UsuarioRow();
                    row.Id = Convert.ToInt32(reader["id"]);
                    row.Usuario = reader["Usuario"].ToString();
                    row.EsAdmin = Convert.ToInt32(reader["EsAdmin"]) != 0;

                    lista.Add(row);
                }
            }
            finally
            {
                if (reader != null) { reader.Close(); reader.Dispose(); }
                if (cmd != null) cmd.Dispose();
                if (connection != null) { if (connection.State == ConnectionState.Open) connection.Close(); connection.Dispose(); }
            }

            return lista;
        }

        private async Task CargarUsuariosAsync(string termino = null)
        {
            bool exacta = RdbExacta != null && RdbExacta.Checked;
            ShowProgress(true);
            try
            {
                var datos = await Task.Run(() => ConsultarUsuariosInterno(termino, exacta));
                LvRegistros.Items.Clear();
                int totalRegistros = 0;
                foreach (var r in datos)
                {
                    ListViewItem item = new ListViewItem(r.Id.ToString());
                    item.SubItems.Add(r.Usuario);
                    item.SubItems.Add(r.EsAdmin ? "Sí" : "No");
                    item.Tag = r.Id;
                    LvRegistros.Items.Add(item);
                    totalRegistros++;
                }
                LblCuenta.Text = "TOTAL DE REGISTROS: " + totalRegistros;
            }
            catch (Exception ex)
            {
                SimpleLogger.Error("Error al cargar usuarios: " + ex.Message);
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }
            finally
            {
                ShowProgress(false);
            }
        }

        private async void BtnBuscar_Click(object sender, EventArgs e)
        {
            await CargarUsuariosAsync(TxtBuscar.Text.Trim());
            ConfigurarEstado("inicio");
        }

        private void LvRegistros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LvRegistros.SelectedItems.Count > 0)
            {
                ListViewItem item = LvRegistros.SelectedItems[0];
                this.idModificar = (int)item.Tag;

                CargarDatosDeUsuario(this.idModificar);

                ConfigurarEstado("seleccionado");
            }
        }

        private async void BtnGrabar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtUsuario.Text) || string.IsNullOrEmpty(TxtClave.Text))
            {
                MessageBox.Show("Para un usuario nuevo, Usuario y Clave son obligatorios.");
                return;
            }

            string claveParaGuardar = PasswordHelper.HashPassword(TxtClave.Text);

            string connectionString = GetConnStr();
            SQLiteConnection connection = null;
            SQLiteCommand cmd = null;

            try
            {
                ShowProgress(true);
                await Task.Run(() =>
                {
                    connection = new SQLiteConnection(connectionString);
                    connection.Open();
                    string query = "INSERT INTO usuarios (Usuario, Clave, EsAdmin) VALUES (@usuario, @clave, @esAdmin)";
                    cmd = new SQLiteCommand(query, connection);
                    cmd.Parameters.AddWithValue("@usuario", TxtUsuario.Text.Trim());
                    cmd.Parameters.AddWithValue("@clave", claveParaGuardar);
                    cmd.Parameters.AddWithValue("@esAdmin", ChkAdmin.Checked ? 1 : 0);
                    cmd.ExecuteNonQuery();
                });
                SimpleLogger.Info($"Usuario creado: {TxtUsuario.Text.Trim()}");
                MessageBox.Show("Usuario creado con éxito.");
                await CargarUsuariosAsync();
                ConfigurarEstado("inicio");
            }
            catch (Exception ex)
            {
                SimpleLogger.Error("Error al grabar usuario: " + ex.Message);
                MessageBox.Show("Error al grabar: " + ex.Message);
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                if (connection != null)
                {
                    if (connection.State == ConnectionState.Open) connection.Close();
                    connection.Dispose();
                }
                ShowProgress(false);
            }
        }

        private async void BtnModificar_Click(object sender, EventArgs e)
        {
            if (this.idModificar == 0) return;

            if (string.IsNullOrEmpty(TxtUsuario.Text))
            {
                MessageBox.Show("Usuario es obligatorio.");
                return;
            }

            string connectionString = GetConnStr();
            SQLiteConnection connection = null;
            SQLiteCommand cmd = null;

            try
            {
                ShowProgress(true);
                await Task.Run(() =>
                {
                    connection = new SQLiteConnection(connectionString);
                    connection.Open();

                    string query = "";
                    cmd = new SQLiteCommand();
                    cmd.Connection = connection;

                    if (!string.IsNullOrEmpty(TxtClave.Text))
                    {
                        string claveParaActualizar = PasswordHelper.HashPassword(TxtClave.Text);
                        query = "UPDATE usuarios SET Usuario = @usuario, Clave = @clave, EsAdmin = @esAdmin WHERE id = @id";
                        cmd.Parameters.AddWithValue("@clave", claveParaActualizar);
                    }
                    else
                    {
                        query = "UPDATE usuarios SET Usuario = @usuario, EsAdmin = @esAdmin WHERE id = @id";
                    }

                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@usuario", TxtUsuario.Text.Trim());
                    cmd.Parameters.AddWithValue("@esAdmin", ChkAdmin.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@id", this.idModificar);

                    cmd.ExecuteNonQuery();
                });

                SimpleLogger.Info($"Usuario actualizado: ID={this.idModificar} ({TxtUsuario.Text.Trim()})");
                MessageBox.Show("Usuario actualizado con éxito.");
                await CargarUsuariosAsync();
                ConfigurarEstado("inicio");
            }
            catch (Exception ex)
            {
                SimpleLogger.Error("Error al modificar usuario: " + ex.Message);
                MessageBox.Show("Error al modificar: " + ex.Message);
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                if (connection != null)
                {
                    if (connection.State == ConnectionState.Open) connection.Close();
                    connection.Dispose();
                }
                ShowProgress(false);
            }
        }

        private async void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (this.idModificar == 0) return;

            DialogResult res = MessageBox.Show("¿Está seguro de que desea eliminar a este usuario?","Confirmar Eliminación",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (res == DialogResult.No) return;

            string connectionString = GetConnStr();
            SQLiteConnection connection = null;
            SQLiteCommand cmd = null;

            try
            {
                ShowProgress(true);
                await Task.Run(() =>
                {
                    connection = new SQLiteConnection(connectionString);
                    connection.Open();
                    string query = "DELETE FROM usuarios WHERE id = @id";
                    cmd = new SQLiteCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id", this.idModificar);
                    cmd.ExecuteNonQuery();
                });

                SimpleLogger.Info($"Usuario eliminado: ID={this.idModificar}");
                MessageBox.Show("Usuario eliminado.");
                await CargarUsuariosAsync();
                ConfigurarEstado("inicio");
            }
            catch (Exception ex)
            {
                SimpleLogger.Error("Error al eliminar usuario: " + ex.Message);
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                if (connection != null)
                {
                    if (connection.State == ConnectionState.Open) connection.Close();
                    connection.Dispose();
                }
                ShowProgress(false);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            ConfigurarEstado("inicio");
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfigurarEstado(string modo)
        {
            if (modo == "inicio")
            {
                LimpiarCampos();
                LvRegistros.Enabled = true;
                BtnBuscar.Enabled = true;

                BtnGrabar.Enabled = true;
                BtnModificar.Enabled = false;
                BtnEliminar.Enabled = false;
            }
            else if (modo == "seleccionado")
            {
                LvRegistros.Enabled = true;
                BtnBuscar.Enabled = true;

                BtnGrabar.Enabled = false;
                BtnModificar.Enabled = true;
                BtnEliminar.Enabled = true;
            }
        }

        private void LimpiarCampos()
        {
            this.idModificar = 0;
            TxtUsuario.Text = "";
            TxtClave.Text = "";
            ChkAdmin.Checked = false;
            LvRegistros.SelectedItems.Clear();
        }

        private void CargarDatosDeUsuario(int idUsuario)
        {
            string connectionString = GetConnStr();
            SQLiteConnection connection = null;
            SQLiteCommand cmd = null;
            SQLiteDataReader reader = null;

            try
            {
                connection = new SQLiteConnection(connectionString);
                connection.Open();
                string query = "SELECT Usuario, EsAdmin FROM usuarios WHERE id = @id";
                cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", idUsuario);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    TxtUsuario.Text = reader["Usuario"].ToString();
                    ChkAdmin.Checked = reader.GetBoolean("EsAdmin");
                    TxtClave.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }
                if (cmd != null) cmd.Dispose();
                if (connection != null)
                {
                    if (connection.State == ConnectionState.Open) connection.Close();
                    connection.Dispose();
                }
            }
        }



    }
}
