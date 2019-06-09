using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlTypes;
using System.Threading.Tasks;

namespace FrbaCrucero.Clases
{
    public class Usuario
    {
        private int id;
        private string nombre;
        private string apellido;
        private string username;
        private int rol_id;
        private List<Funcionalidad> funcionalidades;

        public int Id { get { return id; } set { id = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Apellido { get { return apellido; } set { apellido = value; } }
        public string UserName { get { return username; } set { username = value; } }
        public int Rol { get { return rol_id; } set { rol_id = value; } }
        public List<Funcionalidad> Funcionalidades { get { return funcionalidades; } set { funcionalidades = value; } }

        public Usuario() // Genera un usuario cliente Generico
        {
            this.username = null;

            this.rol_id = 2;
            this.apellido = null;
            this.Nombre = null;
            this.id = 0;

            funcionalidades = Database.funcionalidadesCliente();
        }

        public Usuario(string username) // Genera el usuario que tiene ese username
        {
            this.username = username;
            
            DataRow DatosUsuario = Database.buscarUsuario(username); //Busca los datos en la tabla y los devuelve en forma de fila 
            this.rol_id = Convert.ToInt32(DatosUsuario.ItemArray[3]);//El orden de array viene dado por la consulta del Store Procedure 
            this.apellido = (string)DatosUsuario.ItemArray[2];
            this.Nombre = (string)DatosUsuario.ItemArray[1];
            this.id = Convert.ToInt32(DatosUsuario.ItemArray[0]);

            funcionalidades = Database.funcionalidadesPorUsuario(this.id); // Busco las funcionalidades de acuerdo al rol del usuario
        }

    }
}
