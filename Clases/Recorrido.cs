using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Clases
{
    public class Recorrido
    {
        private List<Tramo> tramos;
        private int id;

        public List<Tramo> Tramos { get { return tramos; } set { tramos = value; } }
        public int Id { get { return id; } set { id = value; } }

        public Recorrido(List<Tramo> _tramos, int _id)
        {
            tramos = new List<Tramo>();
            tramos = _tramos;
            id = _id;
        }

        public void AddTramo(Tramo _tramo)
        {
            tramos.Add(_tramo);
        }
    }
}
