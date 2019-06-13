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

using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace FrbaCrucero.AbmCrucero
{
    public partial class ModificacionCrucero : Frame
    {
        public ModificacionCrucero(Crucero crucero)
        {
            InitializeComponent();
            CargarMarcas();
            CargarDatos(crucero);
        }

        public void CargarMarcas()
        {   
            SqlCommand query = Database.createQuery("select fabr_nombre from CONCORDIA.fabricante");
            List<String> listaFabricantes = Database.consultaObtenerLista(query);

            for (int i = 0; i < listaFabricantes.Count; i++)
            {
                comboBoxMarca.Items.Add(listaFabricantes[i]);
            }

        }

        private void CargarDatos(Crucero crucero)
        {
            textBoxId.Text = crucero.Id.ToString();
            textBoxIdentificador.Text = crucero.Identificador;
            comboBoxMarca.SelectedIndex = crucero.Fabr_id;
            textBoxModelo.Text = crucero.Modelo;
            checkBoxInhabilitado.Checked = crucero.Inahbilitado;
            textBoxFechaAlta.Text = crucero.FechaAlta;

        }

        private void ModificacionCrucero_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
