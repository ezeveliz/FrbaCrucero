using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using FrbaCrucero.Clases;
using System.Globalization;

namespace FrbaCrucero.Clases
{
    public class Reserva
    {
        private int id;
        private bool esValida;
        private int idViaje;
        private Usuario user;
        private DateTime creacion;
        private int montoBase;
        private List<Cabina> cabinas;
        private float multiplicador = 1;
        private float montoTotal;

        public int Id { get { return id; } }
        public bool EsValida { get { return esValida; } }
        public int IdViaje { get { return idViaje; } }
        public Usuario User { get { return user; } }
        public DateTime Creacion { get { return creacion; } }
        public string CreacionString 
        { 
            get 
            {
                CultureInfo culture = new CultureInfo("es-AR");
                return creacion.ToString("d", culture);
            } 
        }
        public float MontoTotal { get { return montoTotal; } }
        public List<Cabina> Cabinas { get { return cabinas; } } 

        public Reserva(string _id)
        {
            id = Int32.Parse(_id);
            this.getDatos(_id);
        }

        private void getDatos(string _id)
        {
            // Verificar de alguna manera que la reserva no haya sido pagada anteriormente
            string queryString = "SELECT viaj_id, usua_id, rese_creacion " +
                                "FROM [GD1C2019].[CONCORDIA].[reserva] " +
                                "WHERE rese_id = @idReserva AND rese_id NOT IN (SELECT rese_id FROM [GD1C2019].[CONCORDIA].[cancelacion_reserva]) AND rese_pagada != 1";
            SqlCommand query = Database.createQuery(queryString);
            query.Parameters.AddWithValue("@idReserva", _id);
            DataRow resultado = Database.getQueryRow(query);
            if (resultado != null)
            {
                this.esValida = true;
                this.idViaje = Int32.Parse(resultado[0].ToString());
                int idUser = Int32.Parse(resultado[1].ToString());
                this.user = new Usuario(idUser);
                string date = resultado[2].ToString();
                CultureInfo culture = new CultureInfo("es-AR");
                DateTime tempDate = Convert.ToDateTime(date, culture);
                this.creacion = tempDate;
                this.montoBase = this.getMOnto();
                this.cabinas = this.getCabinas();
                this.cabinas.ForEach(c =>
                    {
                        this.multiplicador *= c.Recargo;
                    });
                this.montoTotal = this.montoBase * this.multiplicador;
            }
            else
            {
                this.esValida = false;
            }
        }

        //--Obtengo las cabinas de la reserva
        private List<Cabina> getCabinas()
        {
            List<Cabina> cabinasReservadas = new List<Cabina>();
            string queryString = "SELECT CR.cabina_id, TC.tipo_cabi_recargo, TC.tipo_cabi_descripcion " +
                                "FROM [GD1C2019].CONCORDIA.cabina_reserva AS CR, GD1C2019.CONCORDIA.tipo_cabina AS TC, GD1C2019.CONCORDIA.cabina AS C " +
                                "WHERE CR.reserva_id = @idReserva AND CR.cabina_id = C.cabi_id AND C.tipo_cabi_id = TC.tipo_cabi_id";
            SqlCommand query = Database.createQuery(queryString);
            query.Parameters.AddWithValue("@idReserva", this.id);
            DataTable table = Database.getQueryTable(query);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow fila in table.Rows)
                {
                    int id = Int32.Parse(fila[0].ToString());
                    float recargo = float.Parse(fila[1].ToString());
                    string descripcion = fila[2].ToString();
                    cabinasReservadas.Add(new Cabina(id, recargo, descripcion));
                }
            }
            return cabinasReservadas;
        }

        private int getMOnto()
        {
            string queryString = "SELECT SUM(T.tram_precio) AS Monto " +
                        "FROM [GD1C2019].[CONCORDIA].[reserva] AS RES, " +
	                        "[GD1C2019].[CONCORDIA].[viaje] AS V, " +
	                        "[GD1C2019].[CONCORDIA].[recorrido] AS REC, " +  
	                        "[GD1C2019].[CONCORDIA].[recorrido_tramo] AS RT, " +
	                        "[GD1C2019].[CONCORDIA].[tramo] AS T " +
                        "WHERE RES.viaj_id = V.viaj_id AND V.reco_id = REC.reco_id AND REC.reco_id = RT.reco_id AND " +
                                "RT.tram_id = T.tram_id AND RES.rese_id = @idReserva";
            SqlCommand query = Database.createQuery(queryString);
            query.Parameters.AddWithValue("@idReserva", this.id);
            return Int32.Parse(Database.consultaObtenerValor(query));
        }
    }
}
