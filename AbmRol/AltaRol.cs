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
        private List<Funcionalidad> funcionalidadesActuales;

        public AltaRol(AbmRol _padre)
        {
            InitializeComponent();
            inicializarComboBox();
            padre = _padre;
            rolesActuales = Database.getRoles(2);
        }

        //--Agrego las funcionalidades al comboBox
        private void inicializarComboBox()
        {
            funcionalidadesActuales = new List<Funcionalidad>();
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
                int id = Int32.Parse(this.DGVFuncionalidad[0, e.RowIndex].Value.ToString());
                this.DGVFuncionalidad.Rows.RemoveAt(e.RowIndex);
                this.funcionalidadesActuales = funcionalidadesActuales.Where(f => f.Id != id).ToList();
            }
        }

        //--Cuando se selecciona una funcionalidad, la agrego al DGV
        private void CBFuncionalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBFuncionalidad.SelectedItem == null) return;
            KeyValuePair<int, string> funcionalidadSeleccionada = (KeyValuePair<int, string>)CBFuncionalidad.SelectedItem;
            if (noFueAgregado(funcionalidadSeleccionada))
            {
                string descripcion = funcionalidadSeleccionada.Value;
                int id = funcionalidadSeleccionada.Key;
                this.DGVFuncionalidad.Rows.Add(id, descripcion, "Quitar");
                this.funcionalidadesActuales.Add(new Funcionalidad(descripcion, id));
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
            lblError.Hide();
            if (noHayErrores())
            {
                int idRol = Database.persistirRol(this.txtNombre.Text);
                Database.persistirRolFuncionalidad(idRol, funcionalidadesActuales);
                limpiar();
                ventanaInformarExito("Rol agregado.");
            }
        }

        private bool noHayErrores()
        {
            bool rta = true;
            if(string.IsNullOrWhiteSpace(this.txtNombre.Text))
            {
                mostrarErrores("El nombre no puede estar vacio.");
                rta = false;
            }
            else if (funcionalidadesActuales.Count() == 0)
            {
                mostrarErrores("La lista debe poseer una funcionalidad como minimo.");
                rta = false;
            }
            else if (hayOtroRolConLaMismaDescripcion())
            {
                mostrarErrores("Hay otro rol con las mismas funcionalidades.");
                rta = false;
            }
            else if(hayOtroRolConLasMismasFuncionalidades())
            {
                mostrarErrores("Hay otro rol con las mismas funcionalidades.");
                rta = false;
            }
            return rta;
        }

        private bool hayOtroRolConLaMismaDescripcion()
        {
            return rolesActuales.Any(r => r.Descripcion == this.txtNombre.Text);
        }

        private bool hayOtroRolConLasMismasFuncionalidades()
        {
            return rolesActuales.Any(r => r.poseeEstasFuncionalidades(this.funcionalidadesActuales));
        }

        private void mostrarErrores(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.Show();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiar();
        }

        private void limpiar()
        {
            lblError.Hide();
            txtNombre.Text = "";
            funcionalidadesActuales.Clear();
            DGVFuncionalidad.Rows.Clear();
        }
    }
}
