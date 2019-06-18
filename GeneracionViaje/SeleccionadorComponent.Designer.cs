namespace FrbaCrucero.GeneracionViaje
{
    partial class SeleccionadorComponent
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
            this.textBoxFiltro2 = new System.Windows.Forms.TextBox();
            this.textBoxFiltro1 = new System.Windows.Forms.TextBox();
            this.checkBox2Exacto = new System.Windows.Forms.CheckBox();
            this.checkBox1Exacto = new System.Windows.Forms.CheckBox();
            this.labelFiltro2 = new System.Windows.Forms.Label();
            this.labelFiltro1 = new System.Windows.Forms.Label();
            this.tabla = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxFiltro2);
            this.groupBox1.Controls.Add(this.textBoxFiltro1);
            this.groupBox1.Controls.Add(this.checkBox2Exacto);
            this.groupBox1.Controls.Add(this.checkBox1Exacto);
            this.groupBox1.Controls.Add(this.labelFiltro2);
            this.groupBox1.Controls.Add(this.labelFiltro1);
            this.groupBox1.Location = new System.Drawing.Point(33, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(747, 138);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Campos busqueda";
            // 
            // textBoxFiltro2
            // 
            this.textBoxFiltro2.Location = new System.Drawing.Point(127, 78);
            this.textBoxFiltro2.Name = "textBoxFiltro2";
            this.textBoxFiltro2.Size = new System.Drawing.Size(164, 26);
            this.textBoxFiltro2.TabIndex = 7;
            // 
            // textBoxFiltro1
            // 
            this.textBoxFiltro1.Location = new System.Drawing.Point(126, 37);
            this.textBoxFiltro1.Name = "textBoxFiltro1";
            this.textBoxFiltro1.Size = new System.Drawing.Size(165, 26);
            this.textBoxFiltro1.TabIndex = 6;
            // 
            // checkBox2Exacto
            // 
            this.checkBox2Exacto.AutoSize = true;
            this.checkBox2Exacto.Location = new System.Drawing.Point(332, 80);
            this.checkBox2Exacto.Name = "checkBox2Exacto";
            this.checkBox2Exacto.Size = new System.Drawing.Size(159, 24);
            this.checkBox2Exacto.TabIndex = 4;
            this.checkBox2Exacto.Text = "Busqueda exacta";
            this.checkBox2Exacto.UseVisualStyleBackColor = true;
            // 
            // checkBox1Exacto
            // 
            this.checkBox1Exacto.AutoSize = true;
            this.checkBox1Exacto.Location = new System.Drawing.Point(332, 41);
            this.checkBox1Exacto.Name = "checkBox1Exacto";
            this.checkBox1Exacto.Size = new System.Drawing.Size(159, 24);
            this.checkBox1Exacto.TabIndex = 3;
            this.checkBox1Exacto.Text = "Busqueda exacta";
            this.checkBox1Exacto.UseVisualStyleBackColor = true;
            // 
            // labelFiltro2
            // 
            this.labelFiltro2.AutoSize = true;
            this.labelFiltro2.Location = new System.Drawing.Point(37, 81);
            this.labelFiltro2.Name = "labelFiltro2";
            this.labelFiltro2.Size = new System.Drawing.Size(57, 20);
            this.labelFiltro2.TabIndex = 1;
            this.labelFiltro2.Text = "Filtro 2";
            // 
            // labelFiltro1
            // 
            this.labelFiltro1.AutoSize = true;
            this.labelFiltro1.Location = new System.Drawing.Point(37, 37);
            this.labelFiltro1.Name = "labelFiltro1";
            this.labelFiltro1.Size = new System.Drawing.Size(57, 20);
            this.labelFiltro1.TabIndex = 0;
            this.labelFiltro1.Text = "Filtro 1";
            // 
            // tabla
            // 
            this.tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla.Location = new System.Drawing.Point(33, 266);
            this.tabla.Name = "tabla";
            this.tabla.RowTemplate.Height = 28;
            this.tabla.Size = new System.Drawing.Size(724, 249);
            this.tabla.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(455, 200);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(121, 39);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(189, 200);
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
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // SeleccionadorComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 655);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.tabla);
            this.Controls.Add(this.groupBox1);
            this.Name = "SeleccionadorComponent";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxFiltro2;
        private System.Windows.Forms.TextBox textBoxFiltro1;
        private System.Windows.Forms.CheckBox checkBox2Exacto;
        private System.Windows.Forms.CheckBox checkBox1Exacto;
        private System.Windows.Forms.Label labelFiltro2;
        private System.Windows.Forms.Label labelFiltro1;
        private System.Windows.Forms.DataGridView tabla;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSeleccionar;
    }
}