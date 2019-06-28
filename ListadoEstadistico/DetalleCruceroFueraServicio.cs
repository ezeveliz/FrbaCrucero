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
    public partial class DetalleCruceroFueraServicio : Frame
    {
        private ListadoEstadistico padre;
        private Crucero crucero;

        public DetalleCruceroFueraServicio(ListadoEstadistico _padre, Crucero _crucero)
        {
            InitializeComponent();
            this.padre = _padre;
            this.crucero = _crucero;
            this.completarVista();
        }

        private void completarVista()
        {
            this.lblTitulo.Text = "Detalle del Crucero: " + this.crucero.Id;
            this.txtIdentificador.Text = this.crucero.Identificador;
            this.txtModelo.Text = this.crucero.Modelo;
            this.txtAlta.Text = this.crucero.FechaAlta;
            if (this.crucero.Inahbilitado)
            {
                this.txtInhabilitado.Text = "Si";
            }
            else
            {
                this.txtInhabilitado.Text = "No";
            }
            this.txtFabricante.Text = this.crucero.Fabricante.Nombre;
            this.lblFecha.Text = "Año: " + this.padre.AnioSeleccionado + ", " + (this.padre.SemestreSeleccionado == 1 ? "Primer semestre" : "Segundo semestre");

            int dias = 0;
            this.crucero.DiasFueraDeServicio.ForEach(m => 
            {
                dias += m.Value;
                DGVMeses.Rows.Add(m.Key, m.Value);
            });
            lblDias.Text = "Cantidad de Dias Fuera de Servicio: " + dias;

        }

        private void DetalleCruceroFueraServicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Dispose();
            padre.Show();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.DetalleCruceroFueraServicio_FormClosed(sender, new FormClosedEventArgs(CloseReason.UserClosing));
        }
    }
}
