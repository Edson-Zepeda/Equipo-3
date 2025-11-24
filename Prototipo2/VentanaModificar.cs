using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Configuration;
using System.Globalization;

namespace Prototipo2
{
    // Modificar libros.
    // - Busca por nombre/autor, permite editar campos y guardar cambios.
    // - Usa un ListView para seleccionar el libro a modificar.
    public partial class VentanaModificar : Form
    {
        private int idModificar; // id del libro seleccionado
        // Constructor sin parámetros para el diseñador
        public VentanaModificar() : this(false) { }
        public VentanaModificar(bool dummy)
        {
            InitializeComponent();
        }
        private string ObtenerCadena() { var cs = ConfigurationManager.ConnectionStrings["Prototipo2"]; if (cs != null) return cs.ConnectionString; return "Data Source=prototipo2.db;Version=3;"; }
        private void VentanaModificar_Load(object sender, EventArgs e)
        {
            LvRegistros.View = View.Details; LvRegistros.FullRowSelect = true; LvRegistros.GridLines = true; LvRegistros.Columns.Add("Nombre", 250); LvRegistros.Columns.Add("Autor", 200); LvRegistros.Columns.Add("Precio", 80); LvRegistros.Columns.Add("Fecha Pub.", 100); LvRegistros.Columns.Add("Stock", 60); ConfigurarEstado(false);
        }
        private void ConfigurarEstado(bool editando)
        {
            // Habilita/deshabilita controles según estemos editando o no
            TxtNombre.Enabled = editando; TxtAutor.Enabled = editando; TxtPrecio.Enabled = editando; DtpFecha.Enabled = editando; TxtStock.Enabled = editando; BtnGrabar.Enabled = editando; BtnCancelar.Enabled = editando; TxtBuscar.Enabled = !editando; BtnBuscar.Enabled = !editando; RdbExacta.Enabled = !editando; RdbAproximada.Enabled = !editando; LvRegistros.Enabled = !editando; BtnModificar.Enabled = false;
        }
        private void LimpiarCampos() { TxtNombre.Text = ""; TxtAutor.Text = ""; TxtPrecio.Text = ""; TxtStock.Text = ""; DtpFecha.Value = DateTime.Now; idModificar = 0; }
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            // Mismo patrón de búsqueda que otras pantallas
            string termino = TxtBuscar.Text.Trim(); if (string.IsNullOrEmpty(termino)) return; string selectQuery = "SELECT id, nombre, autor, precio, fecha_publicacion, stock FROM libros "; string query = selectQuery; string parametroValor = termino; if (RdbExacta.Checked) { query = selectQuery + "WHERE nombre = @termino OR autor = @termino"; } else if (RdbAproximada.Checked) { query = selectQuery + "WHERE nombre LIKE @termino OR autor LIKE @termino"; parametroValor = "%" + termino + "%"; } else { return; }
            LvRegistros.Items.Clear(); int totalRegistros = 0; SQLiteConnection connection = null; SQLiteCommand cmd = null; SQLiteDataReader reader = null; try { connection = new SQLiteConnection(ObtenerCadena()); connection.Open(); cmd = new SQLiteCommand(query, connection); cmd.Parameters.AddWithValue("@termino", parametroValor); reader = cmd.ExecuteReader(); while (reader.Read()) { ListViewItem item = new ListViewItem(reader["nombre"].ToString()); item.SubItems.Add(reader["autor"].ToString()); item.SubItems.Add(reader["precio"].ToString()); string fechaStr = ""; object fechaObj = reader["fecha_publicacion"]; if (fechaObj != null && fechaObj != DBNull.Value) { try { fechaStr = Convert.ToDateTime(fechaObj).ToString("yyyy-MM-dd"); } catch { fechaStr = fechaObj.ToString(); } } item.SubItems.Add(fechaStr); item.SubItems.Add(reader["stock"].ToString()); item.Tag = Convert.ToInt32(reader["id"]); LvRegistros.Items.Add(item); totalRegistros++; } LblCuenta.Text = "TOTAL DE REGISTROS: " + totalRegistros; } catch (Exception ex) { MessageBox.Show("Error al consultar: " + ex.Message); } finally { if (reader != null) { reader.Close(); reader.Dispose(); } if (cmd != null) cmd.Dispose(); if (connection != null) { if (connection.State == System.Data.ConnectionState.Open) connection.Close(); connection.Dispose(); } }
        }
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            // Llena los campos de edición desde la fila seleccionada
            if (LvRegistros.SelectedItems.Count == 0) return; var itemSeleccionado = LvRegistros.SelectedItems[0]; idModificar = 0; try { idModificar = (int)itemSeleccionado.Tag; } catch { } TxtNombre.Text = itemSeleccionado.SubItems[0].Text; TxtAutor.Text = itemSeleccionado.SubItems[1].Text; TxtPrecio.Text = itemSeleccionado.SubItems[2].Text; string fechaTexto = itemSeleccionado.SubItems[3].Text; if (!string.IsNullOrEmpty(fechaTexto)) { try { DtpFecha.Value = DateTime.ParseExact(fechaTexto, "yyyy-MM-dd", CultureInfo.InvariantCulture); } catch { } } TxtStock.Text = itemSeleccionado.SubItems[4].Text; ConfigurarEstado(true);
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            // Cancela la edición
            if (MessageBox.Show("¿Cancelar la modificación?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) { LimpiarCampos(); ConfigurarEstado(false); }
        }
        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            // Guarda los cambios del libro
            decimal precio = 0; if (!decimal.TryParse(TxtPrecio.Text.Trim(), out precio)) { MessageBox.Show("Precio inválido"); return; } int stock = 0; if (!int.TryParse(TxtStock.Text.Trim(), out stock)) { MessageBox.Show("Stock inválido"); return; } string nombre = TxtNombre.Text.Trim(); string autor = TxtAutor.Text.Trim(); DateTime fecha = DtpFecha.Value; if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(autor)) { MessageBox.Show("Nombre y Autor no pueden estar vacíos."); return; }
            SQLiteConnection connection = null; SQLiteCommand cmd = null; try { connection = new SQLiteConnection(ObtenerCadena()); connection.Open(); cmd = new SQLiteCommand("UPDATE libros SET nombre = @nombre, autor = @autor, precio = @precio, fecha_publicacion = @fecha, stock = @stock WHERE id = @id", connection); cmd.Parameters.AddWithValue("@nombre", nombre); cmd.Parameters.AddWithValue("@autor", autor); cmd.Parameters.AddWithValue("@precio", precio); cmd.Parameters.AddWithValue("@fecha", fecha); cmd.Parameters.AddWithValue("@stock", stock); cmd.Parameters.AddWithValue("@id", idModificar); int filas = cmd.ExecuteNonQuery(); if (filas > 0) { MessageBox.Show("¡Libro actualizado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information); LimpiarCampos(); ConfigurarEstado(false); } } catch (Exception ex) { MessageBox.Show("Error al grabar: " + ex.Message); } finally { if (cmd != null) cmd.Dispose(); if (connection != null) { if (connection.State == System.Data.ConnectionState.Open) connection.Close(); connection.Dispose(); } }
        }
        private void BtnSalir_Click(object sender, EventArgs e) { this.Close(); }
        private void LvRegistros_SelectedIndexChanged(object sender, EventArgs e) { BtnModificar.Enabled = LvRegistros.SelectedItems.Count > 0; }
        // Stubs
        private void BtnMenu_Click(object sender, EventArgs e) { try { Close(); } catch { } }
        private void BtnCerrar_Click(object sender, EventArgs e) { try { Close(); } catch { } }
        private void BtnMinimizar_Click(object sender, EventArgs e) { try { WindowState = FormWindowState.Minimized; } catch { } }
    }
}
