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
        private Usuario user;

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

        //--Limpio y completo con los datos del usuario que realizo la reserva
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.limpiarErrores();
            this.limpiarDatosDeCliente();
            //this.limpiarDatosDePago();
            if (this.noHayErroresEnCodReserva())
            {
                txtNombre.Text = this.user.Nombre;
                txtApellido.Text = this.user.Apellido;
                txtDNI.Text = this.user.DNI.ToString();
                txtTelefono.Text = this.user.Telefono.ToString();
                txtMail.Text = this.user.Email;
                txtDireccion.Text = this.user.Direccion;
                txtNacimiento.Text = this.user.NacimientoString;
            }
        }

        //-- limpio errores, datos de usuario y de pago
        private void limpiar()
        {
            txtReserva.Text = "";
            this.limpiarErrores();
            this.limpiarDatosDeCliente();
            //this.limpiarDatosDePago();
        }

        //--Limpio los datos ingresados de pago
        private void limpiarDatosDePago()
        {
            throw new NotImplementedException();
        }

        //--Limpio los datos del cliente
        private void limpiarDatosDeCliente()
        {
            this.reserva = null;
            this.user = null;
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDNI.Text = "";
            txtTelefono.Text = "";
            txtMail.Text = "";
            txtDireccion.Text = "";
            txtNacimiento.Text = "";
        }

        //--Oculto las etiquetas de errores
        private void limpiarErrores()
        {
            lblErrorPago.Hide();
            lblErrorReserva.Hide();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiar();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            
        }

        //--Verifico que el codigo de reserva sea un nro positivo, que exista, que no haya vencido y que no haya sido pagado
        private bool noHayErroresEnCodReserva()
        {
            if (this.isIntNumber(txtReserva))
            {
                this.reserva = new Reserva(txtReserva.Text);
                this.user = reserva.User;
                if (reserva.EsValida)
                {
                    return true;
                }
                else
                {
                    this.mostrarErrores(lblErrorReserva, "El codigo de reserva ha expirado o\n ya ha pagado esa reserva.");
                    return false;
                }
            }
            else
            {
                this.mostrarErrores(lblErrorReserva, "El cod. de reserva es invalido.");
                return false;
            }
        }

        //--Muestro los errores ocurridos en el label correspondiente
        private void mostrarErrores(Label label, string error)
        {
            label.Text = error;
            label.Show();
        }

        // verifica que sea un nro(int) y que no sea null y que sea mayor a 0
        private bool isIntNumber(TextBox campo)
        {
            int parsedValue;
            string contenido = campo.Text;
            return int.TryParse(contenido, out parsedValue) && parsedValue > 0;
        }
    }
}
