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
    [DesignerCategory("Form")]
    public partial class VentanaPrestamos : Form
    {
        public VentanaPrestamos()
        {
            InitializeComponent();
        }

        private static string GetConnStr()
        {
            System.Configuration.ConnectionStringSettings cs = ConfigurationManager.ConnectionStrings["Prototipo2"];
            if (cs != null)
            {
                return cs.ConnectionString;
            }
            else
            {
                return "Data Source=prototipo2.db;Version=3;";
            }
        }

        private void ShowProgress(bool show)
        {
            if (_progress != null)
                _progress.Visible = show;
            UseWaitCursor = show;
            Cursor.Current = show ? Cursors.WaitCursor : Cursors.Default;
            foreach (Control c in Controls) c.Enabled = !show || c == _progress;
        }

        private async void BtnPrestar_Click(object sender, EventArgs e)
        {
            await Task.Yield();
            string doc = txtDocSocio.Text.Trim();
            string codigo = txtCodigoEjemplar.Text.Trim();
            if (string.IsNullOrEmpty(doc) || string.IsNullOrEmpty(codigo)) { MessageBox.Show("Campos requeridos"); return; }

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
            if (string.IsNullOrEmpty(codigo)) { MessageBox.Show("Código requerido"); return; }

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

        }
    }
}
