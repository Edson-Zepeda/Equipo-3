using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Configuration;

namespace Prototipo2
{
    // Alta de libros.
    // - Valida datos básicos (nombre, autor, precio, stock).
    // - Inserta el libro en la tabla 'libros'.
    public partial class VentanaGuardar : Form
    {
        public VentanaGuardar() { InitializeComponent(); }
        private string ObtenerCadena() { var cs = ConfigurationManager.ConnectionStrings["Prototipo2"]; if (cs != null) return cs.ConnectionString; return "Data Source=prototipo2.db;Version=3;"; }
        private void VentanaGuardar_Load(object sender, EventArgs e) { }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones de principiante pero útiles
            string nombre = TxtNombre.Text.Trim(); string autor = TxtAutor.Text.Trim(); string precioStr = TxtPrecio.Text.Trim(); string stockStr = TxtStock.Text.Trim(); DateTime fecha = DtpFechaPublicacion.Value;
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(autor)) { MessageBox.Show("El Nombre y el Autor son obligatorios."); return; }
            decimal precio = 0; if (!decimal.TryParse(precioStr, out precio)) { MessageBox.Show("El Precio debe ser un número válido (ej. 199.50)."); return; }
            int stock = 0; if (!int.TryParse(stockStr, out stock)) { MessageBox.Show("Copias en Existencia (Stock) debe ser un número entero."); return; }
            // Inserción
            SQLiteConnection conexion = null; SQLiteCommand comando = null; try { conexion = new SQLiteConnection(ObtenerCadena()); conexion.Open(); comando = new SQLiteCommand("INSERT INTO libros (nombre, autor, precio, fecha_publicacion, stock) VALUES (@nombre, @autor, @precio, @fecha, @stock)", conexion); comando.Parameters.AddWithValue("@nombre", nombre); comando.Parameters.AddWithValue("@autor", autor); comando.Parameters.AddWithValue("@precio", precio); comando.Parameters.AddWithValue("@fecha", fecha); comando.Parameters.AddWithValue("@stock", stock); int filasAfectadas = comando.ExecuteNonQuery(); if (filasAfectadas > 0) { MessageBox.Show("¡Libro guardado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information); LimpiarCampos(); } else { MessageBox.Show("No se pudo guardar el libro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } } catch (Exception ex) { MessageBox.Show("Error de base de datos: " + ex.Message); } finally { if (comando != null) comando.Dispose(); if (conexion != null) { if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); conexion.Dispose(); } }
        }
        private void LimpiarCampos() { TxtNombre.Text = ""; TxtAutor.Text = ""; TxtPrecio.Text = ""; TxtStock.Text = ""; DtpFechaPublicacion.Value = DateTime.Now; TxtNombre.Focus(); }
        private void BtnSalir_Click(object sender, EventArgs e) { this.Close(); }
        // Stubs
        private void BtnMenu_Click(object sender, EventArgs e) { try { Close(); } catch { } }
        private void BtnCerrar_Click(object sender, EventArgs e) { try { Close(); } catch { } }
        private void BtnMinimizar_Click(object sender, EventArgs e) { try { WindowState = FormWindowState.Minimized; } catch { } }
    }
}
