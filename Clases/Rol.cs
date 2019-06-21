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
            string queryString = "SELECT RF.func_id, F.func_descripcion FROM [GD1C2019].[CONCORDIA].[funcionalidad] AS F, [GD1C2019].[CONCORDIA].[roles_funcionalidad] AS RF " +
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

        public bool poseeEstasFuncionalidades(List<Funcionalidad> list)
        {
            return (this.funcionalidades.Count == list.Count) && this.funcionalidades.All(f => list.Any(l => l.Id == f.Id));
        }

        public void actualizarInhabilitacion(bool _inhabilitado)
        {
            if (_inhabilitado)
            {
                this.inhabilitar();
            }
            else
            {
                this.habilitar();
            }
            this.Inhabilitado = _inhabilitado;
        }

        public void inhabilitar()
        {
            if (!this.inhabilitado)
            {
                Database.actualizarInhabilitacionDeRol(id, 1);
            }
        }

        public void habilitar()
        {
            if (this.inhabilitado)
            {
                Database.actualizarInhabilitacionDeRol(id, 0);
            }
        }

        public void actualizarFuncionalidades(List<Funcionalidad> funcionalidadesDelRolSeleccionado)
        {
            List<Funcionalidad> funcionalidadesAQuitar = this.funcionalidades.Where(f => 
            {
                return funcionalidadesDelRolSeleccionado.All(fn => fn.Id != f.Id);
            }).ToList();
            List<Funcionalidad> funcionalidadesAAgregar = funcionalidadesDelRolSeleccionado.Where(fn => 
            {
                return !this.funcionalidades.Any(f => f.Id == fn.Id);
            }).ToList();

            if (funcionalidadesAQuitar.Count > 0)
            {
                Database.eliminarRolFuncionalidad(this.id, funcionalidadesAQuitar);
            }
            if (funcionalidadesAAgregar.Count > 0)
            {
                Database.persistirRolFuncionalidad(this.id, funcionalidadesAAgregar);
            }
            this.funcionalidades = funcionalidadesDelRolSeleccionado;
        }

        public void actualizarDescripcion(string nuevaDescripcion)
        {
            if (descripcion != nuevaDescripcion)
            {
                Database.actualizarDescripcionDeRol(id, nuevaDescripcion);
                this.Descripcion = nuevaDescripcion;
            }
        }
    }
}
