namespace FrbaCrucero.AbmRecorrido
{
    partial class ModificarTramos
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
            this.lblError = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.DGVTramos = new System.Windows.Forms.DataGridView();
            this.Inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Destino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Accion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cbInhabilitado = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorController)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTramos)).BeginInit();
            this.SuspendLayout();
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.Titulo.Location = new System.Drawing.Point(45, 9);
            this.Titulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(378, 39);
            this.Titulo.TabIndex = 14;
            this.Titulo.Text = "Modificacion de Tramos";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(36, 365);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(37, 16);
            this.lblError.TabIndex = 21;
            this.lblError.Text = "Error";
            this.lblError.Visible = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGuardar.Location = new System.Drawing.Point(322, 397);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(102, 51);
            this.btnGuardar.TabIndex = 20;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnVolver.Location = new System.Drawing.Point(87, 397);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(102, 51);
            this.btnVolver.TabIndex = 18;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(20, 302);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(63, 13);
            this.lblPrecio.TabIndex = 17;
            this.lblPrecio.Text = "Precio total:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSeleccionar);
            this.groupBox1.Controls.Add(this.btnCrear);
            this.groupBox1.Location = new System.Drawing.Point(20, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(443, 84);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregar tramo";
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(255, 19);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(102, 51);
            this.btnSeleccionar.TabIndex = 1;
            this.btnSeleccionar.Text = "Seleccionar Tramo";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(67, 19);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(102, 51);
            this.btnCrear.TabIndex = 0;
            this.btnCrear.Text = "Crear Tramo";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // DGVTramos
            // 
            this.DGVTramos.AllowUserToAddRows = false;
            this.DGVTramos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVTramos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Inicio,
            this.Destino,
            this.Precio,
            this.Id,
            this.Accion});
            this.DGVTramos.Location = new System.Drawing.Point(20, 140);
            this.DGVTramos.Name = "DGVTramos";
            this.DGVTramos.Size = new System.Drawing.Size(443, 150);
            this.DGVTramos.TabIndex = 15;
            this.DGVTramos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVTramos_CellContentClick);
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
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Accion
            // 
            this.Accion.HeaderText = "Accion";
            this.Accion.Name = "Accion";
            // 
            // cbInhabilitado
            // 
            this.cbInhabilitado.AutoSize = true;
            this.cbInhabilitado.Location = new System.Drawing.Point(194, 335);
            this.cbInhabilitado.Name = "cbInhabilitado";
            this.cbInhabilitado.Size = new System.Drawing.Size(80, 17);
            this.cbInhabilitado.TabIndex = 22;
            this.cbInhabilitado.Text = "Inhabilitado";
            this.cbInhabilitado.UseVisualStyleBackColor = true;
            this.cbInhabilitado.CheckedChanged += new System.EventHandler(this.cbInhabilitado_CheckedChanged);
            // 
            // ModificarTramos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 458);
            this.Controls.Add(this.cbInhabilitado);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DGVTramos);
            this.Controls.Add(this.Titulo);
            this.Name = "ModificarTramos";
            this.Text = "Modificar Tramos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ModificarTramos_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.errorController)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVTramos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.DataGridView DGVTramos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Destino;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewButtonColumn Accion;
        private System.Windows.Forms.CheckBox cbInhabilitado;
    }
}