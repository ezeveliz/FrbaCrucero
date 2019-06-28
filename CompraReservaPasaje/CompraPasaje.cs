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

using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace FrbaCrucero.CompraReservaPasaje
{   //ver como mostrar los datos
    public partial class CompraPasaje : Frame
    {
        List<Cabina> datosCabina;  
        int usua_id = -1;
        int viaj_id;
        String puertoOrigen;
        String puertoDestino;
        int nroPasaje;
        SeleccionadorPasaje padre;
        public CompraPasaje(List<Cabina> _datosPasajes, int _viaj_id, String _puer_inicio,String _puer_fin, SeleccionadorPasaje _padre)
        {
            datosCabina = _datosPasajes;
            viaj_id = _viaj_id;
            puertoOrigen = _puer_inicio;
            puertoDestino = _puer_fin;
            InitializeComponent();
            cargarValor();
            cargarMediosDePago();
            padre = _padre;
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

        private void cargarMediosDePago() 
        {
            SqlCommand query = Database.createQuery(" select medi_pago_tipo from CONCORDIA.medio_pago");

            List<String> listaMediosPagos = Database.consultaObtenerLista(query);

            for (int i = 0; i < listaMediosPagos.Count; i++)
            {
                comboBoxMP.Items.Add(listaMediosPagos[i]);
            }

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

        private void comboBoxMP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMP.SelectedIndex == 0)
            {
                textBoxCuotas.Enabled = textBoxNTarjeta.Enabled = textBoxCodSeguridad.Enabled = true;
                textBoxCuotas.Enabled = false;
            }
            if (comboBoxMP.SelectedIndex == 1)
            {
                textBoxCuotas.Enabled = textBoxNTarjeta.Enabled = textBoxCodSeguridad.Enabled = false;
            }
            if (comboBoxMP.SelectedIndex == 2)
            {
                textBoxCuotas.Enabled = textBoxNTarjeta.Enabled = textBoxCodSeguridad.Enabled = true;
            }
        }

        private List<sqlDatos> generarListaDatosSQL()
        {
            List<sqlDatos> datos = new List<sqlDatos>();

            datos.Add(new sqlDatos("usua_dni", textBoxDNI.Text));
            datos.Add(new sqlDatos("usua_nombre", textBoxNombre.Text));
            datos.Add(new sqlDatos("usua_apellido", textBoxApellido.Text));
            datos.Add(new sqlDatos("usua_email", textBoxMail.Text));
            datos.Add(new sqlDatos("usua_direccion", textBoxDireccion.Text));
            datos.Add(new sqlDatos("usua_fecha_nac", textBoxFN.Text));
            datos.Add(new sqlDatos("usua_telefono", textBoxTelefono.Text));

            return datos;
        }

        private void btnCC_Click(object sender, EventArgs e)
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

                    nroPasaje = Database.cargarCompra(viaj_id, usua_id, comboBoxMP.SelectedIndex + 1, Convert.ToDouble(textBoxValor.Text));

                    for (int i = 0; i < datosCabina.Count; i++)
                    {
                        resultadoCabina = Database.cargarCabinaPasaje(nroPasaje, datosCabina[i].ID);
                    }

                    if (resultadoUsuario > 0 && resultadoCabina > 0)
                    {
                        MessageBox.Show(generarVoucherCompra());
                    }

                }
                else
                {
                    MessageBox.Show("El usuario no puede comprar un pasaje 2 veces o un pasaje que se superponga con otro");
                }

            }
            else
            {
                MessageBox.Show("Complete todos los campos");
                
            }
        }

        private bool camposCompletos() 
        {
            return comboBoxMP.SelectedIndex != -1 && textBoxDNI.Text != "" && textBoxNombre.Text != "" && textBoxApellido.Text != "" && textBoxTelefono.Text != "" && textBoxMail.Text != "" && textBoxFN.Text != "" && Validaciones.esInt(textBoxTelefono.Text) && mediosPagoCompletado();
        }

        private bool mediosPagoCompletado()
        {
            bool resultado = true;
            if (textBoxNTarjeta.Enabled) 
            {
                resultado = textBoxNTarjeta.Text != "" && textBoxCodSeguridad.Text != "" && Validaciones.esInt(textBoxNTarjeta.Text) && Validaciones.esInt(textBoxCodSeguridad.Text);
            }
            if (textBoxCuotas.Enabled)
            {
                resultado = textBoxCuotas.Text != "";
            }

            return resultado;

        }

        public String generarVoucherCompra()
        {
            String retorno;
            retorno = "Pasaje nro: "+ nroPasaje.ToString() + " Viaje Nro: " + viaj_id.ToString() + "\n" + "Puerto Origen: " + puertoOrigen + " Puerto Destino: " + puertoDestino + "\n" + "Comprador: " + textBoxNombre.Text + " " + textBoxApellido.Text + " DNI " + textBoxDNI.Text + "\n";
            retorno += "Cabinas: \n"; 

            for (int i = 0; i < datosCabina.Count; i++)
            {
                retorno += datosCabina[i].Nro.ToString() + " " + datosCabina[i].Piso.ToString() + " " + datosCabina[i].Tipo + "\n";
            }

                return retorno;
        
        }

        private void cargarValor()
        {
            double  recargo = 0;
            for (int i = 0; i < datosCabina.Count; i++) 
            { 
                recargo += datosCabina[i].Recargo;       
            }

            textBoxValor.Text = (Database.valorViaje(viaj_id)*recargo).ToString();
        }

        private void seleccionarFN_Click(object sender, EventArgs e)
        {
            textBoxFN.Text = dateTimePicker1.Value.ToString();
        }

        private void CompraPasaje_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Dispose();
            padre.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.CompraPasaje_FormClosed(sender, new FormClosedEventArgs(CloseReason.UserClosing));
     
        }

            

    }
}
