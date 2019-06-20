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
    public partial class BajaRecorrido : Frame
    {
        private AbmRecorrido padre;
        private Puerto puertoInicio;
        private Puerto puertoDestino;
        private List<Recorrido> recorridos;

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

        public BajaRecorrido(AbmRecorrido _padre)
        {
            InitializeComponent();
            padre = _padre;
            recorridos = new List<Recorrido>();
        }

        private void btnSeleccionarI_Click(object sender, EventArgs e)
        {
            string elOtroCampo = buscarElOtroCampo(txtDestino);
            new ListadoPuertos(this, elOtroCampo, true).ShowDialog();
        }

        private void btnSeleccionarD_Click(object sender, EventArgs e)
        {
            string elOtroCampo = buscarElOtroCampo(txtInicio);
            new ListadoPuertos(this, elOtroCampo, false).ShowDialog();
        }

        private string buscarElOtroCampo(TextBox campo)
        {
            string contenido = campo.Text;
            return (string.IsNullOrWhiteSpace(contenido) ? "" : contenido);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            recorridos.Clear();
            DGVRecorridos.Rows.Clear();
            lblError.Hide();
            if (noHayErrores())
            {
                SqlCommand query = createQuery();
                DataTable table = Database.getQueryTable(query);
                completarDGV(table);
            }
            else 
            {
                mostrarError("Debe seleccionar una ciudad como minimo");
            }
        }

        private void completarDGV(DataTable table)
        {
            if (table.Rows.Count > 0)
            {
                foreach (DataRow fila in table.Rows)
                {
                    int idRecorrido = Int32.Parse(fila[0].ToString());
                    int inhabilitado = Int32.Parse(fila[2].ToString());
                    DGVRecorridos.Rows.Add(idRecorrido, "Ver", "Quitar");
                    recorridos.Add(new Recorrido(idRecorrido, inhabilitado));
                }
            }
            else
            {
                mostrarError("No hay ningun recorrido como el que busca");
            }
        }

        private SqlCommand createQuery()
        {
            string queryString = "SELECT * " +
                                "FROM [GD1C2019].[CONCORDIA].[recorrido] " +
                                "WHERE reco_inhabilitado = 0 AND " +
                                    "reco_id = (SELECT reco_id " +
                                                    "FROM [GD1C2019].[CONCORDIA].[recorrido_tramo] " +
                                                    "WHERE tram_id = (SELECT tram_id " +
                                                                    "FROM [GD1C2019].[CONCORDIA].[tramo]";
            if(puertoInicio != null && puertoDestino != null)
            {
                queryString += "WHERE puer_id_inicio = @inicio AND puer_id_fin = @destino))";
            }
            else if (puertoInicio != null)
            {
                queryString += "WHERE puer_id_inicio = @inicio))";
            }
            else
            {
                queryString += "WHERE puer_id_fin = @destino))";
            }

            SqlCommand query = Database.createQuery(queryString);

            if (puertoInicio != null && puertoDestino != null)
            {
                query.Parameters.AddWithValue("@inicio", puertoInicio.Id);
                query.Parameters.AddWithValue("@destino", puertoDestino.Id);
            }
            else if (puertoInicio != null)
            {
                query.Parameters.AddWithValue("@inicio", puertoInicio.Id);
            }
            else
            {
                query.Parameters.AddWithValue("@destino", puertoDestino.Id);
            }

            return query;

        }

        private void mostrarError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.Show();
        }

        private bool noHayErrores()
        {
            return puertoInicio != null || puertoDestino != null;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.BajaRecorrido_FormClosed(sender, new FormClosedEventArgs(CloseReason.UserClosing));
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            puertoInicio = null;
            txtInicio.Text = "";
            puertoDestino = null;
            txtDestino.Text = "";
            lblError.Hide();
            recorridos.Clear();
            DGVRecorridos.Rows.Clear();
        }

        private void BajaRecorrido_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            this.Hide();
            this.Dispose();
            padre.Show();
        }

        private void DGVTramos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                int idRecorridoSeleccionado = Int32.Parse(this.DGVRecorridos[0, e.RowIndex].Value.ToString());
                Recorrido recorridoSeleccionado = recorridos.Where(r => r.Id == idRecorridoSeleccionado).First();
                recorridoSeleccionado.getAll();

                if (e.ColumnIndex == 1)//--Ver detalle
                {
                    new DetalleDeRecorrido(this, recorridoSeleccionado).ShowDialog();
                }
                else if (e.ColumnIndex == 2)//--Inhabilitar/Quitar
                {
                    int rows = inhabilitarRecorrido(recorridoSeleccionado);
                    if (rows == 1)
                    {
                        ventanaInformarExito("El recorrido ha sido inhabilitado");
                        DGVRecorridos.Rows.RemoveAt(e.RowIndex);
                    }
                    else
                    {
                        ventanaInformarError("Ha ocurrido un error");
                    }
                }
                
            }
        }

        private int inhabilitarRecorrido(Recorrido recorridoSeleccionado)
        {
            recorridos = recorridos.Where(r => r.Id != recorridoSeleccionado.Id).ToList();
            return Database.actualizarInhabilitacionDeRecorrido(recorridoSeleccionado.Id, 1);
        }
    }
}
