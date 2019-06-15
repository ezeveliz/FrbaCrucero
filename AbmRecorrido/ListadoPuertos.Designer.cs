namespace FrbaCrucero.AbmRecorrido
{
    partial class ListadoPuertos
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPuerto = new System.Windows.Forms.TextBox();
            this.lstPuertos = new System.Windows.Forms.ListBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.Titulo = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorController)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblError);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPuerto);
            this.groupBox1.Location = new System.Drawing.Point(47, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(6, 63);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(45, 16);
            this.lblError.TabIndex = 3;
            this.lblError.Text = "label2";
            this.lblError.Visible = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(179, 34);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Puerto";
            // 
            // txtPuerto
            // 
            this.txtPuerto.Location = new System.Drawing.Point(6, 36);
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.Size = new System.Drawing.Size(136, 20);
            this.txtPuerto.TabIndex = 0;
            // 
            // lstPuertos
            // 
            this.lstPuertos.FormattingEnabled = true;
            this.lstPuertos.Location = new System.Drawing.Point(100, 164);
            this.lstPuertos.Name = "lstPuertos";
            this.lstPuertos.Size = new System.Drawing.Size(152, 121);
            this.lstPuertos.TabIndex = 1;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(132, 304);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(102, 44);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(252, 304);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(93, 44);
            this.btnSeleccionar.TabIndex = 3;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.Titulo.Location = new System.Drawing.Point(14, 9);
            this.Titulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(334, 39);
            this.Titulo.TabIndex = 4;
            this.Titulo.Text = "Buscador de Puertos";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(9, 304);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(102, 44);
            this.btnVolver.TabIndex = 5;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // ListadoPuertos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 360);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.Titulo);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.lstPuertos);
            this.Controls.Add(this.groupBox1);
            this.Name = "ListadoPuertos";
            this.Text = "Listado de Puertos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ListadoPuertos_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.errorController)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPuerto;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ListBox lstPuertos;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnVolver;

    }
}