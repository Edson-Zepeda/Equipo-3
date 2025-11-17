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
    public partial class VentanaGuardar : Form
    {
        public VentanaGuardar()
        {
            InitializeComponent();
        }

        private void VentanaGuardar_Load(object sender, EventArgs e)
        {

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = TxtNombre.Text.Trim();
            string autor = TxtAutor.Text.Trim();
            string precioStr = TxtPrecio.Text.Trim();
            string stockStr = TxtStock.Text.Trim();

            DateTime fecha = DtpFechaPublicacion.Value;

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(autor))
            {
                MessageBox.Show("El Nombre y el Autor son obligatorios.");
                return;
            }

            if (!decimal.TryParse(precioStr, out decimal precio))
            {
                MessageBox.Show("El Precio debe ser un número válido (ej. 199.50).");
                return;
            }

            if (!int.TryParse(stockStr, out int stock))
            {
                MessageBox.Show("Copias en Existencia (Stock) debe ser un número entero.");
                return;
            }

            string connectionString = "server=127.0.0.1;database=prototipo2_db;uid=root;pwd=;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO libros (nombre, autor, precio, fecha_publicacion, stock) " + "VALUES (@nombre, @autor, @precio, @fecha, @stock)";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@autor", autor);
                        cmd.Parameters.AddWithValue("@precio", precio);
                        cmd.Parameters.AddWithValue("@fecha", fecha);
                        cmd.Parameters.AddWithValue("@stock", stock);

                        // 6. Ejecutar
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("¡Libro guardado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarCampos();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo guardar el libro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Capturar error común: entrada duplicada
                if (ex.Number == 1062)
                {
                    MessageBox.Show("Error: Ya existe un libro con ese nombre.", "Error de Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        }

        private void LimpiarCampos()
        {
            TxtNombre.Text = "";
            TxtAutor.Text = "";
            TxtPrecio.Text = "";
            TxtStock.Text = "";

            DtpFechaPublicacion.Value = DateTime.Now;

            TxtNombre.Focus();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
