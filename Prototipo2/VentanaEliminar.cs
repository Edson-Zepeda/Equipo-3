using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Configuration;

namespace Prototipo2
{
    // Eliminar libros.
    // - Permite buscar y seleccionar un libro para borrarlo.
    // - Pregunta confirmación antes de eliminar de la BD.
    public partial class VentanaEliminar : Form
    {
        public VentanaEliminar() { InitializeComponent(); }
        private string ObtenerCadena() { var cs = ConfigurationManager.ConnectionStrings["Prototipo2"]; if (cs != null) return cs.ConnectionString; return "Data Source=prototipo2.db;Version=3;"; }
        private void VentanaEliminar_Load(object sender, EventArgs e)
        {
            LvRegistros.View = View.Details; LvRegistros.FullRowSelect = true; LvRegistros.GridLines = true;
            LvRegistros.Columns.Add("Nombre", 250); LvRegistros.Columns.Add("Autor", 200); LvRegistros.Columns.Add("Precio", 80); LvRegistros.Columns.Add("Stock", 60);
        }
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            // Igual que buscar, pero aquí guardamos el id en Tag para saber cuál borrar
            string termino = TxtBuscar.Text.Trim(); if (string.IsNullOrEmpty(termino)) return; string consulta = ""; string valorParametro = termino; if (RdbExacta.Checked) { consulta = "SELECT id, nombre, autor, precio, stock FROM libros WHERE nombre = @termino OR autor = @termino"; } else if (RdbAproximada.Checked) { consulta = "SELECT id, nombre, autor, precio, stock FROM libros WHERE nombre LIKE @termino OR autor LIKE @termino"; valorParametro = "%" + termino + "%"; } else { MessageBox.Show("Por favor, selecciona un tipo de búsqueda."); return; } LvRegistros.Items.Clear(); int totalRegistros = 0; SQLiteConnection conexion = null; SQLiteCommand comando = null; SQLiteDataReader lector = null; try { conexion = new SQLiteConnection(ObtenerCadena()); conexion.Open(); comando = new SQLiteCommand(consulta, conexion); comando.Parameters.AddWithValue("@termino", valorParametro); lector = comando.ExecuteReader(); while (lector.Read()) { ListViewItem elemento = new ListViewItem(lector["nombre"].ToString()); elemento.SubItems.Add(lector["autor"].ToString()); elemento.SubItems.Add(lector["precio"].ToString()); elemento.SubItems.Add(lector["stock"].ToString()); elemento.Tag = Convert.ToInt32(lector["id"]); LvRegistros.Items.Add(elemento); totalRegistros = totalRegistros + 1; } LblCuenta.Text = "TOTAL DE REGISTROS: " + totalRegistros.ToString(); } catch (Exception ex) { MessageBox.Show("Error al consultar la base de datos: " + ex.Message); } finally { if (lector != null) { lector.Close(); lector.Dispose(); } if (comando != null) comando.Dispose(); if (conexion != null) { if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); conexion.Dispose(); } }
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Borrado con confirmación
            if (LvRegistros.SelectedItems.Count == 0) { MessageBox.Show("Por favor, selecciona un libro de la lista para eliminar"); return; }
            var itemSeleccionado = LvRegistros.SelectedItems[0]; string nombreLibro = itemSeleccionado.SubItems[0].Text; int idParaEliminar = 0; try { idParaEliminar = (int)itemSeleccionado.Tag; } catch { }
            if (MessageBox.Show("¿Eliminar el libro:\n\n'" + nombreLibro + "'?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            SQLiteConnection conexion = null; SQLiteCommand comando = null; try { conexion = new SQLiteConnection(ObtenerCadena()); conexion.Open(); comando = new SQLiteCommand("DELETE FROM libros WHERE id = @id", conexion); comando.Parameters.AddWithValue("@id", idParaEliminar); int filas = comando.ExecuteNonQuery(); if (filas > 0) { MessageBox.Show("Libro eliminado con éxito."); LvRegistros.Items.Remove(itemSeleccionado); LblCuenta.Text = "TOTAL DE REGISTROS: " + LvRegistros.Items.Count.ToString(); } else { MessageBox.Show("No se encontró el libro."); } } catch (Exception ex) { MessageBox.Show("Error de base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } finally { if (comando != null) comando.Dispose(); if (conexion != null) { if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); conexion.Dispose(); } }
        }
        private void BtnSalir_Click(object sender, EventArgs e) { this.Close(); }
        // Stubs para eventos del diseñador
        private void BtnMenu_Click(object sender, EventArgs e) { try { Close(); } catch { } }
        private void BtnCerrar_Click(object sender, EventArgs e) { try { Close(); } catch { } }
        private void BtnMinimizar_Click(object sender, EventArgs e) { try { WindowState = FormWindowState.Minimized; } catch { } }
    }
}
