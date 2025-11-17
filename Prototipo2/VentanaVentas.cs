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
    public partial class VentanaVentas : Form
    {
        private int idUsuarioLogueado;

        public VentanaVentas(int idUsuario)
        {
            InitializeComponent();
            this.idUsuarioLogueado = idUsuario;
        }

        private void VentanaVentas_Load(object sender, EventArgs e)
        {
            LvRegistros.View = View.Details;
            LvRegistros.FullRowSelect = true;
            LvRegistros.GridLines = true;

            LvRegistros.Columns.Add("Nombre", 250);
            LvRegistros.Columns.Add("Autor", 200);
            LvRegistros.Columns.Add("Precio", 80);
            LvRegistros.Columns.Add("Publicación", 100);
            LvRegistros.Columns.Add("Stock", 60);

            LvCarrito.View = View.Details;
            LvCarrito.FullRowSelect = true;
            LvCarrito.GridLines = true;

            LvCarrito.Columns.Add("Nombre", 250);
            LvCarrito.Columns.Add("Autor", 200);
            LvCarrito.Columns.Add("Precio Unit.", 80);
            LvCarrito.Columns.Add("Cantidad", 60);
            LvCarrito.Columns.Add("Subtotal", 80);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string termino = TxtBuscar.Text.Trim();
            if (string.IsNullOrEmpty(termino)) return;

            string query = "";
            string parametroValor = "";

            if (RdbExacta.Checked)
            {
                query = "SELECT id, nombre, autor, precio, fecha_publicacion, stock FROM libros " +
                        "WHERE nombre = @termino OR autor = @termino";
                parametroValor = termino;
            }
            else if (RdbAproximada.Checked)
            {
                query = "SELECT id, nombre, autor, precio, fecha_publicacion, stock FROM libros " +
                        "WHERE nombre LIKE @termino OR autor LIKE @termino";
                parametroValor = "%" + termino + "%";
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un tipo de búsqueda");
                return;
            }

            LvRegistros.Items.Clear();
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
                                item.Tag = reader.GetInt32("id");

                                LvRegistros.Items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar la base de datos: " + ex.Message);
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (LvRegistros.SelectedItems.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un libro de la lista de arriba");
                return;
            }

            if (!int.TryParse(TxtCantidad.Text, out int cantidadComprar) || cantidadComprar <= 0)
            {
                MessageBox.Show("Por favor, ingresa una cantidad numérica válida y mayor a cero");
                return;
            }

            ListViewItem itemSeleccionado = LvRegistros.SelectedItems[0];

            string nombre = itemSeleccionado.SubItems[0].Text;
            string autor = itemSeleccionado.SubItems[1].Text;
            decimal precio = decimal.Parse(itemSeleccionado.SubItems[2].Text);
            int stock = int.Parse(itemSeleccionado.SubItems[4].Text);

            if (cantidadComprar > stock)
            {
                MessageBox.Show($"La cantidad solicitada ({cantidadComprar}) supera el stock disponible ({stock})");
                return;
            }

            decimal subtotal = precio * cantidadComprar;

            ListViewItem itemCarrito = new ListViewItem(nombre);
            itemCarrito.SubItems.Add(autor);
            itemCarrito.SubItems.Add(precio.ToString("F2"));
            itemCarrito.SubItems.Add(cantidadComprar.ToString());
            itemCarrito.SubItems.Add(subtotal.ToString("F2"));
            itemCarrito.Tag = itemSeleccionado.Tag;

            LvCarrito.Items.Add(itemCarrito);

            TxtBuscar.Text = "";
            TxtCantidad.Text = "";
            LvRegistros.Items.Clear();
        }

        private void BtnComprar_Click(object sender, EventArgs e)
        {
            if(LvCarrito.Items.Count == 0)
            {
                MessageBox.Show("El carrito está vacío");
                return;
            }

            DialogResult confirmacion = MessageBox.Show("¿Deseas finalizar la compra?","Confirmación",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if(confirmacion == DialogResult.No)
            {
                return;
            }

            string connectionString = "server=127.0.0.1;database=prototipo2_db;uid=root;pwd=;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlTransaction transaccion = null;

            try
            {
                connection.Open();
                transaccion = connection.BeginTransaction();

                decimal totalpagar = 0;

                foreach (ListViewItem item in LvCarrito.Items)
                {
                    totalpagar += decimal.Parse(item.SubItems[4].Text);
                }

                string queryVenta = "INSERT INTO ventas (fecha, id_usuario, total_venta) VALUES (@fecha, @id_usuario, @total)";
                MySqlCommand cmdVenta = new MySqlCommand(queryVenta, connection, transaccion);
                cmdVenta.Parameters.AddWithValue("@fecha", DateTime.Now);
                cmdVenta.Parameters.AddWithValue("@id_usuario", this.idUsuarioLogueado);
                cmdVenta.Parameters.AddWithValue("@total", totalpagar);
                cmdVenta.ExecuteNonQuery();

                long idVentaNueva = cmdVenta.LastInsertedId;

                foreach (ListViewItem item in LvCarrito.Items)
                {
                    int idLibro = (int)item.Tag;
                    int cantidad = int.Parse(item.SubItems[3].Text);
                    decimal precioVenta = decimal.Parse(item.SubItems[2].Text);
                    decimal subtotal = decimal.Parse(item.SubItems[4].Text);

                    string queryDetalle = "INSERT INTO detalle_ventas (id_venta, id_libro, cantidad, precio_unitario_venta, subtotal) " + "VALUES (@id_venta, @id_libro, @cantidad, @precio, @subtotal)";
                    MySqlCommand cmdDetalle = new MySqlCommand(queryDetalle, connection, transaccion);
                    cmdDetalle.Parameters.AddWithValue("@id_venta", idVentaNueva);
                    cmdDetalle.Parameters.AddWithValue("@id_libro", idLibro);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", cantidad);
                    cmdDetalle.Parameters.AddWithValue("@precio", precioVenta);
                    cmdDetalle.Parameters.AddWithValue("@subtotal", subtotal);
                    cmdDetalle.ExecuteNonQuery();

                    string queryStock = "UPDATE libros SET stock = stock - @cantidad WHERE id = @id_libro";
                    MySqlCommand cmdStock = new MySqlCommand(queryStock, connection, transaccion);
                    cmdStock.Parameters.AddWithValue("@cantidad", cantidad);
                    cmdStock.Parameters.AddWithValue("@id_libro", idLibro);
                    cmdStock.ExecuteNonQuery();
                }

                transaccion.Commit();

                MessageBox.Show($"Venta registrada con éxito (Ticket #{idVentaNueva})\nTotal a pagar: {totalpagar:C}","Venta Finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LvCarrito.Items.Clear();
            }
            catch (Exception ex)
            {
                try
                {
                    transaccion?.Rollback();
                }
                catch { }

                MessageBox.Show("Error crítico al registrar la venta. La operación ha sido cancelada.\n\nError: " + ex.Message,"Error de Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if(connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
