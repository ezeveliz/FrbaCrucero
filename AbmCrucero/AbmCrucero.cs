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
using FrbaCrucero.Inicio;

namespace FrbaCrucero.AbmCrucero
{
    public partial class AbmC : Frame
    {
        /* private Usuario usuario; */

        public AbmC()
        {
            InitializeComponent();
          /*  this.usuario = _usuario;*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Alta()
        {
            //(new AltaCrucero()).ShowDialog();
        }

        private void Baja()
        {
            //(new BajaCrucero()).ShowDialog();
        }

        private void Modificacion()
        {
            //(new ModificacionCrucero()).ShowDialog();
        }

        private void BtnAlta_Click(object sender, EventArgs e)
        {
            Alta();
        }

        private void BtnBaja_Click(object sender, EventArgs e)
        {
            Baja();
        }

        private void btnModificacion_Click(object sender, EventArgs e)
        {
            Modificacion();
        }

        private void Atras_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            /*(new MenuPrincipal(this.usuario)).ShowDialog(); */
        }

     
    }
}
