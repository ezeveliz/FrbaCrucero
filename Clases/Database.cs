using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Threading.Tasks;
using FrbaCrucero.Clases;
using FrbaCrucero;

namespace FrbaCrucero.Clases
{
    class Database
    {
        private static String connectionString = ConfigurationManager.ConnectionStrings["conexionString"].ConnectionString;
        private static SqlConnection connection = new SqlConnection(connectionString);

        public static void open()
        {
            connection.Open();
        }

        public static void close()
        {
            connection.Close();
        }

        public static SqlConnection getConnection()
        {
            return connection;
        }

        public static SqlCommand createQuery(string query)
        {
            return new SqlCommand(query, getConnection());
        }

        //--ONLY for Create, Update and Delete Queries
        public static int executeCUDQuery(SqlCommand query)
        {
            int rows = 0;
            open();
            try
            {
                rows = query.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Frame.ventanaInformarErrorDatabase(ex);
            }
            close();
            return rows;
        }

        //--ONLY for Read Queries
        public static DataSet executeReadQuery(SqlCommand query)
        {
            DataSet dataSet = new DataSet();
            try
            {
                new SqlDataAdapter(query).Fill(dataSet);
            }
            catch (Exception ex)
            {
                Frame.ventanaInformarErrorDatabase(ex);
            }
            return dataSet;
        }

        public static DataTable getQueriesTable(SqlCommand consulta)
        {
            return executeReadQuery(consulta).Tables[0];
        }

        public static List<string> consultaObtenerLista(SqlCommand consulta)
        {
            DataTable tabla = consultaObtenerTabla(consulta);
            List<string> columna = new List<string>();
            if (tabla.Rows.Count > 0)
                foreach (DataRow fila in tabla.Rows)
                    columna.Add(fila[0].ToString());
            return columna;
        }

        public static string consultaObtenerValor(SqlCommand consulta)
        {
            List<string> columna = consultaObtenerLista(consulta);
            if (columna.Count > 0)
                return columna[0];
            else
                return "";
        }

        public static DataRow getQueriesRow(SqlCommand consulta)
        {
            DataTable tabla = getQueriesTable(consulta);
            if (tabla.Rows.Count > 0)
                return tabla.Rows[0];
            else
                return null;
        }

        public static LoginDTO loginVerificarCuenta(DataRow fila, string pass)
        {
            string username = (string)fila["Usuario_Nombre"];
            byte[] encryptedPass = (byte[])fila["Usuario_Contrasenia"];
            int attempts = (int)fila["Usuario_IntentosFallidos"];
            Usuario user = new Usuario(username);
            if (attempts >= 3 || usuarioBloqueado(user))
                return loginCuentaBloqueada(user, attempts);
            else
                return loginVerificarContrasenia(username, pass, encryptedPass, attempts);
        }

        public static LoginDTO loginUsuarioInexistente()
        {
            return new LoginDTO().informarUsuarioInexistente();
        }

        public static LoginDTO authenticate(string user, string pass)
        {
            SqlCommand query = createQuery("SELECT Usuario_Nombre, Usuario_Contrasenia, Usuario_IntentosFallidos FROM RIP.Usuarios WHERE Usuario_Nombre = @username");
            query.Parameters.AddWithValue("@username", user);
            DataRow row = getQueriesRow(query);
            return (row != null ? loginVerificarCuenta(row, pass) : loginUsuarioInexistente());
        }
    }
}
