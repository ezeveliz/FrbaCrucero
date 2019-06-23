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

namespace FrbaCrucero.PagoReserva
{
    public partial class PagoReserva : Frame
    {
        private MenuPrincipal padre;

        public PagoReserva(MenuPrincipal _padre)
        {
            InitializeComponent();
            this.padre = _padre;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.PagoReserva_FormClosed(sender, new FormClosedEventArgs(CloseReason.UserClosing));
        }

        private void PagoReserva_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Dispose();
            padre.Show();
        }
    }
}
