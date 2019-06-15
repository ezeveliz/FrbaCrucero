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
    public partial class SeleccionarTramo : Frame
    {
        private AltaRecorrido padre;

        public SeleccionarTramo(AltaRecorrido _padre)
        {
            InitializeComponent();
            padre = _padre;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (noHayErrores())
            {
                lblError.Hide();
                DGVTramos.Rows.Clear();
                string inicio = "'%" + txtInicio + "%'";
                string destino = "'%" + txtDestino + "%'";
                string precio = "'%" + txtPrecio + "%'";
            }
            else
            {
                lblError.Text = "Debe completar alguno de los tres campos.";
                lblError.Show();
            }
        }

        private bool noHayErrores()
        {
            string inicio = txtInicio.Text;
            string destino = txtDestino.Text;
            string precio = txtPrecio.Text;
            return string.IsNullOrWhiteSpace(inicio) && string.IsNullOrWhiteSpace(destino) && string.IsNullOrWhiteSpace(precio);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.SeleccionarTramo_FormClosed(sender, new FormClosedEventArgs(CloseReason.UserClosing));
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDestino.Text = "";
            txtInicio.Text = "";
            txtPrecio.Text = "";
            lblError.Hide();
            DGVTramos.Rows.Clear();
        }

        private void SeleccionarTramo_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Dispose();
            padre.Show();
        }
    }
}
