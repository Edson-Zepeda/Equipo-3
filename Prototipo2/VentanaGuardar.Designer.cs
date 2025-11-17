namespace Prototipo2
{
    partial class VentanaGuardar
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
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.TxtStock = new System.Windows.Forms.TextBox();
            this.TxtAutor = new System.Windows.Forms.TextBox();
            this.TxtPrecio = new System.Windows.Forms.TextBox();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.LblCopias = new System.Windows.Forms.Label();
            this.LblAño = new System.Windows.Forms.Label();
            this.LblAutor = new System.Windows.Forms.Label();
            this.LblPrecio = new System.Windows.Forms.Label();
            this.LblNombre = new System.Windows.Forms.Label();
            this.DtpFechaPublicacion = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // BtnSalir
            // 
            this.BtnSalir.Location = new System.Drawing.Point(300, 242);
            this.BtnSalir.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(102, 29);
            this.BtnSalir.TabIndex = 25;
            this.BtnSalir.Text = "SALIR";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(210, 188);
            this.BtnGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(102, 29);
            this.BtnGuardar.TabIndex = 23;
            this.BtnGuardar.Text = "GUARDAR";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // TxtStock
            // 
            this.TxtStock.Location = new System.Drawing.Point(155, 164);
            this.TxtStock.Margin = new System.Windows.Forms.Padding(2);
            this.TxtStock.Name = "TxtStock";
            this.TxtStock.Size = new System.Drawing.Size(213, 20);
            this.TxtStock.TabIndex = 22;
            // 
            // TxtAutor
            // 
            this.TxtAutor.Location = new System.Drawing.Point(155, 53);
            this.TxtAutor.Margin = new System.Windows.Forms.Padding(2);
            this.TxtAutor.Name = "TxtAutor";
            this.TxtAutor.Size = new System.Drawing.Size(213, 20);
            this.TxtAutor.TabIndex = 20;
            // 
            // TxtPrecio
            // 
            this.TxtPrecio.Location = new System.Drawing.Point(155, 90);
            this.TxtPrecio.Margin = new System.Windows.Forms.Padding(2);
            this.TxtPrecio.Name = "TxtPrecio";
            this.TxtPrecio.Size = new System.Drawing.Size(213, 20);
            this.TxtPrecio.TabIndex = 19;
            // 
            // TxtNombre
            // 
            this.TxtNombre.Location = new System.Drawing.Point(155, 19);
            this.TxtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(213, 20);
            this.TxtNombre.TabIndex = 18;
            // 
            // LblCopias
            // 
            this.LblCopias.AutoSize = true;
            this.LblCopias.Location = new System.Drawing.Point(19, 167);
            this.LblCopias.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblCopias.Name = "LblCopias";
            this.LblCopias.Size = new System.Drawing.Size(130, 13);
            this.LblCopias.TabIndex = 17;
            this.LblCopias.Text = "COPIAS EN EXISTENCIA";
            // 
            // LblAño
            // 
            this.LblAño.AutoSize = true;
            this.LblAño.Location = new System.Drawing.Point(16, 132);
            this.LblAño.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblAño.Name = "LblAño";
            this.LblAño.Size = new System.Drawing.Size(134, 13);
            this.LblAño.TabIndex = 16;
            this.LblAño.Text = "FECHA DE PUBLICACIÓN";
            // 
            // LblAutor
            // 
            this.LblAutor.AutoSize = true;
            this.LblAutor.Location = new System.Drawing.Point(96, 53);
            this.LblAutor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblAutor.Name = "LblAutor";
            this.LblAutor.Size = new System.Drawing.Size(45, 13);
            this.LblAutor.TabIndex = 15;
            this.LblAutor.Text = "AUTOR";
            // 
            // LblPrecio
            // 
            this.LblPrecio.AutoSize = true;
            this.LblPrecio.Location = new System.Drawing.Point(96, 90);
            this.LblPrecio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblPrecio.Name = "LblPrecio";
            this.LblPrecio.Size = new System.Drawing.Size(47, 13);
            this.LblPrecio.TabIndex = 14;
            this.LblPrecio.Text = "PRECIO";
            // 
            // LblNombre
            // 
            this.LblNombre.AutoSize = true;
            this.LblNombre.Location = new System.Drawing.Point(27, 22);
            this.LblNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Size = new System.Drawing.Size(113, 13);
            this.LblNombre.TabIndex = 13;
            this.LblNombre.Text = "NOMBRE DEL LIBRO";
            // 
            // DtpFechaPublicacion
            // 
            this.DtpFechaPublicacion.Location = new System.Drawing.Point(155, 126);
            this.DtpFechaPublicacion.Name = "DtpFechaPublicacion";
            this.DtpFechaPublicacion.Size = new System.Drawing.Size(200, 20);
            this.DtpFechaPublicacion.TabIndex = 26;
            // 
            // VentanaGuardar
            // 
            this.AcceptButton = this.BtnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnSalir;
            this.ClientSize = new System.Drawing.Size(414, 284);
            this.Controls.Add(this.DtpFechaPublicacion);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.TxtStock);
            this.Controls.Add(this.TxtAutor);
            this.Controls.Add(this.TxtPrecio);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.LblCopias);
            this.Controls.Add(this.LblAño);
            this.Controls.Add(this.LblAutor);
            this.Controls.Add(this.LblPrecio);
            this.Controls.Add(this.LblNombre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "VentanaGuardar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GUARDAR";
            this.Load += new System.EventHandler(this.VentanaGuardar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.TextBox TxtStock;
        private System.Windows.Forms.TextBox TxtAutor;
        private System.Windows.Forms.TextBox TxtPrecio;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Label LblCopias;
        private System.Windows.Forms.Label LblAño;
        private System.Windows.Forms.Label LblAutor;
        private System.Windows.Forms.Label LblPrecio;
        private System.Windows.Forms.Label LblNombre;
        private System.Windows.Forms.DateTimePicker DtpFechaPublicacion;
    }
}