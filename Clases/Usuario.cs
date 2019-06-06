using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Clases
{
    class Usuario
    {
        private int id;
        private string nombre;
        private string apellido;
        private string username;

        public int Id { get { return id; } set { id = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Apellido { get { return apellido; } set { apellido = value; } }
        public string UserName { get { return nombre; } set { nombre = value; } }

        public Usuario()
        {
        }
    }
}
