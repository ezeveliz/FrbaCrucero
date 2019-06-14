using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.AbmRecorrido
{
    public partial class ListadoPuertos : Frame
    {
        private AltaRecorrido padre;
        private string elOtroCampo;
        public ListadoPuertos(AltaRecorrido _padre, string _elOtroCampo)
        {
            InitializeComponent();
            padre = _padre;
            elOtroCampo = _elOtroCampo;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPuerto.Text = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string puertoABuscar = txtPuerto.Text;
            if (!string.IsNullOrWhiteSpace(puertoABuscar))
            {
                if (elOtroCampo != "")
                {
                }
                else
                {
                }
            }
            else
            {
                lblError.Text = "Debes escribir algo.";
                lblError.Show();
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {

        }

        private void lstPuertos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListadoPuertos_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Dispose();
            padre.Show();
        }
    }
}
