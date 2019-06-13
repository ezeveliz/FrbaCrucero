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
    public partial class ModificacionRecorrido : Frame
    {
        private AbmRecorrido padre;

        public ModificacionRecorrido(AbmRecorrido _padre)
        {
            InitializeComponent();
            padre = _padre;
        }
    }
}
