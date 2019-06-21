using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.Clases;

namespace FrbaCrucero.AbmRol
{
    public partial class ModificacionRol : Frame
    {
        private AbmRol padre;
        private List<Rol> rolesActuales;
        private Rol rolSeleccionado;
        private List<Funcionalidad> funcionalidadesDelRolSeleccionado;

        public ModificacionRol(AbmRol _padre)
        {
            InitializeComponent();
            padre = _padre;
            rolesActuales = Database.getRoles(2);
            inicializarListBox();
            inicializarComboBox();
        }

        private void inicializarComboBox()
        {
            List<KeyValuePair<int, string>> funcionalidades = new List<KeyValuePair<int, string>>();
            DataTable table = Database.getFuncionalidades();
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

        private void inicializarListBox()
        {
            List<KeyValuePair<int, string>> roles = new List<KeyValuePair<int, string>>();
            foreach (Rol rol in rolesActuales)
            {
                int id = rol.Id;
                string desc = rol.Descripcion;
                roles.Add(new KeyValuePair<int, string>(id, desc));
            }
            lbRoles.DisplayMember = "Value";
            lbRoles.ValueMember = "Key";
            roles.ForEach(f => lbRoles.Items.Add(f));
        }

        private void ModificacionRol_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Dispose();
            padre.Show();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            ModificacionRol_FormClosed(sender, new FormClosedEventArgs(CloseReason.UserClosing));
        }

        private void lbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idRolSeleccionado = ((KeyValuePair<int, string>)lbRoles.SelectedItem).Key;
            rolSeleccionado = rolesActuales.Find(r => r.Id == idRolSeleccionado);
            funcionalidadesDelRolSeleccionado = new List<Funcionalidad>();
            rolSeleccionado.Funcionalidades.ForEach(f => 
            {
                funcionalidadesDelRolSeleccionado.Add(f);
            });
            txtNombre.Text = rolSeleccionado.Descripcion;
            cbInhabilitado.Checked = rolSeleccionado.Inhabilitado;
            inicializarDGVFuncionalidad();
        }

        private void inicializarDGVFuncionalidad()
        {
            DGVFuncionalidad.Rows.Clear();
            funcionalidadesDelRolSeleccionado.ForEach(f =>
            {
                DGVFuncionalidad.Rows.Add(f.Id, f.Descripcion, "Quitar");
            });
        }

        private void DGVFuncionalidad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                int id = Int32.Parse(DGVFuncionalidad[0, e.RowIndex].Value.ToString());
                DGVFuncionalidad.Rows.RemoveAt(e.RowIndex);
                funcionalidadesDelRolSeleccionado = funcionalidadesDelRolSeleccionado.Where(f => f.Id != id).ToList();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(noHayErrores())
            {
                rolSeleccionado.actualizarFuncionalidades(funcionalidadesDelRolSeleccionado);
                rolSeleccionado.actualizarDescripcion(txtNombre.Text);
                rolSeleccionado.actualizarInhabilitacion(cbInhabilitado.Checked);
                rolesActuales.ForEach(r => 
                {
                    if (r.Id == rolSeleccionado.Id)
                    {
                        r.Funcionalidades = rolSeleccionado.Funcionalidades;
                        r.Descripcion = rolSeleccionado.Descripcion;
                        r.Inhabilitado = rolSeleccionado.Inhabilitado;
                    }
                });
                lbRoles.Items.Clear();
                inicializarListBox();
                limpiar();
                ventanaInformarExito("El rol seleccionado ha sido modificado.");
            }
        }

        private bool noHayErrores()
        {
            bool rta = true;
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                mostrarErrores("El nombre no puede estar vacio.");
                rta = false;
            }
            else if (funcionalidadesDelRolSeleccionado.Count() == 0)
            {
                mostrarErrores("La lista debe poseer una funcionalidad como minimo.");
                rta = false;
            }
            else if (hayOtroRolConLaMismaDescripcion())
            {
                mostrarErrores("Hay otro rol con las mismas funcionalidades.");
                rta = false;
            }
            else if (hayOtroRolConLasMismasFuncionalidades())
            {
                mostrarErrores("Hay otro rol con las mismas funcionalidades.");
                rta = false;
            }
            return rta;
        }

        private bool hayOtroRolConLasMismasFuncionalidades()
        {
            List<Rol> todosLosRolesMenosElActual = rolesActuales.Where(r => r.Id != rolSeleccionado.Id).ToList();
            return todosLosRolesMenosElActual.Any(r => r.poseeEstasFuncionalidades(funcionalidadesDelRolSeleccionado));
        }

        private bool hayOtroRolConLaMismaDescripcion()
        {
            List<Rol> todosLosRolesMenosElActual = rolesActuales.Where(r => r.Id != rolSeleccionado.Id).ToList();
            return todosLosRolesMenosElActual.Any(r => r.Descripcion == txtNombre.Text);
        }

        private void mostrarErrores(string p)
        {
            lblError.Text = p;
            lblError.Show();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
           limpiar();
        }

        private void limpiar()
        {
            txtNombre.Text = "";
            DGVFuncionalidad.Rows.Clear();
            lblError.Hide();
        }

        //--Quito una funcionalidad cuado se presiona sobre quitar
        private void CBFuncionalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBFuncionalidad.SelectedItem == null) return;
            KeyValuePair<int, string> funcionalidadSeleccionada = (KeyValuePair<int, string>)CBFuncionalidad.SelectedItem;
            if (noFueAgregado(funcionalidadSeleccionada))
            {
                string descripcion = funcionalidadSeleccionada.Value;
                int id = funcionalidadSeleccionada.Key;
                DGVFuncionalidad.Rows.Add(id, descripcion, "Quitar");
                funcionalidadesDelRolSeleccionado.Add(new Funcionalidad(descripcion, id));
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
    }
}
