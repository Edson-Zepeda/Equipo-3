using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Threading.Tasks;
using Prototipo2.Logging;

namespace Prototipo2
{
    public partial class VentanaSocios : Form
    {
        private static string GetConnStr()
        {
            var cs = ConfigurationManager.ConnectionStrings["Prototipo2"]; 
            return cs != null ? cs.ConnectionString : "server=127.0.0.1;port=3307;database=prototipo2_db;uid=appuser;pwd=apppass123;";
        }

        private class SocioRow
        {
            public int Id;
            public string Nombre;
            public string Documento;
            public string Email;
            public string Estado;
        }

        public VentanaSocios()
        {
            InitializeComponent();
        }

        private ListView lv;
        private TextBox txtNombre;
        private TextBox txtDocumento;
        private TextBox txtEmail;
        private TextBox txtBuscar;
        private Button btnAgregar;
        private Button btnRefrescar;
        private Button btnCerrar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnBuscar;
        private Label lblCount;
        private ProgressBar _progress;
        private int selectedId = 0;

        private void InitializeComponent()
        {
            this.Text = "Socios";
            this.Width = 820;
            this.Height = 600;

            // ListView
            lv = new ListView();
            lv.View = View.Details;
            lv.FullRowSelect = true;
            lv.GridLines = true;
            lv.Left = 10;
            lv.Top = 40;
            lv.Width = 780;
            lv.Height = 350;
            lv.Columns.Add("ID", 60);
            lv.Columns.Add("Nombre", 220);
            lv.Columns.Add("Documento", 150);
            lv.Columns.Add("Email", 200);
            lv.Columns.Add("Estado", 100);
            lv.SelectedIndexChanged += Lv_SelectedIndexChanged;
            this.Controls.Add(lv);

            // Search label
            Label lblSearch = new Label();
            lblSearch.Left = 10;
            lblSearch.Top = 12;
            lblSearch.Text = "Buscar:";
            this.Controls.Add(lblSearch);

            // Search textbox
            txtBuscar = new TextBox();
            txtBuscar.Left = 70;
            txtBuscar.Top = 8;
            txtBuscar.Width = 300;
            this.Controls.Add(txtBuscar);

            // Buscar button
            btnBuscar = new Button();
            btnBuscar.Left = 380;
            btnBuscar.Top = 6;
            btnBuscar.Width = 100;
            btnBuscar.Text = "Buscar";
            btnBuscar.Click += BtnBuscar_Click;
            this.Controls.Add(btnBuscar);

            // Refrescar button
            btnRefrescar = new Button();
            btnRefrescar.Left = 490;
            btnRefrescar.Top = 6;
            btnRefrescar.Width = 120;
            btnRefrescar.Text = "Refrescar";
            btnRefrescar.Click += BtnRefrescar_Click;
            this.Controls.Add(btnRefrescar);

            // Nombre label and textbox
            Label lblN = new Label();
            lblN.Left = 10;
            lblN.Top = 410;
            lblN.Text = "Nombre:";
            this.Controls.Add(lblN);

            txtNombre = new TextBox();
            txtNombre.Left = 70;
            txtNombre.Top = 406;
            txtNombre.Width = 300;
            this.Controls.Add(txtNombre);

            // Documento label and textbox
            Label lblD = new Label();
            lblD.Left = 380;
            lblD.Top = 410;
            lblD.Text = "Documento:";
            this.Controls.Add(lblD);

            txtDocumento = new TextBox();
            txtDocumento.Left = 450;
            txtDocumento.Top = 406;
            txtDocumento.Width = 200;
            this.Controls.Add(txtDocumento);

            // Email label and textbox
            Label lblE = new Label();
            lblE.Left = 10;
            lblE.Top = 440;
            lblE.Text = "Email:";
            this.Controls.Add(lblE);

            txtEmail = new TextBox();
            txtEmail.Left = 70;
            txtEmail.Top = 436;
            txtEmail.Width = 300;
            this.Controls.Add(txtEmail);

            // Buttons: Agregar, Editar, Eliminar, Cerrar
            btnAgregar = new Button();
            btnAgregar.Left = 10;
            btnAgregar.Top = 480;
            btnAgregar.Width = 120;
            btnAgregar.Text = "Agregar";
            btnAgregar.Click += BtnAgregar_Click;
            this.Controls.Add(btnAgregar);

            btnEditar = new Button();
            btnEditar.Left = 140;
            btnEditar.Top = 480;
            btnEditar.Width = 120;
            btnEditar.Text = "Editar";
            btnEditar.Click += BtnEditar_Click;
            this.Controls.Add(btnEditar);

            btnEliminar = new Button();
            btnEliminar.Left = 270;
            btnEliminar.Top = 480;
            btnEliminar.Width = 120;
            btnEliminar.Text = "Eliminar";
            btnEliminar.Click += BtnEliminar_Click;
            this.Controls.Add(btnEliminar);

            btnCerrar = new Button();
            btnCerrar.Left = 670;
            btnCerrar.Top = 480;
            btnCerrar.Width = 120;
            btnCerrar.Text = "Cerrar";
            btnCerrar.Click += (s, e) => this.Close();
            this.Controls.Add(btnCerrar);

            // Count label
            lblCount = new Label();
            lblCount.Left = 10;
            lblCount.Top = 520;
            lblCount.Width = 400;
            lblCount.Text = "TOTAL: 0";
            this.Controls.Add(lblCount);

            // Progress bar
            _progress = new ProgressBar();
            _progress.Style = ProgressBarStyle.Marquee;
            _progress.MarqueeAnimationSpeed = 30;
            _progress.Visible = false;
            _progress.Height = 12;
            _progress.Dock = DockStyle.Bottom;
            this.Controls.Add(_progress);

            this.Load += async (s, e) => await CargarSociosAsync();
        }

        private void ShowProgress(bool show)
        {
            if (_progress != null)
                _progress.Visible = show;
            UseWaitCursor = show;
            Cursor.Current = show ? Cursors.WaitCursor : Cursors.Default;
            foreach (Control c in Controls)
            {
                if (c == _progress) continue;
                c.Enabled = !show;
            }
        }

        private List<SocioRow> ConsultarSociosInterno(string termino = null)
        {
            var lista = new List<SocioRow>();
            string cs = GetConnStr();
            MySqlConnection cn = null; MySqlCommand cmd = null; MySqlDataReader rd = null;
            try
            {
                cn = new MySqlConnection(cs); cn.Open();
                if (string.IsNullOrEmpty(termino))
                {
                    string q = "SELECT id, nombre, documento, email, estado FROM socios ORDER BY id DESC";
                    cmd = new MySqlCommand(q, cn);
                }
                else
                {
                    string q = "SELECT id, nombre, documento, email, estado FROM socios WHERE nombre LIKE @t OR documento LIKE @t ORDER BY id DESC";
                    cmd = new MySqlCommand(q, cn);
                    cmd.Parameters.AddWithValue("@t", "%" + termino + "%");
                }
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    lista.Add(new SocioRow {
                        Id = rd.GetInt32("id"),
                        Nombre = rd["nombre"].ToString(),
                        Documento = rd["documento"].ToString(),
                        Email = rd["email"].ToString(),
                        Estado = rd["estado"].ToString()
                    });
                }
            }
            finally
            {
                if (rd != null) { rd.Close(); rd.Dispose(); }
                if (cmd != null) cmd.Dispose();
                if (cn != null) { if (cn.State == ConnectionState.Open) cn.Close(); cn.Dispose(); }
            }
            return lista;
        }

        private async Task CargarSociosAsync(string termino = null)
        {
            ShowProgress(true);
            try
            {
                var datos = await Task.Run(() => ConsultarSociosInterno(termino));
                lv.Items.Clear();
                int total = 0;
                foreach (var r in datos)
                {
                    var it = new ListViewItem(r.Id.ToString());
                    it.SubItems.Add(r.Nombre);
                    it.SubItems.Add(r.Documento);
                    it.SubItems.Add(r.Email);
                    it.SubItems.Add(r.Estado);
                    it.Tag = r.Id;
                    lv.Items.Add(it); total++;
                }
                lblCount.Text = "TOTAL: " + total;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar socios: " + ex.Message);
            }
            finally
            {
                ShowProgress(false);
            }
        }

        private async void BtnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string doc = txtDocumento.Text.Trim();
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(doc))
            { MessageBox.Show("Nombre y Documento son obligatorios."); return; }

            ShowProgress(true);
            try
            {
                await Task.Run(() =>
                {
                    string cs = GetConnStr();
                    MySqlConnection cn = null; MySqlCommand cmd = null;
                    try
                    {
                        cn = new MySqlConnection(cs); cn.Open();
                        string q = "INSERT INTO socios (nombre, documento, email, estado, fecha_alta) VALUES (@n,@d,@e,'ACTIVO', NOW())";
                        cmd = new MySqlCommand(q, cn);
                        cmd.Parameters.AddWithValue("@n", nombre);
                        cmd.Parameters.AddWithValue("@d", doc);
                        cmd.Parameters.AddWithValue("@e", email);
                        cmd.ExecuteNonQuery();
                    }
                    finally
                    {
                        if (cmd != null) cmd.Dispose();
                        if (cn != null) { if (cn.State == ConnectionState.Open) cn.Close(); cn.Dispose(); }
                    }
                });

                SimpleLogger.Info($"Socio agregado: {nombre} ({doc})");
                MessageBox.Show("Socio agregado.");
                txtNombre.Text = txtDocumento.Text = txtEmail.Text = "";
                await CargarSociosAsync();
            }
            catch (Exception ex)
            {
                SimpleLogger.Error("Error al agregar socio: " + ex.Message);
                MessageBox.Show("Error al agregar socio: " + ex.Message);
            }
            finally
            {
                ShowProgress(false);
            }
        }

        private void Lv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv.SelectedItems.Count == 0)
            {
                selectedId = 0;
                txtNombre.Text = txtDocumento.Text = txtEmail.Text = "";
                return;
            }

            var item = lv.SelectedItems[0];
            selectedId = (int)item.Tag;
            txtNombre.Text = item.SubItems[1].Text;
            txtDocumento.Text = item.SubItems[2].Text;
            txtEmail.Text = item.SubItems[3].Text;
        }

        private async void BtnEditar_Click(object sender, EventArgs e)
        {
            if (selectedId == 0) { MessageBox.Show("Seleccione un socio para editar."); return; }
            string nombre = txtNombre.Text.Trim();
            string doc = txtDocumento.Text.Trim();
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(doc)) { MessageBox.Show("Nombre y Documento son obligatorios."); return; }

            ShowProgress(true);
            try
            {
                await Task.Run(() =>
                {
                    string cs = GetConnStr();
                    MySqlConnection cn = null; MySqlCommand cmd = null;
                    try
                    {
                        cn = new MySqlConnection(cs); cn.Open();
                        string q = "UPDATE socios SET nombre=@n, documento=@d, email=@e WHERE id=@id";
                        cmd = new MySqlCommand(q, cn);
                        cmd.Parameters.AddWithValue("@n", nombre);
                        cmd.Parameters.AddWithValue("@d", doc);
                        cmd.Parameters.AddWithValue("@e", email);
                        cmd.Parameters.AddWithValue("@id", selectedId);
                        cmd.ExecuteNonQuery();
                    }
                    finally
                    {
                        if (cmd != null) cmd.Dispose();
                        if (cn != null) { if (cn.State == ConnectionState.Open) cn.Close(); cn.Dispose(); }
                    }
                });

                SimpleLogger.Info($"Socio actualizado: ID={selectedId} -> {nombre} ({doc})");
                MessageBox.Show("Socio actualizado.");
                await CargarSociosAsync();
            }
            catch (Exception ex)
            {
                SimpleLogger.Error("Error al editar socio: " + ex.Message);
                MessageBox.Show("Error al editar socio: " + ex.Message);
            }
            finally
            {
                ShowProgress(false);
            }
        }

        private async void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (selectedId == 0) { MessageBox.Show("Seleccione un socio para eliminar."); return; }
            var res = MessageBox.Show("¿Seguro que desea eliminar este socio?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res != DialogResult.Yes) return;

            ShowProgress(true);
            try
            {
                await Task.Run(() =>
                {
                    string cs = GetConnStr();
                    MySqlConnection cn = null; MySqlCommand cmd = null;
                    try
                    {
                        cn = new MySqlConnection(cs); cn.Open();
                        string q = "DELETE FROM socios WHERE id=@id";
                        cmd = new MySqlCommand(q, cn);
                        cmd.Parameters.AddWithValue("@id", selectedId);
                        cmd.ExecuteNonQuery();
                    }
                    finally
                    {
                        if (cmd != null) cmd.Dispose();
                        if (cn != null) { if (cn.State == ConnectionState.Open) cn.Close(); cn.Dispose(); }
                    }
                });

                SimpleLogger.Info($"Socio eliminado: ID={selectedId}");
                MessageBox.Show("Socio eliminado.");
                txtNombre.Text = txtDocumento.Text = txtEmail.Text = "";
                selectedId = 0;
                await CargarSociosAsync();
            }
            catch (Exception ex)
            {
                SimpleLogger.Error("Error al eliminar socio: " + ex.Message);
                MessageBox.Show("Error al eliminar socio: " + ex.Message);
            }
            finally
            {
                ShowProgress(false);
            }
        }

        private async void BtnRefrescar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            await CargarSociosAsync();
        }

        private async void BtnBuscar_Click(object sender, EventArgs e)
        {
            string termino = txtBuscar.Text.Trim();
            await CargarSociosAsync(termino);
        }
    }
}
