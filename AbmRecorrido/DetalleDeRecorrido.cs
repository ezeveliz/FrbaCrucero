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
        private Recorrido recorrido;

        public DetalleDeRecorrido(BajaRecorrido _padre, Recorrido _recorrido)
        {
            InitializeComponent();
            padre = _padre;
            recorrido = _recorrido;
            completarVista();
        }

        private void completarVista()
        {
            Titulo.Text = "Detalle de Recorrido:\n " + recorrido.Id;
            int precio = 0;
            foreach (Tramo tramo in recorrido.Tramos)
            {
                DGVTramos.Rows.Add(tramo.Id, tramo.PuertoInicio.Nombre, tramo.PuertoDestino.Nombre, tramo.Precio);
                precio += tramo.Precio;
            }
            lblPrecioTotal.Text = "Precio total: " + precio;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.DetalleRecorrido_FormClosed(sender, new FormClosedEventArgs(CloseReason.UserClosing));
        }

        private void DetalleRecorrido_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            this.Hide();
            this.Dispose();
            padre.Show();
        }
    }
}
