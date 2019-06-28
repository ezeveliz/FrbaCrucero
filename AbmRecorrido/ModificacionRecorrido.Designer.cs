namespace FrbaCrucero.AbmRecorrido
{
    partial class ModificacionRecorrido
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
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.DGVRecorridos = new System.Windows.Forms.DataGridView();
            this.idRecorrido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Accion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSeleccionarD = new System.Windows.Forms.Button();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSeleccionarI = new System.Windows.Forms.Button();
            this.txtInicio = new System.Windows.Forms.TextBox();
            this.Titulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorController)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVRecorridos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnVolver.Location = new System.Drawing.Point(48, 371);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(96, 35);
            this.btnVolver.TabIndex = 17;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLimpiar.Location = new System.Drawing.Point(387, 371);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(96, 35);
            this.btnLimpiar.TabIndex = 18;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(92, 342);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(37, 16);
            this.lblError.TabIndex = 16;
            this.lblError.Text = "Error";
            this.lblError.Visible = false;
            // 
            // DGVRecorridos
            // 
            this.DGVRecorridos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVRecorridos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idRecorrido,
            this.Accion});
            this.DGVRecorridos.Location = new System.Drawing.Point(129, 189);
            this.DGVRecorridos.Name = "DGVRecorridos";
            this.DGVRecorridos.Size = new System.Drawing.Size(244, 150);
            this.DGVRecorridos.TabIndex = 15;
            this.DGVRecorridos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVRecorridos_CellContentClick);
            // 
            // idRecorrido
            // 
            this.idRecorrido.HeaderText = "idRecorrido";
            this.idRecorrido.Name = "idRecorrido";
            // 
            // Accion
            // 
            this.Accion.HeaderText = "Accion";
            this.Accion.Name = "Accion";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSeleccionarD);
            this.groupBox1.Controls.Add(this.txtDestino);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSeleccionarI);
            this.groupBox1.Controls.Add(this.txtInicio);
            this.groupBox1.Location = new System.Drawing.Point(38, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 120);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de busqueda";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(168, 79);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(96, 35);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ciudad de destino";
            // 
            // btnSeleccionarD
            // 
            this.btnSeleccionarD.Location = new System.Drawing.Point(349, 44);
            this.btnSeleccionarD.Name = "btnSeleccionarD";
            this.btnSeleccionarD.Size = new System.Drawing.Size(75, 23);
            this.btnSeleccionarD.TabIndex = 4;
            this.btnSeleccionarD.Text = "Seleccionar";
            this.btnSeleccionarD.UseVisualStyleBackColor = true;
            this.btnSeleccionarD.Click += new System.EventHandler(this.btnSeleccionarD_Click);
            // 
            // txtDestino
            // 
            this.txtDestino.Location = new System.Drawing.Point(243, 46);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.ReadOnly = true;
            this.txtDestino.Size = new System.Drawing.Size(100, 20);
            this.txtDestino.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ciudad de inicio";
            // 
            // btnSeleccionarI
            // 
            this.btnSeleccionarI.Location = new System.Drawing.Point(130, 44);
            this.btnSeleccionarI.Name = "btnSeleccionarI";
            this.btnSeleccionarI.Size = new System.Drawing.Size(75, 23);
            this.btnSeleccionarI.TabIndex = 1;
            this.btnSeleccionarI.Text = "Seleccionar";
            this.btnSeleccionarI.UseVisualStyleBackColor = true;
            this.btnSeleccionarI.Click += new System.EventHandler(this.btnSeleccionarI_Click);
            // 
            // txtInicio
            // 
            this.txtInicio.Location = new System.Drawing.Point(24, 46);
            this.txtInicio.Name = "txtInicio";
            this.txtInicio.ReadOnly = true;
            this.txtInicio.Size = new System.Drawing.Size(100, 20);
            this.txtInicio.TabIndex = 0;
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.Titulo.Location = new System.Drawing.Point(55, 17);
            this.Titulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(411, 39);
            this.Titulo.TabIndex = 13;
            this.Titulo.Text = "Modificacion de Recorrido";
            // 
            // ModificacionRecorrido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 423);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.DGVRecorridos);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Titulo);
            this.Name = "ModificacionRecorrido";
            this.Text = "Modificacion de Recorrido";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ModificacionRecorrido_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.errorController)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVRecorridos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.DataGridView DGVRecorridos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSeleccionarD;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSeleccionarI;
        private System.Windows.Forms.TextBox txtInicio;
        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRecorrido;
        private System.Windows.Forms.DataGridViewButtonColumn Accion;
    }
}