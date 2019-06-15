using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Clases
{
    public class Tramo
    {
        private Puerto puertoInicio;
        private Puerto puertoDestino;
        private int precio;
        private bool persisted;
        private int id;

        public Puerto PuertoInicio { get { return puertoInicio; } }
        public Puerto PuertoDestino { get { return puertoDestino; } }
        public int Precio { get { return precio; } }
        public bool Persisted { get { return persisted; } }
        public int Id { get { return id; } set { id = value; } }

        public Tramo(Puerto _puertoInicio, Puerto _puertoDestino, int _precio, bool _persisted, int _id)
        {
            puertoInicio = _puertoInicio;
            puertoDestino = _puertoDestino;
            precio = _precio;
            persisted = _persisted;
            id = _id;
        }
    }
}
