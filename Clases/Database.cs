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
    public class Database
    {
        // Genero el string de conexion deacuero a lo configurado en App.config
        private static String connectionString = ConfigurationManager.ConnectionStrings["FrbaCrucero.Properties.Settings.Conexion"].ConnectionString;
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

        public static DataTable getQueryTable(SqlCommand consulta)
        {
            return executeReadQuery(consulta).Tables[0];
        }

        public static List<string> consultaObtenerLista(SqlCommand query)
        {
            DataTable table = getQueryTable(query);
            List<string> row = new List<string>();
            if (table.Rows.Count > 0)
            {
                foreach (DataRow fila in table.Rows)
                {
                    row.Add(fila[0].ToString());
                }
            }
            return row;
        }

        //Hace una consulta y retorna el valor de la tabla como Lista de funcionalidades
        public static List<Funcionalidad> ConsultaListaFuncionalidades(SqlCommand query)
        {
            DataTable table = getQueryTable(query);
            List<Funcionalidad> row = new List<Funcionalidad>();
            if (table.Rows.Count > 0)
            {
                foreach (DataRow fila in table.Rows) // Por cada fila de la Tabla agrega un objeto Funcionalidad a la lista
                {
                    row.Add(new Funcionalidad(fila[1].ToString(), Convert.ToInt32(fila[0])));
                }
            }
            return row;
        }

        public static string consultaObtenerValor(SqlCommand query)
        {
            List<string> column = consultaObtenerLista(query);
            return (column.Count() > 0 ? column[0] : "");
        }

        public static DataRow getQueryRow(SqlCommand query)
        {
            DataTable table = getQueryTable(query);
            if (table.Rows.Count > 0)
                return table.Rows[0];
            else
                return null;
        }

        public static int autentificacion(string user, string pass)
        {
            open();
            SqlCommand loginProcedure = createQuery("CONCORDIA.Login_procedure");//Creo a query del Store Procedure 
            loginProcedure.CommandType = CommandType.StoredProcedure;
            loginProcedure.Parameters.AddWithValue("@username", user);// Seteo los parametros del Store Procedure
            loginProcedure.Parameters.AddWithValue("@password", pass);

            SqlParameter retval = new SqlParameter("@cantidad", SqlDbType.Int);// Seteo el parametro que retorna el Store Procedure 
            retval.Direction = ParameterDirection.ReturnValue;

            loginProcedure.Parameters.Add(retval);

            SqlDataReader resultado = loginProcedure.ExecuteReader();

            close();

            return (int)loginProcedure.Parameters["@cantidad"].Value; // Saco el parametro que retorna

        }

        // Crea un crucero y devuelve -1 si ya existe o el id del crucero creado
        public static int CrearCrucero(string identificador, string modelo, int fabricante_id, string fecha_alta)
        {
            open();

            SqlCommand procidureCrucero = Database.createQuery("CONCORDIA.InsertCrucero");
            procidureCrucero.CommandType = CommandType.StoredProcedure;
            procidureCrucero.Parameters.AddWithValue("@identificador", identificador);
            procidureCrucero.Parameters.AddWithValue("@modelo", modelo);
            procidureCrucero.Parameters.AddWithValue("@fabricante_id", fabricante_id);
            procidureCrucero.Parameters.AddWithValue("@fecha_alta", fecha_alta);

            SqlParameter retval = new SqlParameter("@RESULTADO", SqlDbType.Int);// Seteo el parametro que retorna el Store Procedure 
            retval.Direction = ParameterDirection.ReturnValue;

            procidureCrucero.Parameters.Add(retval);

            SqlDataReader resultado = procidureCrucero.ExecuteReader();

            close();

            return (int)procidureCrucero.Parameters["@RESULTADO"].Value; ;

        }

        public static void CrearCabina(int nro, int piso, int cruc_id, int tipo_id)
        {
            open();

            SqlCommand procidureCabina = Database.createQuery("CONCORDIA.InsertarCabina");
            procidureCabina.CommandType = CommandType.StoredProcedure;
            procidureCabina.Parameters.AddWithValue("@piso", piso);
            procidureCabina.Parameters.AddWithValue("@nro", nro);
            procidureCabina.Parameters.AddWithValue("@cruc_id", cruc_id);
            procidureCabina.Parameters.AddWithValue("@tipo_id", tipo_id);

            SqlDataReader resultado = procidureCabina.ExecuteReader();

            close();

        }

        public static DataRow buscarUsuario(string user)
        {
            open();
            SqlCommand query = createQuery("Select usua_id, usua_nombre, usua_apellido, rol_id From CONCORDIA.usuario where usua_username = @username");
            query.Parameters.AddWithValue("@username", user);
            DataRow row = getQueryRow(query);
            close();

            return row;
        }


        public static List<Funcionalidad> funcionalidadesPorUsuario(int usua_id) //Busca las funcionalidades de un usuario 
        {
            SqlCommand getFuncionesProcedure = createQuery("CONCORDIA.GetFuncionalidadesUsuario");
            getFuncionesProcedure.CommandType = CommandType.StoredProcedure;//Setea la query para Stored Procedure 
            getFuncionesProcedure.Parameters.AddWithValue("@usua_id", usua_id);//Setea el parametro 

            return ConsultaListaFuncionalidades(getFuncionesProcedure);
        }


        public static List<Funcionalidad> funcionalidadesCliente()//Busca las funcionalidades de los clientes 
        {
            SqlCommand getFuncionesProcedure = createQuery("CONCORDIA.GetFuncionalidadesCliente");
            getFuncionesProcedure.CommandType = CommandType.StoredProcedure;

            return ConsultaListaFuncionalidades(getFuncionesProcedure);
        }

    }
}
