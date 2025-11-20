using System;
using System.Windows.Forms;

namespace Prototipo2
{
    partial class VentanaPrestamos
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
            this.txtDocSocio = new System.Windows.Forms.TextBox();
            this.txtCodigoEjemplar = new System.Windows.Forms.TextBox();
            this.dtVencimiento = new System.Windows.Forms.DateTimePicker();
            this.btnPrestar = new System.Windows.Forms.Button();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this._progress = new System.Windows.Forms.ProgressBar();
            this.lblDocSocio = new System.Windows.Forms.Label();
            this.lblCodigoEjemplar = new System.Windows.Forms.Label();
            this.lblVence = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDocSocio
            // 
            this.txtDocSocio.Location = new System.Drawing.Point(130, 16);
            this.txtDocSocio.Name = "txtDocSocio";
            this.txtDocSocio.Size = new System.Drawing.Size(150, 22);
            this.txtDocSocio.TabIndex = 0;
            // 
            // txtCodigoEjemplar
            // 
            this.txtCodigoEjemplar.Location = new System.Drawing.Point(130, 46);
            this.txtCodigoEjemplar.Name = "txtCodigoEjemplar";
            this.txtCodigoEjemplar.Size = new System.Drawing.Size(150, 22);
            this.txtCodigoEjemplar.TabIndex = 1;
            // 
            // dtVencimiento
            // 
            this.dtVencimiento.Location = new System.Drawing.Point(130, 76);
            this.dtVencimiento.Name = "dtVencimiento";
            this.dtVencimiento.Size = new System.Drawing.Size(200, 22);
            this.dtVencimiento.TabIndex = 2;
            this.dtVencimiento.Value = new System.DateTime(2025, 11, 26, 9, 20, 23, 734);
            // 
            // btnPrestar
            // 
            this.btnPrestar.Location = new System.Drawing.Point(10, 120);
            this.btnPrestar.Name = "btnPrestar";
            this.btnPrestar.Size = new System.Drawing.Size(120, 30);
            this.btnPrestar.TabIndex = 3;
            this.btnPrestar.Text = "Prestar";
            this.btnPrestar.UseVisualStyleBackColor = true;
            this.btnPrestar.Click += new System.EventHandler(this.BtnPrestar_Click);
            // 
            // btnDevolver
            // 
            this.btnDevolver.Location = new System.Drawing.Point(140, 120);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(120, 30);
            this.btnDevolver.TabIndex = 4;
            this.btnDevolver.Text = "Devolver";
            this.btnDevolver.UseVisualStyleBackColor = true;
            this.btnDevolver.Click += new System.EventHandler(this.BtnDevolver_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(400, 120);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(90, 30);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.Location = new System.Drawing.Point(10, 160);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(480, 23);
            this.lblEstado.TabIndex = 6;
            // 
            // _progress
            // 
            this._progress.Location = new System.Drawing.Point(0, 241);
            this._progress.MarqueeAnimationSpeed = 30;
            this._progress.Name = "_progress";
            this._progress.Size = new System.Drawing.Size(520, 12);
            this._progress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this._progress.TabIndex = 7;
            this._progress.Visible = false;
            // 
            // lblDocSocio
            // 
            this.lblDocSocio.AutoSize = true;
            this.lblDocSocio.Location = new System.Drawing.Point(10, 20);
            this.lblDocSocio.Name = "lblDocSocio";
            this.lblDocSocio.Size = new System.Drawing.Size(115, 16);
            this.lblDocSocio.TabIndex = 8;
            this.lblDocSocio.Text = "Documento socio:";
            // 
            // lblCodigoEjemplar
            // 
            this.lblCodigoEjemplar.AutoSize = true;
            this.lblCodigoEjemplar.Location = new System.Drawing.Point(10, 50);
            this.lblCodigoEjemplar.Name = "lblCodigoEjemplar";
            this.lblCodigoEjemplar.Size = new System.Drawing.Size(110, 16);
            this.lblCodigoEjemplar.TabIndex = 9;
            this.lblCodigoEjemplar.Text = "Código ejemplar:";
            // 
            // lblVence
            // 
            this.lblVence.AutoSize = true;
            this.lblVence.Location = new System.Drawing.Point(10, 80);
            this.lblVence.Name = "lblVence";
            this.lblVence.Size = new System.Drawing.Size(49, 16);
            this.lblVence.TabIndex = 10;
            this.lblVence.Text = "Vence:";
            // 
            // VentanaPrestamos
            // 
            this.ClientSize = new System.Drawing.Size(520, 260);
            this.Controls.Add(this.lblVence);
            this.Controls.Add(this.lblCodigoEjemplar);
            this.Controls.Add(this.lblDocSocio);
            this.Controls.Add(this._progress);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnDevolver);
            this.Controls.Add(this.btnPrestar);
            this.Controls.Add(this.dtVencimiento);
            this.Controls.Add(this.txtCodigoEjemplar);
            this.Controls.Add(this.txtDocSocio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "VentanaPrestamos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Préstamos";
            this.Load += new System.EventHandler(this.VentanaPrestamos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDocSocio;
        private System.Windows.Forms.TextBox txtCodigoEjemplar;
        private System.Windows.Forms.DateTimePicker dtVencimiento;
        private System.Windows.Forms.Button btnPrestar;
        private System.Windows.Forms.Button btnDevolver;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ProgressBar _progress;
        private System.Windows.Forms.Label lblDocSocio;
        private System.Windows.Forms.Label lblCodigoEjemplar;
        private System.Windows.Forms.Label lblVence;
    }
}
