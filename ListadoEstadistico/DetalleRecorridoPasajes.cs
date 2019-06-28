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

namespace FrbaCrucero.ListadoEstadistico
{
    public partial class DetalleRecorridoPasajes : Frame
    {
        private ListadoEstadistico padre;
        private Recorrido recorrido;

        public DetalleRecorridoPasajes(ListadoEstadistico _padre, Recorrido _recorrido)
        {
            InitializeComponent();
            this.padre = _padre;
            this.recorrido = _recorrido;
            this.completarVista();
        }

        private void completarVista()
        {
            Titulo.Text = "Detalle de Recorrido:\n " + recorrido.Id;
            int precio = 0;
            this.recorrido.Tramos.ForEach(tramo =>
            {
                DGVTramos.Rows.Add(tramo.Id, tramo.PuertoInicio.Nombre, tramo.PuertoDestino.Nombre, tramo.Precio);
                precio += tramo.Precio;
            });
            lblPrecioTotal.Text = "Precio Total: " + precio;
            this.lblFecha.Text = "Año: " + this.padre.AnioSeleccionado + ", " + (this.padre.SemestreSeleccionado == 1 ? "Primer semestre" : "Segundo semestre");

            int vendidos = 0;
            this.recorrido.PasajesEnIntervalo.ForEach(m => 
            {
                vendidos += m.Value;
                DGVMeses.Rows.Add(m.Key, m.Value);
            });

            lblVendidos.Text = "Cantidad Vendida Total: " + vendidos;
        }

        private void DetalleRecorridoPasajes_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Dispose();
            padre.Show();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.DetalleRecorridoPasajes_FormClosed(sender, new FormClosedEventArgs(CloseReason.UserClosing));
        }
    }
}
