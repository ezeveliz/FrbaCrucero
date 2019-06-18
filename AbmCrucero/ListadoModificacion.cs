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
    public partial class ListaModificacion : Form
    {
        string consulta = "select cruc_id, cruc_identificador, cruc_modelo, fabr_id, cruc_inhabilitado,cruc_fecha_alta from CONCORDIA.crucero";
        Logger logErrores = new Logger();

        public ListaModificacion()
        {
            InitializeComponent();
            cargarMarcas();
        }

        public void InicializarGrid()
        {
            tablaCruceros.ColumnCount = 6;
            tablaCruceros.Columns[0].Name = "cruc_id";
            tablaCruceros.Columns[1].Name = "cruc_identificador";
            tablaCruceros.Columns[2].Name = "cruc_modelo";
            tablaCruceros.Columns[3].Name = "fabr_id";
            tablaCruceros.Columns[4].Name = "cruc_inhabilitado";
            tablaCruceros.Columns[5].Name = "cruc_fecha_alta";
        }

        public void cargarMarcas()
        {   
            SqlCommand query = Database.createQuery("select fabr_nombre from CONCORDIA.fabricante");
            List<String> listaFabricantes = Database.consultaObtenerLista(query);

            for (int i = 0; i < listaFabricantes.Count; i++)
            {
                comboBoxMarca.Items.Add(listaFabricantes[i]);
            }

        }

        private void Buscar() 
        {   tablaCruceros.AutoGenerateColumns = true;
            tablaCruceros.DataSource = Database.getQueryTable(crearQuery());
            
        }

        private SqlCommand crearQuery()
        {   
            List<string> parametrosDeBusqueda = cargarParametros();
            string query = consulta + generadorDeCondicion(cargarParametros());
            return Database.createQuery(query);
        }

        //Mejorar se ve muy feo
        private List<string> cargarParametros()
        {   
            List<string> parametros = new List<string>();

            if(textBoxId.Text != "")
            {
                if(checkBoxIdExacto.Checked)
                {
                    parametros.Add("cruc_id = " + textBoxId.Text);
                }
                else
                {
                    parametros.Add(" cruc_id LIKE " + "\'%" + textBoxId.Text + "%\'" );
                }
            }
             if(textBoxIdentificador.Text != "")
            {
                if (checkBoxIdentExacto.Checked)
                {
                    parametros.Add(" cruc_identificador = " + "\'" +  textBoxIdentificador.Text + "\'");
                }
                else
                {
                 parametros.Add(" cruc_identificador LIKE " + "\'%" + textBoxIdentificador.Text + "%\'");
                }
            }

            if(comboBoxMarca.SelectedIndex > -1)
            {
                parametros.Add(" fabr_id = " +  (comboBoxMarca.SelectedIndex + 1).ToString());
            }

            return parametros;

        }

        private string generadorDeCondicion(List<string> parametros)
        {   
            string condicion = "";
            
            if(parametros.Count != 0)
            {    
                condicion = " WHERE " + parametros[0];
                 
                for (int i = 1; i < parametros.Count; i++)
                 {
                    condicion += " AND " + parametros[i]; 
                 }
            }

            return condicion;
        }

        private void Limpiar()
        {
            textBoxId.Text = textBoxIdentificador.Text = "";
            checkBoxIdentExacto.Checked = checkBoxIdExacto.Checked = false;
            comboBoxMarca.SelectedIndex = - 1;
            tablaCruceros.DataSource = null;
        }

        private void validarCampos(){
            if(!Validaciones.esInt(textBoxId.Text) || textBoxId.Text != "")
            {
                logErrores.agregarAlLog("id tiene que ser un int");
            }
        }

        private Crucero cargarDatosCrucero(){
           Crucero crucero = new Crucero(
                Convert.ToInt32(tablaCruceros.SelectedCells[0].Value),
                tablaCruceros.SelectedCells[1].Value.ToString(),
                tablaCruceros.SelectedCells[2].Value.ToString(),
                Convert.ToInt32(tablaCruceros.SelectedCells[3].Value),
                Convert.ToBoolean(tablaCruceros.SelectedCells[4].Value),
                tablaCruceros.SelectedCells[5].Value.ToString());

            return crucero;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if ( tablaCruceros.CurrentRow.Selected)
            {
                ModificacionCrucero modificacion = new ModificacionCrucero(cargarDatosCrucero());
                modificacion.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }
            
        }


    }

}
