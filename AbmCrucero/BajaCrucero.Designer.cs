namespace FrbaCrucero.AbmCrucero
{
    partial class BajaCrucero
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
            this.label1 = new System.Windows.Forms.Label();
            this.RBVidaUtil = new System.Windows.Forms.RadioButton();
            this.RBFueraServicio = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.diasDesplazamiento = new System.Windows.Forms.TextBox();
            this.cancPasFS = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cancMotivFS = new System.Windows.Forms.TextBox();
            this.cancMotivFVU = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cancPasFVU = new System.Windows.Forms.CheckBox();
            this.BtnBaja = new System.Windows.Forms.Button();
            this.BtnAtras = new System.Windows.Forms.Button();
            this.FechaVueltaFS = new System.Windows.Forms.TextBox();
            this.seleccionarFS = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(206, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Baja Crucero";
            // 
            // RBVidaUtil
            // 
            this.RBVidaUtil.AutoSize = true;
            this.RBVidaUtil.Location = new System.Drawing.Point(26, 117);
            this.RBVidaUtil.Name = "RBVidaUtil";
            this.RBVidaUtil.Size = new System.Drawing.Size(112, 24);
            this.RBVidaUtil.TabIndex = 1;
            this.RBVidaUtil.TabStop = true;
            this.RBVidaUtil.Text = "Fin vida util";
            this.RBVidaUtil.UseVisualStyleBackColor = true;
            this.RBVidaUtil.CheckedChanged += new System.EventHandler(this.RBVidaUtil_CheckedChanged);
            // 
            // RBFueraServicio
            // 
            this.RBFueraServicio.AutoSize = true;
            this.RBFueraServicio.Location = new System.Drawing.Point(24, 230);
            this.RBFueraServicio.Name = "RBFueraServicio";
            this.RBFueraServicio.Size = new System.Drawing.Size(154, 24);
            this.RBFueraServicio.TabIndex = 2;
            this.RBFueraServicio.TabStop = true;
            this.RBFueraServicio.Text = "Fuera de servicio";
            this.RBFueraServicio.UseVisualStyleBackColor = true;
            this.RBFueraServicio.CheckedChanged += new System.EventHandler(this.RBFueraServicio_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha de alta";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(370, 328);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(221, 26);
            this.dateTimePicker.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 386);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(260, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Dias de desplazamiento de pasajes";
            // 
            // diasDesplazamiento
            // 
            this.diasDesplazamiento.HideSelection = false;
            this.diasDesplazamiento.Location = new System.Drawing.Point(357, 177);
            this.diasDesplazamiento.Name = "diasDesplazamiento";
            this.diasDesplazamiento.Size = new System.Drawing.Size(104, 26);
            this.diasDesplazamiento.TabIndex = 6;
            // 
            // cancPasFS
            // 
            this.cancPasFS.AutoSize = true;
            this.cancPasFS.Location = new System.Drawing.Point(60, 261);
            this.cancPasFS.Name = "cancPasFS";
            this.cancPasFS.Size = new System.Drawing.Size(176, 24);
            this.cancPasFS.TabIndex = 7;
            this.cancPasFS.Text = "Dar de baja pasajes";
            this.cancPasFS.UseVisualStyleBackColor = true;
            this.cancPasFS.CheckedChanged += new System.EventHandler(this.cancPasFS_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(297, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Motivo";
            // 
            // cancMotivFS
            // 
            this.cancMotivFS.Location = new System.Drawing.Point(370, 258);
            this.cancMotivFS.Name = "cancMotivFS";
            this.cancMotivFS.Size = new System.Drawing.Size(218, 26);
            this.cancMotivFS.TabIndex = 10;
            // 
            // cancMotivFVU
            // 
            this.cancMotivFVU.Location = new System.Drawing.Point(370, 145);
            this.cancMotivFVU.Name = "cancMotivFVU";
            this.cancMotivFVU.Size = new System.Drawing.Size(218, 26);
            this.cancMotivFVU.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(294, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Motivo";
            // 
            // cancPasFVU
            // 
            this.cancPasFVU.AutoSize = true;
            this.cancPasFVU.Location = new System.Drawing.Point(57, 151);
            this.cancPasFVU.Name = "cancPasFVU";
            this.cancPasFVU.Size = new System.Drawing.Size(176, 24);
            this.cancPasFVU.TabIndex = 11;
            this.cancPasFVU.Text = "Dar de baja pasajes";
            this.cancPasFVU.UseVisualStyleBackColor = true;
            // 
            // BtnBaja
            // 
            this.BtnBaja.Location = new System.Drawing.Point(375, 460);
            this.BtnBaja.Name = "BtnBaja";
            this.BtnBaja.Size = new System.Drawing.Size(172, 43);
            this.BtnBaja.TabIndex = 15;
            this.BtnBaja.Text = "Baja";
            this.BtnBaja.UseVisualStyleBackColor = true;
            this.BtnBaja.Click += new System.EventHandler(this.BtnBaja_Click);
            // 
            // BtnAtras
            // 
            this.BtnAtras.Location = new System.Drawing.Point(90, 460);
            this.BtnAtras.Name = "BtnAtras";
            this.BtnAtras.Size = new System.Drawing.Size(172, 43);
            this.BtnAtras.TabIndex = 16;
            this.BtnAtras.Text = "Atras";
            this.BtnAtras.UseVisualStyleBackColor = true;
            // 
            // FechaVueltaFS
            // 
            this.FechaVueltaFS.Enabled = false;
            this.FechaVueltaFS.Location = new System.Drawing.Point(57, 330);
            this.FechaVueltaFS.Name = "FechaVueltaFS";
            this.FechaVueltaFS.Size = new System.Drawing.Size(176, 26);
            this.FechaVueltaFS.TabIndex = 20;
            // 
            // seleccionarFS
            // 
            this.seleccionarFS.Location = new System.Drawing.Point(248, 326);
            this.seleccionarFS.Name = "seleccionarFS";
            this.seleccionarFS.Size = new System.Drawing.Size(92, 35);
            this.seleccionarFS.TabIndex = 21;
            this.seleccionarFS.Text = "seleccionar";
            this.seleccionarFS.UseVisualStyleBackColor = true;
            this.seleccionarFS.Click += new System.EventHandler(this.seleccionarFS_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(13, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(591, 117);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fin vida util";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.diasDesplazamiento);
            this.groupBox3.Location = new System.Drawing.Point(13, 209);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(591, 216);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Fuera de servicio";
            // 
            // BajaCrucero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 546);
            this.Controls.Add(this.seleccionarFS);
            this.Controls.Add(this.FechaVueltaFS);
            this.Controls.Add(this.BtnAtras);
            this.Controls.Add(this.BtnBaja);
            this.Controls.Add(this.cancMotivFVU);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cancPasFVU);
            this.Controls.Add(this.cancMotivFS);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cancPasFS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RBFueraServicio);
            this.Controls.Add(this.RBVidaUtil);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Name = "BajaCrucero";
            this.Text = "BajaCrucero";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton RBVidaUtil;
        private System.Windows.Forms.RadioButton RBFueraServicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox diasDesplazamiento;
        private System.Windows.Forms.CheckBox cancPasFS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cancMotivFS;
        private System.Windows.Forms.TextBox cancMotivFVU;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cancPasFVU;
        private System.Windows.Forms.Button BtnBaja;
        private System.Windows.Forms.Button BtnAtras;
        private System.Windows.Forms.TextBox FechaVueltaFS;
        private System.Windows.Forms.Button seleccionarFS;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}