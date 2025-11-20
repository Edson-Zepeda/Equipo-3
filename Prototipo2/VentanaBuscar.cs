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
    public partial class VentanaBuscar : Form
    {
        public VentanaBuscar()
        {
            InitializeComponent();
        }

        private static string GetConnStr()
        {
            var cs = ConfigurationManager.ConnectionStrings["Prototipo2"];
            return cs != null ? cs.ConnectionString : "Data Source=prototipo2.db;Version=3;";
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
            string consulta = "";
            string valorParametro = "";

            // 3. Lógica para decidir la consulta
            if (RdbExacta.Checked)
            {
                consulta = "SELECT nombre, autor, precio, fecha_publicacion, stock FROM libros WHERE nombre = @termino OR autor = @termino";
                valorParametro = termino;
            }
            else if (RdbAproximada.Checked)
            {
                consulta = "SELECT nombre, autor, precio, fecha_publicacion, stock FROM libros WHERE nombre LIKE @termino OR autor LIKE @termino";
                valorParametro = "%" + termino + "%";
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un tipo de búsqueda.");
                return;
            }

            LvRegistros.Items.Clear();
            int totalRegistros = 0;

            string cadenaConexion = GetConnStr();

            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
                {
                    conexion.Open();
                    using (SQLiteCommand comando = new SQLiteCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@termino", valorParametro);

                        using (SQLiteDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                ListViewItem elemento = new ListViewItem(lector["nombre"].ToString());

                                elemento.SubItems.Add(lector["autor"].ToString());
                                elemento.SubItems.Add(lector["precio"].ToString());

                                object fechaObj = lector["fecha_publicacion"];
                                string fechaStr = "";
                                if (fechaObj != null && fechaObj != DBNull.Value)
                                {
                                    try { fechaStr = Convert.ToDateTime(fechaObj).ToString("yyyy-MM-dd"); } catch { fechaStr = fechaObj.ToString(); }
                                }
                                elemento.SubItems.Add(fechaStr);

                                elemento.SubItems.Add(lector["stock"].ToString());

                                LvRegistros.Items.Add(elemento);

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

        private void LvRegistros_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
