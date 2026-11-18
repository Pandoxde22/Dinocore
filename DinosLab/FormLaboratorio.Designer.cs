namespace DinosLab
{
    partial class FormLaboratorio
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.panelDinosaurio = new System.Windows.Forms.Panel();
            this.lblNombreDino = new System.Windows.Forms.Label();
            this.lblNivel = new System.Windows.Forms.Label();
            this.lblVida = new System.Windows.Forms.Label();
            this.progressVida = new System.Windows.Forms.ProgressBar();
            this.progressEnergia = new System.Windows.Forms.ProgressBar();
            this.lblTextoVida = new System.Windows.Forms.Label();
            this.lblEnergia = new System.Windows.Forms.Label();
            this.btnRecuperar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnAlimentarCarne = new System.Windows.Forms.Button();
            this.btnAlimentarVegetales = new System.Windows.Forms.Button();
            this.btnEntrenar = new System.Windows.Forms.Button();
            this.lblExperiencia = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelDinosaurio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(220)))), ((int)(((byte)(170)))));
            this.lblTitulo.Location = new System.Drawing.Point(205, 31);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(280, 50);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "LABORATORIO";
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(220)))), ((int)(((byte)(170)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(190, 82);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(320, 25);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "CENTRO DE INVESTIGACION LABORATORIO";
            this.lblSubtitulo.Click += new System.EventHandler(this.lblSubtitulo_Click);
            // 
            // panelDinosaurio
            // 
            this.panelDinosaurio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(65)))));
            this.panelDinosaurio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDinosaurio.Controls.Add(this.pictureBox1);
            this.panelDinosaurio.Controls.Add(this.lblExperiencia);
            this.panelDinosaurio.Controls.Add(this.lblEnergia);
            this.panelDinosaurio.Controls.Add(this.progressEnergia);
            this.panelDinosaurio.Controls.Add(this.lblTextoVida);
            this.panelDinosaurio.Controls.Add(this.progressVida);
            this.panelDinosaurio.Controls.Add(this.lblVida);
            this.panelDinosaurio.Controls.Add(this.lblNivel);
            this.panelDinosaurio.Controls.Add(this.lblNombreDino);
            this.panelDinosaurio.Location = new System.Drawing.Point(100, 140);
            this.panelDinosaurio.Name = "panelDinosaurio";
            this.panelDinosaurio.Size = new System.Drawing.Size(500, 190);
            this.panelDinosaurio.TabIndex = 2;
            this.panelDinosaurio.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDinosaurio_Paint);
            // 
            // lblNombreDino
            // 
            this.lblNombreDino.AutoSize = true;
            this.lblNombreDino.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNombreDino.Location = new System.Drawing.Point(25, 20);
            this.lblNombreDino.Name = "lblNombreDino";
            this.lblNombreDino.Size = new System.Drawing.Size(137, 16);
            this.lblNombreDino.TabIndex = 0;
            this.lblNombreDino.Text = "DINOSAURIO: T-REX";
            this.lblNombreDino.Click += new System.EventHandler(this.lblNombreDino_Click);
            // 
            // lblNivel
            // 
            this.lblNivel.AutoSize = true;
            this.lblNivel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNivel.Location = new System.Drawing.Point(27, 75);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(51, 16);
            this.lblNivel.TabIndex = 1;
            this.lblNivel.Text = "Nivel: 1";
            this.lblNivel.Click += new System.EventHandler(this.lblNivel_Click);
            // 
            // lblVida
            // 
            this.lblVida.AutoSize = true;
            this.lblVida.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblVida.Location = new System.Drawing.Point(25, 110);
            this.lblVida.Name = "lblVida";
            this.lblVida.Size = new System.Drawing.Size(65, 16);
            this.lblVida.TabIndex = 2;
            this.lblVida.Text = "VIDA: 100";
            this.lblVida.Click += new System.EventHandler(this.lblVida_Click);
            // 
            // progressVida
            // 
            this.progressVida.Location = new System.Drawing.Point(25, 129);
            this.progressVida.Name = "progressVida";
            this.progressVida.Size = new System.Drawing.Size(430, 18);
            this.progressVida.TabIndex = 3;
            this.progressVida.Value = 100;
            this.progressVida.Click += new System.EventHandler(this.progressVida_Click);
            // 
            // progressEnergia
            // 
            this.progressEnergia.Location = new System.Drawing.Point(25, 167);
            this.progressEnergia.Name = "progressEnergia";
            this.progressEnergia.Size = new System.Drawing.Size(430, 18);
            this.progressEnergia.TabIndex = 3;
            this.progressEnergia.Value = 100;
            this.progressEnergia.Click += new System.EventHandler(this.progressEnergia_Click);
            // 
            // lblTextoVida
            // 
            this.lblTextoVida.AutoSize = true;
            this.lblTextoVida.BackColor = System.Drawing.Color.Transparent;
            this.lblTextoVida.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTextoVida.Location = new System.Drawing.Point(25, 129);
            this.lblTextoVida.Name = "lblTextoVida";
            this.lblTextoVida.Size = new System.Drawing.Size(33, 16);
            this.lblTextoVida.TabIndex = 4;
            this.lblTextoVida.Text = "vida";
            this.lblTextoVida.Click += new System.EventHandler(this.lblTextoVida_Click);
            // 
            // lblEnergia
            // 
            this.lblEnergia.AutoSize = true;
            this.lblEnergia.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblEnergia.Location = new System.Drawing.Point(25, 167);
            this.lblEnergia.Name = "lblEnergia";
            this.lblEnergia.Size = new System.Drawing.Size(53, 16);
            this.lblEnergia.TabIndex = 5;
            this.lblEnergia.Text = "energia";
            this.lblEnergia.Click += new System.EventHandler(this.lblEnergia_Click);
            // 
            // btnRecuperar
            // 
            this.btnRecuperar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(150)))), ((int)(((byte)(100)))));
            this.btnRecuperar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecuperar.ForeColor = System.Drawing.Color.White;
            this.btnRecuperar.Location = new System.Drawing.Point(66, 346);
            this.btnRecuperar.Name = "btnRecuperar";
            this.btnRecuperar.Size = new System.Drawing.Size(210, 32);
            this.btnRecuperar.TabIndex = 3;
            this.btnRecuperar.Text = "RECUPERAR ENERGIA";
            this.btnRecuperar.UseVisualStyleBackColor = false;
            this.btnRecuperar.Click += new System.EventHandler(this.btnRecuperar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(75)))), ((int)(((byte)(85)))));
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.ForeColor = System.Drawing.Color.Lime;
            this.btnVolver.Location = new System.Drawing.Point(550, 31);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(120, 45);
            this.btnVolver.TabIndex = 4;
            this.btnVolver.Text = "VOLVER";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnAlimentarCarne
            // 
            this.btnAlimentarCarne.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAlimentarCarne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlimentarCarne.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAlimentarCarne.Location = new System.Drawing.Point(282, 346);
            this.btnAlimentarCarne.Name = "btnAlimentarCarne";
            this.btnAlimentarCarne.Size = new System.Drawing.Size(257, 32);
            this.btnAlimentarCarne.TabIndex = 5;
            this.btnAlimentarCarne.Text = "ALIMENTAR CON CARNE";
            this.btnAlimentarCarne.UseVisualStyleBackColor = false;
            this.btnAlimentarCarne.Click += new System.EventHandler(this.btnAlimentarCarne_Click);
            // 
            // btnAlimentarVegetales
            // 
            this.btnAlimentarVegetales.BackColor = System.Drawing.Color.Green;
            this.btnAlimentarVegetales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlimentarVegetales.Location = new System.Drawing.Point(282, 394);
            this.btnAlimentarVegetales.Name = "btnAlimentarVegetales";
            this.btnAlimentarVegetales.Size = new System.Drawing.Size(257, 33);
            this.btnAlimentarVegetales.TabIndex = 6;
            this.btnAlimentarVegetales.Text = "ALIMENTAR CON VEGETALES";
            this.btnAlimentarVegetales.UseVisualStyleBackColor = false;
            this.btnAlimentarVegetales.Click += new System.EventHandler(this.btnAlimentarVegetales_Click);
            // 
            // btnEntrenar
            // 
            this.btnEntrenar.BackColor = System.Drawing.Color.Red;
            this.btnEntrenar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntrenar.Location = new System.Drawing.Point(66, 394);
            this.btnEntrenar.Name = "btnEntrenar";
            this.btnEntrenar.Size = new System.Drawing.Size(210, 33);
            this.btnEntrenar.TabIndex = 6;
            this.btnEntrenar.Text = "ENTRENAR";
            this.btnEntrenar.UseVisualStyleBackColor = false;
            this.btnEntrenar.Click += new System.EventHandler(this.btnEntrenar_Click);
            // 
            // lblExperiencia
            // 
            this.lblExperiencia.AutoSize = true;
            this.lblExperiencia.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblExperiencia.Location = new System.Drawing.Point(25, 49);
            this.lblExperiencia.Name = "lblExperiencia";
            this.lblExperiencia.Size = new System.Drawing.Size(91, 16);
            this.lblExperiencia.TabIndex = 6;
            this.lblExperiencia.Text = "Experiencia: 0";
            this.lblExperiencia.Click += new System.EventHandler(this.lblExperiencia_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(257, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(198, 93);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FormLaboratorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(682, 453);
            this.Controls.Add(this.btnEntrenar);
            this.Controls.Add(this.btnAlimentarVegetales);
            this.Controls.Add(this.btnAlimentarCarne);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnRecuperar);
            this.Controls.Add(this.panelDinosaurio);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormLaboratorio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLaboratorio";
            this.panelDinosaurio.ResumeLayout(false);
            this.panelDinosaurio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel panelDinosaurio;
        private System.Windows.Forms.Label lblVida;
        private System.Windows.Forms.Label lblNivel;
        private System.Windows.Forms.Label lblNombreDino;
        private System.Windows.Forms.ProgressBar progressEnergia;
        private System.Windows.Forms.Label lblTextoVida;
        private System.Windows.Forms.ProgressBar progressVida;
        private System.Windows.Forms.Label lblEnergia;
        private System.Windows.Forms.Button btnRecuperar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnAlimentarCarne;
        private System.Windows.Forms.Button btnAlimentarVegetales;
        private System.Windows.Forms.Label lblExperiencia;
        private System.Windows.Forms.Button btnEntrenar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}