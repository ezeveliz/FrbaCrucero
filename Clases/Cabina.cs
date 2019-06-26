using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Clases
{
    public class Cabina
    {
        private int id;
        private float recargo;
        private string descripcion;

        public int Id { get { return id; } }
        public float Recargo { get { return recargo; } }
        public string Descripcion { get { return descripcion; } }

        public Cabina(int _id, float _recargo, string _descripcion)
        {
            id = _id;
            recargo = _recargo;
            descripcion = _descripcion;
        }
    }
}
