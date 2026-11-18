namespace DinosLab
{
    partial class Combate
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
            this.lblMiDino = new System.Windows.Forms.Label();
            this.lblRival = new System.Windows.Forms.Label();
            this.pictureMIDino = new System.Windows.Forms.PictureBox();
            this.pictureRival = new System.Windows.Forms.PictureBox();
            this.lblNivelMiDino = new System.Windows.Forms.Label();
            this.lblVidaMiDino = new System.Windows.Forms.Label();
            this.progressVidaMiDino = new System.Windows.Forms.ProgressBar();
            this.lblNivelRival = new System.Windows.Forms.Label();
            this.lblVidaRival = new System.Windows.Forms.Label();
            this.progressVidaRival = new System.Windows.Forms.ProgressBar();
            this.lblRegistro = new System.Windows.Forms.Label();
            this.listBatalla = new System.Windows.Forms.ListBox();
            this.btnHabilidad = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnAtacar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMIDino)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRival)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Lime;
            this.lblTitulo.Location = new System.Drawing.Point(249, 22);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(389, 50);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "ARENA DE COMBATE";
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);
            // 
            // lblMiDino
            // 
            this.lblMiDino.AutoSize = true;
            this.lblMiDino.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMiDino.ForeColor = System.Drawing.Color.Lime;
            this.lblMiDino.Location = new System.Drawing.Point(44, 95);
            this.lblMiDino.Name = "lblMiDino";
            this.lblMiDino.Size = new System.Drawing.Size(177, 25);
            this.lblMiDino.TabIndex = 1;
            this.lblMiDino.Text = "MI DINOSAURIO";
            this.lblMiDino.Click += new System.EventHandler(this.lblMiDino_Click);
            // 
            // lblRival
            // 
            this.lblRival.AutoSize = true;
            this.lblRival.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRival.ForeColor = System.Drawing.Color.Lime;
            this.lblRival.Location = new System.Drawing.Point(612, 95);
            this.lblRival.Name = "lblRival";
            this.lblRival.Size = new System.Drawing.Size(215, 25);
            this.lblRival.TabIndex = 2;
            this.lblRival.Text = "DINOSAURIO RIVAL";
            this.lblRival.Click += new System.EventHandler(this.lblRival_Click);
            // 
            // pictureMIDino
            // 
            this.pictureMIDino.Location = new System.Drawing.Point(44, 141);
            this.pictureMIDino.Name = "pictureMIDino";
            this.pictureMIDino.Size = new System.Drawing.Size(187, 148);
            this.pictureMIDino.TabIndex = 3;
            this.pictureMIDino.TabStop = false;
            this.pictureMIDino.Click += new System.EventHandler(this.pictureMIDino_Click);
            // 
            // pictureRival
            // 
            this.pictureRival.Location = new System.Drawing.Point(628, 141);
            this.pictureRival.Name = "pictureRival";
            this.pictureRival.Size = new System.Drawing.Size(199, 148);
            this.pictureRival.TabIndex = 4;
            this.pictureRival.TabStop = false;
            this.pictureRival.Click += new System.EventHandler(this.pictureRival_Click);
            // 
            // lblNivelMiDino
            // 
            this.lblNivelMiDino.AutoSize = true;
            this.lblNivelMiDino.ForeColor = System.Drawing.Color.White;
            this.lblNivelMiDino.Location = new System.Drawing.Point(50, 312);
            this.lblNivelMiDino.Name = "lblNivelMiDino";
            this.lblNivelMiDino.Size = new System.Drawing.Size(48, 16);
            this.lblNivelMiDino.TabIndex = 5;
            this.lblNivelMiDino.Text = "NIVEL:";
            this.lblNivelMiDino.Click += new System.EventHandler(this.lblNivelMiDino_Click);
            // 
            // lblVidaMiDino
            // 
            this.lblVidaMiDino.AutoSize = true;
            this.lblVidaMiDino.ForeColor = System.Drawing.Color.White;
            this.lblVidaMiDino.Location = new System.Drawing.Point(50, 344);
            this.lblVidaMiDino.Name = "lblVidaMiDino";
            this.lblVidaMiDino.Size = new System.Drawing.Size(87, 16);
            this.lblVidaMiDino.TabIndex = 6;
            this.lblVidaMiDino.Text = "VIDA 100/100";
            this.lblVidaMiDino.Click += new System.EventHandler(this.lblVidaMiDino_Click);
            // 
            // progressVidaMiDino
            // 
            this.progressVidaMiDino.Location = new System.Drawing.Point(44, 376);
            this.progressVidaMiDino.Name = "progressVidaMiDino";
            this.progressVidaMiDino.Size = new System.Drawing.Size(269, 23);
            this.progressVidaMiDino.TabIndex = 7;
            this.progressVidaMiDino.Value = 100;
            this.progressVidaMiDino.Click += new System.EventHandler(this.progressVidaMiDino_Click);
            // 
            // lblNivelRival
            // 
            this.lblNivelRival.AutoSize = true;
            this.lblNivelRival.ForeColor = System.Drawing.Color.White;
            this.lblNivelRival.Location = new System.Drawing.Point(614, 312);
            this.lblNivelRival.Name = "lblNivelRival";
            this.lblNivelRival.Size = new System.Drawing.Size(48, 16);
            this.lblNivelRival.TabIndex = 8;
            this.lblNivelRival.Text = "NIVEL:";
            this.lblNivelRival.Click += new System.EventHandler(this.lblNivelRival_Click);
            // 
            // lblVidaRival
            // 
            this.lblVidaRival.AutoSize = true;
            this.lblVidaRival.ForeColor = System.Drawing.Color.White;
            this.lblVidaRival.Location = new System.Drawing.Point(614, 344);
            this.lblVidaRival.Name = "lblVidaRival";
            this.lblVidaRival.Size = new System.Drawing.Size(87, 16);
            this.lblVidaRival.TabIndex = 9;
            this.lblVidaRival.Text = "VIDA 100/100";
            this.lblVidaRival.Click += new System.EventHandler(this.lblVidaRival_Click);
            // 
            // progressVidaRival
            // 
            this.progressVidaRival.Location = new System.Drawing.Point(558, 376);
            this.progressVidaRival.Name = "progressVidaRival";
            this.progressVidaRival.Size = new System.Drawing.Size(269, 23);
            this.progressVidaRival.TabIndex = 10;
            this.progressVidaRival.Value = 100;
            this.progressVidaRival.Click += new System.EventHandler(this.progressVidaRival_Click);
            // 
            // lblRegistro
            // 
            this.lblRegistro.AutoSize = true;
            this.lblRegistro.BackColor = System.Drawing.Color.Lime;
            this.lblRegistro.Location = new System.Drawing.Point(53, 435);
            this.lblRegistro.Name = "lblRegistro";
            this.lblRegistro.Size = new System.Drawing.Size(161, 16);
            this.lblRegistro.TabIndex = 11;
            this.lblRegistro.Text = "REGISTRO DE BATALLA";
            this.lblRegistro.Click += new System.EventHandler(this.lblRegistro_Click);
            // 
            // listBatalla
            // 
            this.listBatalla.FormattingEnabled = true;
            this.listBatalla.ItemHeight = 16;
            this.listBatalla.Location = new System.Drawing.Point(49, 457);
            this.listBatalla.Name = "listBatalla";
            this.listBatalla.Size = new System.Drawing.Size(327, 84);
            this.listBatalla.TabIndex = 12;
            this.listBatalla.SelectedIndexChanged += new System.EventHandler(this.listBatalla_SelectedIndexChanged);
            // 
            // btnHabilidad
            // 
            this.btnHabilidad.BackColor = System.Drawing.Color.Blue;
            this.btnHabilidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHabilidad.Location = new System.Drawing.Point(376, 344);
            this.btnHabilidad.Name = "btnHabilidad";
            this.btnHabilidad.Size = new System.Drawing.Size(119, 41);
            this.btnHabilidad.TabIndex = 13;
            this.btnHabilidad.Text = "HABILIDAD";
            this.btnHabilidad.UseVisualStyleBackColor = false;
            this.btnHabilidad.Click += new System.EventHandler(this.btnHabilidad_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.Black;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.ForeColor = System.Drawing.Color.Lime;
            this.btnVolver.Location = new System.Drawing.Point(752, 495);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(118, 46);
            this.btnVolver.TabIndex = 14;
            this.btnVolver.Text = "VOLVER";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnAtacar
            // 
            this.btnAtacar.BackColor = System.Drawing.Color.Red;
            this.btnAtacar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtacar.Location = new System.Drawing.Point(376, 290);
            this.btnAtacar.Name = "btnAtacar";
            this.btnAtacar.Size = new System.Drawing.Size(119, 48);
            this.btnAtacar.TabIndex = 15;
            this.btnAtacar.Text = "ATACAR";
            this.btnAtacar.UseVisualStyleBackColor = false;
            this.btnAtacar.Click += new System.EventHandler(this.btnAtacar_Click);
            // 
            // Combate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.btnAtacar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnHabilidad);
            this.Controls.Add(this.listBatalla);
            this.Controls.Add(this.lblRegistro);
            this.Controls.Add(this.progressVidaRival);
            this.Controls.Add(this.lblVidaRival);
            this.Controls.Add(this.lblNivelRival);
            this.Controls.Add(this.progressVidaMiDino);
            this.Controls.Add(this.lblVidaMiDino);
            this.Controls.Add(this.lblNivelMiDino);
            this.Controls.Add(this.pictureRival);
            this.Controls.Add(this.pictureMIDino);
            this.Controls.Add(this.lblRival);
            this.Controls.Add(this.lblMiDino);
            this.Controls.Add(this.lblTitulo);
            this.Name = "Combate";
            this.Text = "Combate";
            ((System.ComponentModel.ISupportInitialize)(this.pictureMIDino)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRival)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblMiDino;
        private System.Windows.Forms.Label lblRival;
        private System.Windows.Forms.PictureBox pictureMIDino;
        private System.Windows.Forms.PictureBox pictureRival;
        private System.Windows.Forms.Label lblNivelMiDino;
        private System.Windows.Forms.Label lblVidaMiDino;
        private System.Windows.Forms.ProgressBar progressVidaMiDino;
        private System.Windows.Forms.Label lblNivelRival;
        private System.Windows.Forms.Label lblVidaRival;
        private System.Windows.Forms.ProgressBar progressVidaRival;
        private System.Windows.Forms.Label lblRegistro;
        private System.Windows.Forms.ListBox listBatalla;
        private System.Windows.Forms.Button btnHabilidad;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnAtacar;
    }
}