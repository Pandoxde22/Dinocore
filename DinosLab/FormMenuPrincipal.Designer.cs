namespace DinosLab
{
    partial class FormMenuPrincipal
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
            this.panelLateral = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.btnTienda = new System.Windows.Forms.Button();
            this.btnMisiones = new System.Windows.Forms.Button();
            this.btnLaboratorio = new System.Windows.Forms.Button();
            this.btnCombate = new System.Windows.Forms.Button();
            this.btnDinosaurios = new System.Windows.Forms.Button();
            this.btnPerfil = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelActividad = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblActividad2 = new System.Windows.Forms.Label();
            this.lblTituloActividad = new System.Windows.Forms.Label();
            this.panelDinosaurio = new System.Windows.Forms.Panel();
            this.lblValorEnergia = new System.Windows.Forms.Label();
            this.lblValorVida = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblEnergia = new System.Windows.Forms.Label();
            this.lblVida = new System.Windows.Forms.Label();
            this.progressEnergia = new System.Windows.Forms.ProgressBar();
            this.progressVida = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblNivel = new System.Windows.Forms.Label();
            this.lblEspecie = new System.Windows.Forms.Label();
            this.lblNombreDinosaurio = new System.Windows.Forms.Label();
            this.btnSubtitulo = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.lblCantidadCarne = new System.Windows.Forms.Label();
            this.lblCantidadVegetales = new System.Windows.Forms.Label();
            this.panelLateral.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelActividad.SuspendLayout();
            this.panelDinosaurio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLateral
            // 
            this.panelLateral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLateral.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelLateral.Controls.Add(this.lblLogo);
            this.panelLateral.Controls.Add(this.btnTienda);
            this.panelLateral.Controls.Add(this.btnMisiones);
            this.panelLateral.Controls.Add(this.btnLaboratorio);
            this.panelLateral.Controls.Add(this.btnCombate);
            this.panelLateral.Controls.Add(this.btnDinosaurios);
            this.panelLateral.Controls.Add(this.btnPerfil);
            this.panelLateral.Location = new System.Drawing.Point(0, 0);
            this.panelLateral.Name = "panelLateral";
            this.panelLateral.Size = new System.Drawing.Size(220, 700);
            this.panelLateral.TabIndex = 0;
            this.panelLateral.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLateral_Paint);
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogo.ForeColor = System.Drawing.Color.Chartreuse;
            this.lblLogo.Location = new System.Drawing.Point(15, 24);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(191, 45);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "DINOCORE";
            this.lblLogo.Click += new System.EventHandler(this.lblLogo_Click);
            // 
            // btnTienda
            // 
            this.btnTienda.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnTienda.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnTienda.FlatAppearance.BorderSize = 0;
            this.btnTienda.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnTienda.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnTienda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTienda.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTienda.ForeColor = System.Drawing.Color.Lime;
            this.btnTienda.Location = new System.Drawing.Point(12, 429);
            this.btnTienda.Name = "btnTienda";
            this.btnTienda.Size = new System.Drawing.Size(190, 48);
            this.btnTienda.TabIndex = 6;
            this.btnTienda.Text = "TIENDA";
            this.btnTienda.UseVisualStyleBackColor = false;
            this.btnTienda.Click += new System.EventHandler(this.btnTienda_Click);
            // 
            // btnMisiones
            // 
            this.btnMisiones.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnMisiones.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnMisiones.FlatAppearance.BorderSize = 0;
            this.btnMisiones.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnMisiones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnMisiones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMisiones.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMisiones.ForeColor = System.Drawing.Color.Lime;
            this.btnMisiones.Location = new System.Drawing.Point(12, 362);
            this.btnMisiones.Name = "btnMisiones";
            this.btnMisiones.Size = new System.Drawing.Size(190, 48);
            this.btnMisiones.TabIndex = 5;
            this.btnMisiones.Text = "MISIONES";
            this.btnMisiones.UseVisualStyleBackColor = false;
            this.btnMisiones.Click += new System.EventHandler(this.btnMisiones_Click);
            // 
            // btnLaboratorio
            // 
            this.btnLaboratorio.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLaboratorio.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnLaboratorio.FlatAppearance.BorderSize = 0;
            this.btnLaboratorio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnLaboratorio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnLaboratorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLaboratorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaboratorio.ForeColor = System.Drawing.Color.Lime;
            this.btnLaboratorio.Location = new System.Drawing.Point(12, 292);
            this.btnLaboratorio.Name = "btnLaboratorio";
            this.btnLaboratorio.Size = new System.Drawing.Size(190, 48);
            this.btnLaboratorio.TabIndex = 4;
            this.btnLaboratorio.Text = "LABORATORIO";
            this.btnLaboratorio.UseVisualStyleBackColor = false;
            this.btnLaboratorio.Click += new System.EventHandler(this.btnLaboratorio_Click);
            // 
            // btnCombate
            // 
            this.btnCombate.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCombate.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnCombate.FlatAppearance.BorderSize = 0;
            this.btnCombate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnCombate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnCombate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCombate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCombate.ForeColor = System.Drawing.Color.Lime;
            this.btnCombate.Location = new System.Drawing.Point(12, 226);
            this.btnCombate.Name = "btnCombate";
            this.btnCombate.Size = new System.Drawing.Size(190, 48);
            this.btnCombate.TabIndex = 3;
            this.btnCombate.Text = "COMBATE";
            this.btnCombate.UseVisualStyleBackColor = false;
            this.btnCombate.Click += new System.EventHandler(this.btnCombate_Click);
            // 
            // btnDinosaurios
            // 
            this.btnDinosaurios.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDinosaurios.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnDinosaurios.FlatAppearance.BorderSize = 0;
            this.btnDinosaurios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnDinosaurios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnDinosaurios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDinosaurios.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDinosaurios.ForeColor = System.Drawing.Color.Lime;
            this.btnDinosaurios.Location = new System.Drawing.Point(12, 161);
            this.btnDinosaurios.Name = "btnDinosaurios";
            this.btnDinosaurios.Size = new System.Drawing.Size(190, 48);
            this.btnDinosaurios.TabIndex = 2;
            this.btnDinosaurios.Text = "MIS DINOSAURIOS";
            this.btnDinosaurios.UseVisualStyleBackColor = false;
            this.btnDinosaurios.Click += new System.EventHandler(this.btnDinosaurios_Click);
            // 
            // btnPerfil
            // 
            this.btnPerfil.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPerfil.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnPerfil.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnPerfil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnPerfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPerfil.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPerfil.ForeColor = System.Drawing.Color.Lime;
            this.btnPerfil.Location = new System.Drawing.Point(12, 92);
            this.btnPerfil.Name = "btnPerfil";
            this.btnPerfil.Size = new System.Drawing.Size(190, 48);
            this.btnPerfil.TabIndex = 1;
            this.btnPerfil.Text = "PERFIL";
            this.btnPerfil.UseVisualStyleBackColor = false;
            this.btnPerfil.Click += new System.EventHandler(this.btnPerfil_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(23)))));
            this.panel1.Controls.Add(this.lblCantidadVegetales);
            this.panel1.Controls.Add(this.lblCantidadCarne);
            this.panel1.Controls.Add(this.panelActividad);
            this.panel1.Controls.Add(this.panelDinosaurio);
            this.panel1.Controls.Add(this.btnSubtitulo);
            this.panel1.Controls.Add(this.lblBienvenida);
            this.panel1.Location = new System.Drawing.Point(226, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(964, 710);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panelActividad
            // 
            this.panelActividad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(39)))), ((int)(((byte)(34)))));
            this.panelActividad.Controls.Add(this.label3);
            this.panelActividad.Controls.Add(this.lblActividad2);
            this.panelActividad.Controls.Add(this.lblTituloActividad);
            this.panelActividad.Location = new System.Drawing.Point(35, 445);
            this.panelActividad.Name = "panelActividad";
            this.panelActividad.Size = new System.Drawing.Size(600, 180);
            this.panelActividad.TabIndex = 3;
            this.panelActividad.Paint += new System.Windows.Forms.PaintEventHandler(this.panelActividad_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(20, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "ULTIMO COMBATE:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblActividad2
            // 
            this.lblActividad2.AutoSize = true;
            this.lblActividad2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActividad2.ForeColor = System.Drawing.Color.Lime;
            this.lblActividad2.Location = new System.Drawing.Point(20, 50);
            this.lblActividad2.Name = "lblActividad2";
            this.lblActividad2.Size = new System.Drawing.Size(122, 16);
            this.lblActividad2.TabIndex = 5;
            this.lblActividad2.Text = "ULTIMA MISION:";
            this.lblActividad2.Click += new System.EventHandler(this.lblActividad2_Click);
            // 
            // lblTituloActividad
            // 
            this.lblTituloActividad.AutoSize = true;
            this.lblTituloActividad.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloActividad.ForeColor = System.Drawing.Color.Lime;
            this.lblTituloActividad.Location = new System.Drawing.Point(20, 15);
            this.lblTituloActividad.Name = "lblTituloActividad";
            this.lblTituloActividad.Size = new System.Drawing.Size(138, 16);
            this.lblTituloActividad.TabIndex = 0;
            this.lblTituloActividad.Text = "Actividad Reciente";
            this.lblTituloActividad.Click += new System.EventHandler(this.lblTituloActividad_Click);
            // 
            // panelDinosaurio
            // 
            this.panelDinosaurio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(39)))), ((int)(((byte)(34)))));
            this.panelDinosaurio.Controls.Add(this.lblValorEnergia);
            this.panelDinosaurio.Controls.Add(this.lblValorVida);
            this.panelDinosaurio.Controls.Add(this.lblEstado);
            this.panelDinosaurio.Controls.Add(this.lblEnergia);
            this.panelDinosaurio.Controls.Add(this.lblVida);
            this.panelDinosaurio.Controls.Add(this.progressEnergia);
            this.panelDinosaurio.Controls.Add(this.progressVida);
            this.panelDinosaurio.Controls.Add(this.pictureBox1);
            this.panelDinosaurio.Controls.Add(this.lblNivel);
            this.panelDinosaurio.Controls.Add(this.lblEspecie);
            this.panelDinosaurio.Controls.Add(this.lblNombreDinosaurio);
            this.panelDinosaurio.Location = new System.Drawing.Point(40, 120);
            this.panelDinosaurio.Name = "panelDinosaurio";
            this.panelDinosaurio.Size = new System.Drawing.Size(600, 300);
            this.panelDinosaurio.TabIndex = 2;
            this.panelDinosaurio.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDinosaurio_Paint);
            // 
            // lblValorEnergia
            // 
            this.lblValorEnergia.AutoSize = true;
            this.lblValorEnergia.Location = new System.Drawing.Point(288, 215);
            this.lblValorEnergia.Name = "lblValorEnergia";
            this.lblValorEnergia.Size = new System.Drawing.Size(53, 16);
            this.lblValorEnergia.TabIndex = 10;
            this.lblValorEnergia.Text = "100/100";
            this.lblValorEnergia.Click += new System.EventHandler(this.lblValorEnergia_Click);
            // 
            // lblValorVida
            // 
            this.lblValorVida.AutoSize = true;
            this.lblValorVida.Location = new System.Drawing.Point(288, 155);
            this.lblValorVida.Name = "lblValorVida";
            this.lblValorVida.Size = new System.Drawing.Size(53, 16);
            this.lblValorVida.TabIndex = 9;
            this.lblValorVida.Text = "100/100";
            this.lblValorVida.Click += new System.EventHandler(this.lblValorVida_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(25, 260);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(118, 16);
            this.lblEstado.TabIndex = 8;
            this.lblEstado.Text = "ESTADO: ACTIVO";
            this.lblEstado.Click += new System.EventHandler(this.lblEstado_Click);
            // 
            // lblEnergia
            // 
            this.lblEnergia.AutoSize = true;
            this.lblEnergia.Location = new System.Drawing.Point(25, 195);
            this.lblEnergia.Name = "lblEnergia";
            this.lblEnergia.Size = new System.Drawing.Size(67, 16);
            this.lblEnergia.TabIndex = 7;
            this.lblEnergia.Text = "ENERGIA";
            this.lblEnergia.Click += new System.EventHandler(this.lblEnergia_Click);
            // 
            // lblVida
            // 
            this.lblVida.AutoSize = true;
            this.lblVida.Location = new System.Drawing.Point(25, 135);
            this.lblVida.Name = "lblVida";
            this.lblVida.Size = new System.Drawing.Size(38, 16);
            this.lblVida.TabIndex = 6;
            this.lblVida.Text = "VIDA";
            this.lblVida.Click += new System.EventHandler(this.lblVida_Click);
            // 
            // progressEnergia
            // 
            this.progressEnergia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.progressEnergia.ForeColor = System.Drawing.Color.Cyan;
            this.progressEnergia.Location = new System.Drawing.Point(25, 215);
            this.progressEnergia.Name = "progressEnergia";
            this.progressEnergia.Size = new System.Drawing.Size(260, 22);
            this.progressEnergia.TabIndex = 5;
            this.progressEnergia.Value = 100;
            this.progressEnergia.Click += new System.EventHandler(this.progressEnergia_Click);
            // 
            // progressVida
            // 
            this.progressVida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.progressVida.ForeColor = System.Drawing.Color.Lime;
            this.progressVida.Location = new System.Drawing.Point(25, 155);
            this.progressVida.Name = "progressVida";
            this.progressVida.Size = new System.Drawing.Size(260, 22);
            this.progressVida.TabIndex = 4;
            this.progressVida.Value = 100;
            this.progressVida.Click += new System.EventHandler(this.progressVida_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(347, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(239, 270);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblNivel
            // 
            this.lblNivel.AutoSize = true;
            this.lblNivel.Location = new System.Drawing.Point(25, 100);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(51, 16);
            this.lblNivel.TabIndex = 2;
            this.lblNivel.Text = "NIvel: 1";
            this.lblNivel.Click += new System.EventHandler(this.lblNivel_Click);
            // 
            // lblEspecie
            // 
            this.lblEspecie.AutoSize = true;
            this.lblEspecie.Location = new System.Drawing.Point(25, 65);
            this.lblEspecie.Name = "lblEspecie";
            this.lblEspecie.Size = new System.Drawing.Size(78, 16);
            this.lblEspecie.TabIndex = 1;
            this.lblEspecie.Text = "ESPECIE: --";
            this.lblEspecie.Click += new System.EventHandler(this.lblEspecie_Click);
            // 
            // lblNombreDinosaurio
            // 
            this.lblNombreDinosaurio.AutoSize = true;
            this.lblNombreDinosaurio.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreDinosaurio.ForeColor = System.Drawing.Color.Lime;
            this.lblNombreDinosaurio.Location = new System.Drawing.Point(25, 20);
            this.lblNombreDinosaurio.Name = "lblNombreDinosaurio";
            this.lblNombreDinosaurio.Size = new System.Drawing.Size(257, 41);
            this.lblNombreDinosaurio.TabIndex = 0;
            this.lblNombreDinosaurio.Text = "TU DINOSAURIO";
            this.lblNombreDinosaurio.Click += new System.EventHandler(this.lblNombreDinosaurio_Click);
            // 
            // btnSubtitulo
            // 
            this.btnSubtitulo.AutoSize = true;
            this.btnSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSubtitulo.ForeColor = System.Drawing.Color.Green;
            this.btnSubtitulo.Location = new System.Drawing.Point(40, 71);
            this.btnSubtitulo.Name = "btnSubtitulo";
            this.btnSubtitulo.Size = new System.Drawing.Size(464, 23);
            this.btnSubtitulo.TabIndex = 1;
            this.btnSubtitulo.Text = "Administra Tu Laboratorio y Prepara Tu Proxima Expedicion";
            this.btnSubtitulo.Click += new System.EventHandler(this.btnSubtitulo_Click);
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenida.ForeColor = System.Drawing.Color.Lime;
            this.lblBienvenida.Location = new System.Drawing.Point(35, 25);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(438, 45);
            this.lblBienvenida.TabIndex = 0;
            this.lblBienvenida.Text = "CENTRO DE OPERACIONES";
            this.lblBienvenida.Click += new System.EventHandler(this.lblBienvenida_Click);
            // 
            // lblCantidadCarne
            // 
            this.lblCantidadCarne.AutoSize = true;
            this.lblCantidadCarne.Location = new System.Drawing.Point(690, 92);
            this.lblCantidadCarne.Name = "lblCantidadCarne";
            this.lblCantidadCarne.Size = new System.Drawing.Size(60, 16);
            this.lblCantidadCarne.TabIndex = 4;
            this.lblCantidadCarne.Text = "CARNE :";
            this.lblCantidadCarne.Click += new System.EventHandler(this.lblCantidadCarne_Click);
            // 
            // lblCantidadVegetales
            // 
            this.lblCantidadVegetales.AutoSize = true;
            this.lblCantidadVegetales.Location = new System.Drawing.Point(690, 120);
            this.lblCantidadVegetales.Name = "lblCantidadVegetales";
            this.lblCantidadVegetales.Size = new System.Drawing.Size(90, 16);
            this.lblCantidadVegetales.TabIndex = 5;
            this.lblCantidadVegetales.Text = "VEGETALES:";
            this.lblCantidadVegetales.Click += new System.EventHandler(this.lblCantidadVegetales_Click);
            // 
            // FormMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1682, 703);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelLateral);
            this.ForeColor = System.Drawing.Color.Snow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "FormMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DINOCORE";
            this.panelLateral.ResumeLayout(false);
            this.panelLateral.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelActividad.ResumeLayout(false);
            this.panelActividad.PerformLayout();
            this.panelDinosaurio.ResumeLayout(false);
            this.panelDinosaurio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLateral;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Button btnTienda;
        private System.Windows.Forms.Button btnMisiones;
        private System.Windows.Forms.Button btnLaboratorio;
        private System.Windows.Forms.Button btnCombate;
        private System.Windows.Forms.Button btnDinosaurios;
        private System.Windows.Forms.Button btnPerfil;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label btnSubtitulo;
        private System.Windows.Forms.Panel panelDinosaurio;
        private System.Windows.Forms.Label lblNombreDinosaurio;
        private System.Windows.Forms.ProgressBar progressEnergia;
        private System.Windows.Forms.ProgressBar progressVida;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblNivel;
        private System.Windows.Forms.Label lblEspecie;
        private System.Windows.Forms.Label lblEnergia;
        private System.Windows.Forms.Label lblVida;
        private System.Windows.Forms.Panel panelActividad;
        private System.Windows.Forms.Label lblTituloActividad;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblActividad2;
        private System.Windows.Forms.Label lblValorVida;
        private System.Windows.Forms.Label lblValorEnergia;
        private System.Windows.Forms.Label lblCantidadVegetales;
        private System.Windows.Forms.Label lblCantidadCarne;
    }
}