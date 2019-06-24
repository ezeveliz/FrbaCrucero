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
using FrbaCrucero.Clases;

namespace FrbaCrucero.PagoReserva
{
    public partial class PagoReserva : Frame
    {
        private MenuPrincipal padre;
        private Reserva reserva;

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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (this.noHayErroresEnCodReserva())
            {
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            
        }

        private bool noHayErroresEnCodReserva()
        {
            if (this.isIntNumber(txtReserva))
            {
                reserva = new Reserva(txtReserva.Text);
                if (reserva.EsValida)
                {
                    return true;
                }
                else
                {
                    this.mostrarErrores(lblErrorReserva, "El codigo de reserva ha expirado.");
                    return false;
                }
            }
            else
            {
                this.mostrarErrores(lblErrorReserva, "El cod. de reserva no es un nro o es negativo.");
                return false;
            }
        }

        // 
        private void mostrarErrores(Label label, string error)
        {
            label.Text = error;
            label.Show();
        }

        // verifica que sea un nro y que no sea null y que sea mayor a 0
        private bool isIntNumber(TextBox campo)
        {
            int parsedValue;
            string contenido = campo.Text;
            return int.TryParse(contenido, out parsedValue) && parsedValue > 0;
        }
    }
}
