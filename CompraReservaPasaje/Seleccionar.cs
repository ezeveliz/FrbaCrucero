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
using FrbaCrucero.GeneracionViaje;

using System.Data.SqlTypes;
using System.Data.SqlClient;


namespace FrbaCrucero.GeneracionViaje
{
    public partial class SeleccionadorViaje : Form
    {
        public string[] seleccionado; 
        string consulta;
        string[] camposConsulta;
        Logger logErrores = new Logger();

        public SeleccionadorViaje(string _consulta, string _filtro1, string _filtro2)
        {
            InitializeComponent();
            consulta = _consulta;
            camposConsulta = parserConsulta(_consulta);
            labelFiltro1.Text = _filtro1;
            labelFiltro2.Text = _filtro2;

        }

        public string[] parserConsulta(String consulta){
            string parseo = consulta.Substring(consulta.IndexOf("SELECT"), consulta.IndexOf("FROM")-4);

            return parseo.Split( new char[] {','}); 
        }

        public void InicializarGrid()
        {
            tabla.ColumnCount = camposConsulta.Length;
            for (int i = 0; i < camposConsulta.Length; i++) {
                tabla.Columns[i].Name = camposConsulta[i];
            }

        }

        private void Buscar() 
        {   tabla.AutoGenerateColumns = true;
            tabla.DataSource = Database.getQueryTable(crearQuery());
            
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

            if(textBoxFiltro1.Text != "")
            {
                if(checkBox1Exacto.Checked)
                {
                    parametros.Add(labelFiltro1.Text + " = " + textBoxFiltro1.Text);
                }
                else
                {
                    parametros.Add(labelFiltro1.Text +" LIKE " + "\'%" + textBoxFiltro1.Text + "%\'" );
                }
            }
             if(textBoxFiltro2.Text != "")
            {
                if (checkBox2Exacto.Checked)
                {
                    parametros.Add( labelFiltro2.Text + " = " + "\'" + textBoxFiltro2.Text + "\'");
                }
                else
                {
                    parametros.Add( labelFiltro2.Text + " LIKE " + "\'%" + textBoxFiltro2.Text + "%\'");
                }
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
            textBoxFiltro1.Text = textBoxFiltro2.Text = "";
            checkBox2Exacto.Checked = checkBox1Exacto.Checked = false;
            tabla.DataSource = null;
        }

        private void validarCampos(){
            if(!Validaciones.esInt(textBoxFiltro1.Text) || textBoxFiltro1.Text != "")
            {
                logErrores.agregarAlLog("id tiene que ser un int");
            }
        }

        private Crucero cargarDatos(){
           Crucero crucero = new Crucero(
                Convert.ToInt32(tabla.SelectedCells[0].Value),
                tabla.SelectedCells[1].Value.ToString(),
                tabla.SelectedCells[2].Value.ToString(),
                Convert.ToInt32(tabla.SelectedCells[3].Value),
                Convert.ToBoolean(tabla.SelectedCells[4].Value),
                tabla.SelectedCells[5].Value.ToString());

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

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (tabla.CurrentRow.Selected)
            {
                String[] row = new String[10];

                for (int i = 0; i < tabla.SelectedCells.Count; i++)
                {
                    row[i] = tabla.SelectedCells[i].Value.ToString();
                }

                seleccionado = row;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }
        }



    }

}
