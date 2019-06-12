using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Security.Cryptography;
using FrbaCrucero.Clases;
using FrbaCrucero;

namespace FrbaCrucero.Clases
{
    public class Crucero
    {   
        int id;
        string identificador;
        string  modelo; 
        int fabr_id;
        bool inhabilitado;
        string fechaAlta;

        public int Id { get { return id; } set { id = value; } }
        public string Identificador { get { return identificador; } set { identificador = value; } }
        public string Modelo { get { return modelo; } set { modelo = value; } }
        public int Fabr_id { get { return fabr_id; } set { fabr_id = value; } };
        public bool Inahbilitado { get { return inhabilitado; } set { inhabilitado = value; } }
        public string FechaAlta { get { return fechaAlta; } set { fechaAlta = value; } }

        public Crucero(int _id, string _identificador,string  _modelo, int _fabr_id, bool _inahbilitado, string _fechaAlta )
        {
            this.id = _id;
            this.identificador = _identificador;
            this.modelo = _modelo;
            this.fabr_id = _fabr_id;
            this.inhabilitado = _inahbilitado;
            this.fechaAlta = _fechaAlta

        }
    }
}
