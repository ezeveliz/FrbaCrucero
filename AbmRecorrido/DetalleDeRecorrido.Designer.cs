namespace FrbaCrucero.AbmRecorrido
{
    partial class DetalleDeRecorrido
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
            this.DGVTramos = new System.Windows.Forms.DataGridView();
            this.idTramo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Destino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblPrecioTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorController)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTramos)).BeginInit();
            this.SuspendLayout();
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.Titulo.Location = new System.Drawing.Point(22, 9);
            this.Titulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(328, 39);
            this.Titulo.TabIndex = 7;
            this.Titulo.Text = "Detalle de Recorrido";
            this.Titulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DGVTramos
            // 
            this.DGVTramos.AllowUserToAddRows = false;
            this.DGVTramos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVTramos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idTramo,
            this.Inicio,
            this.Destino,
            this.Precio});
            this.DGVTramos.Location = new System.Drawing.Point(12, 95);
            this.DGVTramos.Name = "DGVTramos";
            this.DGVTramos.Size = new System.Drawing.Size(343, 132);
            this.DGVTramos.TabIndex = 8;
            // 
            // idTramo
            // 
            this.idTramo.HeaderText = "idTramo";
            this.idTramo.Name = "idTramo";
            this.idTramo.Visible = false;
            // 
            // Inicio
            // 
            this.Inicio.HeaderText = "Inicio";
            this.Inicio.Name = "Inicio";
            // 
            // Destino
            // 
            this.Destino.HeaderText = "Destino";
            this.Destino.Name = "Destino";
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnVolver.Location = new System.Drawing.Point(117, 273);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(119, 42);
            this.btnVolver.TabIndex = 9;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblPrecioTotal
            // 
            this.lblPrecioTotal.AutoSize = true;
            this.lblPrecioTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioTotal.Location = new System.Drawing.Point(12, 244);
            this.lblPrecioTotal.Name = "lblPrecioTotal";
            this.lblPrecioTotal.Size = new System.Drawing.Size(63, 13);
            this.lblPrecioTotal.TabIndex = 11;
            this.lblPrecioTotal.Text = "Precio total:";
            // 
            // DetalleDeRecorrido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 323);
            this.Controls.Add(this.lblPrecioTotal);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.DGVTramos);
            this.Controls.Add(this.Titulo);
            this.Name = "DetalleDeRecorrido";
            this.Text = "Detalle De Recorrido";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DetalleRecorrido_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.errorController)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTramos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.DataGridView DGVTramos;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblPrecioTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTramo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Destino;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
    }
}