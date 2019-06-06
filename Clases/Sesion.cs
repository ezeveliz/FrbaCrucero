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
        private List<string> roles;

        public Usuario Usuario { get; set; }
        public List<string> Roles { get; set; }

        public Sesion(Usuario user, List<string> roles)
        {
            Usuario = user;
            Roles = roles;
        }

        public bool usuarioTieneUnSoloRol()
        {
            return roles.Count == 1;
        }

        public bool usuarioTieneVariosRoles()
        {
            return roles.Count > 1;
        }
    }
}
