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

namespace FrbaCrucero.CompraReservaPasaje
{
    public partial class ReservaPasaje : Frame
    {
        List<Cabina> datosCabina;
        int viaj_id;
        String puertoOrigen;
        String puertoDestino;
        double valor = 0;
        int usua_id;
        int nroReserva;
        SeleccionadorPasaje padre;
       
        public ReservaPasaje(List<Cabina> _datosPasajes, int _viaj_id, String _puer_inicio, String _puer_fin, SeleccionadorPasaje _padre)
        {
            datosCabina = _datosPasajes;
            viaj_id = _viaj_id;
            puertoOrigen = _puer_inicio;
            puertoDestino = _puer_fin;
            InitializeComponent();
            cargarValor();
            padre = _padre; 
        }
       
        public void cargarValor()
        {
            double recargo = 0;
            for (int i = 0; i < datosCabina.Count; i++)
            {
                recargo += datosCabina[i].Recargo;
            }

            valor = Database.valorViaje(viaj_id)* recargo;
      
        }

        private void btnSeleccionarFN_Click(object sender, EventArgs e)
        {
            textBoxFN.Text = dateTimePicker.Value.ToString();
        }

        private void textBoxDNI_Leave(object sender, EventArgs e)
        {
            List<String> datosUsuario = buscarDatos();
            if (!(datosUsuario.Count == 0))
            {

                textBoxMail.Text = datosUsuario[0];

                textBoxNombre.Text = datosUsuario[1];

                textBoxApellido.Text = datosUsuario[2];

                textBoxDireccion.Text = datosUsuario[3];

                textBoxFN.Text = datosUsuario[4];

                textBoxTelefono.Text = datosUsuario[5];

                this.usua_id = Convert.ToInt32(datosUsuario[6]);

            }
        }

        private List<String> buscarDatos()
        {
            List<String> datosUsuario = new List<String>();

            if (textBoxDNI.Text != "")
            {
                datosUsuario = Database.busacDatosUsuario(Convert.ToInt32(textBoxDNI.Text));
            }
            return datosUsuario;
        }

        private void btnCR_Click(object sender, EventArgs e)
        {
            int resultadoUsuario;
            int resultadoCabina = 0;
            if (camposCompletos())
            {
                if (usua_id > 0)
                {
                    resultadoUsuario = Database.updateUsuario(usua_id, Convert.ToInt32(textBoxDNI.Text), textBoxNombre.Text, textBoxApellido.Text, textBoxMail.Text, textBoxDireccion.Text, textBoxFN.Text, Convert.ToInt32(textBoxTelefono.Text));
                }
                else
                {
                    resultadoUsuario = usua_id = Database.insertUsuario(Convert.ToInt32(textBoxDNI.Text), textBoxNombre.Text, textBoxApellido.Text, textBoxMail.Text, textBoxDireccion.Text, textBoxFN.Text, Convert.ToInt32(textBoxTelefono.Text));
                }

                if (Database.validarViajeAComprar(usua_id, viaj_id))
                {

                    nroReserva = Database.cargarReserva(usua_id, viaj_id);

                    for (int i = 0; i < datosCabina.Count; i++)
                    {
                        resultadoCabina = Database.cargarCabinaReserva(nroReserva, datosCabina[i].ID);
                    }

                    if (resultadoUsuario > 0 && resultadoCabina > 0)
                    {
                        MessageBox.Show(generarVoucherReserva());
                    }

                }
                else
                {
                    MessageBox.Show("Ya tiene pasajes reservados o comprados en esta fecha y/o este viaje");
                }

            }
            else
            {
                MessageBox.Show("Complete todos los campos");

            }
  
        }

        private bool camposCompletos()
        {
            return textBoxDNI.Text != "" && textBoxNombre.Text != "" && textBoxApellido.Text != "" && textBoxTelefono.Text != "" && textBoxMail.Text != "" && textBoxFN.Text != "" && Validaciones.esInt(textBoxTelefono.Text);
        }

        public String generarVoucherReserva()
        {
            String retorno;
            retorno = "Reserva nro: " + nroReserva.ToString() + " Viaje Nro: " + viaj_id.ToString() + "\n" + "Puerto Origen: " + puertoOrigen + " Puerto Destino: " + puertoDestino + "\n" + "Comprador: " + textBoxNombre.Text + " " + textBoxApellido.Text + " DNI " + textBoxDNI.Text + "\n";
            retorno += "Cabinas: \n";

            for (int i = 0; i < datosCabina.Count; i++)
            {
                retorno += datosCabina[i].Nro.ToString() + " " + datosCabina[i].Piso.ToString() + " " + datosCabina[i].Tipo + "\n";
            }

            return retorno;

        }

        private void ReservaPasaje_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Dispose();
            padre.Show();
        }

        private void atras_Click(object sender, EventArgs e)
        {
            this.ReservaPasaje_FormClosed(sender, new FormClosedEventArgs(CloseReason.UserClosing));

        }



        
        //public List<String> buscarDatos()
        //{
        //  //  List<String> datosUsuario = Database.busacDatosUsuario(co);
        //}
    }
}
