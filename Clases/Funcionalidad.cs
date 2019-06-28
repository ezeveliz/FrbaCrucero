using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Clases
{
    public class Funcionalidad
    {
        private string descripcion;
        private int id;

        public string Descripcion { get { return descripcion; } set { descripcion = value; } }
        public int Id { get { return id; } set { id = value; } }

        public Funcionalidad(string _descripcion, int _id)
        {
            Descripcion = _descripcion;
            id = _id;
        }
  

    }
}
