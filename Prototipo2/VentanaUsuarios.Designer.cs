namespace Prototipo2
{
    partial class VentanaUsuarios
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
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.TxtClave = new System.Windows.Forms.TextBox();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.LblClave = new System.Windows.Forms.Label();
            this.LblUsuario = new System.Windows.Forms.Label();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnGrabar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.LblCuenta = new System.Windows.Forms.Label();
            this.LvRegistros = new System.Windows.Forms.ListView();
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.RdbAproximada = new System.Windows.Forms.RadioButton();
            this.RdbExacta = new System.Windows.Forms.RadioButton();
            this.ChkAdmin = new System.Windows.Forms.CheckBox();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Location = new System.Drawing.Point(16, 306);
            this.BtnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(93, 33);
            this.BtnEliminar.TabIndex = 72;
            this.BtnEliminar.Text = "ELIMINAR";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // TxtClave
            // 
            this.TxtClave.Location = new System.Drawing.Point(180, 208);
            this.TxtClave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtClave.Name = "TxtClave";
            this.TxtClave.Size = new System.Drawing.Size(116, 22);
            this.TxtClave.TabIndex = 71;
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.Location = new System.Drawing.Point(180, 162);
            this.TxtUsuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(116, 22);
            this.TxtUsuario.TabIndex = 70;
            // 
            // LblClave
            // 
            this.LblClave.AutoSize = true;
            this.LblClave.Location = new System.Drawing.Point(117, 208);
            this.LblClave.Name = "LblClave";
            this.LblClave.Size = new System.Drawing.Size(50, 16);
            this.LblClave.TabIndex = 68;
            this.LblClave.Text = "CLAVE";
            // 
            // LblUsuario
            // 
            this.LblUsuario.AutoSize = true;
            this.LblUsuario.Location = new System.Drawing.Point(97, 162);
            this.LblUsuario.Name = "LblUsuario";
            this.LblUsuario.Size = new System.Drawing.Size(68, 16);
            this.LblUsuario.TabIndex = 67;
            this.LblUsuario.Text = "USUARIO";
            // 
            // BtnModificar
            // 
            this.BtnModificar.Location = new System.Drawing.Point(216, 306);
            this.BtnModificar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(93, 33);
            this.BtnModificar.TabIndex = 65;
            this.BtnModificar.Text = "MODIFICAR";
            this.BtnModificar.UseVisualStyleBackColor = true;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(89, 345);
            this.BtnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(141, 44);
            this.BtnCancelar.TabIndex = 64;
            this.BtnCancelar.Text = "CANCELAR";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnGrabar
            // 
            this.BtnGrabar.Location = new System.Drawing.Point(116, 306);
            this.BtnGrabar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnGrabar.Name = "BtnGrabar";
            this.BtnGrabar.Size = new System.Drawing.Size(93, 33);
            this.BtnGrabar.TabIndex = 63;
            this.BtnGrabar.Text = "GRABAR";
            this.BtnGrabar.UseVisualStyleBackColor = true;
            this.BtnGrabar.Click += new System.EventHandler(this.BtnGrabar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Location = new System.Drawing.Point(815, 410);
            this.BtnSalir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(69, 28);
            this.BtnSalir.TabIndex = 62;
            this.BtnSalir.Text = "SALIR";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // LblCuenta
            // 
            this.LblCuenta.AutoSize = true;
            this.LblCuenta.Location = new System.Drawing.Point(700, 342);
            this.LblCuenta.Name = "LblCuenta";
            this.LblCuenta.Size = new System.Drawing.Size(168, 16);
            this.LblCuenta.TabIndex = 61;
            this.LblCuenta.Text = "TOTAL DE REGISTROS: 0";
            // 
            // LvRegistros
            // 
            this.LvRegistros.HideSelection = false;
            this.LvRegistros.Location = new System.Drawing.Point(316, 114);
            this.LvRegistros.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LvRegistros.Name = "LvRegistros";
            this.LvRegistros.Size = new System.Drawing.Size(552, 224);
            this.LvRegistros.TabIndex = 60;
            this.LvRegistros.UseCompatibleStateImageBehavior = false;
            this.LvRegistros.SelectedIndexChanged += new System.EventHandler(this.LvRegistros_SelectedIndexChanged);
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Location = new System.Drawing.Point(316, 62);
            this.TxtBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(396, 22);
            this.TxtBuscar.TabIndex = 58;
            // 
            // RdbAproximada
            // 
            this.RdbAproximada.AutoSize = true;
            this.RdbAproximada.Location = new System.Drawing.Point(515, 14);
            this.RdbAproximada.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RdbAproximada.Name = "RdbAproximada";
            this.RdbAproximada.Size = new System.Drawing.Size(195, 20);
            this.RdbAproximada.TabIndex = 57;
            this.RdbAproximada.TabStop = true;
            this.RdbAproximada.Text = "BUSQUEDA APROXIMADA";
            this.RdbAproximada.UseVisualStyleBackColor = true;
            // 
            // RdbExacta
            // 
            this.RdbExacta.AutoSize = true;
            this.RdbExacta.Location = new System.Drawing.Point(316, 15);
            this.RdbExacta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RdbExacta.Name = "RdbExacta";
            this.RdbExacta.Size = new System.Drawing.Size(160, 20);
            this.RdbExacta.TabIndex = 56;
            this.RdbExacta.TabStop = true;
            this.RdbExacta.Text = "BUSQUEDA EXACTA";
            this.RdbExacta.UseVisualStyleBackColor = true;
            // 
            // ChkAdmin
            // 
            this.ChkAdmin.AutoSize = true;
            this.ChkAdmin.Location = new System.Drawing.Point(180, 247);
            this.ChkAdmin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ChkAdmin.Name = "ChkAdmin";
            this.ChkAdmin.Size = new System.Drawing.Size(112, 20);
            this.ChkAdmin.TabIndex = 73;
            this.ChkAdmin.Text = "Administrador";
            this.ChkAdmin.UseVisualStyleBackColor = true;
            this.ChkAdmin.CheckedChanged += new System.EventHandler(this.ChkAdmin_CheckedChanged);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(719, 62);
            this.BtnBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(115, 30);
            this.BtnBuscar.TabIndex = 74;
            this.BtnBuscar.Text = "BUSCAR";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // VentanaUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 450);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.ChkAdmin);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.TxtClave);
            this.Controls.Add(this.TxtUsuario);
            this.Controls.Add(this.LblClave);
            this.Controls.Add(this.LblUsuario);
            this.Controls.Add(this.BtnModificar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnGrabar);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.LblCuenta);
            this.Controls.Add(this.LvRegistros);
            this.Controls.Add(this.TxtBuscar);
            this.Controls.Add(this.RdbAproximada);
            this.Controls.Add(this.RdbExacta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "VentanaUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CATALOGO DE USUARIOS";
            this.Load += new System.EventHandler(this.VentanaUsuarios_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.TextBox TxtClave;
        private System.Windows.Forms.TextBox TxtUsuario;
        private System.Windows.Forms.Label LblClave;
        private System.Windows.Forms.Label LblUsuario;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnGrabar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label LblCuenta;
        private System.Windows.Forms.ListView LvRegistros;
        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.RadioButton RdbAproximada;
        private System.Windows.Forms.RadioButton RdbExacta;
        private System.Windows.Forms.CheckBox ChkAdmin;
        private System.Windows.Forms.Button BtnBuscar;
    }
}