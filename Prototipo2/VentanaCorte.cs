using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SQLite;

namespace Prototipo2
{
    public partial class VentanaCorte : Form
    {
        private int idUsuarioLogueado;
        private string nombreUsuarioLogueado = "Desconocido";
        private decimal totalDia = 0;
        // Constructor le da un valor a la variable idUsuarioLogueado al crear la instancia o formulario
        public VentanaCorte(int idUsuario)
        {
            InitializeComponent();
            this.idUsuarioLogueado = idUsuario;
        }

        private static string GetConnStr()
        {
            var cs = ConfigurationManager.ConnectionStrings["Prototipo2"];
            return cs != null ? cs.ConnectionString : "Data Source=prototipo2.db;Version=3;";
        }

        private void VentanaCorte_Load(object sender, EventArgs e)
        {
            LblFecha.Text = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy");
            LblHora.Text = "Hora: " + DateTime.Now.ToString("HH:mm:ss");

            LvCorte.View = View.Details;
            LvCorte.FullRowSelect = true;
            LvCorte.GridLines = true;

            LvCorte.Columns.Add("ID Venta", 80);
            LvCorte.Columns.Add("Fecha/Hora de Venta", 150);
            LvCorte.Columns.Add("Total Venta", 100);

            CargarDatosDelCorte();
        }

        private void CargarDatosDelCorte()
        {
            string connectionString = GetConnStr();

            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    try
                    {
                        using (var cmdNombre = new SQLiteCommand("SELECT Usuario FROM usuarios WHERE id = @idUsuario", connection))
                        {
                            cmdNombre.Parameters.AddWithValue("@idUsuario", this.idUsuarioLogueado);
                            object resultadoNombre = cmdNombre.ExecuteScalar();
                            if (resultadoNombre != null && resultadoNombre != DBNull.Value)
                            {
                                this.nombreUsuarioLogueado = resultadoNombre.ToString();
                            }
                        }
                    }
                    catch (SQLiteException)
                    {
                        // tabla usuarios puede no existir, entonces nada mas lo ignoramos
                    }
                    try
                    {
                        string queryVentas = "SELECT id_venta, fecha, total_venta FROM ventas WHERE id_usuario = @idUsuario AND DATE(fecha) = DATE('now') ORDER BY fecha DESC";
                        using (var cmdVentas = new SQLiteCommand(queryVentas, connection))
                        {
                            cmdVentas.Parameters.AddWithValue("@idUsuario", this.idUsuarioLogueado);
                            using (var reader = cmdVentas.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int idVenta = 0;
                                    decimal total = 0;
                                    DateTime fecha = DateTime.Now;

                                    try { idVenta = Convert.ToInt32(reader["id_venta"]); } catch { }
                                    try { fecha = Convert.ToDateTime(reader["fecha"]); } catch { }
                                    try { total = Convert.ToDecimal(reader["total_venta"]); } catch { }

                                    ListViewItem item = new ListViewItem(idVenta.ToString());
                                    item.SubItems.Add(fecha.ToString("yyyy-MM-dd HH:mm:ss"));
                                    item.SubItems.Add(total.ToString("C"));
                                    LvCorte.Items.Add(item);

                                    this.totalDia += total;
                                }
                            }
                        }
                    }
                    catch (SQLiteException)
                    {
                        // tabla ventas puede no existir, entonces nada mas lo ignoramos
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del corte: " + ex.Message);
            }
        }

        private void BtnCorte_Click(object sender, EventArgs e)
        {
            string fechaCorte = DateTime.Now.ToString("dd/MM/yyyy");
            string horaCorte = DateTime.Now.ToString("HH:mm:ss");

            string mensaje = $"--- CORTE DE CAJA FINALIZADO ---\n\n" +
                         $"Usuario: {this.nombreUsuarioLogueado}\n" +
                         $"Fecha: {fechaCorte}\n" +
                         $"Hora: {horaCorte}\n\n" +
                         $"Total Vendido Hoy: {this.totalDia:C}";

            MessageBox.Show(mensaje, "Corte Realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void LvCorte_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
