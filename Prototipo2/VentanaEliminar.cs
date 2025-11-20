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
    public partial class VentanaEliminar : Form
    {
        private static string GetConnStr()
        {
            var cs = ConfigurationManager.ConnectionStrings["Prototipo2"];
            return cs != null ? cs.ConnectionString : "Data Source=prototipo2.db;Version=3;";
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

            string consulta = "";
            string valorParametro = "";

            if (RdbExacta.Checked)
            {
                consulta = "SELECT id, nombre, autor, precio, stock FROM libros WHERE nombre = @termino OR autor = @termino";
                valorParametro = termino;
            }
            else if (RdbAproximada.Checked)
            {
                consulta = "SELECT id, nombre, autor, precio, stock FROM libros WHERE nombre LIKE @termino OR autor LIKE @termino";
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

            SQLiteConnection conexion = null;
            SQLiteCommand comando = null;
            SQLiteDataReader lector = null;

            try
            {
                conexion = new SQLiteConnection(cadenaConexion);
                conexion.Open();
                comando = new SQLiteCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@termino", valorParametro);
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    ListViewItem elemento = new ListViewItem(lector["nombre"].ToString());
                    elemento.SubItems.Add(lector["autor"].ToString());
                    elemento.SubItems.Add(lector["precio"].ToString());
                    elemento.SubItems.Add(lector["stock"].ToString());

                    elemento.Tag = Convert.ToInt32(lector["id"]);

                    LvRegistros.Items.Add(elemento);
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
                if (lector != null)
                {
                    lector.Close();
                    lector.Dispose();
                }
                if (comando != null) comando.Dispose();
                if (conexion != null)
                {
                    if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                    conexion.Dispose();
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

            ListViewItem elementoSeleccionado = LvRegistros.SelectedItems[0];
            string nombreLibro = elementoSeleccionado.SubItems[0].Text;
            int idParaEliminar = (int)elementoSeleccionado.Tag;

            DialogResult confirmacion = MessageBox.Show($"¿Estás seguro de que quieres eliminar permanentemente el libro:\n\n'{nombreLibro}'?","Confirmar Eliminación",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

            if (confirmacion != DialogResult.Yes) return;

            string cadenaConexion = GetConnStr();
            SQLiteConnection conexion = null;
            SQLiteCommand comando = null;

            try
            {
                conexion = new SQLiteConnection(cadenaConexion);
                conexion.Open();

                string consulta = "DELETE FROM libros WHERE id = @id";
                comando = new SQLiteCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@id", idParaEliminar);

                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Libro eliminado con éxito.");
                    LvRegistros.Items.Remove(elementoSeleccionado);
                    LblCuenta.Text = "TOTAL DE REGISTROS: " + LvRegistros.Items.Count;
                }
                else
                {
                    MessageBox.Show("Error: No se pudo eliminar el libro (no se encontró).");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (comando != null) comando.Dispose();
                if (conexion != null)
                {
                    if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
                    conexion.Dispose();
                }
            }

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LvRegistros_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
