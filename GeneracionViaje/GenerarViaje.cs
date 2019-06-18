using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.GeneracionViaje;
using FrbaCrucero.Clases;

namespace FrbaCrucero.GeneracionViaje
{
    public partial class GenerarViaje : Form
    {
        string[] crucero;
        string[] recorrido;

        public GenerarViaje()
        {
            InitializeComponent();
        }


        private void btnSeleccionarCrucero_Click(object sender, EventArgs e)
        {
            try
            {
                string consulta = "SELECT cruc_id, cruc_identificador FROM CONCORDIA.crucero";
                SeleccionadorComponent sc = new SeleccionadorComponent(consulta, "cruc_id", "cruc_identificador");
                sc.ShowDialog();
                crucero = sc.seleccionado;
                textBoxCrucero.Text = crucero[1];
                sc.Dispose();
            }
            catch (Exception)
            {

            }
        }

        private void btnSeleccionarRecorrido_Click(object sender, EventArgs e)
        {
            try
            {
                string consulta = "SELECT reco_id , reco_codViejo FROM CONCORDIA.recorrido";
                SeleccionadorComponent sc = new SeleccionadorComponent(consulta, "reco_id", "reco_codViejo");
                sc.ShowDialog();
                recorrido = sc.seleccionado;
                textBoxRecorrido.Text = recorrido[1];
                sc.Dispose();
            }
            catch (Exception)
            {

            }
        }

        private void btnSeleccionarFI_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFI.Value > DateTime.Today)
            {
                textBoxFI.Text = dateTimePickerFI.Value.ToString();
            }
            else
            {
                MessageBox.Show("La fecha de inicio tiene que ser mayor a hoy");
            }
        }

        private void btnSeleccionarFF_Click(object sender, EventArgs e)
        {   //verifico que la fecha de llegada sea mayor que la de salida
            if (dateTimePickerFF.Value > Convert.ToDateTime(dateTimePickerFI.Value))
            {
                textBoxFF.Text = dateTimePickerFF.Value.ToString();
            }
            else
            {
                MessageBox.Show("El crucero no viaja en el tiempo por favor elija una fecha mayor a la de salida");
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (camposCompletos())
            {
                int resultado = Database.generarViaje(textBoxFI.Text, textBoxFF.Text, Convert.ToInt32(crucero[0]), Convert.ToInt32(recorrido[0]));
                if (resultado == -1)
                {
                    MessageBox.Show("Error Crucero crucero ya asignado a otro viaje en esas fechas");
                }
                else
                {
                    MessageBox.Show("Creado con Eaxito");
                }
            }
            else
            {
                MessageBox.Show("Completar todos los campos");
            }
        }

        private bool camposCompletos()
        {
            return textBoxFI.Text != "" && textBoxFF.Text != "" && textBoxCrucero.Text != "" && textBoxRecorrido.Text != "";
        }

    }
}
