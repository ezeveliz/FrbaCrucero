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
                                "WHERE rese_id = @idReserva AND rese_id != (SELECT pasa_id FROM [GD1C2019].[CONCORDIA].[cancelacion_reserva])";
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
            }
            else
            {
                this.esValida = false;
            }
        }
    }
}
