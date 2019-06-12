namespace FrbaCrucero.AbmCrucero
{
    partial class AltaCrucero : Frame
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
            this.label1 = new System.Windows.Forms.Label();
            this.textIdentificador = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textModelo = new System.Windows.Forms.TextBox();
            this.comboBoxFabricante = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AgregarCabinas = new System.Windows.Forms.Button();
            this.Atras = new System.Windows.Forms.Button();
            this.Limpiar = new System.Windows.Forms.Button();
            this.Crear = new System.Windows.Forms.Button();
            this.msjError = new System.Windows.Forms.Label();
            this.tablasCabina = new System.Windows.Forms.DataGridView();
            this.comboBoxTipoCabina = new System.Windows.Forms.ComboBox();
            this.textBoxNro = new System.Windows.Forms.TextBox();
            this.textBoxPiso = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxNroCabinas = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBoxFecha = new System.Windows.Forms.TextBox();
            this.SeleccionarFecha = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorController)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablasCabina)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.Titulo.Location = new System.Drawing.Point(250, 11);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(372, 58);
            this.Titulo.TabIndex = 0;
            this.Titulo.Text = "Alta de Crucero";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label1.Location = new System.Drawing.Point(132, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Identificador";
            // 
            // textIdentificador
            // 
            this.textIdentificador.Location = new System.Drawing.Point(137, 149);
            this.textIdentificador.Name = "textIdentificador";
            this.textIdentificador.Size = new System.Drawing.Size(173, 26);
            this.textIdentificador.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(260, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Modelo";
            // 
            // textModelo
            // 
            this.textModelo.Location = new System.Drawing.Point(264, 77);
            this.textModelo.Name = "textModelo";
            this.textModelo.Size = new System.Drawing.Size(191, 26);
            this.textModelo.TabIndex = 4;
            // 
            // comboBoxFabricante
            // 
            this.comboBoxFabricante.FormattingEnabled = true;
            this.comboBoxFabricante.Location = new System.Drawing.Point(502, 73);
            this.comboBoxFabricante.Name = "comboBoxFabricante";
            this.comboBoxFabricante.Size = new System.Drawing.Size(185, 28);
            this.comboBoxFabricante.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(509, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fabricante";
            // 
            // AgregarCabinas
            // 
            this.AgregarCabinas.Location = new System.Drawing.Point(514, 45);
            this.AgregarCabinas.Name = "AgregarCabinas";
            this.AgregarCabinas.Size = new System.Drawing.Size(144, 38);
            this.AgregarCabinas.TabIndex = 9;
            this.AgregarCabinas.Text = "Agregar Cabinas";
            this.AgregarCabinas.UseVisualStyleBackColor = true;
            this.AgregarCabinas.Click += new System.EventHandler(this.AgregarCabinas_Click);
            // 
            // Atras
            // 
            this.Atras.Location = new System.Drawing.Point(172, 646);
            this.Atras.Name = "Atras";
            this.Atras.Size = new System.Drawing.Size(118, 41);
            this.Atras.TabIndex = 10;
            this.Atras.Text = "Atras";
            this.Atras.UseVisualStyleBackColor = true;
            // 
            // Limpiar
            // 
            this.Limpiar.Location = new System.Drawing.Point(388, 646);
            this.Limpiar.Name = "Limpiar";
            this.Limpiar.Size = new System.Drawing.Size(123, 41);
            this.Limpiar.TabIndex = 11;
            this.Limpiar.Text = "Limpiar";
            this.Limpiar.UseVisualStyleBackColor = true;
            this.Limpiar.Click += new System.EventHandler(this.Limpiar_Click);
            // 
            // Crear
            // 
            this.Crear.Location = new System.Drawing.Point(621, 646);
            this.Crear.Name = "Crear";
            this.Crear.Size = new System.Drawing.Size(126, 41);
            this.Crear.TabIndex = 12;
            this.Crear.Text = "Crear";
            this.Crear.UseVisualStyleBackColor = true;
            this.Crear.Click += new System.EventHandler(this.Crear_Click);
            // 
            // msjError
            // 
            this.msjError.AutoSize = true;
            this.msjError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline);
            this.msjError.ForeColor = System.Drawing.Color.Red;
            this.msjError.Location = new System.Drawing.Point(349, 596);
            this.msjError.Name = "msjError";
            this.msjError.Size = new System.Drawing.Size(197, 29);
            this.msjError.TabIndex = 13;
            this.msjError.Text = "Mensaje de error";
            this.msjError.Visible = false;
            // 
            // tablasCabina
            // 
            this.tablasCabina.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablasCabina.Location = new System.Drawing.Point(120, 431);
            this.tablasCabina.Name = "tablasCabina";
            this.tablasCabina.RowTemplate.Height = 28;
            this.tablasCabina.Size = new System.Drawing.Size(666, 150);
            this.tablasCabina.TabIndex = 14;
            // 
            // comboBoxTipoCabina
            // 
            this.comboBoxTipoCabina.FormattingEnabled = true;
            this.comboBoxTipoCabina.Location = new System.Drawing.Point(388, 360);
            this.comboBoxTipoCabina.Name = "comboBoxTipoCabina";
            this.comboBoxTipoCabina.Size = new System.Drawing.Size(171, 28);
            this.comboBoxTipoCabina.TabIndex = 15;
            // 
            // textBoxNro
            // 
            this.textBoxNro.Location = new System.Drawing.Point(258, 362);
            this.textBoxNro.Name = "textBoxNro";
            this.textBoxNro.Size = new System.Drawing.Size(90, 26);
            this.textBoxNro.TabIndex = 16;
            // 
            // textBoxPiso
            // 
            this.textBoxPiso.Location = new System.Drawing.Point(134, 362);
            this.textBoxPiso.Name = "textBoxPiso";
            this.textBoxPiso.Size = new System.Drawing.Size(88, 26);
            this.textBoxPiso.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(255, 339);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Nro";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(133, 339);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 20);
            this.label6.TabIndex = 19;
            this.label6.Text = "Piso";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(385, 337);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 20);
            this.label7.TabIndex = 20;
            this.label7.Text = "Tipo de cabina";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(258, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Fecha Alta";
            // 
            // textBoxNroCabinas
            // 
            this.textBoxNroCabinas.Enabled = false;
            this.textBoxNroCabinas.Location = new System.Drawing.Point(137, 241);
            this.textBoxNroCabinas.Name = "textBoxNroCabinas";
            this.textBoxNroCabinas.Size = new System.Drawing.Size(173, 26);
            this.textBoxNroCabinas.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(132, 200);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "Nro Cabinas";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.textBoxFecha);
            this.groupBox1.Controls.Add(this.SeleccionarFecha);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBoxFabricante);
            this.groupBox1.Controls.Add(this.textModelo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(90, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(728, 231);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Crucero";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.ImeMode = System.Windows.Forms.ImeMode.HangulFull;
            this.dateTimePicker1.Location = new System.Drawing.Point(526, 165);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(170, 26);
            this.dateTimePicker1.TabIndex = 2;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // textBoxFecha
            // 
            this.textBoxFecha.Enabled = false;
            this.textBoxFecha.Location = new System.Drawing.Point(252, 167);
            this.textBoxFecha.Name = "textBoxFecha";
            this.textBoxFecha.Size = new System.Drawing.Size(129, 26);
            this.textBoxFecha.TabIndex = 1;
            // 
            // SeleccionarFecha
            // 
            this.SeleccionarFecha.Location = new System.Drawing.Point(399, 165);
            this.SeleccionarFecha.Name = "SeleccionarFecha";
            this.SeleccionarFecha.Size = new System.Drawing.Size(90, 30);
            this.SeleccionarFecha.TabIndex = 0;
            this.SeleccionarFecha.Text = "Seleccionar";
            this.SeleccionarFecha.UseVisualStyleBackColor = true;
            this.SeleccionarFecha.Click += new System.EventHandler(this.SeleccionarFecha_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AgregarCabinas);
            this.groupBox2.Location = new System.Drawing.Point(89, 309);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(729, 105);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ingreso Cabina";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // AltaCrucero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 718);
            this.Controls.Add(this.textBoxNroCabinas);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxPiso);
            this.Controls.Add(this.textBoxNro);
            this.Controls.Add(this.comboBoxTipoCabina);
            this.Controls.Add(this.tablasCabina);
            this.Controls.Add(this.msjError);
            this.Controls.Add(this.Crear);
            this.Controls.Add(this.Limpiar);
            this.Controls.Add(this.Atras);
            this.Controls.Add(this.textIdentificador);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Titulo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "AltaCrucero";
            this.Text = "AltaCrucero";
            this.Load += new System.EventHandler(this.AltaCrucero_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorController)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablasCabina)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textIdentificador;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textModelo;
        private System.Windows.Forms.ComboBox comboBoxFabricante;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button AgregarCabinas;
        private System.Windows.Forms.Button Atras;
        private System.Windows.Forms.Button Limpiar;
        private System.Windows.Forms.Button Crear;
        private System.Windows.Forms.Label msjError;
        private System.Windows.Forms.DataGridView tablasCabina;
        private System.Windows.Forms.ComboBox comboBoxTipoCabina;
        private System.Windows.Forms.TextBox textBoxNro;
        private System.Windows.Forms.TextBox textBoxPiso;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxNroCabinas;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBoxFecha;
        private System.Windows.Forms.Button SeleccionarFecha;
        private System.Windows.Forms.GroupBox groupBox2;

    }
}