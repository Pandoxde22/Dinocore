namespace DinosLab
{
    partial class FormMisiones
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
            this.panelMisiones = new System.Windows.Forms.Panel();
            this.lblListaMisiones = new System.Windows.Forms.Label();
            this.listMisiones = new System.Windows.Forms.ListBox();
            this.panelDetalles = new System.Windows.Forms.Panel();
            this.lblTituloDetalle = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblProgreso = new System.Windows.Forms.Label();
            this.lblRecompensa = new System.Windows.Forms.Label();
            this.btnReclamar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblNombreMision = new System.Windows.Forms.Label();
            this.lblObjetivo = new System.Windows.Forms.Label();
            this.panelMisiones.SuspendLayout();
            this.panelDetalles.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(220)))), ((int)(((byte)(170)))));
            this.lblTitulo.Location = new System.Drawing.Point(285, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(230, 45);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "MISIONES";
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(220)))), ((int)(((byte)(170)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(220, 75);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(343, 18);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "CENTRO DE OPERACIONES Y OBJETIVOS";
            this.lblSubtitulo.Click += new System.EventHandler(this.lblSubtitulo_Click);
            // 
            // panelMisiones
            // 
            this.panelMisiones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(65)))));
            this.panelMisiones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMisiones.Controls.Add(this.listMisiones);
            this.panelMisiones.Controls.Add(this.lblListaMisiones);
            this.panelMisiones.Location = new System.Drawing.Point(35, 135);
            this.panelMisiones.Name = "panelMisiones";
            this.panelMisiones.Size = new System.Drawing.Size(350, 330);
            this.panelMisiones.TabIndex = 2;
            this.panelMisiones.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMisiones_Paint);
            // 
            // lblListaMisiones
            // 
            this.lblListaMisiones.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaMisiones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(220)))), ((int)(((byte)(170)))));
            this.lblListaMisiones.Location = new System.Drawing.Point(15, 15);
            this.lblListaMisiones.Name = "lblListaMisiones";
            this.lblListaMisiones.Size = new System.Drawing.Size(314, 16);
            this.lblListaMisiones.TabIndex = 0;
            this.lblListaMisiones.Text = "MISIONES DISPONIBLES";
            this.lblListaMisiones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblListaMisiones.Click += new System.EventHandler(this.lblListaMisiones_Click);
            // 
            // listMisiones
            // 
            this.listMisiones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(45)))));
            this.listMisiones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listMisiones.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listMisiones.ForeColor = System.Drawing.SystemColors.Window;
            this.listMisiones.FormattingEnabled = true;
            this.listMisiones.ItemHeight = 23;
            this.listMisiones.Location = new System.Drawing.Point(15, 60);
            this.listMisiones.Name = "listMisiones";
            this.listMisiones.Size = new System.Drawing.Size(310, 232);
            this.listMisiones.TabIndex = 1;
            this.listMisiones.SelectedIndexChanged += new System.EventHandler(this.listMisiones_SelectedIndexChanged);
            // 
            // panelDetalles
            // 
            this.panelDetalles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDetalles.Controls.Add(this.lblObjetivo);
            this.panelDetalles.Controls.Add(this.lblNombreMision);
            this.panelDetalles.Controls.Add(this.lblRecompensa);
            this.panelDetalles.Controls.Add(this.lblProgreso);
            this.panelDetalles.Controls.Add(this.lblDescripcion);
            this.panelDetalles.Controls.Add(this.lblTituloDetalle);
            this.panelDetalles.Location = new System.Drawing.Point(410, 135);
            this.panelDetalles.Name = "panelDetalles";
            this.panelDetalles.Size = new System.Drawing.Size(360, 330);
            this.panelDetalles.TabIndex = 3;
            this.panelDetalles.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDetalles_Paint);
            // 
            // lblTituloDetalle
            // 
            this.lblTituloDetalle.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(220)))), ((int)(((byte)(170)))));
            this.lblTituloDetalle.Location = new System.Drawing.Point(15, 15);
            this.lblTituloDetalle.Name = "lblTituloDetalle";
            this.lblTituloDetalle.Size = new System.Drawing.Size(310, 30);
            this.lblTituloDetalle.TabIndex = 0;
            this.lblTituloDetalle.Text = "Detalles de Mision";
            this.lblTituloDetalle.Click += new System.EventHandler(this.lblTituloDetalle_Click);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDescripcion.Location = new System.Drawing.Point(20, 100);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(310, 55);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Descripcion De La Mision;";
            this.lblDescripcion.Click += new System.EventHandler(this.lblDescripcion_Click);
            // 
            // lblProgreso
            // 
            this.lblProgreso.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblProgreso.Location = new System.Drawing.Point(20, 205);
            this.lblProgreso.Name = "lblProgreso";
            this.lblProgreso.Size = new System.Drawing.Size(310, 25);
            this.lblProgreso.TabIndex = 2;
            this.lblProgreso.Text = "PROGRESO 0/0";
            this.lblProgreso.Click += new System.EventHandler(this.lblProgreso_Click);
            // 
            // lblRecompensa
            // 
            this.lblRecompensa.AutoSize = true;
            this.lblRecompensa.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblRecompensa.Location = new System.Drawing.Point(20, 245);
            this.lblRecompensa.Name = "lblRecompensa";
            this.lblRecompensa.Size = new System.Drawing.Size(162, 16);
            this.lblRecompensa.TabIndex = 3;
            this.lblRecompensa.Text = "Recompensa: 0 monedas";
            this.lblRecompensa.Click += new System.EventHandler(this.lblRecompensa_Click);
            // 
            // btnReclamar
            // 
            this.btnReclamar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(150)))), ((int)(((byte)(100)))));
            this.btnReclamar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReclamar.Location = new System.Drawing.Point(410, 475);
            this.btnReclamar.Name = "btnReclamar";
            this.btnReclamar.Size = new System.Drawing.Size(220, 40);
            this.btnReclamar.TabIndex = 4;
            this.btnReclamar.Text = "Reclamar Recompensa";
            this.btnReclamar.UseVisualStyleBackColor = false;
            this.btnReclamar.Click += new System.EventHandler(this.btnReclamar_Click_1);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(75)))), ((int)(((byte)(85)))));
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(650, 475);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(115, 40);
            this.btnVolver.TabIndex = 5;
            this.btnVolver.Text = "VOLVER";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click_1);
            // 
            // lblNombreMision
            // 
            this.lblNombreMision.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNombreMision.Location = new System.Drawing.Point(20, 60);
            this.lblNombreMision.Name = "lblNombreMision";
            this.lblNombreMision.Size = new System.Drawing.Size(310, 30);
            this.lblNombreMision.TabIndex = 4;
            this.lblNombreMision.Text = "Nombre De La Mision:";
            this.lblNombreMision.Click += new System.EventHandler(this.lblNombreMision_Click);
            // 
            // lblObjetivo
            // 
            this.lblObjetivo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblObjetivo.Location = new System.Drawing.Point(20, 146);
            this.lblObjetivo.Name = "lblObjetivo";
            this.lblObjetivo.Size = new System.Drawing.Size(310, 20);
            this.lblObjetivo.TabIndex = 5;
            this.lblObjetivo.Text = "Objetivo:";
            this.lblObjetivo.Click += new System.EventHandler(this.lblObjetivo_Click);
            // 
            // FormMisiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(798, 524);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnReclamar);
            this.Controls.Add(this.panelDetalles);
            this.Controls.Add(this.panelMisiones);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMisiones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMisiones";
            this.panelMisiones.ResumeLayout(false);
            this.panelDetalles.ResumeLayout(false);
            this.panelDetalles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel panelMisiones;
        private System.Windows.Forms.Label lblListaMisiones;
        private System.Windows.Forms.ListBox listMisiones;
        private System.Windows.Forms.Panel panelDetalles;
        private System.Windows.Forms.Label lblTituloDetalle;
        private System.Windows.Forms.Label lblProgreso;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblRecompensa;
        private System.Windows.Forms.Button btnReclamar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblObjetivo;
        private System.Windows.Forms.Label lblNombreMision;
    }
}