using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Configuration;

namespace Prototipo2
{
    // Buscar libros.
    // - Permite búsqueda exacta o aproximada por nombre/autor.
    // - Muestra los resultados en un ListView con columnas.
    public partial class VentanaBuscar : Form
    {
        public VentanaBuscar()
        {
            InitializeComponent();
        }
        private string ObtenerCadena() { var cs = ConfigurationManager.ConnectionStrings["Prototipo2"]; if (cs != null) return cs.ConnectionString; return "Data Source=prototipo2.db;Version=3;"; }
        private void VentanaBuscar_Load(object sender, EventArgs e)
        {
            // Configurar tabla visual
            LvRegistros.View = View.Details; LvRegistros.FullRowSelect = true; LvRegistros.GridLines = true;
            LvRegistros.Columns.Add("Nombre", 250); LvRegistros.Columns.Add("Autor", 200); LvRegistros.Columns.Add("Precio", 80); LvRegistros.Columns.Add("Publicación", 100); LvRegistros.Columns.Add("Stock", 80);
        }
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            // Arma la consulta según el tipo de búsqueda y la ejecuta
            string termino = TxtBuscar.Text.Trim(); if (string.IsNullOrEmpty(termino)) { MessageBox.Show("Por favor, ingresa un término de búsqueda."); return; }
            string consulta = ""; string valorParametro = termino; if (RdbExacta.Checked) { consulta = "SELECT nombre, autor, precio, fecha_publicacion, stock FROM libros WHERE nombre = @termino OR autor = @termino"; } else if (RdbAproximada.Checked) { consulta = "SELECT nombre, autor, precio, fecha_publicacion, stock FROM libros WHERE nombre LIKE @termino OR autor LIKE @termino"; valorParametro = "%" + termino + "%"; } else { MessageBox.Show("Por favor, selecciona un tipo de búsqueda."); return; }
            LvRegistros.Items.Clear(); int totalRegistros = 0; SQLiteConnection conexion = null; SQLiteCommand comando = null; SQLiteDataReader lector = null; try { conexion = new SQLiteConnection(ObtenerCadena()); conexion.Open(); comando = new SQLiteCommand(consulta, conexion); comando.Parameters.AddWithValue("@termino", valorParametro); lector = comando.ExecuteReader(); while (lector.Read()) { ListViewItem elemento = new ListViewItem(lector["nombre"].ToString()); elemento.SubItems.Add(lector["autor"].ToString()); elemento.SubItems.Add(lector["precio"].ToString()); object fechaObj = lector["fecha_publicacion"]; string fechaStr = ""; if (fechaObj != null && fechaObj != DBNull.Value) { try { fechaStr = Convert.ToDateTime(fechaObj).ToString("yyyy-MM-dd"); } catch { fechaStr = fechaObj.ToString(); } } elemento.SubItems.Add(fechaStr); elemento.SubItems.Add(lector["stock"].ToString()); LvRegistros.Items.Add(elemento); totalRegistros = totalRegistros + 1; } LblCuenta.Text = "TOTAL DE REGISTROS: " + totalRegistros.ToString(); } catch (Exception ex) { MessageBox.Show("Error al consultar la base de datos: " + ex.Message); } finally { if (lector != null) { lector.Close(); lector.Dispose(); } if (comando != null) comando.Dispose(); if (conexion != null) { if (conexion.State == System.Data.ConnectionState.Open) conexion.Close(); conexion.Dispose(); } }
        }
        private void BtnSalir_Click(object sender, EventArgs e) { this.Close(); }
        // Stubs del diseñador
        private void BtnMenu_Click(object sender, EventArgs e) { try { Close(); } catch { } }
        private void PnlTitleBar_MouseDown(object sender, MouseEventArgs e) { try { } catch { } }
        private void BtnCerrar_Click(object sender, EventArgs e) { try { Close(); } catch { } }
        private void BtnMinimizar_Click(object sender, EventArgs e) { try { WindowState = FormWindowState.Minimized; } catch { } }
    }
}