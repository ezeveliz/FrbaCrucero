using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.AbmRecorrido
{
    public partial class AltaRecorrido : Frame
    {
        private AbmRecorrido padre;
        public AltaRecorrido(AbmRecorrido _padre)
        {
            InitializeComponent();
            padre = _padre;
        }

        private void btnSelectInicio_Click(object sender, EventArgs e)
        {
            string elOtroCampo = buscarElOtroCampo(txtDestino);
            new ListadoPuertos(this, elOtroCampo).ShowDialog();
        }

        private void btnSelectDestino_Click(object sender, EventArgs e)
        {
            string elOtroCampo = buscarElOtroCampo(txtInicio);
            new ListadoPuertos(this, elOtroCampo).ShowDialog();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.todosLosCamposCompletos(txtPrecio, txtInicio, txtDestino))
            { 

            }
        }

        private string buscarElOtroCampo(TextBox campo)
        {
            string contenido = campo.Text;
            return (string.IsNullOrWhiteSpace(contenido) ? "" : contenido);
        }

        // Valido que los campos esten completos y posean datos validos
        private bool todosLosCamposCompletos(TextBox precio, TextBox inicio, TextBox destino)
        {
            bool correctos = true;
            if (string.IsNullOrWhiteSpace(inicio.Text))
            {
                this.error(inicio, lblError1, "Debe seleccionar un puerto de inicio y un codigo.");
                correctos = false;
            }
            else if (string.IsNullOrWhiteSpace(inicio.Text))
            {
                this.error(inicio, lblError1, "Debe seleccionar un puerto de inicio.");
                correctos = false;
            }
            if (string.IsNullOrWhiteSpace(destino.Text) && !isNumber(precio))
            {
                this.error(destino, lblError2, "Hay un error en el campo de precio y de destino.", true);
                correctos = false;
            }
            else if (string.IsNullOrWhiteSpace(destino.Text) || !isNumber(precio))
            {
                this.error(destino, lblError2, "Hay un error en el campo de precio o de destino.");
                correctos = false;
            }
            return correctos;
        }

        // verifica que sea un nro y que no sea null
        private bool isNumber(TextBox campo)
        {
            float parsedValue;
            string contenido = campo.Text;
            return float.TryParse(contenido, out parsedValue) && !string.IsNullOrWhiteSpace(contenido);
        }

        // Gestiona los errores en los distintos campos
        private void error(TextBox campo, Label label, string mensaje, bool both = false)
        {
            if (both)
            {
                if (campo.Name == "txtinicio")
                {
                    txtCodigo.Clear();
                }
                else
                {
                    txtPrecio.Clear();
                }
            }
        campo.Clear();
        label.Text = mensaje;
        label.Show();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.AltaRecorrido_FormClosed(sender, new FormClosedEventArgs(CloseReason.UserClosing));
        }

        private void AltaRecorrido_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Dispose();
            padre.Show();
        }
    }
}
