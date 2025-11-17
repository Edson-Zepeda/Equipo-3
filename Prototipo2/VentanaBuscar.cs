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
    public partial class VentanaBuscar : Form
    {
        public VentanaBuscar()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VentanaBuscar_Load(object sender, EventArgs e)
        {
            LvRegistros.View = View.Details;
            LvRegistros.FullRowSelect = true;
            LvRegistros.GridLines = true;

            LvRegistros.Columns.Add("Nombre", 250);
            LvRegistros.Columns.Add("Autor", 200);
            LvRegistros.Columns.Add("Precio", 80);
            LvRegistros.Columns.Add("Publicación", 100);
            LvRegistros.Columns.Add("Stock", 80);
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            // 1. Obtener el término de búsqueda
            string termino = TxtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(termino))
            {
                MessageBox.Show("Por favor, ingresa un término de búsqueda.");
                return;
            }

            // 2. Definir la consulta base y el valor del parámetro
            string query = "";
            string parametroValor = "";

            // 3. Lógica para decidir la consulta
            if (RdbExacta.Checked)
            {
                query = "SELECT nombre, autor, precio, fecha_publicacion, stock FROM libros " +
                        "WHERE nombre = @termino OR autor = @termino";
                parametroValor = termino;
            }
            else if (RdbAproximada.Checked)
            {
                query = "SELECT nombre, autor, precio, fecha_publicacion, stock FROM libros " +
                        "WHERE nombre LIKE @termino OR autor LIKE @termino";
                parametroValor = "%" + termino + "%";
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un tipo de búsqueda.");
                return;
            }

            LvRegistros.Items.Clear();
            int totalRegistros = 0;

            string connectionString = "server=127.0.0.1;database=prototipo2_db;uid=root;pwd=;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@termino", parametroValor);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ListViewItem item = new ListViewItem(reader["nombre"].ToString());

                                item.SubItems.Add(reader["autor"].ToString());
                                item.SubItems.Add(reader["precio"].ToString());

                                DateTime fecha = reader.GetDateTime("fecha_publicacion");
                                item.SubItems.Add(fecha.ToString("yyyy-MM-dd"));

                                item.SubItems.Add(reader["stock"].ToString());

                                LvRegistros.Items.Add(item);

                                totalRegistros++;
                            }
                        }
                    }
                } 

                LblCuenta.Text = "TOTAL DE REGISTROS: " + totalRegistros;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar la base de datos: " + ex.Message);
            }
        }
    }
}
