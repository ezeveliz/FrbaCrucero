namespace FrbaCrucero.AbmRol
{
    partial class AltaRol
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblFuncionalidad = new System.Windows.Forms.Label();
            this.CBFuncionalidad = new System.Windows.Forms.ComboBox();
            this.DGVFuncionalidad = new System.Windows.Forms.DataGridView();
            this.idFuncionalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Funcionalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Accion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorController)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVFuncionalidad)).BeginInit();
            this.SuspendLayout();
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Titulo.Location = new System.Drawing.Point(83, 9);
            this.Titulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(119, 26);
            this.Titulo.TabIndex = 14;
            this.Titulo.Text = "Alta de Rol";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblNombre);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.lblFuncionalidad);
            this.groupBox1.Controls.Add(this.CBFuncionalidad);
            this.groupBox1.Location = new System.Drawing.Point(23, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 86);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(7, 29);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(7, 48);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // lblFuncionalidad
            // 
            this.lblFuncionalidad.AutoSize = true;
            this.lblFuncionalidad.Location = new System.Drawing.Point(131, 28);
            this.lblFuncionalidad.Name = "lblFuncionalidad";
            this.lblFuncionalidad.Size = new System.Drawing.Size(73, 13);
            this.lblFuncionalidad.TabIndex = 1;
            this.lblFuncionalidad.Text = "Funcionalidad";
            // 
            // CBFuncionalidad
            // 
            this.CBFuncionalidad.FormattingEnabled = true;
            this.CBFuncionalidad.Location = new System.Drawing.Point(130, 47);
            this.CBFuncionalidad.Name = "CBFuncionalidad";
            this.CBFuncionalidad.Size = new System.Drawing.Size(121, 21);
            this.CBFuncionalidad.TabIndex = 0;
            this.CBFuncionalidad.Text = "Seleccionar";
            this.CBFuncionalidad.SelectedIndexChanged += new System.EventHandler(this.CBFuncionalidad_SelectedIndexChanged);
            // 
            // DGVFuncionalidad
            // 
            this.DGVFuncionalidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVFuncionalidad.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idFuncionalidad,
            this.Funcionalidad,
            this.Accion});
            this.DGVFuncionalidad.Location = new System.Drawing.Point(23, 136);
            this.DGVFuncionalidad.Name = "DGVFuncionalidad";
            this.DGVFuncionalidad.ReadOnly = true;
            this.DGVFuncionalidad.Size = new System.Drawing.Size(261, 150);
            this.DGVFuncionalidad.TabIndex = 16;
            this.DGVFuncionalidad.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVFuncionalidad_CellContentClick);
            // 
            // idFuncionalidad
            // 
            this.idFuncionalidad.HeaderText = "idFuncionalidad";
            this.idFuncionalidad.Name = "idFuncionalidad";
            this.idFuncionalidad.ReadOnly = true;
            this.idFuncionalidad.Visible = false;
            // 
            // Funcionalidad
            // 
            this.Funcionalidad.HeaderText = "Funcionalidad";
            this.Funcionalidad.Name = "Funcionalidad";
            this.Funcionalidad.ReadOnly = true;
            // 
            // Accion
            // 
            this.Accion.HeaderText = "Accion";
            this.Accion.Name = "Accion";
            this.Accion.ReadOnly = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(170, 325);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(114, 43);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(30, 300);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(42, 16);
            this.lblError.TabIndex = 17;
            this.lblError.Text = "Error";
            this.lblError.Visible = false;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(16, 325);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(114, 43);
            this.btnVolver.TabIndex = 18;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // AltaRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 380);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.DGVFuncionalidad);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Titulo);
            this.Name = "AltaRol";
            this.Text = "Alta de Rol";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AltaRol_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.errorController)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVFuncionalidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblFuncionalidad;
        private System.Windows.Forms.ComboBox CBFuncionalidad;
        private System.Windows.Forms.DataGridView DGVFuncionalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFuncionalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Funcionalidad;
        private System.Windows.Forms.DataGridViewButtonColumn Accion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnVolver;
    }
}