using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Clases
{
    public class Fabricante
    {
        private int id;
        private string nombre;

        public int Id { get { return id; } }
        public string Nombre { get { return nombre; } }

        public Fabricante(int _id, string _nombre)
        {
            this.id = _id;
            this.nombre = _nombre;
        }
    }
}
