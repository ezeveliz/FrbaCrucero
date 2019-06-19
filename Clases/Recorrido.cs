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
    public class Recorrido
    {
        private List<Tramo> tramos;
        private int id;
        private int inhabilitado;

        public List<Tramo> Tramos { get { return tramos; } set { tramos = value; } }
        public int Id { get { return id; } set { id = value; } }
        public int Inhabilitado { get { return inhabilitado; } set { inhabilitado = value; } }

        public Recorrido(int _id, int _inhabilitado)
        {
            tramos = new List<Tramo>();
            id = _id;
            inhabilitado = _inhabilitado;
        }

        public void getAll()
        {
            if(!tramos.Any())
            buscarTramos();
        }

        public void reload()
        {
            tramos.Clear();
            SqlCommand query = getTramos();
            List<string> idTramos = Database.consultaObtenerLista(query);
            foreach (string idT in idTramos)
            {
                tramos.Add(new Tramo(Int32.Parse(idT)));
            }
        }

        private void buscarTramos()
        {
            SqlCommand query = getTramos();
            List<string> idTramos = Database.consultaObtenerLista(query);
            foreach (string idT in idTramos)
            {
                tramos.Add(new Tramo(Int32.Parse(idT)));
            }
        }

        private SqlCommand getTramos()
        {
            string queryString = "SELECT tram_id FROM [GD1C2019].[CONCORDIA].[recorrido_tramo] WHERE reco_id = @recoId";
            SqlCommand query = Database.createQuery(queryString);
            query.Parameters.AddWithValue("@recoId", id);
            return query;
        }

    }
}
