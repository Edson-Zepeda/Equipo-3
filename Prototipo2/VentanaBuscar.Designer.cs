namespace Prototipo2
{
    partial class VentanaBuscar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaBuscar));
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.RdbAproximada = new System.Windows.Forms.RadioButton();
            this.RdbExacta = new System.Windows.Forms.RadioButton();
            this.PnlMenu = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.BtnMenu = new FontAwesome.Sharp.IconButton();
            this.PnlTitleBar = new System.Windows.Forms.Panel();
            this.LblCuenta = new System.Windows.Forms.Label();
            this.LvRegistros = new System.Windows.Forms.ListView();
            this.PnlDesktop = new System.Windows.Forms.Panel();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.iconButton8 = new FontAwesome.Sharp.IconButton();
            this.iconButton6 = new FontAwesome.Sharp.IconButton();
            this.iconButton5 = new FontAwesome.Sharp.IconButton();
            this.iconButton4 = new FontAwesome.Sharp.IconButton();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.iconButton7 = new FontAwesome.Sharp.IconButton();
            this.iconButton9 = new FontAwesome.Sharp.IconButton();
            this.BtnCerrar = new FontAwesome.Sharp.IconButton();
            this.BtnMinimizar = new FontAwesome.Sharp.IconButton();
            this.PnlMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.PnlTitleBar.SuspendLayout();
            this.PnlDesktop.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnSalir
            // 
            this.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnSalir.Location = new System.Drawing.Point(1026, 389);
            this.BtnSalir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(144, 28);
            this.BtnSalir.TabIndex = 13;
            this.BtnSalir.Text = "REGRESAR";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(777, 73);
            this.BtnBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(112, 38);
            this.BtnBuscar.TabIndex = 10;
            this.BtnBuscar.Text = "BUSCAR";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Location = new System.Drawing.Point(255, 100);
            this.TxtBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(452, 22);
            this.TxtBuscar.TabIndex = 9;
            // 
            // RdbAproximada
            // 
            this.RdbAproximada.AutoSize = true;
            this.RdbAproximada.Location = new System.Drawing.Point(489, 73);
            this.RdbAproximada.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RdbAproximada.Name = "RdbAproximada";
            this.RdbAproximada.Size = new System.Drawing.Size(195, 20);
            this.RdbAproximada.TabIndex = 8;
            this.RdbAproximada.TabStop = true;
            this.RdbAproximada.Text = "BUSQUEDA APROXIMADA";
            this.RdbAproximada.UseVisualStyleBackColor = true;
            // 
            // RdbExacta
            // 
            this.RdbExacta.AutoSize = true;
            this.RdbExacta.Location = new System.Drawing.Point(260, 73);
            this.RdbExacta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RdbExacta.Name = "RdbExacta";
            this.RdbExacta.Size = new System.Drawing.Size(160, 20);
            this.RdbExacta.TabIndex = 7;
            this.RdbExacta.TabStop = true;
            this.RdbExacta.Text = "BUSQUEDA EXACTA";
            this.RdbExacta.UseVisualStyleBackColor = true;
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
            this.PnlMenu.Size = new System.Drawing.Size(230, 442);
            this.PnlMenu.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(182)))), ((int)(((byte)(141)))));
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.BtnMenu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 89);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(-17, -15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(142, 118);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // BtnMenu
            // 
            this.BtnMenu.FlatAppearance.BorderSize = 0;
            this.BtnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMenu.IconChar = FontAwesome.Sharp.IconChar.CaretSquareRight;
            this.BtnMenu.IconColor = System.Drawing.Color.DimGray;
            this.BtnMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnMenu.IconSize = 30;
            this.BtnMenu.Location = new System.Drawing.Point(170, 0);
            this.BtnMenu.Name = "BtnMenu";
            this.BtnMenu.Size = new System.Drawing.Size(60, 60);
            this.BtnMenu.TabIndex = 2;
            this.BtnMenu.UseVisualStyleBackColor = true;
            this.BtnMenu.Click += new System.EventHandler(this.BtnMenu_Click);
            // 
            // PnlTitleBar
            // 
            this.PnlTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(127)))), ((int)(((byte)(89)))));
            this.PnlTitleBar.Controls.Add(this.BtnCerrar);
            this.PnlTitleBar.Controls.Add(this.BtnMinimizar);
            this.PnlTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTitleBar.Location = new System.Drawing.Point(230, 0);
            this.PnlTitleBar.Name = "PnlTitleBar";
            this.PnlTitleBar.Size = new System.Drawing.Size(951, 60);
            this.PnlTitleBar.TabIndex = 15;
            this.PnlTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlTitleBar_MouseDown);
            // 
            // LblCuenta
            // 
            this.LblCuenta.AutoSize = true;
            this.LblCuenta.Location = new System.Drawing.Point(252, 395);
            this.LblCuenta.Name = "LblCuenta";
            this.LblCuenta.Size = new System.Drawing.Size(168, 16);
            this.LblCuenta.TabIndex = 12;
            this.LblCuenta.Text = "TOTAL DE REGISTROS: 0";
            // 
            // LvRegistros
            // 
            this.LvRegistros.HideSelection = false;
            this.LvRegistros.Location = new System.Drawing.Point(255, 164);
            this.LvRegistros.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LvRegistros.Name = "LvRegistros";
            this.LvRegistros.Size = new System.Drawing.Size(915, 221);
            this.LvRegistros.TabIndex = 11;
            this.LvRegistros.UseCompatibleStateImageBehavior = false;
            // 
            // PnlDesktop
            // 
            this.PnlDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(232)))), ((int)(((byte)(220)))));
            this.PnlDesktop.Controls.Add(this.LvRegistros);
            this.PnlDesktop.Controls.Add(this.LblCuenta);
            this.PnlDesktop.Controls.Add(this.BtnBuscar);
            this.PnlDesktop.Controls.Add(this.BtnSalir);
            this.PnlDesktop.Controls.Add(this.RdbAproximada);
            this.PnlDesktop.Controls.Add(this.TxtBuscar);
            this.PnlDesktop.Controls.Add(this.RdbExacta);
            this.PnlDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlDesktop.Location = new System.Drawing.Point(0, 0);
            this.PnlDesktop.Name = "PnlDesktop";
            this.PnlDesktop.Size = new System.Drawing.Size(1181, 442);
            this.PnlDesktop.TabIndex = 16;
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
            this.iconButton1.Location = new System.Drawing.Point(0, 329);
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
            this.iconButton8.Location = new System.Drawing.Point(0, 287);
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
            this.iconButton6.Location = new System.Drawing.Point(0, 254);
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
            this.iconButton5.Location = new System.Drawing.Point(0, 221);
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
            this.iconButton4.Location = new System.Drawing.Point(0, 188);
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
            this.iconButton3.Location = new System.Drawing.Point(0, 155);
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
            this.iconButton2.Location = new System.Drawing.Point(0, 122);
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
            this.iconButton7.Location = new System.Drawing.Point(0, 89);
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
            this.iconButton9.Location = new System.Drawing.Point(0, 395);
            this.iconButton9.Name = "iconButton9";
            this.iconButton9.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.iconButton9.Size = new System.Drawing.Size(230, 47);
            this.iconButton9.TabIndex = 20;
            this.iconButton9.Tag = "Regresar";
            this.iconButton9.Text = " Regresar";
            this.iconButton9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton9.UseVisualStyleBackColor = true;
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
            this.BtnCerrar.Location = new System.Drawing.Point(896, 0);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(56, 29);
            this.BtnCerrar.TabIndex = 6;
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
            this.BtnMinimizar.Location = new System.Drawing.Point(843, 0);
            this.BtnMinimizar.Name = "BtnMinimizar";
            this.BtnMinimizar.Size = new System.Drawing.Size(59, 29);
            this.BtnMinimizar.TabIndex = 5;
            this.BtnMinimizar.UseVisualStyleBackColor = false;
            this.BtnMinimizar.Click += new System.EventHandler(this.BtnMinimizar_Click);
            // 
            // VentanaBuscar
            // 
            this.AcceptButton = this.BtnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnSalir;
            this.ClientSize = new System.Drawing.Size(1181, 442);
            this.Controls.Add(this.PnlTitleBar);
            this.Controls.Add(this.PnlMenu);
            this.Controls.Add(this.PnlDesktop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "VentanaBuscar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BUSCAR";
            this.Load += new System.EventHandler(this.VentanaBuscar_Load);
            this.PnlMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.PnlTitleBar.ResumeLayout(false);
            this.PnlDesktop.ResumeLayout(false);
            this.PnlDesktop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.RadioButton RdbAproximada;
        private System.Windows.Forms.RadioButton RdbExacta;
        private System.Windows.Forms.Panel PnlMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel PnlTitleBar;
        private FontAwesome.Sharp.IconButton BtnMenu;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label LblCuenta;
        private System.Windows.Forms.ListView LvRegistros;
        private System.Windows.Forms.Panel PnlDesktop;
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