using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.Clases;

namespace FrbaCrucero.AbmRecorrido
{
    public partial class DetalleDeRecorrido : Frame
    {
        private BajaRecorrido padre;

        public DetalleDeRecorrido(BajaRecorrido _padre)
        {
            InitializeComponent();
            padre = _padre;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.DetalleRecorrido_FormClosed(sender, new FormClosedEventArgs(CloseReason.UserClosing));
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {

        }

        private void DetalleRecorrido_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            this.Hide();
            this.Dispose();
            padre.Show();
        }
    }
}
