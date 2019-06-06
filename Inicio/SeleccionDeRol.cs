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

namespace FrbaCrucero.Inicio
{
    public partial class SeleccionDeRol : Frame
    {
        private Sesion sesion;

        public Sesion Sesion { get { return sesion; } set { sesion = value; } }

        public SeleccionDeRol(Sesion session)
        {
            InitializeComponent();
            Sesion = session;
        }
    }
}
