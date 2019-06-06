using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Clases
{
    class Sesion
    {
        public Rol rol { get; set; }
        public Usuario usuario { get; set; }
        public List<string> roles { get; set; }

        public Sesion(Usuario user, List<string> roles)
        {
            this.usuario = user;
            this.roles = roles;
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
