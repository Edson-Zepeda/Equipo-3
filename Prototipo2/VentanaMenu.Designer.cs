namespace Prototipo2
{
    partial class VentanaMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaMenu));
            this.BtnSalir = new System.Windows.Forms.Button();
            this.GrbAdmin = new System.Windows.Forms.GroupBox();
            this.BtnCatalogo = new System.Windows.Forms.Button();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnCerrarSesion = new System.Windows.Forms.Button();
            this.GrbOperativo = new System.Windows.Forms.GroupBox();
            this.BtnCorte = new System.Windows.Forms.Button();
            this.BtnVentas = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.PnlDesktop = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnCerrar = new FontAwesome.Sharp.IconButton();
            this.BtnMinimizar = new FontAwesome.Sharp.IconButton();
            this.GrbAdmin.SuspendLayout();
            this.GrbOperativo.SuspendLayout();
            this.PnlDesktop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnSalir
            // 
            this.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnSalir.Location = new System.Drawing.Point(560, 369);
            this.BtnSalir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(156, 59);
            this.BtnSalir.TabIndex = 18;
            this.BtnSalir.Text = "SALIR";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // GrbAdmin
            // 
            this.GrbAdmin.Controls.Add(this.BtnCatalogo);
            this.GrbAdmin.Controls.Add(this.BtnModificar);
            this.GrbAdmin.Controls.Add(this.BtnEliminar);
            this.GrbAdmin.Controls.Add(this.BtnGuardar);
            this.GrbAdmin.Location = new System.Drawing.Point(344, 246);
            this.GrbAdmin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GrbAdmin.Name = "GrbAdmin";
            this.GrbAdmin.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GrbAdmin.Size = new System.Drawing.Size(363, 103);
            this.GrbAdmin.TabIndex = 20;
            this.GrbAdmin.TabStop = false;
            this.GrbAdmin.Text = "ADMINISTRADOR";
            // 
            // BtnCatalogo
            // 
            this.BtnCatalogo.Location = new System.Drawing.Point(17, 57);
            this.BtnCatalogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnCatalogo.Name = "BtnCatalogo";
            this.BtnCatalogo.Size = new System.Drawing.Size(308, 36);
            this.BtnCatalogo.TabIndex = 13;
            this.BtnCatalogo.Text = "CATALOGO DE USUARIOS";
            this.BtnCatalogo.UseVisualStyleBackColor = true;
            this.BtnCatalogo.Click += new System.EventHandler(this.BtnCatalogo_Click);
            // 
            // BtnModificar
            // 
            this.BtnModificar.Location = new System.Drawing.Point(238, 23);
            this.BtnModificar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(125, 30);
            this.BtnModificar.TabIndex = 10;
            this.BtnModificar.Text = "MODIFICAR";
            this.BtnModificar.UseVisualStyleBackColor = true;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Location = new System.Drawing.Point(0, 23);
            this.BtnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(114, 30);
            this.BtnEliminar.TabIndex = 8;
            this.BtnEliminar.Text = "ELIMINAR";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(116, 23);
            this.BtnGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(118, 30);
            this.BtnGuardar.TabIndex = 7;
            this.BtnGuardar.Text = "GUARDAR";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnCerrarSesion
            // 
            this.BtnCerrarSesion.Location = new System.Drawing.Point(4, 369);
            this.BtnCerrarSesion.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCerrarSesion.Name = "BtnCerrarSesion";
            this.BtnCerrarSesion.Size = new System.Drawing.Size(472, 60);
            this.BtnCerrarSesion.TabIndex = 21;
            this.BtnCerrarSesion.Text = "Cerrar sesión";
            this.BtnCerrarSesion.UseVisualStyleBackColor = true;
            this.BtnCerrarSesion.Click += new System.EventHandler(this.BtnCerrarSesion_Click);
            // 
            // GrbOperativo
            // 
            this.GrbOperativo.Controls.Add(this.BtnCorte);
            this.GrbOperativo.Controls.Add(this.BtnVentas);
            this.GrbOperativo.Controls.Add(this.BtnBuscar);
            this.GrbOperativo.Location = new System.Drawing.Point(344, 65);
            this.GrbOperativo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GrbOperativo.Name = "GrbOperativo";
            this.GrbOperativo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GrbOperativo.Size = new System.Drawing.Size(351, 162);
            this.GrbOperativo.TabIndex = 19;
            this.GrbOperativo.TabStop = false;
            this.GrbOperativo.Text = "USUARIO OPERATIVO";
            // 
            // BtnCorte
            // 
            this.BtnCorte.Location = new System.Drawing.Point(19, 127);
            this.BtnCorte.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnCorte.Name = "BtnCorte";
            this.BtnCorte.Size = new System.Drawing.Size(306, 30);
            this.BtnCorte.TabIndex = 14;
            this.BtnCorte.Text = "CORTE DE CAJA";
            this.BtnCorte.UseVisualStyleBackColor = true;
            this.BtnCorte.Click += new System.EventHandler(this.BtnCorte_Click);
            // 
            // BtnVentas
            // 
            this.BtnVentas.Location = new System.Drawing.Point(19, 78);
            this.BtnVentas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnVentas.Name = "BtnVentas";
            this.BtnVentas.Size = new System.Drawing.Size(306, 31);
            this.BtnVentas.TabIndex = 12;
            this.BtnVentas.Text = "VENTAS";
            this.BtnVentas.UseVisualStyleBackColor = true;
            this.BtnVentas.Click += new System.EventHandler(this.BtnVentas_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(19, 25);
            this.BtnBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(306, 30);
            this.BtnBuscar.TabIndex = 9;
            this.BtnBuscar.Text = "BUSCAR";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // PnlDesktop
            // 
            this.PnlDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(232)))), ((int)(((byte)(220)))));
            this.PnlDesktop.Controls.Add(this.panel2);
            this.PnlDesktop.Controls.Add(this.pictureBox3);
            this.PnlDesktop.Controls.Add(this.GrbOperativo);
            this.PnlDesktop.Controls.Add(this.BtnCerrarSesion);
            this.PnlDesktop.Controls.Add(this.GrbAdmin);
            this.PnlDesktop.Controls.Add(this.BtnSalir);
            this.PnlDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlDesktop.Location = new System.Drawing.Point(0, 0);
            this.PnlDesktop.Name = "PnlDesktop";
            this.PnlDesktop.Size = new System.Drawing.Size(719, 442);
            this.PnlDesktop.TabIndex = 23;
            this.PnlDesktop.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlDesktop_Paint);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(0, 65);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(326, 284);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 22;
            this.pictureBox3.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(127)))), ((int)(((byte)(89)))));
            this.panel2.Controls.Add(this.BtnCerrar);
            this.panel2.Controls.Add(this.BtnMinimizar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(719, 60);
            this.panel2.TabIndex = 23;
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(182)))), ((int)(((byte)(141)))));
            this.BtnCerrar.FlatAppearance.BorderSize = 0;
            this.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCerrar.IconChar = FontAwesome.Sharp.IconChar.X;
            this.BtnCerrar.IconColor = System.Drawing.Color.Black;
            this.BtnCerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnCerrar.IconSize = 30;
            this.BtnCerrar.Location = new System.Drawing.Point(663, 0);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(56, 29);
            this.BtnCerrar.TabIndex = 4;
            this.BtnCerrar.UseVisualStyleBackColor = false;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click_1);
            // 
            // BtnMinimizar
            // 
            this.BtnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(207)))), ((int)(((byte)(161)))));
            this.BtnMinimizar.FlatAppearance.BorderSize = 0;
            this.BtnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMinimizar.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.BtnMinimizar.IconColor = System.Drawing.Color.Black;
            this.BtnMinimizar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnMinimizar.IconSize = 30;
            this.BtnMinimizar.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnMinimizar.Location = new System.Drawing.Point(610, 0);
            this.BtnMinimizar.Name = "BtnMinimizar";
            this.BtnMinimizar.Size = new System.Drawing.Size(59, 29);
            this.BtnMinimizar.TabIndex = 3;
            this.BtnMinimizar.UseVisualStyleBackColor = false;
            this.BtnMinimizar.Click += new System.EventHandler(this.BtnMinimizar_Click_1);
            // 
            // VentanaMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnSalir;
            this.ClientSize = new System.Drawing.Size(719, 442);
            this.Controls.Add(this.PnlDesktop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "VentanaMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MENU";
            this.Load += new System.EventHandler(this.VentanaMenu_Load);
            this.Resize += new System.EventHandler(this.VentanaMenu_Resize);
            this.GrbAdmin.ResumeLayout(false);
            this.GrbOperativo.ResumeLayout(false);
            this.PnlDesktop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.GroupBox GrbAdmin;
        private System.Windows.Forms.Button BtnCatalogo;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnCerrarSesion;
        private System.Windows.Forms.GroupBox GrbOperativo;
        private System.Windows.Forms.Button BtnCorte;
        private System.Windows.Forms.Button BtnVentas;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Panel PnlDesktop;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private FontAwesome.Sharp.IconButton BtnCerrar;
        private FontAwesome.Sharp.IconButton BtnMinimizar;
    }
}