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
            this.GrbAdmin = new System.Windows.Forms.GroupBox();
            this.BtnPrestamos = new System.Windows.Forms.Button();
            this.BtnSocios = new System.Windows.Forms.Button();
            this.BtnCatalogo = new System.Windows.Forms.Button();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.GrbOperativo = new System.Windows.Forms.GroupBox();
            this.BtnCorte = new System.Windows.Forms.Button();
            this.BtnVentas = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnCerrarSesion = new System.Windows.Forms.Button();
            this.GrbAdmin.SuspendLayout();
            this.GrbOperativo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // GrbAdmin
            // 
            this.GrbAdmin.Controls.Add(this.BtnPrestamos);
            this.GrbAdmin.Controls.Add(this.BtnSocios);
            this.GrbAdmin.Controls.Add(this.BtnCatalogo);
            this.GrbAdmin.Controls.Add(this.BtnModificar);
            this.GrbAdmin.Controls.Add(this.BtnEliminar);
            this.GrbAdmin.Controls.Add(this.BtnGuardar);
            this.GrbAdmin.Location = new System.Drawing.Point(389, 240);
            this.GrbAdmin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GrbAdmin.Name = "GrbAdmin";
            this.GrbAdmin.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GrbAdmin.Size = new System.Drawing.Size(317, 210);
            this.GrbAdmin.TabIndex = 20;
            this.GrbAdmin.TabStop = false;
            this.GrbAdmin.Text = "ADMINISTRADOR";
            // 
            // BtnPrestamos
            // 
            this.BtnPrestamos.Location = new System.Drawing.Point(17, 166);
            this.BtnPrestamos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnPrestamos.Name = "BtnPrestamos";
            this.BtnPrestamos.Size = new System.Drawing.Size(295, 30);
            this.BtnPrestamos.TabIndex = 15;
            this.BtnPrestamos.Text = "PRÉSTAMOS";
            this.BtnPrestamos.UseVisualStyleBackColor = true;
            this.BtnPrestamos.Click += new System.EventHandler(this.BtnPrestamos_Click);
            // 
            // BtnSocios
            // 
            this.BtnSocios.Location = new System.Drawing.Point(17, 130);
            this.BtnSocios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnSocios.Name = "BtnSocios";
            this.BtnSocios.Size = new System.Drawing.Size(295, 30);
            this.BtnSocios.TabIndex = 14;
            this.BtnSocios.Text = "SOCIOS";
            this.BtnSocios.UseVisualStyleBackColor = true;
            this.BtnSocios.Click += new System.EventHandler(this.BtnSocios_Click);
            // 
            // BtnCatalogo
            // 
            this.BtnCatalogo.Location = new System.Drawing.Point(17, 94);
            this.BtnCatalogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnCatalogo.Name = "BtnCatalogo";
            this.BtnCatalogo.Size = new System.Drawing.Size(295, 30);
            this.BtnCatalogo.TabIndex = 13;
            this.BtnCatalogo.Text = "CATALOGO DE USUARIOS";
            this.BtnCatalogo.UseVisualStyleBackColor = true;
            this.BtnCatalogo.Click += new System.EventHandler(this.BtnCatalogo_Click);
            // 
            // BtnModificar
            // 
            this.BtnModificar.Location = new System.Drawing.Point(196, 22);
            this.BtnModificar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(116, 30);
            this.BtnModificar.TabIndex = 10;
            this.BtnModificar.Text = "MODIFICAR";
            this.BtnModificar.UseVisualStyleBackColor = true;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Location = new System.Drawing.Point(17, 22);
            this.BtnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(84, 30);
            this.BtnEliminar.TabIndex = 8;
            this.BtnEliminar.Text = "ELIMINAR";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(107, 22);
            this.BtnGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(84, 30);
            this.BtnGuardar.TabIndex = 7;
            this.BtnGuardar.Text = "GUARDAR";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // GrbOperativo
            // 
            this.GrbOperativo.Controls.Add(this.BtnCorte);
            this.GrbOperativo.Controls.Add(this.BtnVentas);
            this.GrbOperativo.Controls.Add(this.BtnBuscar);
            this.GrbOperativo.Location = new System.Drawing.Point(388, 49);
            this.GrbOperativo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GrbOperativo.Name = "GrbOperativo";
            this.GrbOperativo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GrbOperativo.Size = new System.Drawing.Size(320, 162);
            this.GrbOperativo.TabIndex = 19;
            this.GrbOperativo.TabStop = false;
            this.GrbOperativo.Text = "USUARIO OPERATIVO";
            // 
            // BtnCorte
            // 
            this.BtnCorte.Location = new System.Drawing.Point(19, 127);
            this.BtnCorte.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnCorte.Name = "BtnCorte";
            this.BtnCorte.Size = new System.Drawing.Size(277, 30);
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
            this.BtnVentas.Size = new System.Drawing.Size(277, 31);
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
            this.BtnBuscar.Size = new System.Drawing.Size(277, 30);
            this.BtnBuscar.TabIndex = 9;
            this.BtnBuscar.Text = "BUSCAR";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnSalir.Location = new System.Drawing.Point(648, 395);
            this.BtnSalir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(69, 26);
            this.BtnSalir.TabIndex = 18;
            this.BtnSalir.Text = "SALIR";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(33, 59);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(304, 274);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // BtnCerrarSesion
            // 
            this.BtnCerrarSesion.Location = new System.Drawing.Point(33, 15);
            this.BtnCerrarSesion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnCerrarSesion.Name = "BtnCerrarSesion";
            this.BtnCerrarSesion.Size = new System.Drawing.Size(104, 26);
            this.BtnCerrarSesion.TabIndex = 21;
            this.BtnCerrarSesion.Text = "Cerrar sesión";
            this.BtnCerrarSesion.UseVisualStyleBackColor = true;
            this.BtnCerrarSesion.Click += new System.EventHandler(this.BtnCerrarSesion_Click);
            // 
            // VentanaMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnSalir;
            this.ClientSize = new System.Drawing.Size(731, 470);
            this.Controls.Add(this.BtnCerrarSesion);
            this.Controls.Add(this.GrbAdmin);
            this.Controls.Add(this.GrbOperativo);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "VentanaMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MENU";
            this.Load += new System.EventHandler(this.VentanaMenu_Load);
            this.GrbAdmin.ResumeLayout(false);
            this.GrbOperativo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrbAdmin;
        private System.Windows.Forms.Button BtnCatalogo;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.GroupBox GrbOperativo;
        private System.Windows.Forms.Button BtnCorte;
        private System.Windows.Forms.Button BtnVentas;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnCerrarSesion;
        private System.Windows.Forms.Button BtnSocios;
        private System.Windows.Forms.Button BtnPrestamos;
    }
}