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

namespace FrbaCrucero.AbmCrucero
{
    public partial class AltaCrucero 
    {
        Logger logErrores = new Logger();

        public AltaCrucero()
        {
            InitializeComponent();
            IncializarCabinasTabla();
            InicializarTiposCabinas();
            CargarFabricantes();
        }

        private void CargarFabricantes()
        {
            SqlCommand query = Database.createQuery("select fabr_nombre from CONCORDIA.fabricante");
            List<String> listaFabricantes = Database.consultaObtenerLista(query);

            for (int i = 0; i < listaFabricantes.Count; i++)
            {
                comboBoxFabricante.Items.Add(listaFabricantes[i]);
            }

        }

        private void IncializarCabinasTabla()//setias vacia la tabla de cabinas 
        {
            tablasCabina.ColumnCount = 4;
            tablasCabina.Columns[0].Name = "nro";
            tablasCabina.Columns[1].Name = "psio";
            tablasCabina.Columns[2].Name = "id_tipo_cabina";
            tablasCabina.Columns[3].Name = "desc_tipo_cabina";

        }

        private void InicializarTiposCabinas()
        {
            SqlCommand query = Database.createQuery("select tipo_cabi_descripcion from CONCORDIA.tipo_cabina");
            List<String> listaTiposDeCabinas = Database.consultaObtenerLista(query);

            for (int i = 0; i < listaTiposDeCabinas.Count; i++)
            {
                comboBoxTipoCabina.Items.Add(listaTiposDeCabinas[i]);
            }
        }

        private void CargarFilaCabina(string nro, string piso, string id_tipo, string desc_tipo ) // Carga una cabina a la tabla por parametro
        {
            string[] row = new string[] { nro, piso, id_tipo, desc_tipo };
            tablasCabina.Rows.Add(row);
            
        }

        private bool camposCompletados()
        {
            return textIdentificador.Text != "" && textModelo.Text != "" && textBoxFecha.Text != "" && comboBoxFabricante.SelectedIndex > -1; 

        }

        private bool campoCabinasCompletado()
        {   
            return textBoxNro.Text != "" && textBoxPiso.Text != "" && comboBoxTipoCabina.SelectedIndex > -1;
        }


        private void AltaCrucero_Load(object sender, EventArgs e) { }

        private void Crear_Click(object sender, EventArgs e)
        {
            if (camposCompletados())
            {
                int id_crucero;
                //Crea el crucero y este devuelve su id
                id_crucero = Database.CrearCrucero(textIdentificador.Text, textModelo.Text, (comboBoxFabricante.SelectedIndex + 1), textBoxFecha.Text);

                if (id_crucero == -1) // Controlo que el identificador no este registrado
                {
                    MessageBox.Show("Numero de identificador ya registrado");
                }
                else
                {   //carga cada cabina que incluyeron 
                    for (int i = 0; i < tablasCabina.Rows.Count - 1; i++)
                    {
                        Database.CrearCabina(Convert.ToInt32(tablasCabina.Rows[i].Cells[0].Value),
                                           Convert.ToInt32(tablasCabina.Rows[i].Cells[1].Value),
                                           id_crucero,
                                           Convert.ToInt32(tablasCabina.Rows[i].Cells[2].Value));

                    }

                    MessageBox.Show("Cargado con Exito");
                }
            }
            else
            {
                MessageBox.Show("Complete los campos");
            }
        }

        private void AgregarCabinas_Click(object sender, EventArgs e)
        {   /*Le sumo uno porque el indice empieza en 1*/
            if(campoCabinasCompletado()){
                if (Validaciones.esInt(textBoxNro.Text))
                {
                    if (Validaciones.esInt(textBoxPiso.Text))
                    {
                        CargarFilaCabina(textBoxNro.Text, textBoxPiso.Text, (comboBoxTipoCabina.SelectedIndex + 1).ToString(), comboBoxTipoCabina.Text);
                        textBoxNroCabinas.Text = (tablasCabina.Rows.Count - 1).ToString();
                    }
                    else
                    {
                        MessageBox.Show("El Piso solo acpeta numeros");
                    }
                }

                else
                {
                    MessageBox.Show("El Nro de cabina solo acepta numeros");
                }
            }
            else
            {
                 MessageBox.Show("Completar los datos de la cabina");
            }
   
         }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void limpiarCampos()
        {
            textIdentificador.Text = textModelo.Text = textBoxNro.Text = textBoxPiso.Text = textBoxFecha.Text = textBoxNroCabinas.Text = ""; 
            comboBoxFabricante.SelectedIndex = comboBoxTipoCabina.SelectedIndex = -1;
            tablasCabina.Rows.Clear();
        }

        private void validarCampos() {

            if (!camposCompletados()) {
                this.logErrores.agregarAlLog("Faltan completar campos");
            }
        
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void SeleccionarFecha_Click(object sender, EventArgs e)
        {
            textBoxFecha.Text = dateTimePicker1.Value.ToString();
        }

      


    }

   /* public class Cabina
    {

        private int nro;
        private int piso;
        private int id_Tipo;
        private string desc_Tipo;

        public int Nro { get { return nro; } set { nro = value; } }
        public int Piso { get { return piso; } set { piso = value; } }
        public int Id_Tipo { get { return id_Tipo; } set { id_Tipo = value; } }
        public string Desc_Tipo { get { return desc_Tipo; } set { desc_Tipo = value; } }

        public Cabina(int _nro, int _piso, int _id_Tipo)
        {
            this.nro = _nro;
            this.piso = _piso;
            this.id_Tipo = _id_Tipo;
        }
    }*/
    

}
