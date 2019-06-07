using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Clases
{
    public class Usuario
    {
        private int id;
        private string nombre;
        private string apellido;
        private string username;
        private List<Rol> roles;

        public int Id { get { return id; } set { id = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Apellido { get { return apellido; } set { apellido = value; } }
        public string UserName { get { return username; } set { username = value; } }
        public List<Rol> Roles { get { return roles; } set { roles = value; } }

        public Usuario(string username)
        {
            this.UserName = username;
        }

        public void findID()
        {
            Id = Database.usuarioObtenerID(this);
        }

        public void findRoles()
        {
            Roles = Database.usuarioObtenerRolesEnLista(this);
        }
    }
}
