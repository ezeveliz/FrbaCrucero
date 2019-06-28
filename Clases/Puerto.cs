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
    public class Puerto
    {
        private int id;
        private string nombre;

        public int Id { get { return id; } }
        public string Nombre { get { return nombre; } }

        public Puerto(int _id, string _puerto)
        {
            id = _id;
            nombre = _puerto;
        }

        public Puerto(int _id)
        {
            id = _id;
            buscarNombre();
        }

        private void buscarNombre()
        {
            SqlCommand query = getNombre();
            string _nombre = Database.consultaObtenerValor(query);
            nombre = _nombre;
        }

        private SqlCommand getNombre()
        {
            string queryString = "SELECT puer_ciudad FROM [GD1C2019].[CONCORDIA].[puerto] " +
                                "WHERE puer_id = @puerId;";
            SqlCommand query = Database.createQuery(queryString);
            query.Parameters.AddWithValue("@puerId", id);
            return query;
        }
    }
}
