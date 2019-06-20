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
            rolesActuales = Database.getRoles(0);
            inicializarListBox();
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
            this.ModificacionRol_FormClosed(sender, new FormClosedEventArgs(CloseReason.UserClosing));
        }

        private void lbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rolSeleccionado = ((KeyValuePair<int, string>)this.lbRoles.SelectedItem).Key;

        }
    }
}
