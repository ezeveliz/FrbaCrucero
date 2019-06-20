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

        #region Recorrido

        //--Persisto el recorrido y retorno su id
        public static int persistirRecorrido()
        {
            string queryString = "INSERT [GD1C2019].[CONCORDIA].[recorrido] (reco_inhabilitado) VALUES(@inhabilitado); SELECT SCOPE_IDENTITY();";
            SqlCommand query = Database.createQuery(queryString);
            Database.open();
            int idRecorrido;
            query.CommandType = CommandType.Text;
            {
                query.Parameters.AddWithValue("@inhabilitado", 0);
                //Get the inserted query
                idRecorrido = Convert.ToInt32(query.ExecuteScalar());
            }
            Database.close();
            return idRecorrido;
        }

        //--Persisto el tramo y retorno su id
        public static int persistirTramo(Tramo t)
        {
            int idPuertoInicio = t.PuertoInicio.Id;
            int idPuertoDestino = t.PuertoDestino.Id;
            int precio = t.Precio;

            int idTramoVerificado = verificarQueNoExistaTramo(idPuertoInicio, idPuertoDestino);

            if (idTramoVerificado == 0)
            {
                string queryString = "INSERT [GD1C2019].[CONCORDIA].[tramo] (tram_precio, puer_id_inicio, puer_id_fin) VALUES(@precio, @inicio, @destino); SELECT SCOPE_IDENTITY();";
                SqlCommand query = Database.createQuery(queryString);
                Database.open();

                query.CommandType = CommandType.Text;
                {
                    query.Parameters.AddWithValue("@precio", precio);
                    query.Parameters.AddWithValue("@inicio", idPuertoInicio);
                    query.Parameters.AddWithValue("@destino", idPuertoDestino);
                    //Get the inserted query
                    return Convert.ToInt32(query.ExecuteScalar());
                }
            }
            return idTramoVerificado;
        }

        //--Devuelvo 0 si el tramo no existe o el id en caso de que si
        public static int verificarQueNoExistaTramo(int inicio, int destino)
        {
            string queryString = "SELECT [tram_id] FROM [GD1C2019].[CONCORDIA].[tramo] WHERE puer_id_inicio = @inicio AND puer_id_fin = @destino";
            SqlCommand query = Database.createQuery(queryString);
            query.Parameters.AddWithValue("@inicio", inicio);
            query.Parameters.AddWithValue("@destino", destino);
            string idTramo = Database.consultaObtenerValor(query);

            return (idTramo == "" ? 0 : Int32.Parse(idTramo));
        }

        //--Persisto la relacion recorrido_tramo
        public static void persistirRecorridoTramo(int idRecorrido, List<Tramo> tramos)
        {
            tramos.ForEach(t =>
            {
                string queryString = "INSERT [GD1C2019].[CONCORDIA].[recorrido_tramo] (reco_id, tram_id) VALUES(@idRecorrido, @idTramo)";
                SqlCommand query = Database.createQuery(queryString);
                query.Parameters.AddWithValue("@idRecorrido", idRecorrido);
                query.Parameters.AddWithValue("@idTramo", t.Id);
                Database.executeCUDQuery(query);
            });
        }

        //--Elimino la relacion recorrido_tramo
        public static int eliminarRecorridoTramo(int idRecorrido, List<Tramo> tramosAQuitar)
        {
            int executed = 0;
            tramosAQuitar.ForEach(t =>
            {
                string queryString = "DELETE [GD1C2019].[CONCORDIA].[recorrido_tramo] " +
                                    "WHERE reco_id = @recoId AND tram_id = @tramId";
                SqlCommand query = Database.createQuery(queryString);
                query.Parameters.AddWithValue("@recoId", idRecorrido);
                query.Parameters.AddWithValue("@tramId", t.Id);
                executed += executeCUDQuery(query);
            });
            return executed;
        }

        //--Modifico la habilitacion de un recorrido dado
        public static int actualizarInhabilitacionDeRecorrido(int recoId, int inhabilitado)
        {
            string queryString = "UPDATE [GD1C2019].[CONCORDIA].[recorrido] " +
                                "SET reco_inhabilitado = @inhabilitado " +
                                "WHERE reco_id = @recoId";
            SqlCommand query = Database.createQuery(queryString);
            query.Parameters.AddWithValue("@inhabilitado", inhabilitado);
            query.Parameters.AddWithValue("@recoId", recoId);
            return Database.executeCUDQuery(query);
        }

        #endregion

        #region Rol

        //--Obtengo los roles, si pongo 0 son los habilitado, con 1 son los inhabilitados, otros numero son ambos
        public static List<Rol> getRoles(int _inhabilitado)
        {
            List<Rol> roles = new List<Rol>();
            string queryString = "SELECT R.rol_id, R.rol_descripcion, R.rol_inhabilitado FROM [GD1C2019].[CONCORDIA].[roles] AS R";
            if (_inhabilitado == 0 || _inhabilitado == 1)
            {
                queryString += " WHERE rol_inhabilitado = @inhabilitado";
            }
            SqlCommand query = Database.createQuery(queryString);
            if (_inhabilitado == 0 || _inhabilitado == 1)
            {
                query.Parameters.AddWithValue("@inhabilitado", _inhabilitado);
            }
            DataTable table = Database.getQueryTable(query);
            foreach (DataRow fila in table.Rows)
            {
                int id = Int32.Parse(fila[0].ToString());
                string descripcion = fila[1].ToString();
                bool inhabilitado = Int32.Parse(fila[2].ToString()) == 1;
                Rol rol = new Rol(id, descripcion, inhabilitado);
                roles.Add(rol);
            }
            return roles;
        }

        //--Persisto un rol y devuelvo su id
        public static int persistirRol(string descripcion)
        {
            string queryString = "INSERT [GD1C2019].[CONCORDIA].[roles] (rol_descripcion, rol_inhabilitado) VALUES(@descripcion, @inhabilitado); SELECT SCOPE_IDENTITY();";
            SqlCommand query = Database.createQuery(queryString);
            Database.open();
            int idRol;
            query.CommandType = CommandType.Text;
            {
                query.Parameters.AddWithValue("@descripcion", descripcion);
                query.Parameters.AddWithValue("@inhabilitado", 0);
                //Get the inserted query
                idRol = Convert.ToInt32(query.ExecuteScalar());
            }
            Database.close();
            return idRol;
        }

        //--Persisto la relacion rol funcionalidad
        public static void persistirRolFuncionalidad(int idRol, List<Funcionalidad> funcionalidadesActuales)
        {
            funcionalidadesActuales.ForEach(f =>
            {
                string queryString = "INSERT [GD1C2019].[CONCORDIA].[roles_funcionalidad] (rol_id, func_id) VALUES(@idRol, @idFunc)";
                SqlCommand query = Database.createQuery(queryString);
                query.Parameters.AddWithValue("@idRol", idRol);
                query.Parameters.AddWithValue("@idfunc", f.Id);
                Database.executeCUDQuery(query);
            });
        }

        //--Actualizo la inhabilitacion de un rol dado
        public static void actualizarInhabilitacionDeRol(int id, int inhabilitado)
        {
            string queryString = "UPDATE [GD1C2019].[CONCORDIA].[roles] " +
                                "SET rol_inhabilitado = @inhabilitado " +
                                "WHERE rol_id = @rolId";
            SqlCommand query = Database.createQuery(queryString);
            query.Parameters.AddWithValue("@inhabilitado", inhabilitado);
            query.Parameters.AddWithValue("@rolId", id);
            Database.executeCUDQuery(query);
            if (inhabilitado == 1)
            {
                string queryString2 = "UPDATE [GD1C2019].[CONCORDIA].[usuario] " +
                                               "SET rol_id = @inhabilitado " +
                                               "WHERE rol_id = @rolId";
                SqlCommand query2 = Database.createQuery(queryString2);
                query2.Parameters.AddWithValue("@inhabilitado", null);
                query2.Parameters.AddWithValue("@rolId", id);
                Database.executeCUDQuery(query);
            }
        }

        #endregion
    }
}
