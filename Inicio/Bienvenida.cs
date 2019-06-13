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

namespace FrbaCrucero.Inicio
{
    public partial class Bienvenida : Frame
    {
        public Bienvenida()
        {
            InitializeComponent();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal(new Usuario(), this).ShowDialog();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login(this).ShowDialog();
        }

        public void Inicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
