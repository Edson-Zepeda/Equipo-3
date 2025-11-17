namespace Prototipo2
{
    partial class VentanaCorte
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
            this.LblHora = new System.Windows.Forms.Label();
            this.LblFecha = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnCorte = new System.Windows.Forms.Button();
            this.LvCorte = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // LblHora
            // 
            this.LblHora.AutoSize = true;
            this.LblHora.Location = new System.Drawing.Point(10, 54);
            this.LblHora.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblHora.Name = "LblHora";
            this.LblHora.Size = new System.Drawing.Size(137, 13);
            this.LblHora.TabIndex = 9;
            this.LblHora.Text = "Hora: *poner la del sistema*";
            // 
            // LblFecha
            // 
            this.LblFecha.AutoSize = true;
            this.LblFecha.Location = new System.Drawing.Point(10, 31);
            this.LblFecha.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblFecha.Name = "LblFecha";
            this.LblFecha.Size = new System.Drawing.Size(144, 13);
            this.LblFecha.TabIndex = 8;
            this.LblFecha.Text = "Fecha: *poner la del sistema*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(256, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "CORTE DE CAJA";
            // 
            // BtnCorte
            // 
            this.BtnCorte.Location = new System.Drawing.Point(10, 327);
            this.BtnCorte.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCorte.Name = "BtnCorte";
            this.BtnCorte.Size = new System.Drawing.Size(573, 28);
            this.BtnCorte.TabIndex = 6;
            this.BtnCorte.Text = "CORTE FINAL";
            this.BtnCorte.UseVisualStyleBackColor = true;
            this.BtnCorte.Click += new System.EventHandler(this.BtnCorte_Click);
            // 
            // LvCorte
            // 
            this.LvCorte.HideSelection = false;
            this.LvCorte.Location = new System.Drawing.Point(9, 70);
            this.LvCorte.Margin = new System.Windows.Forms.Padding(2);
            this.LvCorte.Name = "LvCorte";
            this.LvCorte.Size = new System.Drawing.Size(573, 253);
            this.LvCorte.TabIndex = 5;
            this.LvCorte.UseCompatibleStateImageBehavior = false;
            // 
            // VentanaCorte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 366);
            this.Controls.Add(this.LblHora);
            this.Controls.Add(this.LblFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnCorte);
            this.Controls.Add(this.LvCorte);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "VentanaCorte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CORTE DE CAJA";
            this.Load += new System.EventHandler(this.VentanaCorte_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblHora;
        private System.Windows.Forms.Label LblFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnCorte;
        private System.Windows.Forms.ListView LvCorte;
    }
}