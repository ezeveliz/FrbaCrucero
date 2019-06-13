namespace FrbaCrucero.AbmRecorrido
{
    partial class AltaRecorrido
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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblErrorInicio = new System.Windows.Forms.Label();
            this.lblDestino = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblInicio = new System.Windows.Forms.Label();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.btnSelectDestino = new System.Windows.Forms.Button();
            this.btnSelectInicio = new System.Windows.Forms.Button();
            this.txtInicio = new System.Windows.Forms.TextBox();
            this.lblErrorDestino = new System.Windows.Forms.Label();
            this.lblErrorCodigo = new System.Windows.Forms.Label();
            this.lblErrorPrecio = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorController)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.Titulo.Location = new System.Drawing.Point(40, 9);
            this.Titulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(280, 39);
            this.Titulo.TabIndex = 1;
            this.Titulo.Text = "Alta de Recorrido";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblErrorPrecio);
            this.groupBox1.Controls.Add(this.lblErrorCodigo);
            this.groupBox1.Controls.Add(this.lblErrorDestino);
            this.groupBox1.Controls.Add(this.btnSelectInicio);
            this.groupBox1.Controls.Add(this.txtInicio);
            this.groupBox1.Controls.Add(this.btnSelectDestino);
            this.groupBox1.Controls.Add(this.txtDestino);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.lblErrorInicio);
            this.groupBox1.Controls.Add(this.lblDestino);
            this.groupBox1.Controls.Add(this.lblPrecio);
            this.groupBox1.Controls.Add(this.txtPrecio);
            this.groupBox1.Controls.Add(this.lblCodigo);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.lblInicio);
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 223);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Recorrido";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(103, 177);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(104, 40);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblErrorInicio
            // 
            this.lblErrorInicio.AutoSize = true;
            this.lblErrorInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorInicio.ForeColor = System.Drawing.Color.Red;
            this.lblErrorInicio.Location = new System.Drawing.Point(150, 66);
            this.lblErrorInicio.Name = "lblErrorInicio";
            this.lblErrorInicio.Size = new System.Drawing.Size(44, 20);
            this.lblErrorInicio.TabIndex = 8;
            this.lblErrorInicio.Text = "Error";
            this.lblErrorInicio.Visible = false;
            // 
            // lblDestino
            // 
            this.lblDestino.AutoSize = true;
            this.lblDestino.Location = new System.Drawing.Point(151, 90);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(90, 13);
            this.lblDestino.TabIndex = 7;
            this.lblDestino.Text = "Puerto de destino";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(16, 90);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(37, 13);
            this.lblPrecio.TabIndex = 5;
            this.lblPrecio.Text = "Precio";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(16, 109);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(100, 20);
            this.txtPrecio.TabIndex = 4;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(16, 24);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 3;
            this.lblCodigo.Text = "Codigo";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(16, 43);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 2;
            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.Location = new System.Drawing.Point(151, 24);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(80, 13);
            this.lblInicio.TabIndex = 1;
            this.lblInicio.Text = "Puerto de inicio";
            // 
            // txtDestino
            // 
            this.txtDestino.Location = new System.Drawing.Point(154, 109);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.ReadOnly = true;
            this.txtDestino.Size = new System.Drawing.Size(100, 20);
            this.txtDestino.TabIndex = 4;
            // 
            // btnSelectDestino
            // 
            this.btnSelectDestino.Location = new System.Drawing.Point(260, 107);
            this.btnSelectDestino.Name = "btnSelectDestino";
            this.btnSelectDestino.Size = new System.Drawing.Size(75, 23);
            this.btnSelectDestino.TabIndex = 10;
            this.btnSelectDestino.Text = "Seleccionar";
            this.btnSelectDestino.UseVisualStyleBackColor = true;
            this.btnSelectDestino.Click += new System.EventHandler(this.btnSelectDestino_Click);
            // 
            // btnSelectInicio
            // 
            this.btnSelectInicio.Location = new System.Drawing.Point(260, 41);
            this.btnSelectInicio.Name = "btnSelectInicio";
            this.btnSelectInicio.Size = new System.Drawing.Size(75, 23);
            this.btnSelectInicio.TabIndex = 12;
            this.btnSelectInicio.Text = "Seleccionar";
            this.btnSelectInicio.UseVisualStyleBackColor = true;
            this.btnSelectInicio.Click += new System.EventHandler(this.btnSelectInicio_Click);
            // 
            // txtInicio
            // 
            this.txtInicio.Location = new System.Drawing.Point(154, 43);
            this.txtInicio.Name = "txtInicio";
            this.txtInicio.ReadOnly = true;
            this.txtInicio.Size = new System.Drawing.Size(100, 20);
            this.txtInicio.TabIndex = 11;
            // 
            // lblErrorDestino
            // 
            this.lblErrorDestino.AutoSize = true;
            this.lblErrorDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorDestino.ForeColor = System.Drawing.Color.Red;
            this.lblErrorDestino.Location = new System.Drawing.Point(150, 132);
            this.lblErrorDestino.Name = "lblErrorDestino";
            this.lblErrorDestino.Size = new System.Drawing.Size(44, 20);
            this.lblErrorDestino.TabIndex = 13;
            this.lblErrorDestino.Text = "Error";
            this.lblErrorDestino.Visible = false;
            // 
            // lblErrorCodigo
            // 
            this.lblErrorCodigo.AutoSize = true;
            this.lblErrorCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorCodigo.ForeColor = System.Drawing.Color.Red;
            this.lblErrorCodigo.Location = new System.Drawing.Point(15, 70);
            this.lblErrorCodigo.Name = "lblErrorCodigo";
            this.lblErrorCodigo.Size = new System.Drawing.Size(44, 20);
            this.lblErrorCodigo.TabIndex = 14;
            this.lblErrorCodigo.Text = "Error";
            this.lblErrorCodigo.Visible = false;
            // 
            // lblErrorPrecio
            // 
            this.lblErrorPrecio.AutoSize = true;
            this.lblErrorPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorPrecio.ForeColor = System.Drawing.Color.Red;
            this.lblErrorPrecio.Location = new System.Drawing.Point(15, 132);
            this.lblErrorPrecio.Name = "lblErrorPrecio";
            this.lblErrorPrecio.Size = new System.Drawing.Size(44, 20);
            this.lblErrorPrecio.TabIndex = 15;
            this.lblErrorPrecio.Text = "Error";
            this.lblErrorPrecio.Visible = false;
            // 
            // AltaRecorrido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 284);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Titulo);
            this.Name = "AltaRecorrido";
            this.Text = "Alta Recorrido";
            ((System.ComponentModel.ISupportInitialize)(this.errorController)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblErrorInicio;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnSelectInicio;
        private System.Windows.Forms.TextBox txtInicio;
        private System.Windows.Forms.Button btnSelectDestino;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Label lblErrorPrecio;
        private System.Windows.Forms.Label lblErrorCodigo;
        private System.Windows.Forms.Label lblErrorDestino;
    }
}