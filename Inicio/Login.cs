﻿using System;
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
        private Bienvenida bienvenidaView;

        public Login(Bienvenida _bienvenidaView)
        {
            InitializeComponent();
            bienvenidaView = _bienvenidaView;
        }

        public void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Dispose();
            bienvenidaView.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (camposEstanCompletos(txtContraseña, txtUsuario))
            {
                int resultado = Database.autentificacion(txtUsuario.Text, txtContraseña.Text);

                switch (resultado) // Mirar el soreProcedur Login_procedure en el archivo SQL
                {
                    case (-1):
                        txtUsuario.Clear();
                        failedLogin("No existe el usuario");
                        break;
                    case (0):
                        failedLogin("Usuario inhabilitado");
                        break;
                    case (4):
                        successfulLogin(txtUsuario.Text);
                        break;
                    default:
                        failedLogin("Quedan " + resultado.ToString() + " intentos");
                        break;
                }
            }
        }

        private void successfulLogin(string userName)
        {
            this.Hide();
            Usuario usuario = new Usuario(userName);//Genera el usuario que tiene es usurname 
            bienvenidaView.Usuario = usuario;
            new MenuPrincipal(usuario, bienvenidaView).Show();
        }

        private void failedLogin(string mensaje)
        {
            txtContraseña.Clear();
            lblValidation.Text = mensaje;
            lblValidation.Show();
        }

        private bool camposEstanCompletos(TextBox pass, TextBox user)
        {
            if (string.IsNullOrWhiteSpace(pass.Text) && string.IsNullOrWhiteSpace(user.Text))
            {
                failedLogin("Debe completar ambos campos");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(pass.Text) || string.IsNullOrWhiteSpace(user.Text))
            {
                failedLogin("Hay un campo sin completar");
                return false;
            }
            return true;
        }

    }
}
