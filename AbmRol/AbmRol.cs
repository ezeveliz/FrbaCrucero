using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.Inicio;

namespace FrbaCrucero.AbmRol
{
    public partial class AbmRol : Frame
    {
        private MenuPrincipal padre;

        public AbmRol(MenuPrincipal _padre)
        {
            InitializeComponent();
            padre = _padre;
        }

        private void BtnAlta_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AltaRol(this).Show();
        }

        private void BtnBaja_Click(object sender, EventArgs e)
        {
            this.Hide();
            new BajaRol(this).Show();
        }

        private void btnModificacion_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ModificacionRol(this).Show();
        }

        private void Atras_Click(object sender, EventArgs e)
        {
            this.AbmRol_FormClosed(sender, new FormClosedEventArgs(CloseReason.UserClosing));
        }

        private void AbmRol_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Dispose();
            padre.Show();
        }
    }
}
