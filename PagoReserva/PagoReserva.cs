using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
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
        private DataTable medioDePago;

        public PagoReserva(MenuPrincipal _padre)
        {
            InitializeComponent();
            this.padre = _padre;
            this.getDataForComboBox();
        }

        //--Obtengo los medios de pago
        private void getDataForComboBox()
        {
            string queryString = "SELECT medi_pago_id, medi_pago_tipo FROM [GD1C2019].[CONCORDIA].[medio_pago]";
            SqlCommand query = Database.createQuery(queryString);
            medioDePago = Database.getQueryTable(query);
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
            this.limpiarDatosDePago();
            if (this.noHayErroresEnCodReserva())
            {
                btnConfirmar.Enabled = true;
                txtNombre.Text = this.user.Nombre;
                txtApellido.Text = this.user.Apellido;
                txtDNI.Text = this.user.DNI.ToString();
                txtTelefono.Text = this.user.Telefono.ToString();
                txtMail.Text = this.user.Email;
                txtDireccion.Text = this.user.Direccion;
                txtNacimiento.Text = this.user.NacimientoString;
                txtMonto.Text = this.reserva.MontoTotal.ToString();
                this.reinicializarComboBox();
            }
        }

        //--Reinicio el comboBox(selector de medio de pago)
        private void reinicializarComboBox()
        {
            CBMetodo.Items.Clear();
            CBMetodo.SelectedIndex = -1;
            List<KeyValuePair<int, string>> medios = new List<KeyValuePair<int, string>>();
            foreach (DataRow fila in medioDePago.Rows)
            {
                int id = Int32.Parse(fila[0].ToString());
                string func = fila[1].ToString();
                medios.Add(new KeyValuePair<int, string>(id, func));
            }
            CBMetodo.DisplayMember = "Value";
            CBMetodo.ValueMember = "Key";
            medios.ForEach(f => CBMetodo.Items.Add(f));
        }

        //-- limpio errores, datos de usuario y de pago
        private void limpiar()
        {
            txtReserva.Text = "";
            this.limpiarErrores();
            this.limpiarDatosDeCliente();
            this.limpiarDatosDePago();
        }

        //--Limpio los datos ingresados de pago
        private void limpiarDatosDePago()
        {
            btnConfirmar.Enabled = false;
            txtMonto.Text = "";
            txtCuotas.Text = "";
            txtCVV.Text = "";
            txtTarjeta.Text = "";
            CBMetodo.Items.Clear();
            CBMetodo.SelectedIndex = -1;
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

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (this.noHayErroresEnPago())
            { 
                KeyValuePair<int, string> metodoSeleccionado = (KeyValuePair<int, string>)CBMetodo.SelectedItem;
                int codPasaje;
                if (metodoSeleccionado.Value == "Debito")
                {
                    codPasaje = this.pagarConDebito();
                }
                else
                {
                    codPasaje = this.pagarConEfectivo();
                }
                this.limpiar();
                ventanaInformarExito("Su reserva ha sido pagada con exito, su codigo de pasaje es: " + codPasaje);
            }
        }

        //--Creo el pasaje y sus relaciones y retorno su id
        private int pagarConEfectivo()
        {
            return Database.pagarReservaConEfectivo(this.reserva);
        }

        //--Creo el pasaje y sus relaciones y retorno su id
        private int pagarConDebito()
        {
            return Database.pagarReservaConDebito(this.reserva, txtTarjeta.Text);
        }

        //--Verifico que todos los datos en la forma de pago esten y que sean correctos
        private bool noHayErroresEnPago()
        {
            if (CBMetodo.SelectedItem == null)
            {
                this.mostrarErrores(lblErrorPago, "Debe seleccionar un metodo de pago");
                return false;
            }
            else
            {
                KeyValuePair<int, string> metodoSeleccionado = (KeyValuePair<int, string>)CBMetodo.SelectedItem;
                if (metodoSeleccionado.Value == "Debito")
                {
                    if (!this.isIntNumber(txtCuotas))
                    {
                        this.mostrarErrores(lblErrorPago, "El campo cuotas debe ser un entero mayor a 0");
                        return false;
                    }
                    else if (!this.isIntNumber(txtTarjeta))
                    {
                        this.mostrarErrores(lblErrorPago, "El nro de tarjeta debe ser un entero mayor a 0");
                        return false;
                    }
                    else if (!this.isIntNumber(txtCVV))
                    {
                        this.mostrarErrores(lblErrorPago, "El CVV debe ser un entero mayor a 0");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
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

        private void CBMetodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBMetodo.SelectedItem == null) return;
            KeyValuePair<int, string> metodoSeleccionado = (KeyValuePair<int, string>)CBMetodo.SelectedItem;
            if (metodoSeleccionado.Value == "Efectivo")
            {
                txtCuotas.Text = "";
                txtCuotas.ReadOnly = true;
                txtCVV.Text = "";
                txtCVV.ReadOnly = true;
                txtTarjeta.Text = "";
                txtTarjeta.ReadOnly = true;
            }
            else
            {
                txtCuotas.ReadOnly = false;
                txtCVV.ReadOnly = false;
                txtTarjeta.ReadOnly = false;
            }
        }
    }
}
