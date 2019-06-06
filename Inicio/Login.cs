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
            new Bienvenida().ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ventanaCamposEstanCompletos(this, errorController))
            {
                LoginDTO login = Database.authenticate(txtUsuario.Text, txtContraseña.Text);
                if (login.Exito) { successfulLogin(login); } else { failedLogin(login); }
            }
        }

        private void successfulLogin(LoginDTO login)
        {
            this.Hide();
            string username = login.Mensaje;
            Usuario user = new Usuario(username);
            user.Id = Database.usuarioObtenerID(user);
            Sesion sesion = new Sesion(user, Database.usuarioObtenerRolesEnLista(user));
            new SeleccionDeRol(sesion);
        }

        private void failedLogin(LoginDTO logueo)
        {
            txtContraseña.Clear();
            lblValidation.Text = logueo.Mensaje;
            lblValidation.Show();
        }
    }
}
