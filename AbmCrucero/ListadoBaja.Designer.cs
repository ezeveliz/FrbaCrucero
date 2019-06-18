namespace FrbaCrucero.AbmCrucero
{
    partial class ListadoBaja
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
            this.textBoxIdentificador = new System.Windows.Forms.TextBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.comboBoxMarca = new System.Windows.Forms.ComboBox();
            this.checkBoxIdentExacto = new System.Windows.Forms.CheckBox();
            this.checkBoxIdExacto = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Identificador = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tablaCruceros = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBaja = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaCruceros)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxIdentificador);
            this.groupBox1.Controls.Add(this.textBoxId);
            this.groupBox1.Controls.Add(this.comboBoxMarca);
            this.groupBox1.Controls.Add(this.checkBoxIdentExacto);
            this.groupBox1.Controls.Add(this.checkBoxIdExacto);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Identificador);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(33, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(747, 160);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Campos busqueda";
            // 
            // textBoxIdentificador
            // 
            this.textBoxIdentificador.Location = new System.Drawing.Point(281, 72);
            this.textBoxIdentificador.Name = "textBoxIdentificador";
            this.textBoxIdentificador.Size = new System.Drawing.Size(164, 26);
            this.textBoxIdentificador.TabIndex = 7;
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(41, 70);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(165, 26);
            this.textBoxId.TabIndex = 6;
            // 
            // comboBoxMarca
            // 
            this.comboBoxMarca.FormattingEnabled = true;
            this.comboBoxMarca.Location = new System.Drawing.Point(518, 70);
            this.comboBoxMarca.Name = "comboBoxMarca";
            this.comboBoxMarca.Size = new System.Drawing.Size(181, 28);
            this.comboBoxMarca.TabIndex = 5;
            // 
            // checkBoxIdentExacto
            // 
            this.checkBoxIdentExacto.AutoSize = true;
            this.checkBoxIdentExacto.Location = new System.Drawing.Point(281, 117);
            this.checkBoxIdentExacto.Name = "checkBoxIdentExacto";
            this.checkBoxIdentExacto.Size = new System.Drawing.Size(159, 24);
            this.checkBoxIdentExacto.TabIndex = 4;
            this.checkBoxIdentExacto.Text = "Busqueda exacta";
            this.checkBoxIdentExacto.UseVisualStyleBackColor = true;
            // 
            // checkBoxIdExacto
            // 
            this.checkBoxIdExacto.AutoSize = true;
            this.checkBoxIdExacto.Location = new System.Drawing.Point(41, 117);
            this.checkBoxIdExacto.Name = "checkBoxIdExacto";
            this.checkBoxIdExacto.Size = new System.Drawing.Size(159, 24);
            this.checkBoxIdExacto.TabIndex = 3;
            this.checkBoxIdExacto.Text = "Busqueda exacta";
            this.checkBoxIdExacto.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(514, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Marca";
            // 
            // Identificador
            // 
            this.Identificador.AutoSize = true;
            this.Identificador.Location = new System.Drawing.Point(277, 37);
            this.Identificador.Name = "Identificador";
            this.Identificador.Size = new System.Drawing.Size(97, 20);
            this.Identificador.TabIndex = 1;
            this.Identificador.Text = "Identificador";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id";
            // 
            // tablaCruceros
            // 
            this.tablaCruceros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaCruceros.Location = new System.Drawing.Point(33, 266);
            this.tablaCruceros.Name = "tablaCruceros";
            this.tablaCruceros.RowTemplate.Height = 28;
            this.tablaCruceros.Size = new System.Drawing.Size(724, 249);
            this.tablaCruceros.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(594, 209);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(121, 39);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(403, 209);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(121, 39);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBaja
            // 
            this.btnBaja.Location = new System.Drawing.Point(636, 550);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(121, 39);
            this.btnBaja.TabIndex = 4;
            this.btnBaja.Text = "Baja";
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.Location = new System.Drawing.Point(33, 550);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(121, 39);
            this.btnAtras.TabIndex = 5;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            // 
            // ListadoBaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 630);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.tablaCruceros);
            this.Controls.Add(this.groupBox1);
            this.Name = "ListadoBaja";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaCruceros)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxIdentificador;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.ComboBox comboBoxMarca;
        private System.Windows.Forms.CheckBox checkBoxIdentExacto;
        private System.Windows.Forms.CheckBox checkBoxIdExacto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Identificador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView tablaCruceros;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.Button btnAtras;
    }
}