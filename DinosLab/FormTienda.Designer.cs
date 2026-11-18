namespace DinosLab
{
    partial class FormTienda
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
            this.panelProductos = new System.Windows.Forms.Panel();
            this.lblCarne = new System.Windows.Forms.Label();
            this.pictureBoxCarne = new System.Windows.Forms.PictureBox();
            this.btnComprarCarne = new System.Windows.Forms.Button();
            this.lblVegetales = new System.Windows.Forms.Label();
            this.pictureBoxVegetales = new System.Windows.Forms.PictureBox();
            this.btnComprarVegetales = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.panelProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCarne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVegetales)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Teal;
            this.lblTitulo.Location = new System.Drawing.Point(191, 27);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(358, 50);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "TIENDA DINOCORE";
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);
            // 
            // lblMonedas
            // 
            this.lblMonedas.AutoSize = true;
            this.lblMonedas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonedas.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblMonedas.Location = new System.Drawing.Point(500, 85);
            this.lblMonedas.Name = "lblMonedas";
            this.lblMonedas.Size = new System.Drawing.Size(106, 20);
            this.lblMonedas.TabIndex = 1;
            this.lblMonedas.Text = "Monedas: 0";
            this.lblMonedas.Click += new System.EventHandler(this.lblMonedas_Click);
            // 
            // panelProductos
            // 
            this.panelProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(65)))));
            this.panelProductos.Controls.Add(this.btnComprarVegetales);
            this.panelProductos.Controls.Add(this.pictureBoxVegetales);
            this.panelProductos.Controls.Add(this.lblVegetales);
            this.panelProductos.Controls.Add(this.btnComprarCarne);
            this.panelProductos.Controls.Add(this.pictureBoxCarne);
            this.panelProductos.Controls.Add(this.lblCarne);
            this.panelProductos.Location = new System.Drawing.Point(75, 130);
            this.panelProductos.Name = "panelProductos";
            this.panelProductos.Size = new System.Drawing.Size(600, 240);
            this.panelProductos.TabIndex = 2;
            this.panelProductos.Paint += new System.Windows.Forms.PaintEventHandler(this.panelProductos_Paint);
            // 
            // lblCarne
            // 
            this.lblCarne.AutoSize = true;
            this.lblCarne.ForeColor = System.Drawing.Color.Lime;
            this.lblCarne.Location = new System.Drawing.Point(35, 35);
            this.lblCarne.Name = "lblCarne";
            this.lblCarne.Size = new System.Drawing.Size(145, 16);
            this.lblCarne.TabIndex = 0;
            this.lblCarne.Text = "CARNE: 50 MONEDAS";
            this.lblCarne.Click += new System.EventHandler(this.lblCarne_Click);
            // 
            // pictureBoxCarne
            // 
            this.pictureBoxCarne.Location = new System.Drawing.Point(38, 69);
            this.pictureBoxCarne.Name = "pictureBoxCarne";
            this.pictureBoxCarne.Size = new System.Drawing.Size(142, 65);
            this.pictureBoxCarne.TabIndex = 1;
            this.pictureBoxCarne.TabStop = false;
            this.pictureBoxCarne.Click += new System.EventHandler(this.pictureBoxCarne_Click);
            // 
            // btnComprarCarne
            // 
            this.btnComprarCarne.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnComprarCarne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComprarCarne.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnComprarCarne.Location = new System.Drawing.Point(52, 154);
            this.btnComprarCarne.Name = "btnComprarCarne";
            this.btnComprarCarne.Size = new System.Drawing.Size(108, 23);
            this.btnComprarCarne.TabIndex = 2;
            this.btnComprarCarne.Text = "COMPRAR";
            this.btnComprarCarne.UseVisualStyleBackColor = false;
            this.btnComprarCarne.Click += new System.EventHandler(this.btnComprarCarne_Click);
            // 
            // lblVegetales
            // 
            this.lblVegetales.AutoSize = true;
            this.lblVegetales.ForeColor = System.Drawing.Color.Lime;
            this.lblVegetales.Location = new System.Drawing.Point(330, 35);
            this.lblVegetales.Name = "lblVegetales";
            this.lblVegetales.Size = new System.Drawing.Size(87, 16);
            this.lblVegetales.TabIndex = 3;
            this.lblVegetales.Text = "VEGETALES";
            this.lblVegetales.Click += new System.EventHandler(this.lblVegetales_Click);
            // 
            // pictureBoxVegetales
            // 
            this.pictureBoxVegetales.Location = new System.Drawing.Point(299, 69);
            this.pictureBoxVegetales.Name = "pictureBoxVegetales";
            this.pictureBoxVegetales.Size = new System.Drawing.Size(142, 65);
            this.pictureBoxVegetales.TabIndex = 4;
            this.pictureBoxVegetales.TabStop = false;
            this.pictureBoxVegetales.Click += new System.EventHandler(this.pictureBoxVegetales_Click);
            // 
            // btnComprarVegetales
            // 
            this.btnComprarVegetales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnComprarVegetales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComprarVegetales.ForeColor = System.Drawing.Color.Lime;
            this.btnComprarVegetales.Location = new System.Drawing.Point(309, 154);
            this.btnComprarVegetales.Name = "btnComprarVegetales";
            this.btnComprarVegetales.Size = new System.Drawing.Size(108, 23);
            this.btnComprarVegetales.TabIndex = 5;
            this.btnComprarVegetales.Text = "COMPRAR";
            this.btnComprarVegetales.UseVisualStyleBackColor = false;
            this.btnComprarVegetales.Click += new System.EventHandler(this.btnComprarVegetales_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.ForeColor = System.Drawing.Color.Lime;
            this.btnVolver.Location = new System.Drawing.Point(543, 408);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(151, 40);
            this.btnVolver.TabIndex = 3;
            this.btnVolver.Text = "VOLVER";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // FormTienda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(732, 473);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.panelProductos);
            this.Controls.Add(this.lblMonedas);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormTienda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormTienda";
            this.panelProductos.ResumeLayout(false);
            this.panelProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCarne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVegetales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblMonedas;
        private System.Windows.Forms.Panel panelProductos;
        private System.Windows.Forms.Label lblCarne;
        private System.Windows.Forms.PictureBox pictureBoxVegetales;
        private System.Windows.Forms.Label lblVegetales;
        private System.Windows.Forms.Button btnComprarCarne;
        private System.Windows.Forms.PictureBox pictureBoxCarne;
        private System.Windows.Forms.Button btnComprarVegetales;
        private System.Windows.Forms.Button btnVolver;
    }
}