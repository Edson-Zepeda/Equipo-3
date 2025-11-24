using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Configuration;

namespace Prototipo2
{
    // Ventas de libros.
    // - Busca libros, agrega al carrito y registra la venta (ventas + detalle_ventas + ventas_full).
    // - Maneja stock restando unidades vendidas.
    public partial class VentanaVentas : Form
    {
        private int idUsuarioLogueado; // quién vende

        // Constructor para diseñador (sin parámetros)
        public VentanaVentas()
        {
            InitializeComponent();
            idUsuarioLogueado = 0;
        }

        // Constructor que recibe el id del usuario logueado
        public VentanaVentas(int idUsuario)
        {
            InitializeComponent();
            idUsuarioLogueado = idUsuario;
        }

        private string ObtenerCadena()
        {
            var cs = ConfigurationManager.ConnectionStrings["Prototipo2"];
            if (cs != null)
            {
                return cs.ConnectionString;
            }
            return "Data Source=prototipo2.db;Version=3;";
        }

        private void VentanaVentas_Load(object sender, EventArgs e)
        {
            // Listas de resultados y carrito
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

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            // Consulta por nombre/autor exacta o aproximada
            string termino = TxtBuscar.Text.Trim();
            if (string.IsNullOrEmpty(termino))
            {
                return;
            }

            string query = "";
            string parametroValor = termino;

            if (RdbExacta.Checked)
            {
                query = "SELECT id, nombre, autor, precio, fecha_publicacion, stock FROM libros WHERE nombre = @termino OR autor = @termino";
            }
            else if (RdbAproximada.Checked)
            {
                query = "SELECT id, nombre, autor, precio, fecha_publicacion, stock FROM libros WHERE nombre LIKE @termino OR autor LIKE @termino";
                parametroValor = "%" + termino + "%";
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un tipo de búsqueda");
                return;
            }

            LvRegistros.Items.Clear();
            SQLiteConnection connection = null;
            SQLiteCommand cmd = null;
            SQLiteDataReader reader = null;

            try
            {
                connection = new SQLiteConnection(ObtenerCadena());
                connection.Open();

                cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.AddWithValue("@termino", parametroValor);

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["nombre"].ToString());
                    item.SubItems.Add(reader["autor"].ToString());
                    item.SubItems.Add(reader["precio"].ToString());

                    DateTime fecha = DateTime.Now;
                    try
                    {
                        fecha = Convert.ToDateTime(reader["fecha_publicacion"]);
                    }
                    catch
                    {
                    }

                    item.SubItems.Add(fecha.ToString("yyyy-MM-dd"));
                    item.SubItems.Add(reader["stock"].ToString());
                    item.Tag = Convert.ToInt32(reader["id"]);
                    LvRegistros.Items.Add(item);
                }
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

                if (cmd != null)
                {
                    cmd.Dispose();
                }

                if (connection != null)
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    connection.Dispose();
                }
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            // Agrega el libro seleccionado al carrito, validando cantidad y stock.
            if (LvRegistros.SelectedItems.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un libro de la lista de arriba");
                return;
            }

            int cantidadComprar = 0;
            if (!int.TryParse(TxtCantidad.Text, out cantidadComprar) || cantidadComprar <= 0)
            {
                MessageBox.Show("Por favor, ingresa una cantidad numérica válida y mayor a cero");
                return;
            }

            var itemSeleccionado = LvRegistros.SelectedItems[0];

            string nombre = itemSeleccionado.SubItems[0].Text;
            string autor = itemSeleccionado.SubItems[1].Text;

            decimal precio = 0;
            try
            {
                precio = decimal.Parse(itemSeleccionado.SubItems[2].Text);
            }
            catch
            {
            }

            int stock = 0;
            try
            {
                stock = int.Parse(itemSeleccionado.SubItems[4].Text);
            }
            catch
            {
            }

            if (cantidadComprar > stock)
            {
                MessageBox.Show("La cantidad solicitada (" + cantidadComprar + ") supera el stock disponible (" + stock + ")");
                return;
            }

            decimal subtotal = precio * cantidadComprar;

            var itemCarrito = new ListViewItem(nombre);
            itemCarrito.SubItems.Add(autor);
            itemCarrito.SubItems.Add(precio.ToString("F2"));
            itemCarrito.SubItems.Add(cantidadComprar.ToString());
            itemCarrito.SubItems.Add(subtotal.ToString("F2"));
            itemCarrito.Tag = itemSeleccionado.Tag;

            LvCarrito.Items.Add(itemCarrito);

            // Limpieza simple post-agregado
            TxtBuscar.Text = "";
            TxtCantidad.Text = "";
            LvRegistros.Items.Clear();
        }

        private void BtnComprar_Click(object sender, EventArgs e)
        {
            // Registra la venta con transacción para asegurar consistencia
            if (LvCarrito.Items.Count == 0)
            {
                MessageBox.Show("El carrito está vacío");
                return;
            }

            if (MessageBox.Show("¿Deseas finalizar la compra?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            SQLiteConnection connection = null;
            SQLiteTransaction trans = null;
            SQLiteCommand cmdVenta = null;
            SQLiteCommand cmdLast = null;
            SQLiteCommand cmdDetalle = null;
            SQLiteCommand cmdStock = null;
            SQLiteCommand cmdFull = null;

            try
            {
                connection = new SQLiteConnection(ObtenerCadena());
                connection.Open();
                trans = connection.BeginTransaction();

                decimal totalpagar = 0;
                foreach (ListViewItem item in LvCarrito.Items)
                {
                    try
                    {
                        totalpagar += decimal.Parse(item.SubItems[4].Text);
                    }
                    catch
                    {
                    }
                }

                // 1) Venta
                cmdVenta = new SQLiteCommand("INSERT INTO ventas (fecha, id_usuario, total_venta) VALUES (@fecha, @id_usuario, @total)", connection, trans);
                cmdVenta.Parameters.AddWithValue("@fecha", DateTime.Now);
                cmdVenta.Parameters.AddWithValue("@id_usuario", idUsuarioLogueado);
                cmdVenta.Parameters.AddWithValue("@total", totalpagar);
                cmdVenta.ExecuteNonQuery();

                long idVentaNueva = 0;
                cmdLast = new SQLiteCommand("SELECT last_insert_rowid()", connection, trans);
                idVentaNueva = (long)cmdLast.ExecuteScalar();

                // 2) Detalle + 3) Descontar stock
                foreach (ListViewItem item in LvCarrito.Items)
                {
                    int idLibro = 0;
                    try
                    {
                        idLibro = Convert.ToInt32(item.Tag);
                    }
                    catch
                    {
                    }

                    int cantidad = 0;
                    try
                    {
                        cantidad = int.Parse(item.SubItems[3].Text);
                    }
                    catch
                    {
                    }

                    decimal precioVenta = 0;
                    try
                    {
                        precioVenta = decimal.Parse(item.SubItems[2].Text);
                    }
                    catch
                    {
                    }

                    decimal subtotal = 0;
                    try
                    {
                        subtotal = decimal.Parse(item.SubItems[4].Text);
                    }
                    catch
                    {
                    }

                    cmdDetalle = new SQLiteCommand("INSERT INTO detalle_ventas (id_venta, id_libro, cantidad, precio_unitario_venta, subtotal) VALUES (@id_venta, @id_libro, @cantidad, @precio, @subtotal)", connection, trans);
                    cmdDetalle.Parameters.AddWithValue("@id_venta", idVentaNueva);
                    cmdDetalle.Parameters.AddWithValue("@id_libro", idLibro);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", cantidad);
                    cmdDetalle.Parameters.AddWithValue("@precio", precioVenta);
                    cmdDetalle.Parameters.AddWithValue("@subtotal", subtotal);
                    cmdDetalle.ExecuteNonQuery();

                    cmdStock = new SQLiteCommand("UPDATE libros SET stock = stock - @cantidad WHERE id = @id_libro", connection, trans);
                    cmdStock.Parameters.AddWithValue("@cantidad", cantidad);
                    cmdStock.Parameters.AddWithValue("@id_libro", idLibro);
                    cmdStock.ExecuteNonQuery();
                }

                // 4) Tabla resumen "ventas_full" (útil para reportes simples)
                foreach (ListViewItem item in LvCarrito.Items)
                {
                    int idLibro = 0;
                    try
                    {
                        idLibro = Convert.ToInt32(item.Tag);
                    }
                    catch
                    {
                    }

                    int cantidad = 0;
                    try
                    {
                        cantidad = int.Parse(item.SubItems[3].Text);
                    }
                    catch
                    {
                    }

                    decimal precioUnit = 0;
                    try
                    {
                        precioUnit = decimal.Parse(item.SubItems[2].Text);
                    }
                    catch
                    {
                    }

                    decimal subtotalLinea = 0;
                    try
                    {
                        subtotalLinea = decimal.Parse(item.SubItems[4].Text);
                    }
                    catch
                    {
                    }

                    string nombre = item.SubItems[0].Text;
                    string autor = item.SubItems[1].Text;

                    cmdFull = new SQLiteCommand("INSERT INTO ventas_full (venta_id, fecha, usuario_id, libro_id, nombre_libro, autor_libro, cantidad, precio_unitario, subtotal_linea, total_venta) VALUES (@venta_id, @fecha, @usuario_id, @libro_id, @nombre_libro, @autor_libro, @cantidad, @precio_unitario, @subtotal_linea, @total_venta)", connection, trans);
                    cmdFull.Parameters.AddWithValue("@venta_id", idVentaNueva);
                    cmdFull.Parameters.AddWithValue("@fecha", DateTime.Now);
                    cmdFull.Parameters.AddWithValue("@usuario_id", idUsuarioLogueado);
                    cmdFull.Parameters.AddWithValue("@libro_id", idLibro);
                    cmdFull.Parameters.AddWithValue("@nombre_libro", nombre);
                    cmdFull.Parameters.AddWithValue("@autor_libro", autor);
                    cmdFull.Parameters.AddWithValue("@cantidad", cantidad);
                    cmdFull.Parameters.AddWithValue("@precio_unitario", precioUnit);
                    cmdFull.Parameters.AddWithValue("@subtotal_linea", subtotalLinea);
                    cmdFull.Parameters.AddWithValue("@total_venta", totalpagar);
                    cmdFull.ExecuteNonQuery();
                }

                trans.Commit();
                MessageBox.Show("Venta registrada con éxito (Ticket #" + idVentaNueva + ")\nTotal a pagar: " + totalpagar.ToString("C"), "Venta Finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LvCarrito.Items.Clear();
            }
            catch (Exception ex)
            {
                // Si algo falla, se deshace la operación
                try
                {
                    if (trans != null)
                    {
                        trans.Rollback();
                    }
                }
                catch
                {
                }

                MessageBox.Show("Error crítico al registrar la venta. Se canceló la operación.\n\n" + ex.Message, "Error de Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Limpieza de objetos de BD
                if (cmdVenta != null) cmdVenta.Dispose();
                if (cmdLast != null) cmdLast.Dispose();
                if (cmdDetalle != null) cmdDetalle.Dispose();
                if (cmdStock != null) cmdStock.Dispose();
                if (cmdFull != null) cmdFull.Dispose();
                if (trans != null) trans.Dispose();
                if (connection != null)
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    connection.Dispose();
                }
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Stubs
        private void groupBox1_Enter(object sender, EventArgs e)
        {
            try
            {
            }
            catch
            {
            }
        }

        private void BtnMenu_Click_1(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch
            {
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch
            {
            }
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Minimized;
            }
            catch
            {
            }
        }

        private void LvRegistros_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
