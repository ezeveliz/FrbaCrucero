using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.Clases;

namespace FrbaCrucero.AbmRol
{
    public partial class AltaRol : Frame
    {
        private AbmRol padre;
        private List<Rol> rolesActuales;

        public AltaRol(AbmRol _padre)
        {
            InitializeComponent();
            inicializarComboBox();
            padre = _padre;
            getRoles();
        }

        private void getRoles()
        {
            rolesActuales = new List<Rol>();
            string queryString = "SELECT R.rol_id, R.rol_descripcion, R.rol_inhabilitado FROM [GD1C2019].[CONCORDIA].[roles] AS R";
            SqlCommand query = Database.createQuery(queryString);
            DataTable table = Database.getQueryTable(query);
            foreach (DataRow fila in table.Rows)
            {
                int id = Int32.Parse(fila[0].ToString());
                string descripcion = fila[1].ToString();
                bool inhabilitado = Boolean.Parse(fila[2].ToString());
                Rol rol = new Rol(id, descripcion, inhabilitado);
                rolesActuales.Add(rol);
            }

        }

        //--Agrego las funcionalidades al comboBox
        private void inicializarComboBox()
        {
            List<KeyValuePair<int, string>> funcionalidades = new List<KeyValuePair<int, string>>();
            DataTable table = getFuncionalidades();
            foreach (DataRow fila in table.Rows)
            {
                int id = Int32.Parse(fila[0].ToString());
                string func = fila[1].ToString();
                funcionalidades.Add(new KeyValuePair<int, string>(id, func));
            }
            CBFuncionalidad.DisplayMember = "Value";
            CBFuncionalidad.ValueMember = "Key";
            funcionalidades.ForEach(f => CBFuncionalidad.Items.Add(f));
        }

        //--Obtengo las funcionalidades de la DB
        private DataTable getFuncionalidades()
        {
            string queryString = "SELECT [func_id], [func_descripcion] FROM [GD1C2019].[CONCORDIA].[funcionalidad]";
            SqlCommand query = Database.createQuery(queryString);
            return Database.getQueryTable(query);
        }

        private void DGVFuncionalidad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                this.DGVFuncionalidad.Rows.RemoveAt(e.RowIndex);
            }
        }

        //--Cuando se selecciona una funcionalidad, la agrego al DGV
        private void CBFuncionalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBFuncionalidad.SelectedItem == null) return;
            KeyValuePair<int, string> funcionalidadSeleccionada = (KeyValuePair<int, string>)CBFuncionalidad.SelectedItem;
            if (noFueAgregado(funcionalidadSeleccionada))
            {
                DGVFuncionalidad.Rows.Add(funcionalidadSeleccionada.Key, funcionalidadSeleccionada.Value, "Quitar");
            }
        }

        //--Verifico si una funcionalidad ya ha sido aregada al DGV
        private bool noFueAgregado(KeyValuePair<int, string> funcionalidadSeleccionada)
        {
            bool rta = true;

            if (DGVFuncionalidad.Rows.Count > 1)
            {
                foreach (DataGridViewRow row in DGVFuncionalidad.Rows)
                {
                    if (row.Index == (DGVFuncionalidad.Rows.Count - 1))
                    {
                        break;
                    }
                    if (Int32.Parse(DGVFuncionalidad[0, row.Index].Value.ToString()) == funcionalidadSeleccionada.Key)
                    {
                        rta = false;
                        break;
                    }
                }
            }

            return rta;
        }
        
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.AltaRol_FormClosed(sender, new FormClosedEventArgs(CloseReason.UserClosing));
        }

        private void AltaRol_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Dispose();
            padre.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}
