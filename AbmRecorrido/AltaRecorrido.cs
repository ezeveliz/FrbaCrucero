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
    public partial class AltaRecorrido : Frame
    {
        private AbmRecorrido padre;
        private List<Tramo> tramos = new List<Tramo>();

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

        public AltaRecorrido(AbmRecorrido _padre)
        {
            InitializeComponent();
            padre = _padre;
        }

        private void AltaRecorrido_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Dispose();
            padre.Show();
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
            this.AltaRecorrido_FormClosed(sender, new FormClosedEventArgs(CloseReason.UserClosing));
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiar();
        }

        //--Limpio la vista
        private void limpiar()
        {
            lblPrecio.Text = "Precio total:";
            lblError.Hide();
            DGVTramos.Rows.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (noHayErrores())
            {
                this.limpiar();
                tramos.ForEach(t => 
                {
                    if (!t.Persisted)
                    {
                        int id = Database.persistirTramo(t);
                        t.Id = id;
                    }
                });
                int idRecorrido = Database.persistirRecorrido();
                Database.persistirRecorridoTramo(idRecorrido, tramos);
                limpiar();
                ventanaInformarExito("Su recorrido ha sido cargado.");
            }
            else
            {
                lblError.Text = "Su recorrido debe poseer minimamente un tramo.";
                lblError.Show();
            }
        }

        

        //--Verifica que se haya agregado 1 tramo minimamente
        private bool noHayErrores()
        {
            return DGVTramos.Rows.Count > 1;
        }

        //--Remuevo un tramo previamente agregado al DGV
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
