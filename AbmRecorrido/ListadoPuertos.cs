using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using FrbaCrucero.Clases;

namespace FrbaCrucero.AbmRecorrido
{
    public partial class ListadoPuertos : Frame
    {
        private AltaTramo padre;
        private string elOtroCampo;
        private bool inicio;

        public ListadoPuertos(AltaTramo _padre, string _elOtroCampo, bool _inicio)
        {
            InitializeComponent();
            padre = _padre;
            elOtroCampo = _elOtroCampo;
            this.btnSeleccionar.Enabled = false;
            inicio = _inicio;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            lstPuertos.Items.Clear();
            txtPuerto.Text = "";
            this.btnSeleccionar.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            lstPuertos.Items.Clear();
            if (!string.IsNullOrWhiteSpace(txtPuerto.Text))
            {
                string queryString = generateQueryString();
                SqlCommand query = Database.createQuery(queryString);
                DataTable tabla = Database.getQueryTable(query);
                agregarPuertosAlListBox(tabla);
            }
            else
            {
                mostrarError("Debes escribir algo.");
            }
        }

        private void mostrarError(string error)
        {
            lblError.Text = error;
            lblError.Show();
            this.btnSeleccionar.Enabled = false;
        }

        private string generateQueryString()
        {
            string puertoABuscar = "'%" + txtPuerto.Text + "%'";
            string query = "SELECT * FROM [GD1C2019].[CONCORDIA].[puerto] WHERE puer_ciudad LIKE " + puertoABuscar;
            if (elOtroCampo != "")
            {
                query += " AND puer_ciudad != " + "'" + elOtroCampo + "'";
            }
            return query;
        }

        private void agregarPuertosAlListBox(DataTable tabla)
        {
            var funcionalidades = new List<KeyValuePair<int, string>>(); //Genera una lista de funcionalidades vacias

            foreach (DataRow fila in tabla.Rows)
            {
                int id = Int32.Parse(fila[0].ToString());
                string puerto = fila[1].ToString();
                funcionalidades.Add(new KeyValuePair<int, string>(id, puerto));
            }

            this.lstPuertos.DisplayMember = "Value"; // setea el key y value para el listbox
            this.lstPuertos.ValueMember = "Key";

            funcionalidades.ForEach(item => lstPuertos.Items.Add(item));// Agrega las funcionalidades al list box

            if (this.lstPuertos.Items.Count < 1) //Si no seleccione ninguna funcionalidad no puedo continuar
            {
                mostrarError("No hay puertos con ese nombre.");
                this.btnSeleccionar.Enabled = false;
            }
            else
            {
                lblError.Hide();
                this.btnSeleccionar.Enabled = true;
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            int idSeleccionada = ((KeyValuePair<int, string>)this.lstPuertos.SelectedItem).Key;
            string nombreSeleccionado = ((KeyValuePair<int, string>)this.lstPuertos.SelectedItem).Value;
            Puerto puerto = new Puerto(idSeleccionada, nombreSeleccionado);
            if (inicio)
            {
                padre.PuertoInicio = puerto;
            }
            else 
            {
                padre.PuertoDestino = puerto;
            }
            this.ListadoPuertos_FormClosed(sender, new FormClosedEventArgs(CloseReason.UserClosing));
        }

        private void ListadoPuertos_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Dispose();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.ListadoPuertos_FormClosed(sender, new FormClosedEventArgs(CloseReason.UserClosing));
        }
    }
}
