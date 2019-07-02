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
using System.Globalization;

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

        //--Busca el usuario por la id del mismo
        public static DataRow buscarUsuarioPorId(int id)
        {
            string queryString = "SELECT usua_dni, usua_nombre, usua_apellido, usua_email, usua_fecha_nac, usua_direccion, usua_telefono FROM CONCORDIA.usuario where usua_id = @userId";
            SqlCommand query = createQuery(queryString);
            query.Parameters.AddWithValue("@userId", id);
            return getQueryRow(query);
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

        //--Obtengo todas las funcionalidades
        public static DataTable getFuncionalidades()
        {
            string queryString = "SELECT [func_id], [func_descripcion] FROM [GD1C2019].[CONCORDIA].[funcionalidad]";
            SqlCommand query = Database.createQuery(queryString);
            return Database.getQueryTable(query);
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

        public static void eliminarRolFuncionalidad(int id, List<Funcionalidad> funcionalidadesAQuitar)
        {
            funcionalidadesAQuitar.ForEach(f => 
            {
                string queryString = "DELETE [GD1C2019].[CONCORDIA].[roles_funcionalidad] " +
                                       "WHERE rol_id = @rolId AND func_id = @funcId";
                SqlCommand query = Database.createQuery(queryString);
                query.Parameters.AddWithValue("@rolId", id);
                query.Parameters.AddWithValue("@funcId", f.Id);
                executeCUDQuery(query);
            });
        }

        //--Actualizo la inhabilitacion de un rol dado y de los usuarios que lo posean en caso de que sea necesario
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

        //--Actualizo la descripcion del rol
        public static void actualizarDescripcionDeRol(int id, string nuevaDescripcion)
        {
            string queryString = "UPDATE [GD1C2019].[CONCORDIA].[roles] " +
                                "SET rol_descripcion = @desc " +
                                "WHERE rol_id = @rolId";
            SqlCommand query = Database.createQuery(queryString);
            query.Parameters.AddWithValue("@desc", nuevaDescripcion);
            query.Parameters.AddWithValue("@rolId", id);
            Database.executeCUDQuery(query);
        }

        #endregion

        //--NO EJECUTAR HASTA QUE ESTE TODO LISTO!!!!!
        //--Este metodo da de baja las reservas de mas de 3 dias de antiguedad
        public static void verificarReservas()
        {
            string limitDate = DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy");
            string queryString = "INSERT [GD1C2019].[CONCORDIA].[cancelacion_reserva] (rese_id, canc_descripcion) " +
                                    "SELECT rese_id, 'Reserva expirada' FROM [GD1C2019].[CONCORDIA].[reserva] " +
                                    "WHERE rese_creacion < CONVERT(datetime, @fecha, 103)";
            SqlCommand query = Database.createQuery(queryString);
            query.Parameters.AddWithValue("@fecha", limitDate);
            Database.executeCUDQuery(query);
        }

        #region PagoReserva

        //--Persisto la reserva con efectivo
        public static int pagarReservaConEfectivo(Reserva reserva)
        {
            int idPasaje = Database.persistirPasaje(reserva, "efectivo");
            Database.persistirCabinaPasaje(idPasaje, reserva);
            Database.updateReservaStatus(reserva);
            return idPasaje;
        }

        //--Persisto la reserva con debito
        public static int pagarReservaConDebito(Reserva reserva, string tarjeta)
        {
            int idPasaje = Database.persistirPasaje(reserva, "debito", Int32.Parse(tarjeta));
            Database.persistirCabinaPasaje(idPasaje, reserva);
            Database.updateReservaStatus(reserva);
            return idPasaje;
        }

        //--Persisto la relacion cabina_pasaje
        private static void persistirCabinaPasaje(int idPasaje, Reserva reserva)
        {
            List<Cabina> cabinas = reserva.Cabinas;
            cabinas.ForEach(c =>
            {
                string queryString = "INSERT [GD1C2019].[CONCORDIA].[cabina_pasaje] (pasaje_id, cabina_id) VALUES(@idPasaje, @cabinaId)";
                SqlCommand query = Database.createQuery(queryString);
                query.Parameters.AddWithValue("@idPasaje", idPasaje);
                query.Parameters.AddWithValue("@cabinaId", c.Id);
                Database.executeCUDQuery(query);
            });
            
        }

        //--persisto el pasaje y retorno su id
        private static int persistirPasaje(Reserva reserva, string tipo, int tarjeta = 0)
        {
            int idPasaje;
            Database.open();
            if (tipo == "efectivo")
            {
                string queryString = "INSERT [GD1C2019].[CONCORDIA].[pasaje] (viaj_id, usua_id, pasa_fecha_compra, medi_pago_id, pasa_precio) " +
                                    "VALUES(@idViaje, @userId, CONVERT(datetime, @fecha, 103), @medioPago, @precio); SELECT SCOPE_IDENTITY();";
                SqlCommand query = Database.createQuery(queryString);
                query.CommandType = CommandType.Text;
                {
                    query.Parameters.AddWithValue("@idViaje", reserva.IdViaje);
                    query.Parameters.AddWithValue("@userId", reserva.User.Id);
                    query.Parameters.AddWithValue("@fecha", reserva.CreacionString);
                    query.Parameters.AddWithValue("@medioPago", 2);
                    query.Parameters.AddWithValue("@precio", (int)reserva.MontoTotal);
                    //Get the inserted query
                    idPasaje = Convert.ToInt32(query.ExecuteScalar());
                }
            }
            else
            {
                string queryString = "INSERT [GD1C2019].[CONCORDIA].[pasaje] (viaj_id, usua_id, pasa_fecha_compra, medi_pago_id, pasa_cod_tajeta, pasa_precio) " +
                                    "VALUES(@idViaje, @userId, CONVERT(datetime, @fecha, 103), @medioPago, @codTarjeta, @precio); SELECT SCOPE_IDENTITY();";
                SqlCommand query = Database.createQuery(queryString);
                query.CommandType = CommandType.Text;
                {
                    query.Parameters.AddWithValue("@idViaje", reserva.IdViaje);
                    query.Parameters.AddWithValue("@userId", reserva.User.Id);
                    query.Parameters.AddWithValue("@fecha", reserva.CreacionString);
                    query.Parameters.AddWithValue("@medioPago", 1);
                    query.Parameters.AddWithValue("@codTarjeta", tarjeta);
                    query.Parameters.AddWithValue("@precio", (int)reserva.MontoTotal);
                    //Get the inserted query
                    idPasaje = Convert.ToInt32(query.ExecuteScalar());
                }
            }
            Database.close();
            return idPasaje;
        }

        //--Marco una reserva dada como pagada
        private static void updateReservaStatus(Reserva reserva)
        {
            string queryString = "UPDATE [GD1C2019].[CONCORDIA].[reserva] SET rese_pagada = @pagada WHERE rese_id = @idReserva";
            SqlCommand query = Database.createQuery(queryString);
            query.Parameters.AddWithValue("@pagada", 1);
            query.Parameters.AddWithValue("@idReserva", reserva.Id);
            Database.executeCUDQuery(query);
        }
        #endregion

        #region ListadoEstadistico

        //--Obtengo el primer año en el que se empezaron a vender pasajes
        public static int getMinorYear()
        {
            string queryString = "SELECT MIN(pasa_fecha_compra) FROM GD1C2019.CONCORDIA.pasaje";
            SqlCommand query = Database.createQuery(queryString);
            string date = Database.consultaObtenerValor(query);
            CultureInfo culture = new CultureInfo("es-AR");
            DateTime tempDate = Convert.ToDateTime(date, culture);
            return tempDate.Year;
        }

        //--Obtengo los recorridos con mas pasajes vendidos en el año seleccionado y en el trimestre seleccionado
        public static DataTable recorridosConMasPasajesCompradosEn(int anioSeleccionado, int semestreSeleccionado)
        {
            string queryString = "SELECT TOP 5 R.reco_id AS CodigoDeRecorrido, COUNT(*) AS CantDeViajes " +
                                "FROM  GD1C2019.CONCORDIA.recorrido AS R, GD1C2019.CONCORDIA.viaje AS V, GD1C2019.CONCORDIA.pasaje AS P " +
                                "WHERE R.reco_id = V.reco_id AND V.viaj_id = P.viaj_id AND " + 
                                    "DATEPART(YEAR, P.pasa_fecha_compra) = @year AND " + 
                                    "(DATEPART(QUARTER, P.pasa_fecha_compra) = @inicio OR DATEPART(QUARTER, P.pasa_fecha_compra) = @fin) " +
                                "GROUP BY R.reco_id " +
                                "ORDER BY CantDeViajes DESC";
            SqlCommand query = Database.createQuery(queryString);
            query.Parameters.AddWithValue("@year", anioSeleccionado);
            if (semestreSeleccionado == 1)
            {
                query.Parameters.AddWithValue("@inicio", 1);
                query.Parameters.AddWithValue("@fin", 2);
            }
            else
            {
                query.Parameters.AddWithValue("@inicio", 3);
                query.Parameters.AddWithValue("@fin", 4);
            }
            return Database.getQueryTable(query);
        }

        public static DataTable detalleDeRecorridosConMasPasajesCompradosEn(int anioSeleccionado, int semestreSeleccionado, int idRecorrido)
        {
            string caseWhen = "SELECT CASE ";
            if (semestreSeleccionado == 1)
            {
                caseWhen += "WHEN DATEPART(MONTH, P.pasa_fecha_compra) = 1 THEN 'Enero' " +
                            "WHEN DATEPART(MONTH, P.pasa_fecha_compra) = 2 THEN 'Febrero' " +
                            "WHEN DATEPART(MONTH, P.pasa_fecha_compra) = 3 THEN 'Marzo' " +
                            "WHEN DATEPART(MONTH, P.pasa_fecha_compra) = 4 THEN 'Abril' " +
                            "WHEN DATEPART(MONTH, P.pasa_fecha_compra) = 5 THEN 'Mayo' " +
                            "WHEN DATEPART(MONTH, P.pasa_fecha_compra) = 6 THEN 'Junio' ";
            }
            else
            {
                caseWhen += "WHEN DATEPART(MONTH, P.pasa_fecha_compra) = 7 THEN 'Julio' " +
                            "WHEN DATEPART(MONTH, P.pasa_fecha_compra) = 8 THEN 'Agosto' " +
                            "WHEN DATEPART(MONTH, P.pasa_fecha_compra) = 9 THEN 'Septiembre' " +
                            "WHEN DATEPART(MONTH, P.pasa_fecha_compra) = 10 THEN 'Octubre' " +
                            "WHEN DATEPART(MONTH, P.pasa_fecha_compra) = 11 THEN 'Noviembre' " +
                            "WHEN DATEPART(MONTH, P.pasa_fecha_compra) = 12 THEN 'Diciembre' ";
            }
            caseWhen += "END AS Mes, COUNT(*) AS CantidadVendida ";

            string queryString = caseWhen + "FROM  GD1C2019.CONCORDIA.recorrido AS R, GD1C2019.CONCORDIA.viaje AS V, GD1C2019.CONCORDIA.pasaje AS P " +
                                            "WHERE R.reco_id = V.reco_id AND V.viaj_id = P.pasa_id AND R.reco_id = @idRecorrido AND " +
	                                            "DATEPART(YEAR, P.pasa_fecha_compra) = @year AND " +
	                                            "(DATEPART(QUARTER, P.pasa_fecha_compra) = @inicio OR DATEPART(QUARTER, P.pasa_fecha_compra) = @fin) " +
                                            "GROUP BY DATEPART(MONTH, P.pasa_fecha_compra)";
            SqlCommand query = Database.createQuery(queryString);
            query.Parameters.AddWithValue("@year", anioSeleccionado);
            if (semestreSeleccionado == 1)
            {
                query.Parameters.AddWithValue("@inicio", 1);
                query.Parameters.AddWithValue("@fin", 2);
            }
            else
            {
                query.Parameters.AddWithValue("@inicio", 3);
                query.Parameters.AddWithValue("@fin", 4);
            }
            query.Parameters.AddWithValue("@idRecorrido", idRecorrido);
            return Database.getQueryTable(query);
        }

        public static DataTable crucerosConMasDiasDeBajaEn(int anioSeleccionado, int semestreSeleccionado)
        {
            string queryString = "SELECT TOP 5 C.cruc_id AS idCrucero, SUM(DATEDIFF(DAY, CFV.cfs_fecha_baja, CFV.cfs_fecha_alta)) AS diasDeBaja " +
                                "FROM GD1C2019.CONCORDIA.crucero AS C, GD1C2019.CONCORDIA.crucero_fuera_servicio AS CFV " +
                                "WHERE C.cruc_id = CFV.cruc_id AND " +
                                    "DATEPART(YEAR, CFV.cfs_fecha_baja) = @year AND " + 
                                    "(DATEPART(QUARTER, CFV.cfs_fecha_baja) = @inicio OR DATEPART(QUARTER, CFV.cfs_fecha_baja) = @fin) " +
                                "GROUP BY C.cruc_id " +
                                "ORDER BY diasDeBaja DESC";
            SqlCommand query = Database.createQuery(queryString);
            query.Parameters.AddWithValue("@year", anioSeleccionado);
            if (semestreSeleccionado == 1)
            {
                query.Parameters.AddWithValue("@inicio", 1);
                query.Parameters.AddWithValue("@fin", 2);
            }
            else
            {
                query.Parameters.AddWithValue("@inicio", 3);
                query.Parameters.AddWithValue("@fin", 4);
            }
            return Database.getQueryTable(query);
        }

        public static DataTable detalleDeCruceroConMasDiasDeBajaEn(int anioSeleccionado, int semestreSeleccionado, int idCrucero)
        {
            string caseWhen = "SELECT CASE ";
            if (semestreSeleccionado == 1)
            {
                caseWhen += "WHEN DATEPART(MONTH, CFV.cfs_fecha_baja) = 1 THEN 'Enero' " +
                            "WHEN DATEPART(MONTH, CFV.cfs_fecha_baja) = 2 THEN 'Febrero' " +
                            "WHEN DATEPART(MONTH, CFV.cfs_fecha_baja) = 3 THEN 'Marzo' " +
                            "WHEN DATEPART(MONTH, CFV.cfs_fecha_baja) = 4 THEN 'Abril' " +
                            "WHEN DATEPART(MONTH, CFV.cfs_fecha_baja) = 5 THEN 'Mayo' " +
                            "WHEN DATEPART(MONTH, CFV.cfs_fecha_baja) = 6 THEN 'Junio' ";
            }
            else
            {
                caseWhen += "WHEN DATEPART(MONTH, CFV.cfs_fecha_baja) = 7 THEN 'Julio' " +
                            "WHEN DATEPART(MONTH, CFV.cfs_fecha_baja) = 8 THEN 'Agosto' " +
                            "WHEN DATEPART(MONTH, CFV.cfs_fecha_baja) = 9 THEN 'Septiembre' " +
                            "WHEN DATEPART(MONTH, CFV.cfs_fecha_baja) = 10 THEN 'Octubre' " +
                            "WHEN DATEPART(MONTH, CFV.cfs_fecha_baja) = 11 THEN 'Noviembre' " +
                            "WHEN DATEPART(MONTH, CFV.cfs_fecha_baja) = 12 THEN 'Diciembre' ";
            }
            caseWhen += "END AS Mes, SUM(DATEDIFF(DAY, CFV.cfs_fecha_baja, CFV.cfs_fecha_alta)) AS diasDeBaja ";

            string queryString = caseWhen + "FROM GD1C2019.CONCORDIA.crucero AS C, GD1C2019.CONCORDIA.crucero_fuera_servicio AS CFV " +
                                            "WHERE C.cruc_id = CFV.cruc_id AND " +
                                                "DATEPART(YEAR, CFV.cfs_fecha_baja) = 2019 AND " +
                                                "(DATEPART(QUARTER, CFV.cfs_fecha_baja) = @inicio OR DATEPART(QUARTER, CFV.cfs_fecha_baja) = @fin) AND " +
                                                "C.cruc_id = @idCrucero " +
                                            "GROUP BY DATEPART(MONTH, CFV.cfs_fecha_baja)";
            SqlCommand query = Database.createQuery(queryString);
            query.Parameters.AddWithValue("@year", anioSeleccionado);
            if (semestreSeleccionado == 1)
            {
                query.Parameters.AddWithValue("@inicio", 1);
                query.Parameters.AddWithValue("@fin", 2);
            }
            else
            {
                query.Parameters.AddWithValue("@inicio", 3);
                query.Parameters.AddWithValue("@fin", 4);
            }
            query.Parameters.AddWithValue("@idCrucero", idCrucero);
            return Database.getQueryTable(query);
        }

        public static DataTable recorridosConMasCabinasLibresEn(int anioSeleccionado, int semestreSeleccionado)
        {
            string queryString = "SELECT TOP 5 R.reco_id AS CodigoDeRecorrido, " +
						                "(SELECT COUNT(*) AS cantDeCabinas " +
						                "FROM GD1C2019.CONCORDIA.recorrido AS R2, GD1C2019.CONCORDIA.viaje AS V, " +
							                "GD1C2019.CONCORDIA.crucero AS CR, GD1C2019.CONCORDIA.cabina AS CA " +
						                "WHERE R2.reco_id = V.reco_id AND V.cruc_id = CR.cruc_id AND " + 
							                "CR.cruc_id = CA.cruc_id AND R2.reco_id = R.reco_id AND " +
							                "DATEPART(YEAR, V.viaj_salida) = @year AND " + 
							                "(DATEPART(QUARTER, V.viaj_salida) = @inicio OR DATEPART(QUARTER, V.viaj_salida) = @fin) " +
						                "GROUP BY R2.reco_id) - " +
						                "(SELECT COUNT(*) AS cantDeCabinasLibres " +
						                "FROM GD1C2019.CONCORDIA.recorrido AS R2, GD1C2019.CONCORDIA.viaje AS V, " +
							                "GD1C2019.CONCORDIA.crucero AS CR, GD1C2019.CONCORDIA.cabina AS CA " +
						                "WHERE R2.reco_id = R.reco_id AND R2.reco_id = V.reco_id AND " +
							                "CR.cruc_id = V.cruc_id AND CA.cruc_id = CR.cruc_id AND " +
							                "DATEPART(YEAR, V.viaj_salida) = @year AND " + 
							                "(DATEPART(QUARTER, V.viaj_salida) = @inicio OR DATEPART(QUARTER, V.viaj_salida) = @fin) AND " +
							                "CA.cabi_id NOT IN (SELECT CP.cabina_id " +
												                "FROM GD1C2019.CONCORDIA.cabina_pasaje AS CP, GD1C2019.CONCORDIA.pasaje AS P " +
												                "WHERE P.pasa_id = CP.pasaje_id AND P.viaj_id = V.viaj_id) " +
						                "GROUP BY R2.reco_id) AS cantDeCabinasLibres " +
                                    "FROM GD1C2019.CONCORDIA.recorrido AS R " +
                                    "GROUP BY R.reco_id " +
                                    "ORDER BY cantDeCabinasLibres DESC";
            SqlCommand query = Database.createQuery(queryString);
            query.Parameters.AddWithValue("@year", anioSeleccionado);
            if (semestreSeleccionado == 1)
            {
                query.Parameters.AddWithValue("@inicio", 1);
                query.Parameters.AddWithValue("@fin", 2);
            }
            else
            {
                query.Parameters.AddWithValue("@inicio", 3);
                query.Parameters.AddWithValue("@fin", 4);
            }
            return Database.getQueryTable(query);
        }

        public static DataTable detalleDeRecorridoConMasCabinasLibres(int anioSeleccionado, int semestreSeleccionado, int idRecorrido)
        {
            string queryString = "";
            if (semestreSeleccionado == 1)
            {
                for (int i = 0; i <= 5; i++)
                {
                    string mes = "\'" + new DateTime(2019, i + 1, 1).ToString("MMMM", CultureInfo.CreateSpecificCulture("es")) + "\'";
                    queryString += " SELECT " + mes + " AS Mes, (SELECT COUNT(*) AS cantDeCabinas " +
		            "FROM GD1C2019.CONCORDIA.recorrido AS R, GD1C2019.CONCORDIA.viaje AS V, " +
			            "GD1C2019.CONCORDIA.crucero AS CR, GD1C2019.CONCORDIA.cabina AS CA " +
		            "WHERE R.reco_id = V.reco_id AND V.cruc_id = CR.cruc_id AND " +
			            "CR.cruc_id = CA.cruc_id AND R.reco_id = " + idRecorrido + " AND " +
			            "DATEPART(YEAR, V.viaj_salida) = " + anioSeleccionado + " AND " +
			            "DATEPART(MONTH, V.viaj_salida) = " + (i + 1) + " " +
		            "GROUP BY R.reco_id) - (SELECT COUNT(*) AS cantDeCabinasLibres " +
					            "FROM GD1C2019.CONCORDIA.recorrido AS R, GD1C2019.CONCORDIA.viaje AS V, " +
						            "GD1C2019.CONCORDIA.crucero AS CR, GD1C2019.CONCORDIA.cabina AS CA " +
                                "WHERE R.reco_id = " + idRecorrido + " AND R.reco_id = V.reco_id AND " +
						            "CR.cruc_id = V.cruc_id AND CA.cruc_id = CR.cruc_id AND " +
                                    "DATEPART(YEAR, V.viaj_salida) = " + anioSeleccionado + " AND " +
                                    "DATEPART(MONTH, V.viaj_salida) = " + (i + 1) + " AND " +
						            "CA.cabi_id NOT IN (SELECT CP.cabina_id " +
												            "FROM GD1C2019.CONCORDIA.cabina_pasaje AS CP, GD1C2019.CONCORDIA.pasaje AS P " +
												            "WHERE P.pasa_id = CP.pasaje_id AND P.viaj_id = V.viaj_id) " +
												            "GROUP BY R.reco_id) AS cantLibres";
                    queryString += (i + 1 != 6 ? " UNION " : "");
                }
            }
            else
            {
                for (int i = 6; i <= 11; i++)
                {
                    string mes = "\'" + new DateTime(2019, i + 1, 1).ToString("MMMM", CultureInfo.CreateSpecificCulture("es")) + "\'";
                    queryString += " SELECT " + mes + " AS Mes, (SELECT COUNT(*) AS cantDeCabinas " +
                    "FROM GD1C2019.CONCORDIA.recorrido AS R, GD1C2019.CONCORDIA.viaje AS V, " +
                        "GD1C2019.CONCORDIA.crucero AS CR, GD1C2019.CONCORDIA.cabina AS CA " +
                    "WHERE R.reco_id = V.reco_id AND V.cruc_id = CR.cruc_id AND " +
                        "CR.cruc_id = CA.cruc_id AND R.reco_id = " + idRecorrido + " AND " +
                        "DATEPART(YEAR, V.viaj_salida) = " + anioSeleccionado + " AND " +
                        "DATEPART(MONTH, V.viaj_salida) = " + (i + 1) + " " +
                    "GROUP BY R.reco_id) - (SELECT COUNT(*) AS cantDeCabinasLibres " +
                                "FROM GD1C2019.CONCORDIA.recorrido AS R, GD1C2019.CONCORDIA.viaje AS V, " +
                                    "GD1C2019.CONCORDIA.crucero AS CR, GD1C2019.CONCORDIA.cabina AS CA " +
                                "WHERE R.reco_id = " + idRecorrido + " AND R.reco_id = V.reco_id AND " +
                                    "CR.cruc_id = V.cruc_id AND CA.cruc_id = CR.cruc_id AND " +
                                    "DATEPART(YEAR, V.viaj_salida) = " + anioSeleccionado + " AND " +
                                    "DATEPART(MONTH, V.viaj_salida) = " + (i + 1) + " AND " +
                                    "CA.cabi_id NOT IN (SELECT CP.cabina_id " +
                                                            "FROM GD1C2019.CONCORDIA.cabina_pasaje AS CP, GD1C2019.CONCORDIA.pasaje AS P " +
                                                            "WHERE P.pasa_id = CP.pasaje_id AND P.viaj_id = V.viaj_id) " +
                                                            "GROUP BY R.reco_id) AS cantLibres";
                    queryString += (i + 1 != 12 ? " UNION " : "");
                }
            }
            SqlCommand query = Database.createQuery(queryString);
            return Database.getQueryTable(query); 
        }

        #endregion
    }
}
