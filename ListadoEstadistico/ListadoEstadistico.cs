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
using FrbaCrucero.Inicio;

namespace FrbaCrucero.ListadoEstadistico
{
    public partial class ListadoEstadistico : Frame
    {
        private MenuPrincipal padre;
        private int anioSeleccionado;
        private int semestreSeleccionado;

        public ListadoEstadistico(MenuPrincipal _padre)
        {
            InitializeComponent();
            this.padre = _padre;
            this.inicializarCBSemestre();
            this.inicializarCBAnio();
        }

        //--Cargo los posibles años a seleccionar en el comboBox de años
        private void inicializarCBAnio()
        {
            int menorAño = Database.getMinorYear();
            int añoActual = Int32.Parse(DateTime.Now.Year.ToString());

            List<KeyValuePair<int, string>> años = new List<KeyValuePair<int, string>>();
            for (int año = añoActual; año >= menorAño; año--)
            {
                int id = año;
                string func = año.ToString();
                años.Add(new KeyValuePair<int, string>(id, func));
            }
            CBAnio.DisplayMember = "Value";
            CBAnio.ValueMember = "Key";
            años.ForEach(a => CBAnio.Items.Add(a));
        }

        // Cargo los semestres a seleccionar en el comboBox de semestres
        private void inicializarCBSemestre()
        {
            List<KeyValuePair<int, string>> semestres = new List<KeyValuePair<int, string>>();
            semestres.Add(new KeyValuePair<int, string>(1, "1° Semestre"));
            semestres.Add(new KeyValuePair<int, string>(2, "2° Semestre"));
            CBSemestre.DisplayMember = "Value";
            CBSemestre.ValueMember = "Key";
            semestres.ForEach(s => CBSemestre.Items.Add(s));
        }

        private void ListadoEstadistico_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Dispose();
            padre.Show();   
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.ListadoEstadistico_FormClosed(sender, new FormClosedEventArgs(CloseReason.UserClosing));
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiar();
        }

        //--Limpio toda la vista
        private void limpiar()
        {
            this.limpiarDGV();
            this.limpiarErrores();
            this.limpiarRadios();
            this.limpiarComboBoxes();
        }

        //--Limpio la seleccion de los comboBox
        private void limpiarComboBoxes()
        {
            CBSemestre.SelectedIndex = -1;
            CBAnio.SelectedIndex = -1;
        }

        //--Deselecciono todos los radios
        private void limpiarRadios()
        {
            this.rbCabinas.Checked = false;
            this.rbDias.Checked = false;
            this.rbPasajes.Checked = false;
        }

        //--Busco la opcion requerida segun los datos especificados
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(this.noHayErrores())
            {
                this.limpiarErrores();
                this.limpiarDGV();

                bool buscarCabinas = rbCabinas.Checked;
                bool buscarDias = rbDias.Checked;
                bool buscarPasajes = rbPasajes.Checked;

                this.anioSeleccionado = ((KeyValuePair<int, string>)this.CBAnio.SelectedItem).Key;
                this.semestreSeleccionado = ((KeyValuePair<int, string>)this.CBSemestre.SelectedItem).Key;

                if (buscarCabinas)
                {
                    this.buscarRecorridosConMasCabinasLibres();
                }
                else if (buscarDias)
                {
                    this.buscarCrucerosConMayorCantDeDiasFueraDeServicio();
                }
                else
                {
                    this.buscarRecorridosConMasPasajesComprados();
                }
            }
        }

        //--Quito todas las filas y columnas de la tabla
        private void limpiarDGV()
        {
            this.DGVDatos.Columns.Clear();
        }

        //--Escondo la etiqueta de error
        private void limpiarErrores()
        {
            this.lblError.Hide();
        }

        //--Busco los recorridos con mas pasajes comprados
        private void buscarRecorridosConMasPasajesComprados()
        {
            ventanaInformarExito("Buscar recorridos con mas pasajes comprados");
        }

        //--Busco los cruceros con mayor cantidad de dias fuera de servicio
        private void buscarCrucerosConMayorCantDeDiasFueraDeServicio()
        {
            ventanaInformarExito("Buscar cruceros con mayor cant de dias fuera de servicio");
        }

        //--Busco los recorridos con mas cabinas libres en sus viajes 
        private void buscarRecorridosConMasCabinasLibres()
        {
            ventanaInformarExito("Buscar recorridos con mas cabinas libres");
        }

        //--Verifico que esten todos los campos seleccionados
        private bool noHayErrores()
        {
            return this.hayAlgunRadioSeleccionado() && this.ambosComboBoxSeleccionados();
        }

        //--Verifico que los dos comboBox esten seleccionados
        private bool ambosComboBoxSeleccionados()
        {
            bool hayUnSemestreSeleccionado = CBSemestre.SelectedIndex > -1;
            bool hayUnAñoSeleccionado = CBAnio.SelectedIndex > -1;
            if(hayUnAñoSeleccionado && hayUnSemestreSeleccionado)
            {
                return true;
            }
            else
            {
                this.mostrarError("Debe seleccionar tanto un semestre como un año.");
                return false;
            }
        }

        //--Verifico que algun radio este seleccionado
        private bool hayAlgunRadioSeleccionado()
        {
            if(rbCabinas.Checked || rbDias.Checked || rbPasajes.Checked)
            {
                return true;
            }
            else
            {
                this.mostrarError("Debe seleccionar alguno de los 3 radios.");
                return false;
            }
        }

        //--Muestro el error generado
        private void mostrarError(string error)
        {
            this.lblError.Text = error;
            this.lblError.Show();
        }
    }
}
