﻿namespace FrbaCrucero.CompraReservaPasaje
{
    partial class SeleccionadorPasaje
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxPD = new System.Windows.Forms.ComboBox();
            this.comboBoxPO = new System.Windows.Forms.ComboBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SeleccionarFecha = new System.Windows.Forms.Button();
            this.textBoxFS = new System.Windows.Forms.TextBox();
            this.labelFiltro1 = new System.Windows.Forms.Label();
            this.tabla = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorController)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxPD);
            this.groupBox1.Controls.Add(this.comboBoxPO);
            this.groupBox1.Controls.Add(this.dateTimePicker);
            this.groupBox1.Controls.Add(this.SeleccionarFecha);
            this.groupBox1.Controls.Add(this.textBoxFS);
            this.groupBox1.Controls.Add(this.labelFiltro1);
            this.groupBox1.Location = new System.Drawing.Point(33, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(747, 202);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Campos busqueda";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(311, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Puerto Destino";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Puerto origen";
            // 
            // comboBoxPD
            // 
            this.comboBoxPD.FormattingEnabled = true;
            this.comboBoxPD.Location = new System.Drawing.Point(291, 141);
            this.comboBoxPD.Name = "comboBoxPD";
            this.comboBoxPD.Size = new System.Drawing.Size(201, 28);
            this.comboBoxPD.TabIndex = 10;
            // 
            // comboBoxPO
            // 
            this.comboBoxPO.FormattingEnabled = true;
            this.comboBoxPO.Location = new System.Drawing.Point(18, 140);
            this.comboBoxPO.Name = "comboBoxPO";
            this.comboBoxPO.Size = new System.Drawing.Size(201, 28);
            this.comboBoxPO.TabIndex = 9;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(367, 58);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(325, 26);
            this.dateTimePicker.TabIndex = 8;
            // 
            // SeleccionarFecha
            // 
            this.SeleccionarFecha.Location = new System.Drawing.Point(215, 55);
            this.SeleccionarFecha.Name = "SeleccionarFecha";
            this.SeleccionarFecha.Size = new System.Drawing.Size(115, 36);
            this.SeleccionarFecha.TabIndex = 7;
            this.SeleccionarFecha.Text = "Seleccionar";
            this.SeleccionarFecha.UseVisualStyleBackColor = true;
            this.SeleccionarFecha.Click += new System.EventHandler(this.seleccionarFecha_Click);
            // 
            // textBoxFS
            // 
            this.textBoxFS.Enabled = false;
            this.textBoxFS.Location = new System.Drawing.Point(18, 60);
            this.textBoxFS.Name = "textBoxFS";
            this.textBoxFS.Size = new System.Drawing.Size(165, 26);
            this.textBoxFS.TabIndex = 6;
            // 
            // labelFiltro1
            // 
            this.labelFiltro1.AutoSize = true;
            this.labelFiltro1.Location = new System.Drawing.Point(20, 37);
            this.labelFiltro1.Name = "labelFiltro1";
            this.labelFiltro1.Size = new System.Drawing.Size(121, 20);
            this.labelFiltro1.TabIndex = 0;
            this.labelFiltro1.Text = "Fecha de salida";
            // 
            // tabla
            // 
            this.tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla.Location = new System.Drawing.Point(33, 343);
            this.tabla.Name = "tabla";
            this.tabla.RowTemplate.Height = 28;
            this.tabla.Size = new System.Drawing.Size(724, 172);
            this.tabla.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(486, 252);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(121, 39);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(201, 252);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(121, 39);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(585, 556);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(122, 43);
            this.btnSeleccionar.TabIndex = 4;
            this.btnSeleccionar.Text = "Comprar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnCompra_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(56, 302);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Viajes";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(313, 556);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 43);
            this.button2.TabIndex = 6;
            this.button2.Text = "Reservar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnReserva_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(51, 556);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 43);
            this.button3.TabIndex = 7;
            this.button3.Text = "Atras";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // SeleccionadorPasaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 655);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.tabla);
            this.Controls.Add(this.groupBox1);
            this.Name = "SeleccionadorPasaje";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SeleccionarPasaje_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.errorController)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxFS;
        private System.Windows.Forms.Label labelFiltro1;
        private System.Windows.Forms.DataGridView tabla;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button SeleccionarFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBoxPD;
        private System.Windows.Forms.ComboBox comboBoxPO;
    }
}