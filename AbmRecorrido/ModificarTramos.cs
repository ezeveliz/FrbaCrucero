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
    public partial class ModificarTramos : Frame
    {
        private ModificacionRecorrido padre;
        private Recorrido recorrido;
        private List<Tramo> tramos;

        public ModificarTramos(ModificacionRecorrido _padre, Recorrido _recorrido)
        {
            InitializeComponent();
            padre = _padre;
            recorrido = _recorrido;
            tramos = recorrido.Tramos;
            Titulo.Text = "Modificar tramos de: " + recorrido.Id;
            foreach (Tramo t in tramos)
            {
                agregarAlDataGrid(t);
            }
            recalcularTotal();
        }

        //--Agrego un tramo al recorrido que aun no ha sido persistido
        public void addNonPersistedTramo(Tramo tramo)
        {
            addId(tramo);
            tramos.Add(tramo);
            agregarAlDataGrid(tramo);
            recalcularTotal();
        }

        //--Agrego un tramo al recorrido que ya habia sido persistido con anterioridad
        public void addPersistedTramo(Tramo tramo)
        {
            tramos.Add(tramo);
            agregarAlDataGrid(tramo);
            recalcularTotal();
        }

        //--Agrego una id temporal a los tramos sin persistir para poder referenciarlos desde el dataGridView
        private void addId(Tramo tramo)
        {
            if (tramos.Count() > 0)
            {
                int max = tramos.Max(t => t.Id);
                tramo.Id = max + 1;
            }
            else
            {
                tramo.Id = 1;
            }

        }

        //--Sumo todos los precios de todos los tramos
        private void recalcularTotal()
        {
            int total = tramos.Sum(t => t.Precio);
            lblPrecio.Text = "Precio total: " + total.ToString();
        }

        //--Cargo los tramos en el dataGridView
        private void agregarAlDataGrid(Tramo tramo)
        {
            Puerto puertoInicio = tramo.PuertoInicio;
            Puerto puertoDestino = tramo.PuertoDestino;
            int precio = tramo.Precio;
            DGVTramos.Rows.Add(puertoInicio.Nombre, puertoDestino.Nombre, precio, tramo.Id, "Quitar");
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            new AltaTramo(this).ShowDialog();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            new SeleccionarTramo(this).ShowDialog();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.ModificarTramos_FormClosed(sender, new FormClosedEventArgs(CloseReason.UserClosing));
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void ModificarTramos_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Dispose();
        }

        private void DGVTramos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                int idTramo = Int32.Parse(this.DGVTramos[3, e.RowIndex].Value.ToString());
                tramos = tramos.Where(t => t.Id != idTramo).ToList();

                this.DGVTramos.Rows.RemoveAt(e.RowIndex);
                recalcularTotal();
            }
        }


    }
}
