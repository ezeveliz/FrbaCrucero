using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.Inicio;

namespace FrbaCrucero.AbmRecorrido
{
    public partial class AbmRecorrido : Frame
    {
        private MenuPrincipal menu;

        public AbmRecorrido(MenuPrincipal _menu)
        {
            InitializeComponent();
            menu = _menu;
        }

        private void Atras_Click(object sender, EventArgs e)
        {
            this.AbmRecorrido_FormClosed(sender, new FormClosedEventArgs(CloseReason.UserClosing));
        }

        private void btnModificacion_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ModificacionRecorrido(this).ShowDialog();
        }

        private void BtnBaja_Click(object sender, EventArgs e)
        {
            this.Hide();
            new BajaRecorrido(this).ShowDialog();
        }

        private void BtnAlta_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AltaRecorrido(this).ShowDialog();
        }

        private void AbmRecorrido_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Dispose();
            menu.Show();
        }
    }
}
