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
        private Fabricante fabricante;
        private List<KeyValuePair<string, int>> diasFueraDeServicio;

        public int Id { get { return id; } set { id = value; } }
        public string Identificador { get { return identificador; } set { identificador = value; } }
        public string Modelo { get { return modelo; } set { modelo = value; } }
        public int Fabr_id { get { return fabr_id; } set { fabr_id = value; } }
        public bool Inahbilitado { get { return inhabilitado; } set { inhabilitado = value; } }
        public string FechaAlta { get { return fechaAlta; } set { fechaAlta = value; } }
        public List<KeyValuePair<string, int>> DiasFueraDeServicio { get { return diasFueraDeServicio; } }
        public Fabricante Fabricante { get { return fabricante; } }

        public Crucero(int _id, string _identificador,string  _modelo, int _fabr_id, bool _inahbilitado, string _fechaAlta )
        {
            this.id = _id;
            this.identificador = _identificador;
            this.modelo = _modelo;
            this.fabr_id = _fabr_id;
            this.inhabilitado = _inahbilitado;
            this.fechaAlta = _fechaAlta;
        }

        public Crucero(int _id)
        {
            this.id = _id;
        }

        //--Obtengo los datos del crucero
        public void getData()
        {
            string queryString = "SELECT C.cruc_identificador, C.cruc_modelo, C.cruc_fecha_alta, C.cruc_inhabilitado, F.fabr_nombre, F.fabr_id " +
                                "FROM GD1C2019.CONCORDIA.crucero AS C, GD1C2019.CONCORDIA.fabricante AS F " +
                                "WHERE C.fabr_id = F.fabr_id AND C.cruc_id = @idCrucero";
            SqlCommand query = Database.createQuery(queryString);
            query.Parameters.AddWithValue("@idCrucero", this.id);
            DataRow fila = Database.getQueryRow(query);
            this.identificador = fila[0].ToString();
            this.modelo = fila[1].ToString();
            this.fechaAlta = fila[2].ToString();
            this.inhabilitado = Int32.Parse(fila[3].ToString()) == 1;
            string nombreFabricante = fila[4].ToString();
            int idFabricante = Int32.Parse(fila[5].ToString());
            this.fabricante = new Fabricante(idFabricante, nombreFabricante);
        }

        //--Obtengo los dias fuera de servivio del crucero en un año y semestre dados
        public void getDiasFueraDeServicioEn(int anioSeleccionado, int semestreSeleccionado)
        {
            DataTable table = Database.detalleDeCruceroConMasDiasDeBajaEn(anioSeleccionado, semestreSeleccionado, this.id);
            List<KeyValuePair<string, int>> detalles = new List<KeyValuePair<string, int>>();
            foreach (DataRow fila in table.Rows)
            {
                string mes = fila[0].ToString();
                int cantDeDias = Int32.Parse(fila[1].ToString());
                detalles.Add(new KeyValuePair<string, int>(mes, cantDeDias));
            }
            this.diasFueraDeServicio = detalles;
        }
    }
}
