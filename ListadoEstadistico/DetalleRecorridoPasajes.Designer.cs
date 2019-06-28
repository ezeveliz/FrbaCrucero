namespace FrbaCrucero.ListadoEstadistico
{
    partial class DetalleRecorridoPasajes
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
            this.lblPrecioTotal = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.DGVTramos = new System.Windows.Forms.DataGridView();
            this.idTramo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Destino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Titulo = new System.Windows.Forms.Label();
            this.DGVMeses = new System.Windows.Forms.DataGridView();
            this.Mes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadVendida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblVendidos = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorController)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTramos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMeses)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPrecioTotal
            // 
            this.lblPrecioTotal.AutoSize = true;
            this.lblPrecioTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioTotal.Location = new System.Drawing.Point(12, 250);
            this.lblPrecioTotal.Name = "lblPrecioTotal";
            this.lblPrecioTotal.Size = new System.Drawing.Size(63, 13);
            this.lblPrecioTotal.TabIndex = 15;
            this.lblPrecioTotal.Text = "Precio total:";
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnVolver.Location = new System.Drawing.Point(110, 508);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(119, 42);
            this.btnVolver.TabIndex = 14;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // DGVTramos
            // 
            this.DGVTramos.AllowUserToAddRows = false;
            this.DGVTramos.AllowUserToDeleteRows = false;
            this.DGVTramos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVTramos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idTramo,
            this.Inicio,
            this.Destino,
            this.Precio});
            this.DGVTramos.Location = new System.Drawing.Point(12, 115);
            this.DGVTramos.Name = "DGVTramos";
            this.DGVTramos.ReadOnly = true;
            this.DGVTramos.Size = new System.Drawing.Size(343, 132);
            this.DGVTramos.TabIndex = 13;
            // 
            // idTramo
            // 
            this.idTramo.HeaderText = "idTramo";
            this.idTramo.Name = "idTramo";
            this.idTramo.ReadOnly = true;
            this.idTramo.Visible = false;
            // 
            // Inicio
            // 
            this.Inicio.HeaderText = "Inicio";
            this.Inicio.Name = "Inicio";
            this.Inicio.ReadOnly = true;
            // 
            // Destino
            // 
            this.Destino.HeaderText = "Destino";
            this.Destino.Name = "Destino";
            this.Destino.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.Titulo.Location = new System.Drawing.Point(22, 15);
            this.Titulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(328, 39);
            this.Titulo.TabIndex = 12;
            this.Titulo.Text = "Detalle de Recorrido";
            this.Titulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DGVMeses
            // 
            this.DGVMeses.AllowUserToAddRows = false;
            this.DGVMeses.AllowUserToDeleteRows = false;
            this.DGVMeses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVMeses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Mes,
            this.CantidadVendida});
            this.DGVMeses.Location = new System.Drawing.Point(54, 279);
            this.DGVMeses.Name = "DGVMeses";
            this.DGVMeses.ReadOnly = true;
            this.DGVMeses.Size = new System.Drawing.Size(258, 186);
            this.DGVMeses.TabIndex = 16;
            // 
            // Mes
            // 
            this.Mes.HeaderText = "Mes";
            this.Mes.Name = "Mes";
            this.Mes.ReadOnly = true;
            // 
            // CantidadVendida
            // 
            this.CantidadVendida.HeaderText = "Cantidad Vendida";
            this.CantidadVendida.Name = "CantidadVendida";
            this.CantidadVendida.ReadOnly = true;
            // 
            // lblVendidos
            // 
            this.lblVendidos.AutoSize = true;
            this.lblVendidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendidos.Location = new System.Drawing.Point(15, 481);
            this.lblVendidos.Name = "lblVendidos";
            this.lblVendidos.Size = new System.Drawing.Size(35, 13);
            this.lblVendidos.TabIndex = 17;
            this.lblVendidos.Text = "label1";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(107, 90);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(37, 13);
            this.lblFecha.TabIndex = 32;
            this.lblFecha.Text = "Fecha";
            // 
            // DetalleRecorridoPasajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 562);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblVendidos);
            this.Controls.Add(this.DGVMeses);
            this.Controls.Add(this.lblPrecioTotal);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.DGVTramos);
            this.Controls.Add(this.Titulo);
            this.Name = "DetalleRecorridoPasajes";
            this.Text = "DetalleRecorridoPasajes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DetalleRecorridoPasajes_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.errorController)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTramos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMeses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPrecioTotal;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridView DGVTramos;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTramo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Destino;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.DataGridView DGVMeses;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mes;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadVendida;
        private System.Windows.Forms.Label lblVendidos;
        private System.Windows.Forms.Label lblFecha;
    }
}