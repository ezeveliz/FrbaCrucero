namespace FrbaCrucero.Inicio
{
    partial class MenuPrincipal
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
            this.listFuncionalidades = new System.Windows.Forms.ListBox();
            this.seleccionar = new System.Windows.Forms.Button();
            this.volver = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorController)).BeginInit();
            this.SuspendLayout();
            // 
            // listFuncionalidades
            // 
            this.listFuncionalidades.FormattingEnabled = true;
            this.listFuncionalidades.Location = new System.Drawing.Point(56, 75);
            this.listFuncionalidades.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listFuncionalidades.Name = "listFuncionalidades";
            this.listFuncionalidades.Size = new System.Drawing.Size(301, 95);
            this.listFuncionalidades.TabIndex = 0;
            // 
            // seleccionar
            // 
            this.seleccionar.Location = new System.Drawing.Point(229, 187);
            this.seleccionar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.seleccionar.Name = "seleccionar";
            this.seleccionar.Size = new System.Drawing.Size(76, 29);
            this.seleccionar.TabIndex = 1;
            this.seleccionar.Text = "Seleccionar";
            this.seleccionar.UseVisualStyleBackColor = true;
            this.seleccionar.Click += new System.EventHandler(this.seleccionar_Click);
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(90, 187);
            this.volver.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(76, 29);
            this.volver.TabIndex = 2;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(116, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Lista de Funcionalidades ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label2.Location = new System.Drawing.Point(85, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "FRBA CRUCEROS";
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 250);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.seleccionar);
            this.Controls.Add(this.listFuncionalidades);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MenuPrincipal";
            this.Text = "Seleccionar Funcionalidad";
            ((System.ComponentModel.ISupportInitialize)(this.errorController)).EndInit();
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MenuPrincipal_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listFuncionalidades;
        private System.Windows.Forms.Button seleccionar;
        private System.Windows.Forms.Button volver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}