namespace Prototipo2
{
    partial class VentanaVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaVentas));
            this.BtnComprar = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.LvRegistros = new System.Windows.Forms.ListView();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.RdbAproximada = new System.Windows.Forms.RadioButton();
            this.RdbExacta = new System.Windows.Forms.RadioButton();
            this.BtnRegresar = new System.Windows.Forms.Button();
            this.LvCarrito = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtCantidad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PnlMenu = new System.Windows.Forms.Panel();
            this.iconButton9 = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.iconButton8 = new FontAwesome.Sharp.IconButton();
            this.iconButton6 = new FontAwesome.Sharp.IconButton();
            this.iconButton5 = new FontAwesome.Sharp.IconButton();
            this.iconButton4 = new FontAwesome.Sharp.IconButton();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.iconButton7 = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.BtnMenu = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BtnCerrar = new FontAwesome.Sharp.IconButton();
            this.BtnMinimizar = new FontAwesome.Sharp.IconButton();
            this.groupBox1.SuspendLayout();
            this.PnlMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnComprar
            // 
            this.BtnComprar.Location = new System.Drawing.Point(765, 206);
            this.BtnComprar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnComprar.Name = "BtnComprar";
            this.BtnComprar.Size = new System.Drawing.Size(167, 34);
            this.BtnComprar.TabIndex = 20;
            this.BtnComprar.Text = "COMPRAR";
            this.BtnComprar.UseVisualStyleBackColor = true;
            this.BtnComprar.Click += new System.EventHandler(this.BtnComprar_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Location = new System.Drawing.Point(1034, 139);
            this.BtnAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(167, 34);
            this.BtnAgregar.TabIndex = 19;
            this.BtnAgregar.Text = "AGREGAR";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // LvRegistros
            // 
            this.LvRegistros.HideSelection = false;
            this.LvRegistros.Location = new System.Drawing.Point(294, 187);
            this.LvRegistros.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LvRegistros.Name = "LvRegistros";
            this.LvRegistros.Size = new System.Drawing.Size(916, 183);
            this.LvRegistros.TabIndex = 17;
            this.LvRegistros.UseCompatibleStateImageBehavior = false;
            this.LvRegistros.SelectedIndexChanged += new System.EventHandler(this.LvRegistros_SelectedIndexChanged);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(681, 147);
            this.BtnBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(118, 26);
            this.BtnBuscar.TabIndex = 16;
            this.BtnBuscar.Text = "BUSCAR";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Location = new System.Drawing.Point(294, 151);
            this.TxtBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(381, 22);
            this.TxtBuscar.TabIndex = 15;
            // 
            // RdbAproximada
            // 
            this.RdbAproximada.AutoSize = true;
            this.RdbAproximada.Location = new System.Drawing.Point(532, 123);
            this.RdbAproximada.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RdbAproximada.Name = "RdbAproximada";
            this.RdbAproximada.Size = new System.Drawing.Size(195, 20);
            this.RdbAproximada.TabIndex = 14;
            this.RdbAproximada.TabStop = true;
            this.RdbAproximada.Text = "BUSQUEDA APROXIMADA";
            this.RdbAproximada.UseVisualStyleBackColor = true;
            // 
            // RdbExacta
            // 
            this.RdbExacta.AutoSize = true;
            this.RdbExacta.Location = new System.Drawing.Point(294, 123);
            this.RdbExacta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RdbExacta.Name = "RdbExacta";
            this.RdbExacta.Size = new System.Drawing.Size(160, 20);
            this.RdbExacta.TabIndex = 13;
            this.RdbExacta.TabStop = true;
            this.RdbExacta.Text = "BUSQUEDA EXACTA";
            this.RdbExacta.UseVisualStyleBackColor = true;
            // 
            // BtnRegresar
            // 
            this.BtnRegresar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnRegresar.Location = new System.Drawing.Point(1075, 633);
            this.BtnRegresar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnRegresar.Name = "BtnRegresar";
            this.BtnRegresar.Size = new System.Drawing.Size(157, 44);
            this.BtnRegresar.TabIndex = 21;
            this.BtnRegresar.Text = "REGRESAR";
            this.BtnRegresar.UseVisualStyleBackColor = true;
            this.BtnRegresar.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // LvCarrito
            // 
            this.LvCarrito.HideSelection = false;
            this.LvCarrito.Location = new System.Drawing.Point(15, 26);
            this.LvCarrito.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LvCarrito.Name = "LvCarrito";
            this.LvCarrito.Size = new System.Drawing.Size(916, 176);
            this.LvCarrito.TabIndex = 22;
            this.LvCarrito.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LvCarrito);
            this.groupBox1.Controls.Add(this.BtnComprar);
            this.groupBox1.Location = new System.Drawing.Point(279, 376);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(951, 251);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CARRITO:";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // TxtCantidad
            // 
            this.TxtCantidad.Location = new System.Drawing.Point(1116, 114);
            this.TxtCantidad.Margin = new System.Windows.Forms.Padding(4);
            this.TxtCantidad.Name = "TxtCantidad";
            this.TxtCantidad.Size = new System.Drawing.Size(104, 22);
            this.TxtCantidad.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1005, 117);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "CANTIDAD:";
            // 
            // PnlMenu
            // 
            this.PnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(207)))), ((int)(((byte)(161)))));
            this.PnlMenu.Controls.Add(this.iconButton9);
            this.PnlMenu.Controls.Add(this.iconButton1);
            this.PnlMenu.Controls.Add(this.iconButton8);
            this.PnlMenu.Controls.Add(this.iconButton6);
            this.PnlMenu.Controls.Add(this.iconButton5);
            this.PnlMenu.Controls.Add(this.iconButton4);
            this.PnlMenu.Controls.Add(this.iconButton3);
            this.PnlMenu.Controls.Add(this.iconButton2);
            this.PnlMenu.Controls.Add(this.iconButton7);
            this.PnlMenu.Controls.Add(this.panel1);
            this.PnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlMenu.Location = new System.Drawing.Point(0, 0);
            this.PnlMenu.Name = "PnlMenu";
            this.PnlMenu.Size = new System.Drawing.Size(230, 688);
            this.PnlMenu.TabIndex = 15;
            // 
            // iconButton9
            // 
            this.iconButton9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.iconButton9.FlatAppearance.BorderSize = 0;
            this.iconButton9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton9.ForeColor = System.Drawing.Color.DimGray;
            this.iconButton9.IconChar = FontAwesome.Sharp.IconChar.SignOut;
            this.iconButton9.IconColor = System.Drawing.Color.DimGray;
            this.iconButton9.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton9.IconSize = 30;
            this.iconButton9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton9.Location = new System.Drawing.Point(0, 610);
            this.iconButton9.Name = "iconButton9";
            this.iconButton9.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.iconButton9.Size = new System.Drawing.Size(230, 78);
            this.iconButton9.TabIndex = 20;
            this.iconButton9.Tag = "Regresar";
            this.iconButton9.Text = " Regresar";
            this.iconButton9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton9.UseVisualStyleBackColor = true;
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(207)))), ((int)(((byte)(161)))));
            this.iconButton1.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.ForeColor = System.Drawing.Color.DimGray;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Portrait;
            this.iconButton1.IconColor = System.Drawing.Color.DimGray;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 30;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.Location = new System.Drawing.Point(0, 361);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.iconButton1.Size = new System.Drawing.Size(230, 51);
            this.iconButton1.TabIndex = 19;
            this.iconButton1.Tag = "Usuarios";
            this.iconButton1.Text = "Catálogo de Usuarios";
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = false;
            // 
            // iconButton8
            // 
            this.iconButton8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(207)))), ((int)(((byte)(161)))));
            this.iconButton8.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton8.FlatAppearance.BorderSize = 0;
            this.iconButton8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton8.ForeColor = System.Drawing.Color.DimGray;
            this.iconButton8.IconChar = FontAwesome.Sharp.IconChar.Pencil;
            this.iconButton8.IconColor = System.Drawing.Color.DimGray;
            this.iconButton8.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton8.IconSize = 30;
            this.iconButton8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton8.Location = new System.Drawing.Point(0, 319);
            this.iconButton8.Name = "iconButton8";
            this.iconButton8.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.iconButton8.Size = new System.Drawing.Size(230, 42);
            this.iconButton8.TabIndex = 18;
            this.iconButton8.Tag = "Modificar";
            this.iconButton8.Text = "Modificar";
            this.iconButton8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton8.UseVisualStyleBackColor = false;
            // 
            // iconButton6
            // 
            this.iconButton6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(207)))), ((int)(((byte)(161)))));
            this.iconButton6.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton6.FlatAppearance.BorderSize = 0;
            this.iconButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton6.ForeColor = System.Drawing.Color.DimGray;
            this.iconButton6.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            this.iconButton6.IconColor = System.Drawing.Color.DimGray;
            this.iconButton6.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton6.IconSize = 30;
            this.iconButton6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton6.Location = new System.Drawing.Point(0, 286);
            this.iconButton6.Name = "iconButton6";
            this.iconButton6.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.iconButton6.Size = new System.Drawing.Size(230, 33);
            this.iconButton6.TabIndex = 17;
            this.iconButton6.Tag = "Guardar";
            this.iconButton6.Text = "Guardar";
            this.iconButton6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton6.UseVisualStyleBackColor = false;
            // 
            // iconButton5
            // 
            this.iconButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(207)))), ((int)(((byte)(161)))));
            this.iconButton5.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton5.FlatAppearance.BorderSize = 0;
            this.iconButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton5.ForeColor = System.Drawing.Color.DimGray;
            this.iconButton5.IconChar = FontAwesome.Sharp.IconChar.Remove;
            this.iconButton5.IconColor = System.Drawing.Color.DimGray;
            this.iconButton5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton5.IconSize = 30;
            this.iconButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton5.Location = new System.Drawing.Point(0, 253);
            this.iconButton5.Name = "iconButton5";
            this.iconButton5.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.iconButton5.Size = new System.Drawing.Size(230, 33);
            this.iconButton5.TabIndex = 16;
            this.iconButton5.Tag = "Eliminar";
            this.iconButton5.Text = "Eliminar";
            this.iconButton5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton5.UseVisualStyleBackColor = false;
            // 
            // iconButton4
            // 
            this.iconButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(207)))), ((int)(((byte)(161)))));
            this.iconButton4.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton4.FlatAppearance.BorderSize = 0;
            this.iconButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton4.ForeColor = System.Drawing.Color.DimGray;
            this.iconButton4.IconChar = FontAwesome.Sharp.IconChar.Receipt;
            this.iconButton4.IconColor = System.Drawing.Color.DimGray;
            this.iconButton4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton4.IconSize = 30;
            this.iconButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton4.Location = new System.Drawing.Point(0, 220);
            this.iconButton4.Name = "iconButton4";
            this.iconButton4.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.iconButton4.Size = new System.Drawing.Size(230, 33);
            this.iconButton4.TabIndex = 15;
            this.iconButton4.Tag = "Corte";
            this.iconButton4.Text = "Corte de Caja";
            this.iconButton4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton4.UseVisualStyleBackColor = false;
            // 
            // iconButton3
            // 
            this.iconButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(207)))), ((int)(((byte)(161)))));
            this.iconButton3.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton3.FlatAppearance.BorderSize = 0;
            this.iconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton3.ForeColor = System.Drawing.Color.DimGray;
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.MoneyBillWave;
            this.iconButton3.IconColor = System.Drawing.Color.DimGray;
            this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton3.IconSize = 30;
            this.iconButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton3.Location = new System.Drawing.Point(0, 187);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.iconButton3.Size = new System.Drawing.Size(230, 33);
            this.iconButton3.TabIndex = 14;
            this.iconButton3.Tag = "Venta";
            this.iconButton3.Text = "Ventas";
            this.iconButton3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton3.UseVisualStyleBackColor = false;
            // 
            // iconButton2
            // 
            this.iconButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(207)))), ((int)(((byte)(161)))));
            this.iconButton2.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton2.ForeColor = System.Drawing.Color.DimGray;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.iconButton2.IconColor = System.Drawing.Color.DimGray;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.IconSize = 30;
            this.iconButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton2.Location = new System.Drawing.Point(0, 154);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.iconButton2.Size = new System.Drawing.Size(230, 33);
            this.iconButton2.TabIndex = 13;
            this.iconButton2.Tag = "Buscar";
            this.iconButton2.Text = "Buscar";
            this.iconButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton2.UseVisualStyleBackColor = false;
            // 
            // iconButton7
            // 
            this.iconButton7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(207)))), ((int)(((byte)(161)))));
            this.iconButton7.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton7.FlatAppearance.BorderSize = 0;
            this.iconButton7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton7.ForeColor = System.Drawing.Color.DimGray;
            this.iconButton7.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            this.iconButton7.IconColor = System.Drawing.Color.DimGray;
            this.iconButton7.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton7.IconSize = 30;
            this.iconButton7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton7.Location = new System.Drawing.Point(0, 121);
            this.iconButton7.Name = "iconButton7";
            this.iconButton7.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.iconButton7.Size = new System.Drawing.Size(230, 33);
            this.iconButton7.TabIndex = 12;
            this.iconButton7.Tag = "Menú";
            this.iconButton7.Text = "Menú";
            this.iconButton7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton7.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(182)))), ((int)(((byte)(141)))));
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.BtnMenu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 121);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(-21, -13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(175, 144);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // BtnMenu
            // 
            this.BtnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMenu.IconChar = FontAwesome.Sharp.IconChar.CaretSquareRight;
            this.BtnMenu.IconColor = System.Drawing.Color.DimGray;
            this.BtnMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnMenu.Location = new System.Drawing.Point(172, 0);
            this.BtnMenu.Name = "BtnMenu";
            this.BtnMenu.Size = new System.Drawing.Size(58, 45);
            this.BtnMenu.TabIndex = 0;
            this.BtnMenu.UseVisualStyleBackColor = true;
            this.BtnMenu.Click += new System.EventHandler(this.BtnMenu_Click_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(232)))), ((int)(((byte)(220)))));
            this.panel2.Controls.Add(this.BtnRegresar);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.PnlMenu);
            this.panel2.Controls.Add(this.TxtCantidad);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.LvRegistros);
            this.panel2.Controls.Add(this.BtnAgregar);
            this.panel2.Controls.Add(this.RdbExacta);
            this.panel2.Controls.Add(this.BtnBuscar);
            this.panel2.Controls.Add(this.RdbAproximada);
            this.panel2.Controls.Add(this.TxtBuscar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1282, 688);
            this.panel2.TabIndex = 27;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(127)))), ((int)(((byte)(89)))));
            this.panel3.Controls.Add(this.BtnCerrar);
            this.panel3.Controls.Add(this.BtnMinimizar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(230, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1052, 70);
            this.panel3.TabIndex = 26;
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
            this.BtnCerrar.Location = new System.Drawing.Point(996, 0);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(56, 29);
            this.BtnCerrar.TabIndex = 8;
            this.BtnCerrar.UseVisualStyleBackColor = false;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
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
            this.BtnMinimizar.Location = new System.Drawing.Point(943, 0);
            this.BtnMinimizar.Name = "BtnMinimizar";
            this.BtnMinimizar.Size = new System.Drawing.Size(59, 29);
            this.BtnMinimizar.TabIndex = 7;
            this.BtnMinimizar.UseVisualStyleBackColor = false;
            this.BtnMinimizar.Click += new System.EventHandler(this.BtnMinimizar_Click);
            // 
            // VentanaVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnRegresar;
            this.ClientSize = new System.Drawing.Size(1282, 688);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "VentanaVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VENTAS";
            this.Load += new System.EventHandler(this.VentanaVentas_Load);
            this.groupBox1.ResumeLayout(false);
            this.PnlMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnComprar;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.ListView LvRegistros;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.RadioButton RdbAproximada;
        private System.Windows.Forms.RadioButton RdbExacta;
        private System.Windows.Forms.Button BtnRegresar;
        private System.Windows.Forms.ListView LvCarrito;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtCantidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PnlMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private FontAwesome.Sharp.IconButton BtnMenu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconButton8;
        private FontAwesome.Sharp.IconButton iconButton6;
        private FontAwesome.Sharp.IconButton iconButton5;
        private FontAwesome.Sharp.IconButton iconButton4;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton iconButton7;
        private FontAwesome.Sharp.IconButton iconButton9;
        private FontAwesome.Sharp.IconButton BtnCerrar;
        private FontAwesome.Sharp.IconButton BtnMinimizar;
    }
}