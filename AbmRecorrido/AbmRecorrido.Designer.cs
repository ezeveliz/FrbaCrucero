﻿namespace FrbaCrucero.AbmRecorrido
{
    partial class AbmRecorrido
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
            this.Atras = new System.Windows.Forms.Button();
            this.btnModificacion = new System.Windows.Forms.Button();
            this.BtnBaja = new System.Windows.Forms.Button();
            this.BtnAlta = new System.Windows.Forms.Button();
            this.Titulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorController)).BeginInit();
            this.SuspendLayout();
            // 
            // Atras
            // 
            this.Atras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Atras.Location = new System.Drawing.Point(67, 238);
            this.Atras.Margin = new System.Windows.Forms.Padding(2);
            this.Atras.Name = "Atras";
            this.Atras.Size = new System.Drawing.Size(151, 39);
            this.Atras.TabIndex = 12;
            this.Atras.Text = "Atras";
            this.Atras.UseVisualStyleBackColor = false;
            this.Atras.Click += new System.EventHandler(this.Atras_Click);
            // 
            // btnModificacion
            // 
            this.btnModificacion.Location = new System.Drawing.Point(67, 183);
            this.btnModificacion.Margin = new System.Windows.Forms.Padding(2);
            this.btnModificacion.Name = "btnModificacion";
            this.btnModificacion.Size = new System.Drawing.Size(151, 39);
            this.btnModificacion.TabIndex = 11;
            this.btnModificacion.Text = "Modificacion";
            this.btnModificacion.UseVisualStyleBackColor = true;
            this.btnModificacion.Click += new System.EventHandler(this.btnModificacion_Click);
            // 
            // BtnBaja
            // 
            this.BtnBaja.Location = new System.Drawing.Point(67, 122);
            this.BtnBaja.Margin = new System.Windows.Forms.Padding(2);
            this.BtnBaja.Name = "BtnBaja";
            this.BtnBaja.Size = new System.Drawing.Size(151, 39);
            this.BtnBaja.TabIndex = 10;
            this.BtnBaja.Text = "Baja";
            this.BtnBaja.UseVisualStyleBackColor = true;
            this.BtnBaja.Click += new System.EventHandler(this.BtnBaja_Click);
            // 
            // BtnAlta
            // 
            this.BtnAlta.Location = new System.Drawing.Point(67, 65);
            this.BtnAlta.Margin = new System.Windows.Forms.Padding(2);
            this.BtnAlta.Name = "BtnAlta";
            this.BtnAlta.Size = new System.Drawing.Size(151, 39);
            this.BtnAlta.TabIndex = 9;
            this.BtnAlta.Text = "Alta";
            this.BtnAlta.UseVisualStyleBackColor = true;
            this.BtnAlta.Click += new System.EventHandler(this.BtnAlta_Click);
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Titulo.Location = new System.Drawing.Point(65, 26);
            this.Titulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(160, 26);
            this.Titulo.TabIndex = 8;
            this.Titulo.Text = "ABM Recorrido";
            // 
            // AbmRecorrido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 303);
            this.Controls.Add(this.Atras);
            this.Controls.Add(this.btnModificacion);
            this.Controls.Add(this.BtnBaja);
            this.Controls.Add(this.BtnAlta);
            this.Controls.Add(this.Titulo);
            this.Name = "AbmRecorrido";
            this.Text = "ABM Recorrido";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AbmRecorrido_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.errorController)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Atras;
        private System.Windows.Forms.Button btnModificacion;
        private System.Windows.Forms.Button BtnBaja;
        private System.Windows.Forms.Button BtnAlta;
        private System.Windows.Forms.Label Titulo;




    }
}