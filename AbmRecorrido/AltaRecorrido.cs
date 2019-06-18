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
                        int id = persistirTramo(t);
                        t.Id = id;
                    }
                });
                int idRecorrido = persistirRecorrido();
                persistirRecorridoTramo(idRecorrido);
                limpiar();
                ventanaInformarExito("Su recorrido ha sido cargado.");
            }
            else
            {
                lblError.Text = "Su recorrido debe poseer minimamente un tramo.";
                lblError.Show();
            }
        }

        //--Persisto la relacion recorrido_tramo
        private void persistirRecorridoTramo(int idRecorrido)
        {
            tramos.ForEach(t => 
            {
                string queryString = "INSERT [GD1C2019].[CONCORDIA].[recorrido_tramo] (reco_id, tram_id) VALUES(@idRecorrido, @idTramo)";
                SqlCommand query = Database.createQuery(queryString);
                query.Parameters.AddWithValue("@idRecorrido", idRecorrido);
                query.Parameters.AddWithValue("@idTramo", t.Id);
                Database.executeCUDQuery(query);
            });
        }

        //--Persisto el recorrido y retorno su id
        private int persistirRecorrido()
        {
            string queryString = "INSERT [GD1C2019].[CONCORDIA].[recorrido] (reco_inhabilitado) VALUES(@inhabilitado); SELECT SCOPE_IDENTITY();";
            SqlCommand query = Database.createQuery(queryString);
            Database.open();
            int idRecorrido;
            query.CommandType = CommandType.Text;
            {
                query.Parameters.AddWithValue("@inhabilitado", 0);
                //Get the inserted query
                idRecorrido = Convert.ToInt32(query.ExecuteScalar());
            }
            return idRecorrido;
        }

        //--Persisto el tramo y retorno su id
        private int persistirTramo(Tramo t)
        {
            int idPuertoInicio = t.PuertoInicio.Id;
            int idPuertoDestino = t.PuertoDestino.Id;
            int precio = t.Precio;

            int idTramoVerificado = verificarQueNoExistaTramo(idPuertoInicio, idPuertoDestino);

            if (idTramoVerificado == 0)
            {
                string queryString = "INSERT [GD1C2019].[CONCORDIA].[tramo] (tram_precio, puer_id_inicio, puer_id_fin) VALUES(@precio, @inicio, @destino); SELECT SCOPE_IDENTITY();";
                SqlCommand query = Database.createQuery(queryString);
                Database.open();

                query.CommandType = CommandType.Text;
                {
                    query.Parameters.AddWithValue("@precio", precio);
                    query.Parameters.AddWithValue("@inicio", idPuertoInicio);
                    query.Parameters.AddWithValue("@destino", idPuertoDestino);
                    //Get the inserted query
                    return Convert.ToInt32(query.ExecuteScalar());
                }
            }
            return idTramoVerificado;
        }

        //--Devuelvo 0 si el tramo no existe o el id en caso de que si
        private int verificarQueNoExistaTramo(int inicio, int destino)
        {
            string queryString = "SELECT [tram_id] FROM [GD1C2019].[CONCORDIA].[tramo] WHERE puer_id_inicio = @inicio AND puer_id_fin = @destino";
            SqlCommand query = Database.createQuery(queryString);
            query.Parameters.AddWithValue("@inicio", inicio);
            query.Parameters.AddWithValue("@destino", destino);
            string idTramo = Database.consultaObtenerValor(query);

            return (idTramo == "" ? 0 : Int32.Parse(idTramo));
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
