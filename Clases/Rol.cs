using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using FrbaCrucero.Clases;

namespace FrbaCrucero.Clases
{
    public class Rol
    {
        private int id;
        private string descripcion;
        private List<Funcionalidad> funcionalidades;
        private bool inhabilitado;

        public int Id { get { return id; } set { id = value; } }
        public string Descripcion { get { return descripcion; } set { descripcion = value; } }
        public bool Inhabilitado { get { return inhabilitado; } set { inhabilitado = value; } }
        public List<Funcionalidad> Funcionalidades { get { return funcionalidades; } set { funcionalidades = value; } }

        public Rol(string _descripcion)
        {
            descripcion = _descripcion;
        }

        public Rol(int id, string descripcion, bool inhabilitado)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.inhabilitado = inhabilitado;
            getFuncionalidades();
        }

        private void getFuncionalidades()
        {
            this.funcionalidades = new List<Funcionalidad>();
            string queryString = "SELECT RF.func_id FROM [GD1C2019].[CONCORDIA].[funcionalidad] AS F, [GD1C2019].[CONCORDIA].[roles_funcionalidad] AS RF " +
                                "WHERE RF.rol_id = @rolId AND RF.func_id = F.func_id";
            SqlCommand query = Database.createQuery(queryString);
            query.Parameters.AddWithValue("@rolId", this.id);
            DataTable table = Database.getQueryTable(query);
            foreach (DataRow fila in table.Rows)
            {
                int id = Int32.Parse(fila[0].ToString());
                string descripcion = fila[1].ToString();
                Funcionalidad funcionalidad = new Funcionalidad(descripcion, id);
                this.funcionalidades.Add(funcionalidad);
            }
        }
    }
}
