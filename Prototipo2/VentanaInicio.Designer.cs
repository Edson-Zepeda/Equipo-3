namespace Prototipo2
{
    partial class VentanaInicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaInicio));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.TxtClave = new System.Windows.Forms.TextBox();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.ChkMostrarContra = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnMinimizar = new FontAwesome.Sharp.IconButton();
            this.BtnCerrar = new FontAwesome.Sharp.IconButton();
            this.LblClave = new System.Windows.Forms.Label();
            this.LblUsuario = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-28, 31);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(331, 283);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(310, 228);
            this.BtnAceptar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(249, 51);
            this.BtnAceptar.TabIndex = 10;
            this.BtnAceptar.Text = "ACEPTAR";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // TxtClave
            // 
            this.TxtClave.Location = new System.Drawing.Point(310, 157);
            this.TxtClave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtClave.MaxLength = 20;
            this.TxtClave.Name = "TxtClave";
            this.TxtClave.Size = new System.Drawing.Size(249, 22);
            this.TxtClave.TabIndex = 9;
            this.TxtClave.UseSystemPasswordChar = true;
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.ForeColor = System.Drawing.Color.Gray;
            this.TxtUsuario.Location = new System.Drawing.Point(310, 94);
            this.TxtUsuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtUsuario.MaxLength = 20;
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(249, 22);
            this.TxtUsuario.TabIndex = 8;
            // 
            // ChkMostrarContra
            // 
            this.ChkMostrarContra.AutoSize = true;
            this.ChkMostrarContra.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkMostrarContra.Location = new System.Drawing.Point(310, 190);
            this.ChkMostrarContra.Margin = new System.Windows.Forms.Padding(4);
            this.ChkMostrarContra.Name = "ChkMostrarContra";
            this.ChkMostrarContra.Size = new System.Drawing.Size(146, 20);
            this.ChkMostrarContra.TabIndex = 12;
            this.ChkMostrarContra.Text = "Mostrar Contraseña";
            this.ChkMostrarContra.UseVisualStyleBackColor = true;
            this.ChkMostrarContra.CheckedChanged += new System.EventHandler(this.ChkMostrarContra_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(528, 185);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 28);
            this.button1.TabIndex = 13;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(127)))), ((int)(((byte)(89)))));
            this.panel1.Controls.Add(this.BtnCerrar);
            this.panel1.Controls.Add(this.BtnMinimizar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 40);
            this.panel1.TabIndex = 14;
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
            this.BtnMinimizar.Location = new System.Drawing.Point(475, 0);
            this.BtnMinimizar.Name = "BtnMinimizar";
            this.BtnMinimizar.Size = new System.Drawing.Size(59, 29);
            this.BtnMinimizar.TabIndex = 1;
            this.BtnMinimizar.UseVisualStyleBackColor = false;
            this.BtnMinimizar.Click += new System.EventHandler(this.BtnMinimizar_Click);
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
            this.BtnCerrar.Location = new System.Drawing.Point(528, 0);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(56, 29);
            this.BtnCerrar.TabIndex = 2;
            this.BtnCerrar.UseVisualStyleBackColor = false;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // LblClave
            // 
            this.LblClave.AutoSize = true;
            this.LblClave.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblClave.Location = new System.Drawing.Point(306, 132);
            this.LblClave.Name = "LblClave";
            this.LblClave.Size = new System.Drawing.Size(54, 23);
            this.LblClave.TabIndex = 7;
            this.LblClave.Text = "Clave";
            // 
            // LblUsuario
            // 
            this.LblUsuario.AutoSize = true;
            this.LblUsuario.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUsuario.Location = new System.Drawing.Point(306, 69);
            this.LblUsuario.Name = "LblUsuario";
            this.LblUsuario.Size = new System.Drawing.Size(73, 23);
            this.LblUsuario.TabIndex = 6;
            this.LblUsuario.Text = "Usuario";
            // 
            // VentanaInicio
            // 
            this.AcceptButton = this.BtnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(232)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(584, 292);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ChkMostrarContra);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.TxtClave);
            this.Controls.Add(this.TxtUsuario);
            this.Controls.Add(this.LblClave);
            this.Controls.Add(this.LblUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "VentanaInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOGIN";
            this.Load += new System.EventHandler(this.VentanaInicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.TextBox TxtClave;
        private System.Windows.Forms.TextBox TxtUsuario;
        private System.Windows.Forms.CheckBox ChkMostrarContra;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton BtnCerrar;
        private FontAwesome.Sharp.IconButton BtnMinimizar;
        private System.Windows.Forms.Label LblClave;
        private System.Windows.Forms.Label LblUsuario;
    }
}

