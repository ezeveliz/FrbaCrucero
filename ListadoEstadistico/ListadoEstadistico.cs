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
using FrbaCrucero.Inicio;

namespace FrbaCrucero.ListadoEstadistico
{
    public partial class ListadoEstadistico : Frame
    {
        private MenuPrincipal padre;
        private int anioSeleccionado;
        private int semestreSeleccionado;
        private string radioSeleccionado;

        public int AnioSeleccionado { get { return anioSeleccionado; } }
        public int SemestreSeleccionado { get { return semestreSeleccionado; } }

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
                    this.radioSeleccionado = "cabinas";
                    this.buscarRecorridosConMasCabinasLibres();
                }
                else if (buscarDias)
                {
                    this.radioSeleccionado = "dias";
                    this.buscarCrucerosConMayorCantDeDiasFueraDeServicio();
                }
                else
                {
                    this.radioSeleccionado = "pasajes";
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
            this.lblErrorBusqueda.Hide();
            this.lblErrorResultados.Hide();
        }

        //--Busco los recorridos con mas pasajes comprados
        private void buscarRecorridosConMasPasajesComprados()
        {
            DataTable table = Database.recorridosConMasPasajesCompradosEn(this.anioSeleccionado, this.semestreSeleccionado);
            List<KeyValuePair<int, int>> recorridos = new List<KeyValuePair<int, int>>();
            if (table.Rows.Count > 0)
            {
                foreach (DataRow fila in table.Rows)
                {
                    int idRecorrido = Int32.Parse(fila[0].ToString());
                    int cantDePasajes = Int32.Parse(fila[1].ToString());
                    recorridos.Add(new KeyValuePair<int, int>(idRecorrido, cantDePasajes));
                }

                DGVDatos.Columns.Add("recorridoId", "Id de recorrido");
                DGVDatos.Columns.Add("cantPasajes", "Cantidad de pasajes comprados");
                DataGridViewButtonColumn boton = new DataGridViewButtonColumn();
                boton.Name = "Accion";
                boton.HeaderText = "Accion";
                boton.Text = "Ver detalle";
                DGVDatos.Columns.Add(boton);

                recorridos.ForEach(r =>
                {
                    DGVDatos.Rows.Add(r.Key, r.Value, "Ver detalle");
                });
            }
            else
            {
                this.mostrarError(lblErrorResultados, "No hay ningun resultado para mostrar en esta fecha.");
            }
        }

        //--Busco los cruceros con mayor cantidad de dias fuera de servicio
        private void buscarCrucerosConMayorCantDeDiasFueraDeServicio()
        {
            DataTable table = Database.crucerosConMasDiasDeBajaEn(this.anioSeleccionado, this.semestreSeleccionado);
            List<KeyValuePair<int, int>> cruceros = new List<KeyValuePair<int, int>>();
            if (table.Rows.Count > 0)
            {
                foreach (DataRow fila in table.Rows)
                {
                    int idCrucero = Int32.Parse(fila[0].ToString());
                    int cantDeDias = Int32.Parse(fila[1].ToString());
                    cruceros.Add(new KeyValuePair<int, int>(idCrucero, cantDeDias));
                }

                DGVDatos.Columns.Add("cruceroId", "Id de crucero");
                DGVDatos.Columns.Add("cantDias", "Cantidad de dias fuera de uso");
                DataGridViewButtonColumn boton = new DataGridViewButtonColumn();
                boton.Name = "Accion";
                boton.HeaderText = "Accion";
                boton.Text = "Ver detalle";
                DGVDatos.Columns.Add(boton);

                cruceros.ForEach(c =>
                {
                    DGVDatos.Rows.Add(c.Key, c.Value, "Ver detalle");
                });
            }
            else
            {
                this.mostrarError(lblErrorResultados, "No hay ningun resultado para mostrar en esta fecha.");
            }
        }

        //--Busco los recorridos con mas cabinas libres en sus viajes 
        private void buscarRecorridosConMasCabinasLibres()
        {
            DataTable table = Database.recorridosConMasCabinasLibresEn(this.anioSeleccionado, this.semestreSeleccionado);
            List<KeyValuePair<int, int>> recorridos = new List<KeyValuePair<int, int>>();
            if (table.Rows.Count > 0)
            {
                foreach (DataRow fila in table.Rows)
                {
                    int idRecorrido = Int32.Parse(fila[0].ToString());
                    int cantDeCabinas = (!fila.IsNull(1) ? Int32.Parse(fila[1].ToString()) : 0);
                    recorridos.Add(new KeyValuePair<int, int>(idRecorrido, cantDeCabinas));
                }

                DGVDatos.Columns.Add("cruceroId", "Id de recorrido");
                DGVDatos.Columns.Add("cantDias", "Cantidad de cabinas libres");
                DataGridViewButtonColumn boton = new DataGridViewButtonColumn();
                boton.Name = "Accion";
                boton.HeaderText = "Accion";
                boton.Text = "Ver detalle";
                DGVDatos.Columns.Add(boton);

                recorridos.ForEach(c =>
                {
                    DGVDatos.Rows.Add(c.Key, c.Value, "Ver detalle");
                });
            }
            else
            {
                this.mostrarError(lblErrorResultados, "No hay ningun resultado para mostrar en esta fecha.");
            }
        }

        //--Muestro el detalle del crucero/recorrido seleccionado
        private void DGVDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                int id = Int32.Parse(this.DGVDatos[0, e.RowIndex].Value.ToString());
                //--Recorrido con sus pasajes comprados
                if (radioSeleccionado == "pasajes")
                {
                    int idRecorrido = id;
                    Recorrido recorrido = new Recorrido(idRecorrido, 0);
                    recorrido.getAll();
                    recorrido.getPasajesEn(this.anioSeleccionado, this.semestreSeleccionado);
                    new DetalleRecorridoPasajes(this, recorrido).ShowDialog();
                }
                //--Crucero con sus dias fuera de servicio
                else if (radioSeleccionado == "dias")
                {
                    int idCrucero = id;
                    Crucero crucero = new Crucero(idCrucero);
                    crucero.getData();
                    crucero.getDiasFueraDeServicioEn(this.anioSeleccionado, this.semestreSeleccionado);
                    new DetalleCruceroFueraServicio(this, crucero).ShowDialog();
                }
                //--Recorrido con las cabinas libres en los viajes
                else
                {
                    int idRecorrido = id;
                    Recorrido recorrido = new Recorrido(idRecorrido, 0);
                    recorrido.getAll();
                    recorrido.getCabinasLibresEn(this.anioSeleccionado, this.semestreSeleccionado);
                    new DetalleRecorridoCabinasLibres(this, recorrido).ShowDialog();
                }
            }
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
                this.mostrarError(lblErrorBusqueda, "Debe seleccionar tanto un semestre como un año.");
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
                this.mostrarError(lblErrorBusqueda, "Debe seleccionar alguno de los 3 radios.");
                return false;
            }
        }

        //--Muestro el error generado
        private void mostrarError(Label label, string error)
        {
            label.Text = error;
            label.Show();
        }
    }
}
