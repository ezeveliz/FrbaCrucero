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

        public static LoginDTO authenticate(string user, string pass)
        {
            SqlCommand query = createQuery("SELECT Usuario_Nombre, Usuario_Contrasenia, Usuario_IntentosFallidos FROM RIP.Usuarios WHERE Usuario_Nombre = @username");
            query.Parameters.AddWithValue("@username", user);
            DataRow row = getQueryRow(query);
            return (row != null ? loginVerificarCuenta(row, pass) : loginUsuarioInexistente());
        }

        public static LoginDTO loginVerificarCuenta(DataRow fila, string pass)
        {
            string username = (string)fila["Usuario_Nombre"];
            byte[] encryptedPass = (byte[])fila["Usuario_Contrasenia"];
            int attempts = (int)fila["Usuario_IntentosFallidos"];
            Usuario user = new Usuario(username);
            if (attempts >= 3 || usuarioBloqueado(user))
                return loginCuentaBloqueada();
            else
                return loginVerificarContrasenia(username, pass, encryptedPass, attempts);
        }

        private static bool usuarioBloqueado(Usuario user)
        {
            return !usuarioHabilitado(user);
        }

        public static bool usuarioHabilitado(Usuario user)
        {
            SqlCommand query = createQuery("SELECT Usuario_Estado FROM RIP.Usuarios WHERE Usuario_Nombre = @Nombre");
            query.Parameters.AddWithValue("@Nombre", user.Nombre);
            return bool.Parse(consultaObtenerValor(query));
        }

        private static LoginDTO loginCuentaBloqueada()
        {
            return new LoginDTO().userBloqued();
        }

        private static LoginDTO loginVerificarContrasenia(string username, string pass, byte[] encryptedPass, int attempts)
        {
            return (loginContraseniaEsCorrecta(pass, encryptedPass) ? loginExitoso(username) : loginFallido(username, attempts));
        }

        private static bool loginContraseniaEsCorrecta(string pass, byte[] encryptedPass)
        {
            return loginEncriptarContraseña(pass).SequenceEqual(encryptedPass);
        }

        private static byte[] loginEncriptarContraseña(string pass)
        {
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding encoder = Encoding.UTF8;
                return hash.ComputeHash(encoder.GetBytes(pass));
            }
        }

        public static LoginDTO loginExitoso(string username)
        {
            loginActualizarIntentos(username, 0);
            return new LoginDTO().success(username);
        }

        public static void loginActualizarIntentos(string username, int attempts)
        {
            SqlCommand query = createQuery("UPDATE RIP.Usuarios SET Usuario_IntentosFallidos = @cantidad WHERE Usuario_Nombre = @username");
            query.Parameters.AddWithValue("@username", username);
            query.Parameters.AddWithValue("@cantidad", attempts);
            executeCUDQuery(query);
        }

        public static LoginDTO loginFallido(string user, int failedAttempts)
        {
            failedAttempts++;
            loginActualizarIntentos(user, failedAttempts);
            LoginDTO login = new LoginDTO();
            if (failedAttempts >= 3)
            {
                usuarioBloquear(new Usuario(user));
                return login.userBloqued();
            }

            else
                return login.wrongPassword();
        }

        public static void usuarioBloquear(Usuario usuario)
        {
            SqlCommand query = createQuery("UPDATE RIP.Usuarios SET Usuario_Estado = 0 WHERE Usuario_ID = @ID");
            query.Parameters.AddWithValue("@ID", usuarioObtenerID(usuario));
            executeCUDQuery(query);
        }

        public static LoginDTO loginUsuarioInexistente()
        {
            return new LoginDTO().inexistentUser();
        }

        public static int usuarioObtenerID(Usuario user)
        {
            SqlCommand query = createQuery("SELECT Usuario_ID FROM RIP.Usuarios WHERE Usuario_Nombre = @Nombre");
            query.Parameters.AddWithValue("@Nombre", user.Nombre);
            return int.Parse(consultaObtenerValor(query));
        }

        public static List<Rol> usuarioObtenerRolesEnLista(Usuario user)
        {
            SqlCommand query = createQuery("SELECT Rol_Nombre FROM RIP.Roles JOIN RIP.Usuarios_Roles ON Rol_ID = UsuarioRol_RolID JOIN RIP.Usuarios ON UsuarioRol_UsuarioID = Usuario_ID WHERE Usuario_Nombre = @Nombre");
            query.Parameters.AddWithValue("@Nombre", user.Nombre);
            return consultaObtenerLista(query).Select(rol => new Rol(rol)).ToList();
        }
    }
}
