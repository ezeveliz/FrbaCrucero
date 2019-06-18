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

namespace FrbaCrucero.AbmCrucero
{
    public partial class BajaCrucero : Form
    {
        Crucero datosCrucero;

        public BajaCrucero(Crucero crucero)
        {
            datosCrucero = crucero;
            InitializeComponent();
        }

        private void bajaVidaUtil()
        {
            //Controlo que opcion eligio el usuario para el fin de la vida util 
            //Opciones : -Cancelar pasajes - Remplazar crucero
            if (cancPasFVU.Checked)
            {   
                //finDeVidaUtilCrucero devuelve un numero mayor a 0 si se pudo dar de baja
                int resultado_baja_crucero = Database.finDeVidaUtilCrucero(datosCrucero.Id, cancMotivFVU.Text);
                
                //Controlo que el crucero no este dado de baja desde antes
                if (resultado_baja_crucero > 0)
                {
                    int resultado = Database.cancelarPasajes(datosCrucero.Id, cancMotivFVU.Text);

                    MessageBox.Show("Se dieron de baja " + resultado.ToString() + " pasajes");
                }
                else
                {
                    MessageBox.Show("El crucero ya fue dado de baja");
                }

            }
            else
            {   
                //Busco un crucero que pueda remplazar al curcero original
                int cruceroRemplazante = Database.buscarCruceroRemplazo(datosCrucero.Id);
                
                //Si retorna 0 no hay viajes a remplazar
                //Solo doy de baja el crucero en este caso
                if (cruceroRemplazante == 0)
                {
                    int resultado_baja_crucero = Database.finDeVidaUtilCrucero(datosCrucero.Id, cancMotivFVU.Text);
                
                    //Controlo que el crucero no este dado de baja
                    if (resultado_baja_crucero > 0)
                    {
                        Database.finDeVidaUtilCrucero(datosCrucero.Id, cancMotivFVU.Text);
                        MessageBox.Show("Crucero dado de baja ");
                    }
                    else
                    {
                        MessageBox.Show("El crucero ya fue dado de baja");
                    }
                }

                //Si es mayor a 0 doy de baja el crucero y y remplazo todos sus viajes con otro crucero
                else if (cruceroRemplazante > 0)
                {
                    int resultado_baja_crucero = Database.finDeVidaUtilCrucero(datosCrucero.Id, cancMotivFVU.Text);
                    
                    //Controlo que no este dado de baja 
                    if (resultado_baja_crucero > 0)
                    {
                        Database.finDeVidaUtilCrucero(datosCrucero.Id, cancMotivFVU.Text);
                        Database.remplazarCrucero(datosCrucero.Id, cruceroRemplazante);
                        MessageBox.Show("Se remplazo por crucero con id " + cruceroRemplazante.ToString());
                    }
                    else
                    {
                        MessageBox.Show("El crucero ya fue dado de baja");
                    }
                }

                //En este caso no existe curcero y se abre la pestaña para crear un crucero nuevo
                else
                {
                    MessageBox.Show("No hay crucero que lo remplace, Cree un nuevo crucero");
                    (new AltaCrucero()).Show();
                }

            }
        }

        private void bajaFueraDeServicio()
        {   
            //Primero doy de baja el crucero por fuera de servicio 
            Database.fueraServicioCrucero(datosCrucero.Id, FechaVueltaFS.Text.ToString());
            
            // Controlo cual fue la eleccion del usuario por fuera de serivicio 
            //Opciones: -Cancelar pasajes -Desplazar pasajes x dias  
            if (cancPasFS.Checked)
            {
                int resultado = Database.cancelarPasajes(datosCrucero.Id, cancMotivFS.Text, FechaVueltaFS.Text);

                MessageBox.Show("Se dieron de baja " + resultado.ToString() + " pasajes");

            }
            else
            {
                int resultado = Database.desplazarPasajes(datosCrucero.Id, Convert.ToInt32(diasDesplazamiento.Text), FechaVueltaFS.Text);

                MessageBox.Show("Se desplazaron " + resultado.ToString() + " pasajes");

            }

        }


        private void RBVidaUtil_CheckedChanged(object sender, EventArgs e)
        {
            cancPasFS.Enabled = cancMotivFS.Enabled = seleccionarFS.Enabled = diasDesplazamiento.Enabled = dateTimePicker.Enabled = false;
            cancPasFVU.Enabled = cancMotivFVU.Enabled = true;
        }

        private void RBFueraServicio_CheckedChanged(object sender, EventArgs e)
        {
            cancPasFS.Enabled = cancMotivFS.Enabled = seleccionarFS.Enabled = diasDesplazamiento.Enabled = dateTimePicker.Enabled = true;
            cancPasFVU.Enabled = cancMotivFVU.Enabled = false;

        }

        private void seleccionarFS_Click(object sender, EventArgs e)
        {
            FechaVueltaFS.Text = dateTimePicker.Value.ToString();
        }

        private int idCrucero(string identificador)
        {
            return Database.ObtenerIdCrucero(identificador);
        }

        private void BtnBaja_Click(object sender, EventArgs e)
        {

            if (RBVidaUtil.Checked)
            {
                bajaVidaUtil();
            }
            else
            {
                bajaFueraDeServicio();
            }


        }

        private void cancPasFS_CheckedChanged(object sender, EventArgs e)
        {
            diasDesplazamiento.Enabled = !cancPasFS.Checked;
        }



    }
}
