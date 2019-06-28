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
        private MenuPrincipal padre;

        public AbmC(MenuPrincipal _padre)
        {
            InitializeComponent();
            padre = _padre;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Alta()
        {
            this.Hide();
            (new AltaCrucero(this)).ShowDialog();
        }

        private void Baja()
        {
            this.Hide();
            (new ListadoBaja(this)).ShowDialog();
        }

        private void Modificacion()
        {
            this.Hide();
            (new ListaModificacion(this)).ShowDialog();
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
            this.AbmCrucero_FormClosed(sender, new FormClosedEventArgs(CloseReason.UserClosing));
        }

        private void AbmCrucero_FormClosed(object sender, FormClosedEventArgs e) {

            this.Hide();
            this.Dispose();
            padre.Show();

        }
     
    }
}
