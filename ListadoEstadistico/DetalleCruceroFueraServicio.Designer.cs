namespace FrbaCrucero.ListadoEstadistico
{
    partial class DetalleCruceroFueraServicio
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
            this.DGVMeses = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiasFueraDeServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblDias = new System.Windows.Forms.Label();
            this.lblIdentificador = new System.Windows.Forms.Label();
            this.txtIdentificador = new System.Windows.Forms.TextBox();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.lblModelo = new System.Windows.Forms.Label();
            this.txtAlta = new System.Windows.Forms.TextBox();
            this.lblAlta = new System.Windows.Forms.Label();
            this.txtInhabilitado = new System.Windows.Forms.TextBox();
            this.lblInhabilitado = new System.Windows.Forms.Label();
            this.txtFabricante = new System.Windows.Forms.TextBox();
            this.lblFabricante = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorController)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMeses)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblTitulo.Location = new System.Drawing.Point(42, 9);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(199, 26);
            this.lblTitulo.TabIndex = 15;
            this.lblTitulo.Text = "Detalle de Crucero:";
            // 
            // DGVMeses
            // 
            this.DGVMeses.AllowUserToAddRows = false;
            this.DGVMeses.AllowUserToDeleteRows = false;
            this.DGVMeses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVMeses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.DiasFueraDeServicio});
            this.DGVMeses.Location = new System.Drawing.Point(14, 248);
            this.DGVMeses.Name = "DGVMeses";
            this.DGVMeses.ReadOnly = true;
            this.DGVMeses.Size = new System.Drawing.Size(258, 186);
            this.DGVMeses.TabIndex = 18;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Mes";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // DiasFueraDeServicio
            // 
            this.DiasFueraDeServicio.HeaderText = "Dias Fuera De Servicio";
            this.DiasFueraDeServicio.Name = "DiasFueraDeServicio";
            this.DiasFueraDeServicio.ReadOnly = true;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnVolver.Location = new System.Drawing.Point(80, 470);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(119, 42);
            this.btnVolver.TabIndex = 19;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblDias
            // 
            this.lblDias.AutoSize = true;
            this.lblDias.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDias.Location = new System.Drawing.Point(12, 446);
            this.lblDias.Name = "lblDias";
            this.lblDias.Size = new System.Drawing.Size(28, 13);
            this.lblDias.TabIndex = 20;
            this.lblDias.Text = "Dias";
            // 
            // lblIdentificador
            // 
            this.lblIdentificador.AutoSize = true;
            this.lblIdentificador.Location = new System.Drawing.Point(29, 90);
            this.lblIdentificador.Name = "lblIdentificador";
            this.lblIdentificador.Size = new System.Drawing.Size(65, 13);
            this.lblIdentificador.TabIndex = 21;
            this.lblIdentificador.Text = "Identificador";
            // 
            // txtIdentificador
            // 
            this.txtIdentificador.Location = new System.Drawing.Point(32, 107);
            this.txtIdentificador.Name = "txtIdentificador";
            this.txtIdentificador.ReadOnly = true;
            this.txtIdentificador.Size = new System.Drawing.Size(100, 20);
            this.txtIdentificador.TabIndex = 22;
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(32, 155);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.ReadOnly = true;
            this.txtModelo.Size = new System.Drawing.Size(100, 20);
            this.txtModelo.TabIndex = 24;
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Location = new System.Drawing.Point(29, 138);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(42, 13);
            this.lblModelo.TabIndex = 23;
            this.lblModelo.Text = "Modelo";
            // 
            // txtAlta
            // 
            this.txtAlta.Location = new System.Drawing.Point(157, 107);
            this.txtAlta.Name = "txtAlta";
            this.txtAlta.ReadOnly = true;
            this.txtAlta.Size = new System.Drawing.Size(100, 20);
            this.txtAlta.TabIndex = 26;
            // 
            // lblAlta
            // 
            this.lblAlta.AutoSize = true;
            this.lblAlta.Location = new System.Drawing.Point(154, 90);
            this.lblAlta.Name = "lblAlta";
            this.lblAlta.Size = new System.Drawing.Size(73, 13);
            this.lblAlta.TabIndex = 25;
            this.lblAlta.Text = "Fecha de Alta";
            // 
            // txtInhabilitado
            // 
            this.txtInhabilitado.Location = new System.Drawing.Point(157, 155);
            this.txtInhabilitado.Name = "txtInhabilitado";
            this.txtInhabilitado.ReadOnly = true;
            this.txtInhabilitado.Size = new System.Drawing.Size(100, 20);
            this.txtInhabilitado.TabIndex = 28;
            // 
            // lblInhabilitado
            // 
            this.lblInhabilitado.AutoSize = true;
            this.lblInhabilitado.Location = new System.Drawing.Point(154, 138);
            this.lblInhabilitado.Name = "lblInhabilitado";
            this.lblInhabilitado.Size = new System.Drawing.Size(61, 13);
            this.lblInhabilitado.TabIndex = 27;
            this.lblInhabilitado.Text = "Inhabilitado";
            // 
            // txtFabricante
            // 
            this.txtFabricante.Location = new System.Drawing.Point(98, 209);
            this.txtFabricante.Name = "txtFabricante";
            this.txtFabricante.ReadOnly = true;
            this.txtFabricante.Size = new System.Drawing.Size(100, 20);
            this.txtFabricante.TabIndex = 30;
            // 
            // lblFabricante
            // 
            this.lblFabricante.AutoSize = true;
            this.lblFabricante.Location = new System.Drawing.Point(95, 192);
            this.lblFabricante.Name = "lblFabricante";
            this.lblFabricante.Size = new System.Drawing.Size(57, 13);
            this.lblFabricante.TabIndex = 29;
            this.lblFabricante.Text = "Fabricante";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(77, 65);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(37, 13);
            this.lblFecha.TabIndex = 31;
            this.lblFecha.Text = "Fecha";
            // 
            // DetalleCruceroFueraServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 522);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.txtFabricante);
            this.Controls.Add(this.lblFabricante);
            this.Controls.Add(this.txtInhabilitado);
            this.Controls.Add(this.lblInhabilitado);
            this.Controls.Add(this.txtAlta);
            this.Controls.Add(this.lblAlta);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.lblModelo);
            this.Controls.Add(this.txtIdentificador);
            this.Controls.Add(this.lblIdentificador);
            this.Controls.Add(this.lblDias);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.DGVMeses);
            this.Controls.Add(this.lblTitulo);
            this.Name = "DetalleCruceroFueraServicio";
            this.Text = "DetalleCruceroFueraServicio";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DetalleCruceroFueraServicio_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.errorController)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMeses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView DGVMeses;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblDias;
        private System.Windows.Forms.Label lblIdentificador;
        private System.Windows.Forms.TextBox txtIdentificador;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.TextBox txtAlta;
        private System.Windows.Forms.Label lblAlta;
        private System.Windows.Forms.TextBox txtInhabilitado;
        private System.Windows.Forms.Label lblInhabilitado;
        private System.Windows.Forms.TextBox txtFabricante;
        private System.Windows.Forms.Label lblFabricante;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiasFueraDeServicio;
        private System.Windows.Forms.Label lblFecha;
    }
}