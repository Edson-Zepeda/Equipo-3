using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Configuration;

namespace Prototipo2
{
    // Catálogo simple de usuarios.
    // - Lista, crea, modifica (con o sin cambio de clave) y elimina usuarios.
    // - Las contraseñas se guardan con hash usando PasswordHelper.
    public partial class VentanaUsuarios : Form
    {
        private int idModificar; // id de usuario seleccionado
        // Constructor sin parámetros para diseñador
        public VentanaUsuarios() : this(false) { }
        public VentanaUsuarios(bool dummy)
        {
            InitializeComponent();
        }
        private string ObtenerCadena() { var cs = ConfigurationManager.ConnectionStrings["Prototipo2"]; if (cs != null) { return cs.ConnectionString; } else { return "Data Source=prototipo2.db;Version=3;"; } }
        private void VentanaUsuarios_Load(object sender, EventArgs e)
        {
            // Configurar listado
            LvRegistros.View = View.Details; LvRegistros.FullRowSelect = true; LvRegistros.GridLines = true; LvRegistros.Columns.Add("ID", 60); LvRegistros.Columns.Add("Usuario", 200); LvRegistros.Columns.Add("Es Admin", 100); CargarUsuarios(null); ConfigurarEstado("inicio");
        }
        private void CargarUsuarios(string termino)
        {
            // Consultar usuarios (filtro exacto o LIKE)
            LvRegistros.Items.Clear(); string selectBase = "SELECT id, Usuario, EsAdmin FROM usuarios "; string query = selectBase; string terminoParam = termino; bool hayTermino = false; if (!string.IsNullOrEmpty(termino)) { hayTermino = true; if (RdbExacta.Checked) { query = selectBase + "WHERE Usuario = @termino"; } else { query = selectBase + "WHERE Usuario LIKE @termino"; terminoParam = "%" + termino + "%"; } }
            SQLiteConnection connection = null; SQLiteCommand cmd = null; SQLiteDataReader reader = null; int totalRegistros = 0; try { connection = new SQLiteConnection(ObtenerCadena()); connection.Open(); cmd = new SQLiteCommand(query, connection); if (hayTermino) { cmd.Parameters.AddWithValue("@termino", terminoParam); } reader = cmd.ExecuteReader(); while (reader.Read()) { int id = 0; try { id = Convert.ToInt32(reader["id"]); } catch { } string usuario = ""; try { usuario = reader["Usuario"].ToString(); } catch { } int esAdminInt = 0; try { esAdminInt = Convert.ToInt32(reader["EsAdmin"]); } catch { } string esAdminTexto = esAdminInt != 0 ? "Sí" : "No"; var item = new ListViewItem(id.ToString()); item.SubItems.Add(usuario); item.SubItems.Add(esAdminTexto); item.Tag = id; LvRegistros.Items.Add(item); totalRegistros++; } LblCuenta.Text = "TOTAL DE REGISTROS: " + totalRegistros; } catch (Exception ex) { MessageBox.Show("Error al cargar usuarios: " + ex.Message); } finally { if (reader != null) { reader.Close(); reader.Dispose(); } if (cmd != null) cmd.Dispose(); if (connection != null) { if (connection.State == System.Data.ConnectionState.Open) connection.Close(); connection.Dispose(); } }
        }
        private void BtnBuscar_Click(object sender, EventArgs e) { CargarUsuarios(TxtBuscar.Text.Trim()); ConfigurarEstado("inicio"); }
        private void LvRegistros_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Al seleccionar, cargamos detalles y habilitamos Modificar/Eliminar
            if (LvRegistros.SelectedItems.Count > 0) { var item = LvRegistros.SelectedItems[0]; idModificar = 0; try { idModificar = (int)item.Tag; } catch { } CargarDatosDeUsuario(idModificar); ConfigurarEstado("seleccionado"); }
        }
        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            // Crear usuario con clave hasheada (nunca texto plano)
            if (string.IsNullOrEmpty(TxtUsuario.Text) || string.IsNullOrEmpty(TxtClave.Text)) { MessageBox.Show("Para un usuario nuevo, Usuario y Clave son obligatorios."); return; }
            string claveParaGuardar = PasswordHelper.HashPassword(TxtClave.Text); SQLiteConnection connection = null; SQLiteCommand cmd = null; try { connection = new SQLiteConnection(ObtenerCadena()); connection.Open(); cmd = new SQLiteCommand("INSERT INTO usuarios (Usuario, Clave, EsAdmin) VALUES (@usuario, @clave, @esAdmin)", connection); cmd.Parameters.AddWithValue("@usuario", TxtUsuario.Text.Trim()); cmd.Parameters.AddWithValue("@clave", claveParaGuardar); int esAdminInt = ChkAdmin.Checked ? 1 : 0; cmd.Parameters.AddWithValue("@esAdmin", esAdminInt); cmd.ExecuteNonQuery(); MessageBox.Show("Usuario creado con éxito."); CargarUsuarios(null); ConfigurarEstado("inicio"); } catch (Exception ex) { MessageBox.Show("Error al grabar: " + ex.Message); } finally { if (cmd != null) cmd.Dispose(); if (connection != null) { if (connection.State == System.Data.ConnectionState.Open) connection.Close(); connection.Dispose(); } }
        }
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            // Editar usuario; si no cambia la clave, no la tocamos
            if (idModificar == 0) return; if (string.IsNullOrEmpty(TxtUsuario.Text)) { MessageBox.Show("Usuario es obligatorio."); return; }
            SQLiteConnection connection = null; SQLiteCommand cmd = null; try { connection = new SQLiteConnection(ObtenerCadena()); connection.Open(); string query = ""; cmd = new SQLiteCommand(); cmd.Connection = connection; if (!string.IsNullOrEmpty(TxtClave.Text)) { string claveParaActualizar = PasswordHelper.HashPassword(TxtClave.Text); query = "UPDATE usuarios SET Usuario = @usuario, Clave = @clave, EsAdmin = @esAdmin WHERE id = @id"; cmd.Parameters.AddWithValue("@clave", claveParaActualizar); } else { query = "UPDATE usuarios SET Usuario = @usuario, EsAdmin = @esAdmin WHERE id = @id"; } cmd.CommandText = query; cmd.Parameters.AddWithValue("@usuario", TxtUsuario.Text.Trim()); int esAdminInt = ChkAdmin.Checked ? 1 : 0; cmd.Parameters.AddWithValue("@esAdmin", esAdminInt); cmd.Parameters.AddWithValue("@id", idModificar); cmd.ExecuteNonQuery(); MessageBox.Show("Usuario actualizado con éxito."); CargarUsuarios(null); ConfigurarEstado("inicio"); } catch (Exception ex) { MessageBox.Show("Error al modificar: " + ex.Message); } finally { if (cmd != null) cmd.Dispose(); if (connection != null) { if (connection.State == System.Data.ConnectionState.Open) connection.Close(); connection.Dispose(); } }
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Eliminar usuario seleccionado
            if (idModificar == 0) return; if (MessageBox.Show("¿Eliminar este usuario?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return; SQLiteConnection connection = null; SQLiteCommand cmd = null; try { connection = new SQLiteConnection(ObtenerCadena()); connection.Open(); cmd = new SQLiteCommand("DELETE FROM usuarios WHERE id = @id", connection); cmd.Parameters.AddWithValue("@id", idModificar); cmd.ExecuteNonQuery(); MessageBox.Show("Usuario eliminado."); CargarUsuarios(null); ConfigurarEstado("inicio"); } catch (Exception ex) { MessageBox.Show("Error al eliminar: " + ex.Message); } finally { if (cmd != null) cmd.Dispose(); if (connection != null) { if (connection.State == System.Data.ConnectionState.Open) connection.Close(); connection.Dispose(); } }
        }
        private void BtnCancelar_Click(object sender, EventArgs e) { ConfigurarEstado("inicio"); }
        private void BtnSalir_Click(object sender, EventArgs e) { this.Close(); }
        private void ConfigurarEstado(string modo)
        {
            // Pequeña máquina de estados para habilitar botones correctos
            if (modo == "inicio") { LimpiarCampos(); LvRegistros.Enabled = true; BtnBuscar.Enabled = true; BtnGrabar.Enabled = true; BtnModificar.Enabled = false; BtnEliminar.Enabled = false; }
            else if (modo == "seleccionado") { LvRegistros.Enabled = true; BtnBuscar.Enabled = true; BtnGrabar.Enabled = false; BtnModificar.Enabled = true; BtnEliminar.Enabled = true; }
        }
        private void LimpiarCampos() { idModificar = 0; TxtUsuario.Text = ""; TxtClave.Text = ""; ChkAdmin.Checked = false; LvRegistros.SelectedItems.Clear(); }
        private void CargarDatosDeUsuario(int idUsuario)
        {
            // Lee datos del usuario para llenar el formulario
            SQLiteConnection connection = null; SQLiteCommand cmd = null; SQLiteDataReader reader = null; try { connection = new SQLiteConnection(ObtenerCadena()); connection.Open(); cmd = new SQLiteCommand("SELECT Usuario, EsAdmin FROM usuarios WHERE id = @id", connection); cmd.Parameters.AddWithValue("@id", idUsuario); reader = cmd.ExecuteReader(); if (reader.Read()) { string usuario = ""; try { usuario = reader["Usuario"].ToString(); } catch { } TxtUsuario.Text = usuario; int esAdminInt = 0; try { esAdminInt = Convert.ToInt32(reader["EsAdmin"]); } catch { } ChkAdmin.Checked = esAdminInt != 0; TxtClave.Text = ""; } } catch (Exception ex) { MessageBox.Show("Error al cargar datos: " + ex.Message); } finally { if (reader != null) { reader.Close(); reader.Dispose(); } if (cmd != null) cmd.Dispose(); if (connection != null) { if (connection.State == System.Data.ConnectionState.Open) connection.Close(); connection.Dispose(); } }
        }
        // Stubs para eventos de header
        private void BtnMenu_Click(object sender, EventArgs e) { try { Close(); } catch { } }
        private void BtnCerrar_Click(object sender, EventArgs e) { try { Close(); } catch { } }
        private void BtnMinimizar_Click(object sender, EventArgs e) { try { WindowState = FormWindowState.Minimized; } catch { } }
    }
}
