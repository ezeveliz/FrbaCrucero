using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

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

        public Tramo(int _id)
        {
            id = _id;
            buscarPuertos();
        }

        private void buscarPuertos()
        {
            SqlCommand query = getPuertos();
            DataRow fila = Database.getQueryRow(query);
            int idInicio = Int32.Parse(fila[0].ToString());
            int idDestino = Int32.Parse(fila[1].ToString());
            int _precio = Int32.Parse(fila[2].ToString());
            precio = _precio;
            puertoInicio = new Puerto(idInicio);
            puertoDestino = new Puerto(idDestino);
        }

        private SqlCommand getPuertos()
        {
            string queryString = "SELECT puer_id_inicio, puer_id_fin, tram_precio FROM [GD1C2019].[CONCORDIA].[tramo] " +
                                "WHERE tram_id = @idTram";
            SqlCommand query = Database.createQuery(queryString);
            query.Parameters.AddWithValue("@idTram", id);
            return query;
        }
    }
}
