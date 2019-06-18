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

namespace FrbaCrucero.AbmRecorrido
{
    public partial class BajaRecorrido : Frame
    {
        private AbmRecorrido padre;
        private Puerto puertoInicio;
        private Puerto puertoDestino;

        public Puerto PuertoInicio 
        { 
            set 
            { 
                puertoInicio = value;
                txtInicio.Text = puertoInicio.Nombre; 
            } 
        }
        public Puerto PuertoDestino 
        { 
            set 
            { 
                puertoDestino = value;
                txtDestino.Text = puertoDestino.Nombre;
            } 
        }

        public BajaRecorrido(AbmRecorrido _padre)
        {
            InitializeComponent();
            padre = _padre;
        }

        private void btnSeleccionarI_Click(object sender, EventArgs e)
        {
            string elOtroCampo = buscarElOtroCampo(txtDestino);
            new ListadoPuertos(this, elOtroCampo, true).ShowDialog();
        }

        private void btnSeleccionarD_Click(object sender, EventArgs e)
        {
            string elOtroCampo = buscarElOtroCampo(txtInicio);
            new ListadoPuertos(this, elOtroCampo, false).ShowDialog();
        }

        private string buscarElOtroCampo(TextBox campo)
        {
            string contenido = campo.Text;
            return (string.IsNullOrWhiteSpace(contenido) ? "" : contenido);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (noHayErrores())
            {
                SqlCommand query = createQuery();
            }
            else 
            {
                mostrarError("Debe seleccionar una ciudad como minimo");
            }
        }

        private SqlCommand createQuery()
        {
            string queryString = "SELECT * " +
                                "FROM [GD1C2019].[CONCORDIA].[recorrido] " +
                                "WHERE reco_id = (SELECT reco_id " +
                                                    "FROM [GD1C2019].[CONCORDIA].[recorrido_tramo] " +
                                                    "WHERE tram_id = (SELECT tram_id " +
                                                                    "FROM [GD1C2019].[CONCORDIA].[tramo]";
            if(puertoInicio != null && puertoDestino != null)
            {
                queryString += "WHERE puer_id_inicio = @inicio AND puer_id_fin = @destino))";
            }
            else if (puertoInicio != null)
            {
                queryString += "WHERE puer_id_inicio = @inicio))";
            }
            else
            {
                queryString += "WHERE puer_id_fin = @destino))";
            }

            SqlCommand query = Database.createQuery(queryString);

            if (puertoInicio != null && puertoDestino != null)
            {
                query.Parameters.AddWithValue("@inicio", puertoInicio.Id);
                query.Parameters.AddWithValue("@destino", puertoDestino.Id);
            }
            else if (puertoInicio != null)
            {
                query.Parameters.AddWithValue("@inicio", puertoInicio.Id);
            }
            else
            {
                query.Parameters.AddWithValue("@destino", puertoDestino.Id);
            }

            return query;

        }

        private void mostrarError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.Show();
        }

        private bool noHayErrores()
        {
            return puertoInicio != null || puertoDestino != null;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.BajaRecorrido_FormClosed(sender, new FormClosedEventArgs(CloseReason.UserClosing));
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            puertoInicio = null;
            txtInicio.Text = "";
            puertoDestino = null;
            txtDestino.Text = "";
            lblError.Hide();
            DGVTramos.Rows.Clear();
        }

        private void BajaRecorrido_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            this.Hide();
            this.Dispose();
            padre.Show();
        }

        private void DGVTramos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
