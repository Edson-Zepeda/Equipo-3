using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Configuration;

namespace Prototipo2
{
    // Pantalla principal (menú).
    // - Muestra botones para navegar a las demás pantallas.
    // - Habilita opciones de administrador según el rol.
    // - Nota: Hay varios manejadores "stubs" (vacíos) agregados para satisfacer
    //   eventos del Diseñador. Esto es común en proyectos principiantes.
    public partial class VentanaMenu : Form
    {
        private bool esAdmin;               // true = usuario administrador
        private int idUsuarioLogueado;      // id del usuario actual
        private int bordersize = 2;         // sin uso real; lo deja el diseñador


        public VentanaMenu(bool admin, int idUsuario)
        {
            InitializeComponent();
            this.esAdmin = admin;
            this.idUsuarioLogueado = idUsuario;
        }


        private void VentanaMenu_Load(object sender, EventArgs e)
        {
            // Si no es admin, se oculta el grupo de acciones de administración
            if (this.esAdmin == true)
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
            // Cierra sesión de forma simple reiniciando la app
            MessageBox.Show("Sesión cerrada exitosamente", "Cierre de sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart();
        }


        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            // Navegación: abrir ventana de búsqueda de libros
            this.Hide();

            VentanaBuscar frmBuscar = new VentanaBuscar();
            frmBuscar.ShowDialog();

            this.Show();
        }


        private void BtnVentas_Click(object sender, EventArgs e)
        {
            // Navegación: abrir ventas, pasando id del usuario
            this.Hide();

            VentanaVentas frmventas = new VentanaVentas(this.idUsuarioLogueado);
            frmventas.ShowDialog();

            this.Show();
        }


        private void BtnCorte_Click(object sender, EventArgs e)
        {
            // Navegación: abrir corte de caja del día
            this.Hide();

            VentanaCorte frmcorte = new VentanaCorte(this.idUsuarioLogueado);
            frmcorte.ShowDialog();

            this.Show();
        }


        private void BtnSalir_Click(object sender, EventArgs e)
        {
            // Sale completamente de la aplicación
            DialogResult respuesta = MessageBox.Show("¿Quieres cerrar la applicación?", "Cerrar aplicación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (respuesta == DialogResult.OK)
            {
                Application.Exit();
            }
        }


        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Navegación: eliminar libros
            this.Hide();

            VentanaEliminar frmEliminar = new VentanaEliminar();
            frmEliminar.ShowDialog();

            this.Show();
        }


        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Navegación: agregar/guardar libros
            this.Hide();

            VentanaGuardar frmGuardar = new VentanaGuardar();
            frmGuardar.ShowDialog();

            this.Show();
        }


        private void BtnModificar_Click(object sender, EventArgs e)
        {
            // Navegación: modificar libros existentes
            this.Hide();

            VentanaModificar frmModificar = new VentanaModificar();
            frmModificar.ShowDialog();

            this.Show();
        }


        private void BtnCatalogo_Click(object sender, EventArgs e)
        {
            // Navegación: catálogo de usuarios
            this.Hide();

            VentanaUsuarios frmUsuarios = new VentanaUsuarios();
            frmUsuarios.ShowDialog();

            this.Show();
        }


        private void BtnCorte2_Click(object sender, EventArgs e)
        {
            // Botón alterno que reutiliza la misma acción
            BtnCorte_Click(sender, e);
        }


        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // Dibujo del panel principal (no se usa, pero queda el evento conectado)
        private void PnlDesktop_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                // pintar fondo si se necesita
            }
            catch
            {
            }
        }


        // Botón cerrar del header personalizado
        private void BtnCerrar_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch
            {
            }
        }


        // Botón minimizar del header personalizado
        private void BtnMinimizar_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Minimized;
            }
            catch
            {
            }
        }


        // Redimensionado de la ventana (no se usa por ahora)
        private void VentanaMenu_Resize(object sender, EventArgs e)
        {
            try
            {
                // ajustar controles si se requiere
            }
            catch
            {
            }
        }
    }
}
