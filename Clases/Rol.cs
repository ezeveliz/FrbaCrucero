using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Clases
{
    public class Rol
    {
        private string nombre;
        private bool inhabilitado;

        public string Nombre { get { return nombre; } set { nombre = value; } }
        public bool Inhabilitado { get { return inhabilitado; } set { inhabilitado = value; } }

        public Rol(string name)
        {
            Nombre = name;
        }
    }
}
