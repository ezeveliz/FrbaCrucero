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
    public partial class Frame : Form
    {
        public Frame()
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
                        errorProvider.SetError(listBox, "Debe seleccionar al menos una opción");
                    }
                }
            }
            if (!camposTodosCompletos)
                SystemSounds.Beep.Play();
            return camposTodosCompletos;
        }

        public static void ventanaInformarErrorDatabase(Exception ex)
        {
            SystemSounds.Hand.Play();
            MessageBox.Show("Error en la base de datos:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ventanaInformarExito(string mensaje)
        {
            SystemSounds.Exclamation.Play();
            MessageBox.Show("Exito: " + mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ventanaInformarError(string mensaje)
        {
            SystemSounds.Hand.Play();
            MessageBox.Show("Error: " + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
