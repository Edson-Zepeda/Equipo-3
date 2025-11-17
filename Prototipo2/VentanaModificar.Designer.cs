namespace Prototipo2
{
    partial class VentanaModificar
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
            this.TxtStock = new System.Windows.Forms.TextBox();
            this.TxtAutor = new System.Windows.Forms.TextBox();
            this.TxtPrecio = new System.Windows.Forms.TextBox();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.LblCopias = new System.Windows.Forms.Label();
            this.LblAño = new System.Windows.Forms.Label();
            this.LblAutor = new System.Windows.Forms.Label();
            this.LblPrecio = new System.Windows.Forms.Label();
            this.LblNombre = new System.Windows.Forms.Label();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnGrabar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.LblCuenta = new System.Windows.Forms.Label();
            this.LvRegistros = new System.Windows.Forms.ListView();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.RdbAproximada = new System.Windows.Forms.RadioButton();
            this.RdbExacta = new System.Windows.Forms.RadioButton();
            this.DtpFecha = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // TxtStock
            // 
            this.TxtStock.Location = new System.Drawing.Point(152, 238);
            this.TxtStock.Margin = new System.Windows.Forms.Padding(2);
            this.TxtStock.Name = "TxtStock";
            this.TxtStock.Size = new System.Drawing.Size(88, 20);
            this.TxtStock.TabIndex = 76;
            // 
            // TxtAutor
            // 
            this.TxtAutor.Location = new System.Drawing.Point(152, 129);
            this.TxtAutor.Margin = new System.Windows.Forms.Padding(2);
            this.TxtAutor.Name = "TxtAutor";
            this.TxtAutor.Size = new System.Drawing.Size(88, 20);
            this.TxtAutor.TabIndex = 74;
            // 
            // TxtPrecio
            // 
            this.TxtPrecio.Location = new System.Drawing.Point(152, 164);
            this.TxtPrecio.Margin = new System.Windows.Forms.Padding(2);
            this.TxtPrecio.Name = "TxtPrecio";
            this.TxtPrecio.Size = new System.Drawing.Size(88, 20);
            this.TxtPrecio.TabIndex = 73;
            // 
            // TxtNombre
            // 
            this.TxtNombre.Location = new System.Drawing.Point(152, 93);
            this.TxtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(88, 20);
            this.TxtNombre.TabIndex = 72;
            // 
            // LblCopias
            // 
            this.LblCopias.AutoSize = true;
            this.LblCopias.Location = new System.Drawing.Point(8, 241);
            this.LblCopias.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblCopias.Name = "LblCopias";
            this.LblCopias.Size = new System.Drawing.Size(130, 13);
            this.LblCopias.TabIndex = 71;
            this.LblCopias.Text = "COPIAS EN EXISTENCIA";
            // 
            // LblAño
            // 
            this.LblAño.AutoSize = true;
            this.LblAño.Location = new System.Drawing.Point(14, 206);
            this.LblAño.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblAño.Name = "LblAño";
            this.LblAño.Size = new System.Drawing.Size(134, 13);
            this.LblAño.TabIndex = 70;
            this.LblAño.Text = "FECHA DE PUBLICACIÓN";
            // 
            // LblAutor
            // 
            this.LblAutor.AutoSize = true;
            this.LblAutor.Location = new System.Drawing.Point(94, 129);
            this.LblAutor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblAutor.Name = "LblAutor";
            this.LblAutor.Size = new System.Drawing.Size(45, 13);
            this.LblAutor.TabIndex = 69;
            this.LblAutor.Text = "AUTOR";
            // 
            // LblPrecio
            // 
            this.LblPrecio.AutoSize = true;
            this.LblPrecio.Location = new System.Drawing.Point(94, 167);
            this.LblPrecio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblPrecio.Name = "LblPrecio";
            this.LblPrecio.Size = new System.Drawing.Size(47, 13);
            this.LblPrecio.TabIndex = 68;
            this.LblPrecio.Text = "PRECIO";
            // 
            // LblNombre
            // 
            this.LblNombre.AutoSize = true;
            this.LblNombre.Location = new System.Drawing.Point(27, 100);
            this.LblNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Size = new System.Drawing.Size(113, 13);
            this.LblNombre.TabIndex = 67;
            this.LblNombre.Text = "NOMBRE DEL LIBRO";
            // 
            // BtnModificar
            // 
            this.BtnModificar.Location = new System.Drawing.Point(585, 277);
            this.BtnModificar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(86, 27);
            this.BtnModificar.TabIndex = 66;
            this.BtnModificar.Text = "MODIFICAR";
            this.BtnModificar.UseVisualStyleBackColor = true;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(159, 284);
            this.BtnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(82, 27);
            this.BtnCancelar.TabIndex = 65;
            this.BtnCancelar.Text = "CANCELAR";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnGrabar
            // 
            this.BtnGrabar.Location = new System.Drawing.Point(78, 284);
            this.BtnGrabar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnGrabar.Name = "BtnGrabar";
            this.BtnGrabar.Size = new System.Drawing.Size(70, 27);
            this.BtnGrabar.TabIndex = 64;
            this.BtnGrabar.Text = "GRABAR";
            this.BtnGrabar.UseVisualStyleBackColor = true;
            this.BtnGrabar.Click += new System.EventHandler(this.BtnGrabar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Location = new System.Drawing.Point(884, 335);
            this.BtnSalir.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(67, 20);
            this.BtnSalir.TabIndex = 63;
            this.BtnSalir.Text = "SALIR";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // LblCuenta
            // 
            this.LblCuenta.AutoSize = true;
            this.LblCuenta.Location = new System.Drawing.Point(804, 284);
            this.LblCuenta.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblCuenta.Name = "LblCuenta";
            this.LblCuenta.Size = new System.Drawing.Size(138, 13);
            this.LblCuenta.TabIndex = 62;
            this.LblCuenta.Text = "TOTAL DE REGISTROS: 0";
            // 
            // LvRegistros
            // 
            this.LvRegistros.HideSelection = false;
            this.LvRegistros.Location = new System.Drawing.Point(255, 93);
            this.LvRegistros.Margin = new System.Windows.Forms.Padding(2);
            this.LvRegistros.Name = "LvRegistros";
            this.LvRegistros.Size = new System.Drawing.Size(696, 183);
            this.LvRegistros.TabIndex = 61;
            this.LvRegistros.UseCompatibleStateImageBehavior = false;
            this.LvRegistros.SelectedIndexChanged += new System.EventHandler(this.LvRegistros_SelectedIndexChanged);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(585, 52);
            this.BtnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(86, 24);
            this.BtnBuscar.TabIndex = 60;
            this.BtnBuscar.Text = "BUSCAR";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Location = new System.Drawing.Point(255, 55);
            this.TxtBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(298, 20);
            this.TxtBuscar.TabIndex = 59;
            // 
            // RdbAproximada
            // 
            this.RdbAproximada.AutoSize = true;
            this.RdbAproximada.Location = new System.Drawing.Point(404, 16);
            this.RdbAproximada.Margin = new System.Windows.Forms.Padding(2);
            this.RdbAproximada.Name = "RdbAproximada";
            this.RdbAproximada.Size = new System.Drawing.Size(159, 17);
            this.RdbAproximada.TabIndex = 58;
            this.RdbAproximada.TabStop = true;
            this.RdbAproximada.Text = "BUSQUEDA APROXIMADA";
            this.RdbAproximada.UseVisualStyleBackColor = true;
            // 
            // RdbExacta
            // 
            this.RdbExacta.AutoSize = true;
            this.RdbExacta.Location = new System.Drawing.Point(255, 18);
            this.RdbExacta.Margin = new System.Windows.Forms.Padding(2);
            this.RdbExacta.Name = "RdbExacta";
            this.RdbExacta.Size = new System.Drawing.Size(130, 17);
            this.RdbExacta.TabIndex = 57;
            this.RdbExacta.TabStop = true;
            this.RdbExacta.Text = "BUSQUEDA EXACTA";
            this.RdbExacta.UseVisualStyleBackColor = true;
            // 
            // DtpFecha
            // 
            this.DtpFecha.Location = new System.Drawing.Point(153, 200);
            this.DtpFecha.Name = "DtpFecha";
            this.DtpFecha.Size = new System.Drawing.Size(88, 20);
            this.DtpFecha.TabIndex = 78;
            // 
            // VentanaModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 366);
            this.Controls.Add(this.DtpFecha);
            this.Controls.Add(this.TxtStock);
            this.Controls.Add(this.TxtAutor);
            this.Controls.Add(this.TxtPrecio);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.LblCopias);
            this.Controls.Add(this.LblAño);
            this.Controls.Add(this.LblAutor);
            this.Controls.Add(this.LblPrecio);
            this.Controls.Add(this.LblNombre);
            this.Controls.Add(this.BtnModificar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnGrabar);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.LblCuenta);
            this.Controls.Add(this.LvRegistros);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.TxtBuscar);
            this.Controls.Add(this.RdbAproximada);
            this.Controls.Add(this.RdbExacta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "VentanaModificar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MODIFICAR";
            this.Load += new System.EventHandler(this.VentanaModificar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TxtStock;
        private System.Windows.Forms.TextBox TxtAutor;
        private System.Windows.Forms.TextBox TxtPrecio;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Label LblCopias;
        private System.Windows.Forms.Label LblAño;
        private System.Windows.Forms.Label LblAutor;
        private System.Windows.Forms.Label LblPrecio;
        private System.Windows.Forms.Label LblNombre;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnGrabar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label LblCuenta;
        private System.Windows.Forms.ListView LvRegistros;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.RadioButton RdbAproximada;
        private System.Windows.Forms.RadioButton RdbExacta;
        private System.Windows.Forms.DateTimePicker DtpFecha;
    }
}