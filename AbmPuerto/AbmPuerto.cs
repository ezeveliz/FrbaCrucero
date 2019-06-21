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

namespace FrbaCrucero.AbmPuerto
{
    public partial class AbmPuerto : Frame
    {
        private MenuPrincipal padre;

        public AbmPuerto(MenuPrincipal _padre)
        {
            InitializeComponent();
            padre = _padre;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.AbmPuerto_FormClosed(sender, new FormClosedEventArgs(CloseReason.UserClosing));
        }

        public void AbmPuerto_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Dispose();
            padre.Show();
        }

    }
}
