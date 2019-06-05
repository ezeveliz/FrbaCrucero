using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Clases
{
    class LoginDTO
    {

        //-------------------------------------- Atributos -------------------------------------

        public string mensaje { get; set; }
        public bool exito { get; set; }

        //-------------------------------------- Constructores -------------------------------------

        public LoginDTO()
        {

        }

        //-------------------------------------- Metodos -------------------------------------

        public LoginDTO informarExito(string nombreUsuario)
        {
            exito = true;
            mensaje = nombreUsuario;
            return this;
        }

        public LoginDTO informarUsuarioInexistente()
        {
            exito = false;
            mensaje = "El usuario no existe.";
            return this;
        }

        public LoginDTO informarContraseniaIncorrecta()
        {
            exito = false;
            mensaje = "La contraseña es invalida.";
            return this;
        }

        public LoginDTO informarBloqueo()
        {
            exito = false;
            mensaje = "Usuario deshabilitado.";
            return this;
        }

    }
}
