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
using FrbaCrucero.CompraReservaPasaje;

using System.Data.SqlTypes;
using System.Data.SqlClient;
using FrbaCrucero.Inicio;

namespace FrbaCrucero.CompraReservaPasaje
{
    public partial class SeleccionadorPasaje : Frame
    {
        List<String> listPuertos;
        public string[] seleccionado;
        Logger logErrores = new Logger();
        bool TablaActivada = false;
        MenuPrincipal padre;
        public SeleccionadorPasaje(MenuPrincipal _padre)
        {
            InitializeComponent();
            CargarPuertos();
            dateTimePicker.CustomFormat = "yyyy/MM/dd";
            padre = _padre;
        }

        private void CargarPuertos()
        {
            SqlCommand query = Database.createQuery(" select puer_ciudad from CONCORDIA.puerto ");

            listPuertos = Database.consultaObtenerLista(query);

            for (int i = 0; i < listPuertos.Count; i++)
            {
                comboBoxPO.Items.Add(listPuertos[i]);
                comboBoxPD.Items.Add(listPuertos[i]);
            }
        }

        private void Buscar()
        {
            tabla.AutoGenerateColumns = true;
            tabla.DataSource = Database.ViajesDisponibles(textBoxFS.Text, Convert.ToInt32(comboBoxPO.SelectedIndex) + 1, Convert.ToInt32(comboBoxPD.SelectedIndex) + 1);

        }

        private void validarCampos()
        {
            if (!Validaciones.esInt(textBoxFS.Text) || textBoxFS.Text != "")
            {
                logErrores.agregarAlLog("id tiene que ser un int");
            }
        }

        private void Limpiar()
        {
            textBoxFS.Text = "";
            comboBoxPO.SelectedIndex = comboBoxPD.SelectedIndex = -1;
            tabla.DataSource = null;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
            TablaActivada = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private List<Cabina> generarDatosPasaje()
        {

            DataGridViewSelectedRowCollection Seleccionados = tabla.SelectedRows;
            List<Cabina> retorno = new List<Cabina>();

            foreach (DataGridViewRow item in Seleccionados)
            {
                Cabina cabina =new Cabina( Convert.ToInt32(item.Cells[2].Value), Convert.ToInt32(item.Cells[3].Value), Convert.ToInt32(item.Cells[4].Value), item.Cells[5].Value.ToString() , Convert.ToDouble(item.Cells[6].Value) );

                retorno.Add(cabina);
            }
            return retorno;
        }

        private bool esTodoElMismoViaje() {
           
            DataGridViewSelectedRowCollection Seleccionados = tabla.SelectedRows;
            bool resultado = true;
            int viaj_id = Convert.ToInt32(Seleccionados[0].Cells[0].Value);
            
            foreach (DataGridViewRow item in Seleccionados)
            {
                if (viaj_id != Convert.ToInt32(item.Cells[0].Value)) {
                    resultado = false; 
                }

            }
            return resultado;
        }

        private void btnCompra_Click(object sender, EventArgs e)
        {
            if (this.TablaActivada)
            {
                if (esTodoElMismoViaje())
                {
                    if (tabla.CurrentRow.Selected)
                    {
                        CompraPasaje cp = new CompraPasaje(generarDatosPasaje(), Convert.ToInt32(tabla.SelectedRows[0].Cells[0].Value),listPuertos[comboBoxPO.SelectedIndex],listPuertos[comboBoxPD.SelectedIndex],this);
                        cp.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("Seleccione una fila");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione solo un viaje");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un viaje");
            }
        }

        private void seleccionarFecha_Click(object sender, EventArgs e)
        {
            textBoxFS.Text = (dateTimePicker.Value).ToString("yyyy-MM-dd");
        }

        private void btnReserva_Click(object sender, EventArgs e)
        {
            if (this.TablaActivada)
            {

                if (tabla.CurrentRow.Selected)
                {
                    ReservaPasaje cp = new ReservaPasaje(generarDatosPasaje(), Convert.ToInt32(tabla.SelectedRows[0].Cells[0].Value),listPuertos[comboBoxPO.SelectedIndex],listPuertos[comboBoxPD.SelectedIndex],this);
                    cp.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Seleccione una fila");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un viaje");
            }


        }

        private void SeleccionarPasaje_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Dispose();
            padre.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.SeleccionarPasaje_FormClosed(sender, new FormClosedEventArgs(CloseReason.UserClosing));
      
        }


    }

    public class Cabina
    {
        int id;

        int nro;

        int piso;

        string tipo;

        double recargo;

        public int ID { get { return id; } set { id = value; } }

        public int Nro { get { return nro; } set { nro = value; } }

        public int Piso { get { return piso; } set { piso = value; } }

        public String Tipo { get { return tipo; } set { tipo = value; } }

        public double Recargo { get { return recargo; } set { recargo = value; } }

        public Cabina(int _id, int _nro, int _piso, String _tipo, double _recargo)
        {
            id = _id;
            nro = _nro;
            piso = _piso;
            tipo = _tipo;
            recargo = _recargo;
        }
    }

}
