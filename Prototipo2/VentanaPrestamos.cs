using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using Prototipo2.Data;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Diagnostics;
using System.ComponentModel;

namespace Prototipo2
{
    // Préstamos de ejemplares (biblioteca simple).
    // - Presta un ejemplar a un socio si está ACTIVO y el ejemplar DISPONIBLE.
    // - Registra devolución y vuelve el ejemplar a DISPONIBLE.
    [DesignerCategory("Form")]
    public partial class VentanaPrestamos : Form
    {
        // Controles básicos
        private TextBox txtDocSocio;
        private TextBox txtCodigoEjemplar;
        private DateTimePicker dtVencimiento;
        private Button btnPrestar;
        private Button btnDevolver;
        private Button btnCerrar;
        private Label lblEstado;
        private Label lblDocSocio;
        private Label lblCodigo;
        private Label lblVencimiento;
        private Label _progress; // indicador textual de progreso

        public VentanaPrestamos()
        {
            InitializeComponent();
        }

        private static string GetConnStr()
        {
            var cs = ConfigurationManager.ConnectionStrings["Prototipo2"]; if (cs != null) return cs.ConnectionString; return "Data Source=prototipo2.db;Version=3;";
        }

        private void ShowProgress(bool show)
        {
            if (_progress != null)
            {
                _progress.Visible = show;
                _progress.Text = show ? "Procesando..." : string.Empty;
            }

            UseWaitCursor = show;
            Cursor.Current = show ? Cursors.WaitCursor : Cursors.Default;

            foreach (Control c in Controls)
            {
                c.Enabled = !show || c == _progress;
            }
        }

        private async void BtnPrestar_Click(object sender, EventArgs e)
        {
            await Task.Yield();

            string doc = txtDocSocio.Text.Trim();
            string codigo = txtCodigoEjemplar.Text.Trim();

            if (string.IsNullOrEmpty(doc) || string.IsNullOrEmpty(codigo))
            {
                MessageBox.Show("Campos requeridos");
                return;
            }

            ShowProgress(true);
            try
            {
                await Task.Run(() =>
                {
                    AyudanteBD.EjecutarEnTransaccion((SQLiteConnection cn, SQLiteTransaction tx) =>
                    {
                        int socioId = 0;
                        SQLiteCommand cmd = new SQLiteCommand("SELECT id FROM socios WHERE documento=@d AND estado='ACTIVO'", cn);
                        cmd.Transaction = tx;
                        cmd.Parameters.AddWithValue("@d", doc);
                        object r = cmd.ExecuteScalar();
                        if (r != null) socioId = Convert.ToInt32(r);

                        if (socioId == 0) throw new Exception("Socio no encontrado o inactivo.");

                        int ejemplarId = 0;
                        SQLiteCommand cmd2 = new SQLiteCommand("SELECT id FROM ejemplares WHERE codigo_barra=@c AND estado='DISPONIBLE'", cn);
                        cmd2.Transaction = tx;
                        cmd2.Parameters.AddWithValue("@c", codigo);
                        object r2 = cmd2.ExecuteScalar();
                        if (r2 != null) ejemplarId = Convert.ToInt32(r2);

                        if (ejemplarId == 0) throw new Exception("Ejemplar no disponible.");

                        SQLiteCommand cmd3 = new SQLiteCommand("INSERT INTO prestamos (socio_id, ejemplar_id, fecha_prestamo, fecha_vencimiento, estado) VALUES (@s,@e,CURRENT_TIMESTAMP,@v,'ACTIVO')", cn);
                        cmd3.Transaction = tx;
                        cmd3.Parameters.AddWithValue("@s", socioId);
                        cmd3.Parameters.AddWithValue("@e", ejemplarId);
                        cmd3.Parameters.AddWithValue("@v", dtVencimiento.Value);
                        cmd3.ExecuteNonQuery();

                        SQLiteCommand cmd4 = new SQLiteCommand("UPDATE ejemplares SET estado='PRESTADO' WHERE id=@e", cn);
                        cmd4.Transaction = tx;
                        cmd4.Parameters.AddWithValue("@e", ejemplarId);
                        cmd4.ExecuteNonQuery();

                        SQLiteCommand cmd5 = new SQLiteCommand("INSERT INTO auditoria (usuario_id, accion, entidad, entidad_id, fecha, detalle) VALUES (@u,'PRESTAR','PRESTAMO',NULL,CURRENT_TIMESTAMP,@d)", cn);
                        cmd5.Transaction = tx;
                        cmd5.Parameters.AddWithValue("@u", DBNull.Value);
                        cmd5.Parameters.AddWithValue("@d", "Socio:" + socioId.ToString() + ";Ejemplar:" + ejemplarId.ToString());
                        cmd5.ExecuteNonQuery();
                    });
                });

                lblEstado.Text = "Préstamo creado correctamente.";
                Trace.WriteLine("Préstamo creado para ejemplar " + txtCodigoEjemplar.Text.Trim() + " por socio " + txtDocSocio.Text.Trim());
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Error al crear préstamo: " + ex.Message);
                MessageBox.Show("Error al prestar: " + ex.Message);
            }
            finally
            {
                ShowProgress(false);
            }
        }

        private async void BtnDevolver_Click(object sender, EventArgs e)
        {
            await Task.Yield();

            string codigo = txtCodigoEjemplar.Text.Trim();

            if (string.IsNullOrEmpty(codigo))
            {
                MessageBox.Show("Código requerido");
                return;
            }

            ShowProgress(true);
            try
            {
                await Task.Run(() =>
                {
                    AyudanteBD.EjecutarEnTransaccion((SQLiteConnection cn, SQLiteTransaction tx) =>
                    {
                        int ejemplarId = 0;
                        SQLiteCommand cmd = new SQLiteCommand("SELECT id FROM ejemplares WHERE codigo_barra=@c", cn);
                        cmd.Transaction = tx;
                        cmd.Parameters.AddWithValue("@c", codigo);
                        object r = cmd.ExecuteScalar();
                        if (r != null) ejemplarId = Convert.ToInt32(r);

                        if (ejemplarId == 0) throw new Exception("Ejemplar no existe");

                        SQLiteCommand cmd2 = new SQLiteCommand("UPDATE prestamos SET fecha_devolucion=CURRENT_TIMESTAMP, estado='DEVUELTO' WHERE ejemplar_id=@e AND estado='ACTIVO'", cn);
                        cmd2.Transaction = tx;
                        cmd2.Parameters.AddWithValue("@e", ejemplarId);
                        cmd2.ExecuteNonQuery();

                        SQLiteCommand cmd3 = new SQLiteCommand("UPDATE ejemplares SET estado='DISPONIBLE' WHERE id=@e", cn);
                        cmd3.Transaction = tx;
                        cmd3.Parameters.AddWithValue("@e", ejemplarId);
                        cmd3.ExecuteNonQuery();

                        SQLiteCommand cmd4 = new SQLiteCommand("INSERT INTO auditoria (usuario_id, accion, entidad, entidad_id, fecha, detalle) VALUES (@u,'DEVOLVER','PRESTAMO',NULL,CURRENT_TIMESTAMP,@d)", cn);
                        cmd4.Transaction = tx;
                        cmd4.Parameters.AddWithValue("@u", DBNull.Value);
                        cmd4.Parameters.AddWithValue("@d", "Ejemplar:" + ejemplarId.ToString());
                        cmd4.ExecuteNonQuery();
                    });
                });

                lblEstado.Text = "Devolución registrada.";
                Trace.WriteLine("Devolución para ejemplar " + codigo);
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Error al devolver: " + ex.Message);
                MessageBox.Show("Error al devolver: " + ex.Message);
            }
            finally
            {
                ShowProgress(false);
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VentanaPrestamos_Load(object sender, EventArgs e)
        {
            // nada por ahora
        }

        private void InitializeComponent()
        {
            this.lblDocSocio = new System.Windows.Forms.Label();
            this.txtDocSocio = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigoEjemplar = new System.Windows.Forms.TextBox();
            this.lblVencimiento = new System.Windows.Forms.Label();
            this.dtVencimiento = new System.Windows.Forms.DateTimePicker();
            this.btnPrestar = new System.Windows.Forms.Button();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this._progress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // VentanaPrestamos (propiedades de Form)
            // 
            this.Text = "Préstamos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Width = 520;
            this.Height = 260;
            // 
            // lblDocSocio
            // 
            this.lblDocSocio.Left = 20;
            this.lblDocSocio.Top = 20;
            this.lblDocSocio.Width = 120;
            this.lblDocSocio.Text = "Doc. Socio:";
            // 
            // txtDocSocio
            // 
            this.txtDocSocio.Left = 150;
            this.txtDocSocio.Top = 18;
            this.txtDocSocio.Width = 160;
            // 
            // lblCodigo
            // 
            this.lblCodigo.Left = 20;
            this.lblCodigo.Top = 60;
            this.lblCodigo.Width = 120;
            this.lblCodigo.Text = "Código Ejemplar:";
            // 
            // txtCodigoEjemplar
            // 
            this.txtCodigoEjemplar.Left = 150;
            this.txtCodigoEjemplar.Top = 58;
            this.txtCodigoEjemplar.Width = 160;
            // 
            // lblVencimiento
            // 
            this.lblVencimiento.Left = 20;
            this.lblVencimiento.Top = 100;
            this.lblVencimiento.Width = 120;
            this.lblVencimiento.Text = "Vencimiento:";
            // 
            // dtVencimiento
            // 
            this.dtVencimiento.Left = 150;
            this.dtVencimiento.Top = 98;
            this.dtVencimiento.Width = 160;
            // 
            // btnPrestar
            // 
            this.btnPrestar.Left = 330;
            this.btnPrestar.Top = 18;
            this.btnPrestar.Width = 150;
            this.btnPrestar.Text = "Prestar";
            this.btnPrestar.Click += new System.EventHandler(this.BtnPrestar_Click);
            // 
            // btnDevolver
            // 
            this.btnDevolver.Left = 330;
            this.btnDevolver.Top = 58;
            this.btnDevolver.Width = 150;
            this.btnDevolver.Text = "Registrar devolución";
            this.btnDevolver.Click += new System.EventHandler(this.BtnDevolver_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Left = 330;
            this.btnCerrar.Top = 98;
            this.btnCerrar.Width = 150;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.Left = 20;
            this.lblEstado.Top = 150;
            this.lblEstado.Width = 460;
            this.lblEstado.Height = 25;
            this.lblEstado.Text = "";
            // 
            // _progress
            // 
            this._progress.Left = 20;
            this._progress.Top = 180;
            this._progress.Width = 460;
            this._progress.Height = 25;
            this._progress.Visible = false;
            this._progress.Text = "Procesando...";
            // 
            // Add controls
            // 
            this.Controls.Add(this.lblDocSocio);
            this.Controls.Add(this.txtDocSocio);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.txtCodigoEjemplar);
            this.Controls.Add(this.lblVencimiento);
            this.Controls.Add(this.dtVencimiento);
            this.Controls.Add(this.btnPrestar);
            this.Controls.Add(this.btnDevolver);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this._progress);
            // 
            // Load event
            // 
            this.Load += new System.EventHandler(this.VentanaPrestamos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void lblEstado_Click(object sender, EventArgs e) { }
        private void lblDocSocio_Click(object sender, EventArgs e) { }
    }
}
