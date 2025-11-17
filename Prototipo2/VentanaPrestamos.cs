using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using Prototipo2.Data;
using Prototipo2.Logging;
using System.Threading.Tasks;

namespace Prototipo2
{
    public partial class VentanaPrestamos : Form
    {
        private static string GetConnStr()
        {
            var cs = ConfigurationManager.ConnectionStrings["Prototipo2"];
            return cs != null ? cs.ConnectionString : "server=127.0.0.1;port=3307;database=prototipo2_db;uid=appuser;pwd=apppass123;";
        }

        private TextBox txtDocSocio;
        private TextBox txtCodigoEjemplar;
        private DateTimePicker dtVencimiento;
        private Button btnPrestar;
        private Button btnDevolver;
        private Button btnCerrar;
        private Label lblEstado;
        private ProgressBar _progress;

        public VentanaPrestamos()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Préstamos";
            this.Width = 520;
            this.Height = 300;

            Label l1 = new Label();
            l1.Left = 10;
            l1.Top = 20;
            l1.Text = "Documento socio:";

            txtDocSocio = new TextBox();
            txtDocSocio.Left = 130;
            txtDocSocio.Top = 16;
            txtDocSocio.Width = 150;

            Label l2 = new Label();
            l2.Left = 10;
            l2.Top = 50;
            l2.Text = "Código ejemplar:";

            txtCodigoEjemplar = new TextBox();
            txtCodigoEjemplar.Left = 130;
            txtCodigoEjemplar.Top = 46;
            txtCodigoEjemplar.Width = 150;

            Label l3 = new Label();
            l3.Left = 10;
            l3.Top = 80;
            l3.Text = "Vence:";

            dtVencimiento = new DateTimePicker();
            dtVencimiento.Left = 130;
            dtVencimiento.Top = 76;
            dtVencimiento.Width = 200;
            dtVencimiento.Value = DateTime.Now.AddDays(7);

            btnPrestar = new Button();
            btnPrestar.Left = 10;
            btnPrestar.Top = 120;
            btnPrestar.Width = 120;
            btnPrestar.Text = "Prestar";
            btnPrestar.Click += async (s, e) => await BtnPrestar_Click(s, e);

            btnDevolver = new Button();
            btnDevolver.Left = 140;
            btnDevolver.Top = 120;
            btnDevolver.Width = 120;
            btnDevolver.Text = "Devolver";
            btnDevolver.Click += async (s, e) => await BtnDevolver_Click(s, e);

            btnCerrar = new Button();
            btnCerrar.Left = 400;
            btnCerrar.Top = 120;
            btnCerrar.Width = 90;
            btnCerrar.Text = "Cerrar";
            btnCerrar.Click += (s, e) => this.Close();

            lblEstado = new Label();
            lblEstado.Left = 10;
            lblEstado.Top = 160;
            lblEstado.Width = 480;
            lblEstado.Text = "";

            _progress = new ProgressBar();
            _progress.Style = ProgressBarStyle.Marquee;
            _progress.MarqueeAnimationSpeed = 30;
            _progress.Visible = false;
            _progress.Height = 12;
            _progress.Dock = DockStyle.Bottom;

            // Add controls one by one
            this.Controls.Add(l1);
            this.Controls.Add(txtDocSocio);
            this.Controls.Add(l2);
            this.Controls.Add(txtCodigoEjemplar);
            this.Controls.Add(l3);
            this.Controls.Add(dtVencimiento);
            this.Controls.Add(btnPrestar);
            this.Controls.Add(btnDevolver);
            this.Controls.Add(btnCerrar);
            this.Controls.Add(lblEstado);
            this.Controls.Add(_progress);
        }

        private void ShowProgress(bool show)
        {
            if (_progress != null)
                _progress.Visible = show;
            UseWaitCursor = show;
            Cursor.Current = show ? Cursors.WaitCursor : Cursors.Default;
            foreach (Control c in Controls) c.Enabled = !show || c == _progress;
        }

        private async Task BtnPrestar_Click(object sender, EventArgs e)
        {
            string doc = txtDocSocio.Text.Trim();
            string codigo = txtCodigoEjemplar.Text.Trim();
            if (string.IsNullOrEmpty(doc) || string.IsNullOrEmpty(codigo)) { MessageBox.Show("Campos requeridos"); return; }

            ShowProgress(true);
            try
            {
                await Task.Run(() =>
                {
                    DbHelper.ExecuteInTransaction((cn, tx) =>
                    {
                        int socioId = 0;
                        using (var cmd = new MySqlCommand("SELECT id FROM socios WHERE documento=@d AND estado='ACTIVO'", cn, tx))
                        {
                            cmd.Parameters.AddWithValue("@d", doc);
                            var r = cmd.ExecuteScalar();
                            if (r != null) socioId = Convert.ToInt32(r);
                        }
                        if (socioId == 0) throw new Exception("Socio no encontrado o inactivo.");

                        int ejemplarId = 0;
                        using (var cmd = new MySqlCommand("SELECT id FROM ejemplares WHERE codigo_barra=@c AND estado='DISPONIBLE'", cn, tx))
                        {
                            cmd.Parameters.AddWithValue("@c", codigo);
                            var r = cmd.ExecuteScalar();
                            if (r != null) ejemplarId = Convert.ToInt32(r);
                        }
                        if (ejemplarId == 0) throw new Exception("Ejemplar no disponible.");

                        using (var cmd = new MySqlCommand("INSERT INTO prestamos (socio_id, ejemplar_id, fecha_prestamo, fecha_vencimiento, estado) VALUES (@s,@e,NOW(),@v,'ACTIVO')", cn, tx))
                        {
                            cmd.Parameters.AddWithValue("@s", socioId);
                            cmd.Parameters.AddWithValue("@e", ejemplarId);
                            cmd.Parameters.AddWithValue("@v", dtVencimiento.Value);
                            cmd.ExecuteNonQuery();
                        }

                        using (var cmd = new MySqlCommand("UPDATE ejemplares SET estado='PRESTADO' WHERE id=@e", cn, tx))
                        {
                            cmd.Parameters.AddWithValue("@e", ejemplarId);
                            cmd.ExecuteNonQuery();
                        }

                        using (var cmd = new MySqlCommand("INSERT INTO auditoria (usuario_id, accion, entidad, entidad_id, fecha, detalle) VALUES (@u,'PRESTAR','PRESTAMO',NULL,NOW(),@d)", cn, tx))
                        {
                            cmd.Parameters.AddWithValue("@u", DBNull.Value);
                            cmd.Parameters.AddWithValue("@d", $"Socio:{socioId};Ejemplar:{ejemplarId}");
                            cmd.ExecuteNonQuery();
                        }
                    });
                });

                lblEstado.Text = "Préstamo creado correctamente.";
                SimpleLogger.Info($"Préstamo creado para ejemplar {txtCodigoEjemplar.Text.Trim()} por socio {txtDocSocio.Text.Trim()}");
            }
            catch (Exception ex)
            {
                SimpleLogger.Error("Error al crear préstamo: " + ex.Message);
                MessageBox.Show("Error al prestar: " + ex.Message);
            }
            finally
            {
                ShowProgress(false);
            }
        }

        private async Task BtnDevolver_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigoEjemplar.Text.Trim();
            if (string.IsNullOrEmpty(codigo)) { MessageBox.Show("Código requerido"); return; }

            ShowProgress(true);
            try
            {
                await Task.Run(() =>
                {
                    DbHelper.ExecuteInTransaction((cn, tx) =>
                    {
                        int ejemplarId = 0;
                        using (var cmd = new MySqlCommand("SELECT id FROM ejemplares WHERE codigo_barra=@c", cn, tx))
                        {
                            cmd.Parameters.AddWithValue("@c", codigo);
                            var r = cmd.ExecuteScalar();
                            if (r != null) ejemplarId = Convert.ToInt32(r);
                        }
                        if (ejemplarId == 0) throw new Exception("Ejemplar no existe");

                        using (var cmd = new MySqlCommand("UPDATE prestamos SET fecha_devolucion=NOW(), estado='DEVUELTO' WHERE ejemplar_id=@e AND estado='ACTIVO'", cn, tx))
                        {
                            cmd.Parameters.AddWithValue("@e", ejemplarId);
                            cmd.ExecuteNonQuery();
                        }

                        using (var cmd = new MySqlCommand("UPDATE ejemplares SET estado='DISPONIBLE' WHERE id=@e", cn, tx))
                        {
                            cmd.Parameters.AddWithValue("@e", ejemplarId);
                            cmd.ExecuteNonQuery();
                        }

                        using (var cmd = new MySqlCommand("INSERT INTO auditoria (usuario_id, accion, entidad, entidad_id, fecha, detalle) VALUES (@u,'DEVOLVER','PRESTAMO',NULL,NOW(),@d)", cn, tx))
                        {
                            cmd.Parameters.AddWithValue("@u", DBNull.Value);
                            cmd.Parameters.AddWithValue("@d", $"Ejemplar:{ejemplarId}");
                            cmd.ExecuteNonQuery();
                        }
                    });
                });

                lblEstado.Text = "Devolución registrada.";
                SimpleLogger.Info($"Devolución para ejemplar {codigo}");
            }
            catch (Exception ex)
            {
                SimpleLogger.Error("Error al devolver: " + ex.Message);
                MessageBox.Show("Error al devolver: " + ex.Message);
            }
            finally
            {
                ShowProgress(false);
            }
        }
    }
}
