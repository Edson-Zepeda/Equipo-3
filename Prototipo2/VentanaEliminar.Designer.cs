namespace Prototipo2
{
    partial class VentanaEliminar
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
            this.BtnSalir = new System.Windows.Forms.Button();
            this.LblCuenta = new System.Windows.Forms.Label();
            this.LvRegistros = new System.Windows.Forms.ListView();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.RdbAproximada = new System.Windows.Forms.RadioButton();
            this.RdbExacta = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Location = new System.Drawing.Point(318, 290);
            this.BtnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(158, 26);
            this.BtnEliminar.TabIndex = 22;
            this.BtnEliminar.Text = "ELIMINAR";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Location = new System.Drawing.Point(648, 335);
            this.BtnSalir.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(67, 20);
            this.BtnSalir.TabIndex = 21;
            this.BtnSalir.Text = "SALIR";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // LblCuenta
            // 
            this.LblCuenta.AutoSize = true;
            this.LblCuenta.Location = new System.Drawing.Point(577, 275);
            this.LblCuenta.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblCuenta.Name = "LblCuenta";
            this.LblCuenta.Size = new System.Drawing.Size(138, 13);
            this.LblCuenta.TabIndex = 20;
            this.LblCuenta.Text = "TOTAL DE REGISTROS: 0";
            // 
            // LvRegistros
            // 
            this.LvRegistros.HideSelection = false;
            this.LvRegistros.Location = new System.Drawing.Point(37, 93);
            this.LvRegistros.Margin = new System.Windows.Forms.Padding(2);
            this.LvRegistros.Name = "LvRegistros";
            this.LvRegistros.Size = new System.Drawing.Size(678, 180);
            this.LvRegistros.TabIndex = 19;
            this.LvRegistros.UseCompatibleStateImageBehavior = false;
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(340, 50);
            this.BtnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(86, 21);
            this.BtnBuscar.TabIndex = 18;
            this.BtnBuscar.Text = "BUSCAR";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Location = new System.Drawing.Point(37, 50);
            this.TxtBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(299, 20);
            this.TxtBuscar.TabIndex = 17;
            // 
            // RdbAproximada
            // 
            this.RdbAproximada.AutoSize = true;
            this.RdbAproximada.Location = new System.Drawing.Point(177, 11);
            this.RdbAproximada.Margin = new System.Windows.Forms.Padding(2);
            this.RdbAproximada.Name = "RdbAproximada";
            this.RdbAproximada.Size = new System.Drawing.Size(159, 17);
            this.RdbAproximada.TabIndex = 16;
            this.RdbAproximada.TabStop = true;
            this.RdbAproximada.Text = "BUSQUEDA APROXIMADA";
            this.RdbAproximada.UseVisualStyleBackColor = true;
            // 
            // RdbExacta
            // 
            this.RdbExacta.AutoSize = true;
            this.RdbExacta.Location = new System.Drawing.Point(37, 11);
            this.RdbExacta.Margin = new System.Windows.Forms.Padding(2);
            this.RdbExacta.Name = "RdbExacta";
            this.RdbExacta.Size = new System.Drawing.Size(130, 17);
            this.RdbExacta.TabIndex = 15;
            this.RdbExacta.TabStop = true;
            this.RdbExacta.Text = "BUSQUEDA EXACTA";
            this.RdbExacta.UseVisualStyleBackColor = true;
            // 
            // VentanaEliminar
            // 
            this.AcceptButton = this.BtnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnSalir;
            this.ClientSize = new System.Drawing.Size(743, 366);
            this.Controls.Add(this.BtnEliminar);
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
            this.Name = "VentanaEliminar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ELIMINAR";
            this.Load += new System.EventHandler(this.VentanaEliminar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label LblCuenta;
        private System.Windows.Forms.ListView LvRegistros;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.RadioButton RdbAproximada;
        private System.Windows.Forms.RadioButton RdbExacta;
    }
}