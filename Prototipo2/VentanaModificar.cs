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
using System.Globalization;

namespace Prototipo2
{
    public partial class VentanaModificar : Form
    {
        private int idModificar;
        public VentanaModificar()
        {
            InitializeComponent();
        }

        private void VentanaModificar_Load(object sender, EventArgs e)
        {
            LvRegistros.View = View.Details;
            LvRegistros.FullRowSelect = true;
            LvRegistros.GridLines = true;

            LvRegistros.Columns.Add("Nombre", 250);
            LvRegistros.Columns.Add("Autor", 200);
            LvRegistros.Columns.Add("Precio", 80);
            LvRegistros.Columns.Add("Fecha Pub.", 100);
            LvRegistros.Columns.Add("Stock", 60);
        
            ConfigurarEstado(false);
        }

        private void ConfigurarEstado(bool editando)
        {
            TxtNombre.Enabled = editando;
            TxtAutor.Enabled = editando;
            TxtPrecio.Enabled = editando;
            DtpFecha.Enabled = editando;
            TxtStock.Enabled = editando;

            BtnGrabar.Enabled = editando;
            BtnCancelar.Enabled = editando;

            TxtBuscar.Enabled = !editando;
            BtnBuscar.Enabled = !editando;
            RdbExacta.Enabled = !editando;
            RdbAproximada.Enabled = !editando;
            LvRegistros.Enabled = !editando;

            BtnModificar.Enabled = false;
        }

        private void LimpiarCampos()
        {
            TxtNombre.Text = "";
            TxtAutor.Text = "";
            TxtPrecio.Text = "";
            TxtStock.Text = "";
            DtpFecha.Value = DateTime.Now;
            this.idModificar = 0;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string termino = TxtBuscar.Text.Trim();
            if (string.IsNullOrEmpty(termino)) return;

            string query = "";
            string parametroValor = "";

            string selectQuery = "SELECT id, nombre, autor, precio, fecha_publicacion, stock FROM libros ";

            if (RdbExacta.Checked)
            {
                query = selectQuery + "WHERE nombre = @termino OR autor = @termino";
                parametroValor = termino;
            }
            else if (RdbAproximada.Checked)
            {
                query = selectQuery + "WHERE nombre LIKE @termino OR autor LIKE @termino";
                parametroValor = "%" + termino + "%";
            }
            else 
            {
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
                                item.SubItems.Add(reader.GetDateTime("fecha_publicacion").ToString("yyyy-MM-dd"));
                                item.SubItems.Add(reader["stock"].ToString());

                                item.Tag = reader.GetInt32("id");

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
                MessageBox.Show("Error al consultar: " + ex.Message);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (LvRegistros.SelectedItems.Count == 0) return;

            ListViewItem itemSeleccionado = LvRegistros.SelectedItems[0];

            this.idModificar = (int)itemSeleccionado.Tag;

            TxtNombre.Text = itemSeleccionado.SubItems[0].Text;
            TxtAutor.Text = itemSeleccionado.SubItems[1].Text;
            TxtPrecio.Text = itemSeleccionado.SubItems[2].Text;
            DtpFecha.Value = DateTime.ParseExact(itemSeleccionado.SubItems[3].Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            TxtStock.Text = itemSeleccionado.SubItems[4].Text;

            ConfigurarEstado(true);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("¿Cancelar la modificación? Los cambios se perderán", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                LimpiarCampos();
                ConfigurarEstado(false);
            }
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(TxtPrecio.Text.Trim(), out decimal precio) || !int.TryParse(TxtStock.Text.Trim(), out int stock))
            {
                MessageBox.Show("Precio y Stock deben ser números válidos.");
                return;
            }

            string nombre = TxtNombre.Text.Trim();
            string autor = TxtAutor.Text.Trim();
            DateTime fecha = DtpFecha.Value;

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(autor))
            {
                MessageBox.Show("Nombre y Autor no pueden estar vacíos.");
                return;
            }

            string connectionString = "server=127.0.0.1;database=prototipo2_db;uid=root;pwd=;";
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE libros SET nombre = @nombre, autor = @autor, precio = @precio, " + "fecha_publicacion = @fecha, stock = @stock WHERE id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@autor", autor);
                        cmd.Parameters.AddWithValue("@precio", precio);
                        cmd.Parameters.AddWithValue("@fecha", fecha);
                        cmd.Parameters.AddWithValue("@stock", stock);
                        cmd.Parameters.AddWithValue("@id", this.idModificar);

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("¡Libro actualizado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarCampos();
                            ConfigurarEstado(false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al grabar: " + ex.Message);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LvRegistros_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnModificar.Enabled = (LvRegistros.SelectedItems.Count > 0);
        }
    }
}
