namespace FrbaCrucero.AbmCrucero
{
    partial class AbmC
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
            this.Titulo = new System.Windows.Forms.Label();
            this.BtnAlta = new System.Windows.Forms.Button();
            this.BtnBaja = new System.Windows.Forms.Button();
            this.btnModificacion = new System.Windows.Forms.Button();
            this.Atras = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Titulo.Location = new System.Drawing.Point(92, 37);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(225, 37);
            this.Titulo.TabIndex = 3;
            this.Titulo.Text = "ABM Cruceros";
            // 
            // BtnAlta
            // 
            this.BtnAlta.Location = new System.Drawing.Point(94, 97);
            this.BtnAlta.Name = "BtnAlta";
            this.BtnAlta.Size = new System.Drawing.Size(226, 60);
            this.BtnAlta.TabIndex = 4;
            this.BtnAlta.Text = "Alta";
            this.BtnAlta.UseVisualStyleBackColor = true;
            this.BtnAlta.Click += new System.EventHandler(this.BtnAlta_Click);
            // 
            // BtnBaja
            // 
            this.BtnBaja.Location = new System.Drawing.Point(94, 185);
            this.BtnBaja.Name = "BtnBaja";
            this.BtnBaja.Size = new System.Drawing.Size(226, 60);
            this.BtnBaja.TabIndex = 5;
            this.BtnBaja.Text = "Baja";
            this.BtnBaja.UseVisualStyleBackColor = true;
            this.BtnBaja.Click += new System.EventHandler(this.BtnBaja_Click);
            // 
            // btnModificacion
            // 
            this.btnModificacion.Location = new System.Drawing.Point(94, 278);
            this.btnModificacion.Name = "btnModificacion";
            this.btnModificacion.Size = new System.Drawing.Size(226, 60);
            this.btnModificacion.TabIndex = 6;
            this.btnModificacion.Text = "Modificacion";
            this.btnModificacion.UseVisualStyleBackColor = true;
            this.btnModificacion.Click += new System.EventHandler(this.btnModificacion_Click);
            // 
            // Atras
            // 
            this.Atras.Location = new System.Drawing.Point(94, 363);
            this.Atras.Name = "Atras";
            this.Atras.Size = new System.Drawing.Size(226, 60);
            this.Atras.TabIndex = 7;
            this.Atras.Text = "Atras";
            this.Atras.UseVisualStyleBackColor = true;
            this.Atras.Click += new System.EventHandler(this.Atras_Click_1);
            // 
            // AbmCrucero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 453);
            this.Controls.Add(this.Atras);
            this.Controls.Add(this.btnModificacion);
            this.Controls.Add(this.BtnBaja);
            this.Controls.Add(this.BtnAlta);
            this.Controls.Add(this.Titulo);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AbmCrucero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABM Crucero";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AbmCrucero_FormClosed);



        }

        #endregion

        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.Button BtnAlta;
        private System.Windows.Forms.Button BtnBaja;
        private System.Windows.Forms.Button btnModificacion;
        private System.Windows.Forms.Button Atras;
    }
}