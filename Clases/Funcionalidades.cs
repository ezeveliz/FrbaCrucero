using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Clases
{
    public class Funcionalidad
    {
        private string nombre;
        private int id;

        public string Nombre { get { return nombre; } set { nombre = value; } }
        public int Id { get { return id; } set { id = value; } }

        public Funcionalidad(string name, int id_set)
        {
            Nombre = name;
            id = id_set;
        }
  

    }
}
