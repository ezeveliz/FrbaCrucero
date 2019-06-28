using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FrbaCrucero.Clases
{
    public class Logger
    {

        private string log;

        public Logger()
        {
            this.log = "";

        }

        public void agregarAlLog(string detalle)
        {
            this.log += "- " + detalle + "\n";
        }

        public bool huboErrores()
        {
            return log.Length > 0;
        }

        public void resetear()
        {
            log = "";
        }

        public string mostrarLog()
        {
            return log;
        }

    }
}
