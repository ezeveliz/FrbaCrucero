using System.Windows.Forms;
namespace FrbaCrucero.ListadoEstadistico
{
    partial class ListadoEstadistico
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
            this.lblAnio = new System.Windows.Forms.Label();
            this.CBAnio = new System.Windows.Forms.ComboBox();
            this.rbDias = new System.Windows.Forms.RadioButton();
            this.rbCabinas = new System.Windows.Forms.RadioButton();
            this.rbPasajes = new System.Windows.Forms.RadioButton();
            this.lblError = new System.Windows.Forms.Label();
            this.lblSemestre = new System.Windows.Forms.Label();
            this.CBSemestre = new System.Windows.Forms.ComboBox();
            this.DGVDatos = new System.Windows.Forms.DataGridView();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorController)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Titulo.Location = new System.Drawing.Point(155, 9);
            this.Titulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(194, 26);
            this.Titulo.TabIndex = 14;
            this.Titulo.Text = "Listado Estadistico";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblAnio);
            this.groupBox1.Controls.Add(this.CBAnio);
            this.groupBox1.Controls.Add(this.rbDias);
            this.groupBox1.Controls.Add(this.rbCabinas);
            this.groupBox1.Controls.Add(this.rbPasajes);
            this.groupBox1.Controls.Add(this.lblError);
            this.groupBox1.Controls.Add(this.lblSemestre);
            this.groupBox1.Controls.Add(this.CBSemestre);
            this.groupBox1.Location = new System.Drawing.Point(13, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(496, 170);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de busqueda";
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Location = new System.Drawing.Point(273, 20);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(26, 13);
            this.lblAnio.TabIndex = 7;
            this.lblAnio.Text = "Año";
            // 
            // CBAnio
            // 
            this.CBAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBAnio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBAnio.FormattingEnabled = true;
            this.CBAnio.Location = new System.Drawing.Point(273, 39);
            this.CBAnio.Name = "CBAnio";
            this.CBAnio.Size = new System.Drawing.Size(121, 21);
            this.CBAnio.TabIndex = 6;
            // 
            // rbDias
            // 
            this.rbDias.AutoSize = true;
            this.rbDias.Location = new System.Drawing.Point(65, 116);
            this.rbDias.Name = "rbDias";
            this.rbDias.Size = new System.Drawing.Size(283, 17);
            this.rbDias.TabIndex = 5;
            this.rbDias.TabStop = true;
            this.rbDias.Text = "Cruceros con mayor cantidad de días fuera de servicio";
            this.rbDias.UseVisualStyleBackColor = true;
            // 
            // rbCabinas
            // 
            this.rbCabinas.AutoSize = true;
            this.rbCabinas.Location = new System.Drawing.Point(65, 93);
            this.rbCabinas.Name = "rbCabinas";
            this.rbCabinas.Size = new System.Drawing.Size(360, 17);
            this.rbCabinas.TabIndex = 4;
            this.rbCabinas.TabStop = true;
            this.rbCabinas.Text = "Recorridos con más cabinas libres en cada uno de los viajes realizados";
            this.rbCabinas.UseVisualStyleBackColor = true;
            // 
            // rbPasajes
            // 
            this.rbPasajes.AutoSize = true;
            this.rbPasajes.Location = new System.Drawing.Point(65, 70);
            this.rbPasajes.Name = "rbPasajes";
            this.rbPasajes.Size = new System.Drawing.Size(216, 17);
            this.rbPasajes.TabIndex = 3;
            this.rbPasajes.TabStop = true;
            this.rbPasajes.Text = "Recorridos con mas pasajes comprados ";
            this.rbPasajes.UseVisualStyleBackColor = true;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(6, 139);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(42, 16);
            this.lblError.TabIndex = 2;
            this.lblError.Text = "Error";
            this.lblError.Visible = false;
            // 
            // lblSemestre
            // 
            this.lblSemestre.AutoSize = true;
            this.lblSemestre.Location = new System.Drawing.Point(65, 20);
            this.lblSemestre.Name = "lblSemestre";
            this.lblSemestre.Size = new System.Drawing.Size(51, 13);
            this.lblSemestre.TabIndex = 1;
            this.lblSemestre.Text = "Semestre";
            // 
            // CBSemestre
            // 
            this.CBSemestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBSemestre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBSemestre.FormattingEnabled = true;
            this.CBSemestre.Location = new System.Drawing.Point(65, 39);
            this.CBSemestre.Name = "CBSemestre";
            this.CBSemestre.Size = new System.Drawing.Size(121, 21);
            this.CBSemestre.TabIndex = 0;
            // 
            // DGVDatos
            // 
            this.DGVDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVDatos.Location = new System.Drawing.Point(13, 276);
            this.DGVDatos.Name = "DGVDatos";
            this.DGVDatos.ReadOnly = true;
            this.DGVDatos.Size = new System.Drawing.Size(496, 224);
            this.DGVDatos.TabIndex = 16;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLimpiar.Location = new System.Drawing.Point(395, 506);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(114, 43);
            this.btnLimpiar.TabIndex = 22;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnVolver.Location = new System.Drawing.Point(13, 506);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(114, 43);
            this.btnVolver.TabIndex = 21;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnBuscar.Location = new System.Drawing.Point(193, 227);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(119, 43);
            this.btnBuscar.TabIndex = 23;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // ListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 558);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.DGVDatos);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Titulo);
            this.Name = "ListadoEstadistico";
            this.Text = "Listado Estadistico";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ListadoEstadistico_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.errorController)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSemestre;
        private System.Windows.Forms.ComboBox CBSemestre;
        private System.Windows.Forms.DataGridView DGVDatos;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.ComboBox CBAnio;
        private System.Windows.Forms.RadioButton rbDias;
        private System.Windows.Forms.RadioButton rbCabinas;
        private System.Windows.Forms.RadioButton rbPasajes;
    }
}