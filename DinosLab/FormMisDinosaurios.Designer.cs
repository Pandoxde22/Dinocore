namespace DinosLab
{
    partial class FormMisDinosaurios
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.panelDinosaurios = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Lime;
            this.lblTitulo.Location = new System.Drawing.Point(35, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(354, 50);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "MIS DINOSAURIOS";
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(755, 425);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(39)))), ((int)(((byte)(34)))));
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnVolver.ForeColor = System.Drawing.Color.Lime;
            this.btnVolver.Location = new System.Drawing.Point(760, 601);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(175, 40);
            this.btnVolver.TabIndex = 3;
            this.btnVolver.Text = "VOLVER AL MENU";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // panelDinosaurios
            // 
            this.panelDinosaurios.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.panelDinosaurios.AutoScroll = true;
            this.panelDinosaurios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(39)))), ((int)(((byte)(34)))));
            this.panelDinosaurios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDinosaurios.Location = new System.Drawing.Point(35, 100);
            this.panelDinosaurios.Name = "panelDinosaurios";
            this.panelDinosaurios.Size = new System.Drawing.Size(900, 480);
            this.panelDinosaurios.TabIndex = 2;
            this.panelDinosaurios.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDinosaurios_Paint);
            // 
            // FormMisDinosaurios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(23)))));
            this.ClientSize = new System.Drawing.Size(982, 653);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.panelDinosaurios);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMisDinosaurios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMisDinosaurios";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Panel panelDinosaurios;
    }
}