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

namespace Prototipo2
{
    
    public partial class VentanaCorte : Form
    {
        private int idUsuarioLogueado;
        private string nombreUsuarioLogueado = "Desconocido";
        private decimal totalDia = 0;

        public VentanaCorte(int idUsuario)
        {
            InitializeComponent();
            this.idUsuarioLogueado=idUsuario;
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
            string connectionString = "server=127.0.0.1;database=prototipo2_db;uid=root;pwd=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string queryNombre = "SELECT Usuario FROM usuarios WHERE ID = @idUsuario";
                    MySqlCommand cmdNombre = new MySqlCommand(queryNombre, connection);
                    cmdNombre.Parameters.AddWithValue("@idUsuario", this.idUsuarioLogueado);
                    object resultadoNombre = cmdNombre.ExecuteScalar();
                    if (resultadoNombre != null)
                    {
                        this.nombreUsuarioLogueado = resultadoNombre.ToString();
                    }

                    string queryVentas = "SELECT id_venta, fecha, total_venta FROM ventas " + "WHERE id_usuario = @idUsuario AND DATE(fecha) = CURDATE() " + "ORDER BY fecha DESC";

                    MySqlCommand cmdVentas = new MySqlCommand(queryVentas, connection);
                    cmdVentas.Parameters.AddWithValue("@idUsuario", this.idUsuarioLogueado);

                    using (MySqlDataReader reader = cmdVentas.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader.GetInt32("id_venta").ToString());
                            item.SubItems.Add(reader.GetDateTime("fecha").ToString("yyyy-MM-dd HH:mm:ss"));
                            item.SubItems.Add(reader.GetDecimal("total_venta").ToString("C"));
                            LvCorte.Items.Add(item);

                            this.totalDia += reader.GetDecimal("total_venta");
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos del corte: " + ex.Message);
                }
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

        
    }
}
