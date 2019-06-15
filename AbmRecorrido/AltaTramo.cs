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
    public partial class AltaTramo : Frame
    {
        private AltaRecorrido padre;
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

        public AltaTramo(AltaRecorrido _padre)
        {
            InitializeComponent();
            padre = _padre;
        }

        private void btnSelectInicio_Click(object sender, EventArgs e)
        {
            string elOtroCampo = buscarElOtroCampo(txtDestino);
            new ListadoPuertos(this, elOtroCampo, true).ShowDialog();
        }

        private void btnSelectDestino_Click(object sender, EventArgs e)
        {
            string elOtroCampo = buscarElOtroCampo(txtInicio);
            new ListadoPuertos(this, elOtroCampo, false).ShowDialog();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.todosLosCamposCompletos(txtPrecio))
            {
                Tramo tramo = new Tramo(puertoInicio, puertoDestino, Int32.Parse(txtPrecio.Text), false, 0);
                padre.addNonPersistedTramo(tramo);
                limpiarAltaTramo();
                ventanaInformarExito("El tramo ha sido agregado a su recorrido.");
            }
        }

        private void limpiarAltaTramo()
        {
            puertoInicio = null;
            txtInicio.Text = "";
            puertoDestino = null;
            txtDestino.Text = "";
            txtPrecio.Text = "";
            lblError1.Hide();
            lblError2.Hide();
        }

        private string buscarElOtroCampo(TextBox campo)
        {
            string contenido = campo.Text;
            return (string.IsNullOrWhiteSpace(contenido) ? "" : contenido);
        }

        // Valido que los campos esten completos y posean datos validos
        private bool todosLosCamposCompletos(TextBox precio)
        {
            bool correctos = true;
            if (puertoInicio == null && puertoDestino == null)
            {
                this.error(txtInicio, lblError1, "Debe seleccionar ambos puertos.");
                correctos = false;
            }
            else if (puertoInicio == null || puertoDestino == null)
            {
                if (puertoInicio == null)
                {
                    this.error(txtInicio, lblError1, "Debe seleccionar un puerto de inicio.");
                    correctos = false;
                }
                else
                {
                    this.error(txtDestino, lblError1, "Debe seleccionar un puerto de destino.");
                    correctos = false;
                }
            }

            if (!isNumber(precio))
            {
                this.error(precio, lblError2, "Debe completar el precio con un valor valido.");
                correctos = false;
            }
            return correctos;
        }

        // verifica que sea un nro y que no sea null
        private bool isNumber(TextBox campo)
        {
            float parsedValue;
            string contenido = campo.Text;
            return float.TryParse(contenido, out parsedValue) && parsedValue > 0 ;
        }

        // Gestiona los errores en los distintos campos
        private void error(TextBox campo, Label label, string mensaje, bool both = false)
        {
            if (both)
            {
                txtDestino.Clear();
            }
            campo.Clear();
            label.Text = mensaje;
            label.Show();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.AltaTramo_FormClosed(sender, new FormClosedEventArgs(CloseReason.UserClosing));
        }

        private void AltaTramo_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Dispose();
            padre.Show();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarAltaTramo();
        }
    }
}
