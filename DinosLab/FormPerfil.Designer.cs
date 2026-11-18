namespace DinosLab
{
    partial class FormPerfil
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
            this.lblMonedas = new System.Windows.Forms.Label();
            this.lblVictorias = new System.Windows.Forms.Label();
            this.lblDerrotas = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Lime;
            this.lblTitulo.Location = new System.Drawing.Point(112, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(149, 38);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "TU PERFIL";
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);
            // 
            // lblMonedas
            // 
            this.lblMonedas.AutoSize = true;
            this.lblMonedas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(23)))));
            this.lblMonedas.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonedas.ForeColor = System.Drawing.SystemColors.Control;
            this.lblMonedas.Location = new System.Drawing.Point(107, 120);
            this.lblMonedas.Name = "lblMonedas";
            this.lblMonedas.Size = new System.Drawing.Size(172, 32);
            this.lblMonedas.TabIndex = 1;
            this.lblMonedas.Text = "MONEDAS:";
            this.lblMonedas.Click += new System.EventHandler(this.lblMonedas_Click);
            // 
            // lblVictorias
            // 
            this.lblVictorias.AutoSize = true;
            this.lblVictorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVictorias.ForeColor = System.Drawing.SystemColors.Control;
            this.lblVictorias.Location = new System.Drawing.Point(107, 174);
            this.lblVictorias.Name = "lblVictorias";
            this.lblVictorias.Size = new System.Drawing.Size(182, 32);
            this.lblVictorias.TabIndex = 2;
            this.lblVictorias.Text = "VICTORIAS:";
            this.lblVictorias.Click += new System.EventHandler(this.lblVictorias_Click);
            // 
            // lblDerrotas
            // 
            this.lblDerrotas.AutoSize = true;
            this.lblDerrotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDerrotas.ForeColor = System.Drawing.SystemColors.Control;
            this.lblDerrotas.Location = new System.Drawing.Point(107, 220);
            this.lblDerrotas.Name = "lblDerrotas";
            this.lblDerrotas.Size = new System.Drawing.Size(187, 32);
            this.lblDerrotas.TabIndex = 3;
            this.lblDerrotas.Text = "DERROTAS:";
            this.lblDerrotas.Click += new System.EventHandler(this.lblDerrotas_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.ForeColor = System.Drawing.Color.Lime;
            this.btnVolver.Location = new System.Drawing.Point(370, 351);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(200, 40);
            this.btnVolver.TabIndex = 4;
            this.btnVolver.Text = "VOLVER";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.SystemColors.Control;
            this.lblNombre.Location = new System.Drawing.Point(107, 75);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(152, 32);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "NOMBRE:";
            this.lblNombre.Click += new System.EventHandler(this.lblNombre_Click);
            // 
            // FormPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(23)))));
            this.ClientSize = new System.Drawing.Size(582, 403);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lblDerrotas);
            this.Controls.Add(this.lblVictorias);
            this.Controls.Add(this.lblMonedas);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FormPerfil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPerfil";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblMonedas;
        private System.Windows.Forms.Label lblVictorias;
        private System.Windows.Forms.Label lblDerrotas;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblNombre;
    }
}