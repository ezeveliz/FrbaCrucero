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
        private List<KeyValuePair<string, int>> pasajesEnIntervalo;
        private List<KeyValuePair<string, int>> cabinasLibresEnIntervalo;

        public List<Tramo> Tramos { get { return tramos; } set { tramos = value; } }
        public int Id { get { return id; } set { id = value; } }
        public int Inhabilitado { get { return inhabilitado; } set { inhabilitado = value; } }
        public List<KeyValuePair<string, int>> PasajesEnIntervalo { get { return pasajesEnIntervalo; } }
        public List<KeyValuePair<string, int>> CabinasLibresEnIntervalo { get { return cabinasLibresEnIntervalo; } }

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

        //--Obtengo los pasajes vendidos del recorrido en un año y semestre dados
        public void getPasajesEn(int anioSeleccionado, int semestreSeleccionado)
        {
            DataTable table = Database.detalleDeRecorridosConMasPasajesCompradosEn(anioSeleccionado, semestreSeleccionado, this.id);
            List<KeyValuePair<string, int>> detalles = new List<KeyValuePair<string, int>>();
            foreach (DataRow fila in table.Rows)
            {
                string mes = fila[0].ToString();
                int cantDePasajes = Int32.Parse(fila[1].ToString());
                detalles.Add(new KeyValuePair<string, int>(mes, cantDePasajes));
            }
            this.pasajesEnIntervalo = detalles;
        }

        //--Obtengo las cabinas libres del recorrido en un año y semestre dado
        public void getCabinasLibresEn(int anioSeleccionado, int semestreSeleccionado)
        {
            DataTable table = Database.detalleDeRecorridoConMasCabinasLibres(anioSeleccionado, semestreSeleccionado, this.id);
            List<KeyValuePair<string, int>> detalles = new List<KeyValuePair<string, int>>();
            foreach (DataRow fila in table.Rows)
            {
                string mes = fila[0].ToString();
                
                int cantDeCabinas = (!fila.IsNull(1) ? Int32.Parse(fila[1].ToString()) : 0 );
                //int cantDeCabinas = ()Int32.Parse(fila[1].ToString());
                detalles.Add(new KeyValuePair<string, int>(mes, cantDeCabinas));
            }
            this.cabinasLibresEnIntervalo = detalles;
        }
    }
}
