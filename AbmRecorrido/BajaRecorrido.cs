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

            }
            else 
            {
                mostrarError("Debe seleccionar una ciudad como minimo");
            }
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
