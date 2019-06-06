using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Clases
{
    public class LoginDTO
    {
        private bool exito;
        private string mensaje;

        public bool Exito { get { return exito; } set { exito = value; } }
        public string Mensaje { get { return mensaje; } set { mensaje = value; } }

        public LoginDTO success(string nombreUsuario)
        {
            exito = true;
            mensaje = nombreUsuario;
            return this;
        }

        public LoginDTO inexistentUser()
        {
            exito = false;
            mensaje = "El usuario no existe.";
            return this;
        }

        public LoginDTO wrongPassword()
        {
            exito = false;
            mensaje = "La contraseña es inválida.";
            return this;
        }

        public LoginDTO userBloqued()
        {
            exito = false;
            mensaje = "Usuario deshabilitado.";
            return this;
        }

    }
}
