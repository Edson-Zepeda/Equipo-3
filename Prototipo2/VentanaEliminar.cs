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
using System.Configuration;

namespace Prototipo2
{
    public partial class VentanaEliminar : Form
    {
        private static string GetConnStr()
        {
            var cs = ConfigurationManager.ConnectionStrings["Prototipo2"];
            return cs != null ? cs.ConnectionString : "server=127.0.0.1;database=prototipo2_db;uid=root;pwd=;";
        }
        public VentanaEliminar()
        {
            InitializeComponent();
        }

        private void VentanaEliminar_Load(object sender, EventArgs e)
        {
            LvRegistros.View = View.Details;
            LvRegistros.FullRowSelect = true;
            LvRegistros.GridLines = true;

            LvRegistros.Columns.Add("Nombre", 250);
            LvRegistros.Columns.Add("Autor", 200);
            LvRegistros.Columns.Add("Precio", 80);
            LvRegistros.Columns.Add("Stock", 60);
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string termino = TxtBuscar.Text.Trim();
            if (string.IsNullOrEmpty(termino)) return;

            string query = "";
            string parametroValor = "";

            if (RdbExacta.Checked)
            {
                query = "SELECT id, nombre, autor, precio, stock FROM libros " + "WHERE nombre = @termino OR autor = @termino";
                parametroValor = termino;
            }
            else if (RdbAproximada.Checked)
            {
                query = "SELECT id, nombre, autor, precio, stock FROM libros " + "WHERE nombre LIKE @termino OR autor LIKE @termino";
                parametroValor = "%" + termino + "%";
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un tipo de búsqueda.");
                return;
            }

            LvRegistros.Items.Clear();
            int totalRegistros = 0;
            string connectionString = GetConnStr();

            MySqlConnection connection = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@termino", parametroValor);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["nombre"].ToString());
                    item.SubItems.Add(reader["autor"].ToString());
                    item.SubItems.Add(reader["precio"].ToString());
                    item.SubItems.Add(reader["stock"].ToString());

                    item.Tag = reader.GetInt32("id");

                    LvRegistros.Items.Add(item);
                    totalRegistros++;
                }
                LblCuenta.Text = "TOTAL DE REGISTROS: " + totalRegistros;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar la base de datos: " + ex.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }
                if (cmd != null) cmd.Dispose();
                if (connection != null)
                {
                    if (connection.State == System.Data.ConnectionState.Open) connection.Close();
                    connection.Dispose();
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (LvRegistros.SelectedItems.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un libro de la lista para eliminar");
                return;
            }

            ListViewItem itemSeleccionado = LvRegistros.SelectedItems[0];
            string nombreLibro = itemSeleccionado.SubItems[0].Text;
            int idParaEliminar = (int)itemSeleccionado.Tag;

            DialogResult confrimación = MessageBox.Show($"¿Estás seguro de que quieres eliminar permanentemente el libro:\n\n'{nombreLibro}'?","Confirmar Eliminación",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

            if (confrimación != DialogResult.Yes) return;

            string connectionString = GetConnStr();
            MySqlConnection connection = null;
            MySqlCommand cmd = null;

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                string query = "DELETE FROM libros WHERE id = @id";
                cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", idParaEliminar);

                int filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Libro eliminado con éxito.");
                    LvRegistros.Items.Remove(itemSeleccionado);
                    LblCuenta.Text = "TOTAL DE REGISTROS: " + LvRegistros.Items.Count;
                }
                else
                {
                    MessageBox.Show("Error: No se pudo eliminar el libro (no se encontró).");
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                {
                    MessageBox.Show("No se puede eliminar este libro porque está asociado a una o más ventas registradas.",
                        "Error de Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error de base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cmd != null) cmd.Dispose();
                if (connection != null)
                {
                    if (connection.State == System.Data.ConnectionState.Open) connection.Close();
                    connection.Dispose();
                }
            }

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
