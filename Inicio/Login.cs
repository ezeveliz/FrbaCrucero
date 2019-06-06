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
    public partial class Login : Frame
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
                LoginDTO login = Database.authenticate(txtUsuario.Text, txtContraseña.Text);
                if (login.exito)
                {
                    ventanaLogueoExitoso(login);
                }
                else
                {
                    ventanaLogueoFallido(login);
                }
            }
        }

        private void ventanaLogueoExitoso(LoginDTO login)
        {
            this.Hide();
            string username = login.mensaje;
            Usuario user = new Usuario(username);
            user.id = Database.usuarioObtenerID(usuario);
            Sesion sesion = new Sesion(user, Database.usuarioObtenerRolesEnLista(user));
            VentanaSeleccionRolHotel ventanaSeleccionRol = new VentanaSeleccionRolHotel(sesion);
        }

        private void ventanaLogueoFallido(LoginDTO logueo)
        {
            txtContraseña.Clear();
            lblValidation.Text = logueo.mensaje;
            lblValidation.Show();
        }
    }
}
