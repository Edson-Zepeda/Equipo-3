using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Configuration;
using System.Data.SQLite;

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

        private static string GetConnStr()
        {
            var cs = ConfigurationManager.ConnectionStrings["Prototipo2"];
            return cs != null ? cs.ConnectionString : "Data Source=prototipo2.db;Version=3;";
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

            string cadenaConexion = GetConnStr();

            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
                {
                    conexion.Open();

                    string consulta = "INSERT INTO libros (nombre, autor, precio, fecha_publicacion, stock) VALUES (@nombre, @autor, @precio, @fecha, @stock)";

                    using (SQLiteCommand comando = new SQLiteCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@nombre", nombre);
                        comando.Parameters.AddWithValue("@autor", autor);
                        comando.Parameters.AddWithValue("@precio", precio);
                        comando.Parameters.AddWithValue("@fecha", fecha);
                        comando.Parameters.AddWithValue("@stock", stock);

                        int filasAfectadas = comando.ExecuteNonQuery();

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
            catch (Exception ex)
            {
                MessageBox.Show("Error de base de datos: " + ex.Message);
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
