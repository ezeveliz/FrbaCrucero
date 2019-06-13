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
