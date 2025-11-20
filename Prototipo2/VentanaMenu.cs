using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototipo2
{
    public partial class VentanaMenu : Form
    {

        private bool esAdmin;
        private int idUsuarioLogueado;
        public VentanaMenu(bool admin, int idUsuario)
        {
            InitializeComponent();

            this.esAdmin = admin;
            this.idUsuarioLogueado = idUsuario;
        }

        private void VentanaMenu_Load(object sender, EventArgs e)
        {
            if(this.esAdmin == true)
            {
                GrbAdmin.Visible = true;
            }
            else
            {
                GrbAdmin.Visible = false;
            }
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sesión cerrada exitosamente", "Cierre de sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Application.Restart();   
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.Hide();

            VentanaBuscar frmBuscar = new VentanaBuscar();
            frmBuscar.ShowDialog();

            this.Show();
        }

        private void BtnVentas_Click(object sender, EventArgs e)
        {
            this.Hide();

            VentanaVentas frmventas = new VentanaVentas(this.idUsuarioLogueado);
            frmventas.ShowDialog();

            this.Show();
        }

        private void BtnCorte_Click(object sender, EventArgs e)
        {
            this.Hide();

            VentanaCorte frmcorte = new VentanaCorte(this.idUsuarioLogueado);
            frmcorte.ShowDialog();

            this.Show();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Quieres cerrar la applicación?","Cerrar aplicación",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);

            if (respuesta == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            this.Hide();

            VentanaEliminar frmEliminar = new VentanaEliminar();
            frmEliminar.ShowDialog();

            this.Show();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            this.Hide();

            VentanaGuardar frmGuardar = new VentanaGuardar();
            frmGuardar.ShowDialog();

            this.Show();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            this.Hide();

            VentanaModificar frmModificar = new VentanaModificar();
            frmModificar.ShowDialog();

            this.Show();
        }

        private void BtnCatalogo_Click(object sender, EventArgs e)
        {
            this.Hide();

            VentanaUsuarios frmUsuarios = new VentanaUsuarios();
            frmUsuarios.ShowDialog();

            this.Show();
        }

        private void BtnSocios_Click(object sender, EventArgs e)
        {
            // VentanaSocios was removed — show placeholder message
            MessageBox.Show("La funcionalidad de Socios no está disponible en esta versión.", "No disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnPrestamos_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frm = new VentanaPrestamos();
            frm.ShowDialog();
            this.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
