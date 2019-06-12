using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlTypes;
using System.Threading.Tasks;

namespace FrbaCrucero.Clases
{
    public static class Validaciones
    {
        public static bool esInt(String campo)
        {
            int resultado;
            return int.TryParse(campo, out resultado);
        }

    }
}
