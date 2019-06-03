using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.Login
{
    public partial class Login : VentanaBase
    {
        public Login()
        {
            InitializeComponent();
        }

        public void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Inicio ventana = new Inicio();
            ventana.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(this, errorController))
            {
                LogueoDTO logueo = Database.loginAutenticar(txtUsuario.Text, txtContraseña.Text);
                if (logueo.exito)
                    ventanaLogueoExitoso(logueo);
                else
                    ventanaLogueoFallido(logueo);
            }
        }

        private void ventanaLogueoExitoso(LogueoDTO logueo)
        {
            this.Hide();
            string nombreUsuario = logueo.mensaje;
            Usuario usuario = new Usuario(nombreUsuario);
            usuario.id = Database.usuarioObtenerID(usuario);
            Sesion sesion = new Sesion(usuario, Database.usuarioObtenerHotelesEnLista(usuario), Database.usuarioObtenerRolesEnLista(usuario));
            VentanaSeleccionRolHotel ventanaSeleccionRol = new VentanaSeleccionRolHotel(sesion);
        }

        private void ventanaLogueoFallido(LogueoDTO logueo)
        {
            txtContraseña.Clear();
            lblErrorLogueo.Text = logueo.mensaje;
            lblErrorLogueo.Show();
        }
    }
}
