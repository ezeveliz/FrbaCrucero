using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Media;

namespace FrbaCrucero
{
    public partial class VentanaBase : Form
    {
        public VentanaBase()
        {
            InitializeComponent();
        }

        public static bool ventanaCamposEstanCompletos(Control ventana, ErrorProvider errorProvider)
        {
            bool camposTodosCompletos = true;
            foreach (Control objeto in ventana.Controls)
            {
                if (objeto is TextBox)
                {
                    TextBox textBox = (TextBox)objeto;
                    if (string.IsNullOrEmpty(textBox.Text.Trim()))
                    {
                        camposTodosCompletos = false;
                        errorProvider.SetError(textBox, "El campo no puede estar vacio");
                    }
                    if (!textBox.ShortcutsEnabled)
                    {
                        Regex expresionParaEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                        if (!expresionParaEmail.IsMatch(textBox.Text))
                        {
                            camposTodosCompletos = false;
                            errorProvider.SetError(textBox, "El formato de E-mail es invalido");
                        }
                    }
                }
                if (objeto is ListBox)
                {
                    ListBox listBox = (ListBox)objeto;
                    if (listBox.Items.Count == 0)
                    {
                        camposTodosCompletos = false;
                        errorProvider.SetError(listBox, "Debe seleccionar al menos una opcion");
                    }
                }
            }
            if (!camposTodosCompletos)
                SystemSounds.Beep.Play();
            return camposTodosCompletos;
        }

    }
}
