using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Clases
{
    public class Sesion
    {
        private Usuario usuario;

        public Usuario Usuario { get { return usuario; } set { usuario = value; } }

        public Sesion(Usuario user)
        {
            Usuario = user;
        }
        /*
        public bool usuarioTieneUnSoloRol()
        {
            return usuario.Roles.Count == 1;
        }

        public bool usuarioTieneVariosRoles()
        {
            return usuario.Roles.Count > 1;
        }*/
    }
}
