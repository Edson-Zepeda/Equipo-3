using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Configuration;

namespace Prototipo2
{
    // Corte de caja del día.
    // - Muestra ventas del usuario en el día actual.
    // - Suma totales y presenta un resumen simple.
    public partial class VentanaCorte : Form
    {
        private int idUsuarioLogueado;           // usuario que realiza el corte
        private string nombreUsuarioLogueado = "Desconocido";
        private decimal totalDia = 0;            // acumulado de ventas del día
        // Constructor sin parámetros para diseñador
        public VentanaCorte() : this(0) { }
        public VentanaCorte(int idUsuario)
        {
            InitializeComponent();
            idUsuarioLogueado = idUsuario;
        }
        private string ObtenerCadena()
        {
            var cs = ConfigurationManager.ConnectionStrings["Prototipo2"]; if (cs != null) return cs.ConnectionString; return "Data Source=prototipo2.db;Version=3;";
        }
        private void VentanaCorte_Load(object sender, EventArgs e)
        {
            LblFecha.Text = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy");
            LblHora.Text = "Hora: " + DateTime.Now.ToString("HH:mm:ss");
            // Configuración del listado
            LvCorte.View = View.Details; LvCorte.FullRowSelect = true; LvCorte.GridLines = true;
            LvCorte.Columns.Add("ID Venta", 80); LvCorte.Columns.Add("Fecha/Hora de Venta", 150); LvCorte.Columns.Add("Total Venta", 100);
            CargarDatosDelCorte();
        }
        private void CargarDatosDelCorte()
        {
            // Nota: para principiantes, se usan try/catch simples para que la app no se caiga.
            SQLiteConnection connection = null; SQLiteCommand cmdNombre = null; SQLiteCommand cmdVentas = null; SQLiteDataReader reader = null;
            try
            {
                connection = new SQLiteConnection(ObtenerCadena()); connection.Open();
                // Nombre del usuario
                try
                {
                    cmdNombre = new SQLiteCommand("SELECT Usuario FROM usuarios WHERE id = @idUsuario", connection); cmdNombre.Parameters.AddWithValue("@idUsuario", idUsuarioLogueado); object resultadoNombre = cmdNombre.ExecuteScalar(); if (resultadoNombre != null && resultadoNombre != DBNull.Value) nombreUsuarioLogueado = resultadoNombre.ToString();
                }
                catch { }
                // Ventas del día
                try
                {
                    cmdVentas = new SQLiteCommand("SELECT id_venta, fecha, total_venta FROM ventas WHERE id_usuario = @idUsuario AND DATE(fecha) = DATE('now') ORDER BY fecha DESC", connection); cmdVentas.Parameters.AddWithValue("@idUsuario", idUsuarioLogueado); reader = cmdVentas.ExecuteReader(); while (reader.Read()) { int idVenta = 0; decimal total = 0; DateTime fecha = DateTime.Now; try { idVenta = Convert.ToInt32(reader["id_venta"]); } catch { } try { fecha = Convert.ToDateTime(reader["fecha"]); } catch { } try { total = Convert.ToDecimal(reader["total_venta"]); } catch { } ListViewItem item = new ListViewItem(idVenta.ToString()); item.SubItems.Add(fecha.ToString("yyyy-MM-dd HH:mm:ss")); item.SubItems.Add(total.ToString("C")); LvCorte.Items.Add(item); totalDia = totalDia + total; }
                }
                catch { }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del corte: " + ex.Message);
            }
            finally
            {
                if (reader != null) { reader.Close(); reader.Dispose(); }
                if (cmdNombre != null) cmdNombre.Dispose();
                if (cmdVentas != null) cmdVentas.Dispose();
                if (connection != null) { if (connection.State == System.Data.ConnectionState.Open) connection.Close(); connection.Dispose(); }
            }
        }
        private void BtnCorte_Click(object sender, EventArgs e)
        {
            // Mensaje con resumen. En un sistema real, aquí se podría exportar un PDF o ticket.
            string fechaCorte = DateTime.Now.ToString("dd/MM/yyyy"); string horaCorte = DateTime.Now.ToString("HH:mm:ss"); string mensaje = "--- CORTE DE CAJA FINALIZADO ---\n\n" + "Usuario: " + nombreUsuarioLogueado + "\n" + "Fecha: " + fechaCorte + "\n" + "Hora: " + horaCorte + "\n\n" + "Total Vendido Hoy: " + totalDia.ToString("C"); MessageBox.Show(mensaje, "Corte Realizado", MessageBoxButtons.OK, MessageBoxIcon.Information); this.Close();
        }
        // Stubs conectados por el diseñador (no hacen nada crítico)
        private void BtnMenu_Click(object sender, EventArgs e) { try { Close(); } catch { } }
        private void panel2_Paint(object sender, PaintEventArgs e) { try { } catch { } }
        private void BtnCerrar_Click(object sender, EventArgs e) { try { Close(); } catch { } }
        private void BtnMinimizar_Click(object sender, EventArgs e) { try { WindowState = FormWindowState.Minimized; } catch { } }
    }
}
