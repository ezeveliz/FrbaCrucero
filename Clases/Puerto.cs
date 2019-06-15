using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Clases
{
    public class Puerto
    {
        private int id;
        private string nombre;

        public int Id { get { return id; } }
        public string Nombre { get { return nombre; } }

        public Puerto(int _id, string _puerto)
        {
            id = _id;
            nombre = _puerto;
        }
    }
}
