using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using FrbaCrucero.Clases;

namespace FrbaCrucero.AbmRecorrido
{
    public partial class SeleccionarTramo : Frame
    {
        private AltaRecorrido padre;
        private ModificarTramos padreMT;

        public SeleccionarTramo(AltaRecorrido _padre)
        {
            InitializeComponent();
            padre = _padre;
        }

        public SeleccionarTramo(ModificarTramos _padre)
        {
            InitializeComponent();
            padreMT = _padre;
        }

        private void DGVTramos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                int tramo_id = Int32.Parse(this.DGVTramos[0, e.RowIndex].Value.ToString());
                int puerto_id_inicio = Int32.Parse(this.DGVTramos[1, e.RowIndex].Value.ToString());
                string puerto_inicio = this.DGVTramos[2, e.RowIndex].Value.ToString();
                int puerto_id_destino = Int32.Parse(this.DGVTramos[3, e.RowIndex].Value.ToString());
                string puerto_destino = this.DGVTramos[4, e.RowIndex].Value.ToString();
                int precio = Int32.Parse(this.DGVTramos[5, e.RowIndex].Value.ToString());

                Puerto puertoInicio = new Puerto(puerto_id_inicio, puerto_inicio);
                Puerto puertoDestino = new Puerto(puerto_id_destino, puerto_destino);
                Tramo tramo = new Tramo(puertoInicio, puertoDestino, precio, true, tramo_id);

                if (padre != null)
                {
                    padre.addPersistedTramo(tramo);
                }
                else
                {
                    padreMT.addPersistedTramo(tramo);
                }

                this.DGVTramos.Rows.RemoveAt(e.RowIndex);
                ventanaInformarExito("Tramo agregado a su recorrido.");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (noHayErrores())
            {
                lblError.Hide();
                DGVTramos.Rows.Clear();
                SqlCommand query = createQuery();
                DataTable tabla = Database.getQueryTable(query);
                agregarCamposAlDGV(tabla);
            }
            else
            {
                lblError.Text = "Debe completar alguno de los tres campos.";
                lblError.Show();
            }
        }

        private void agregarCamposAlDGV(DataTable tabla)
        {
            foreach (DataRow fila in tabla.Rows)
            {
                DGVTramos.Rows.Add(fila[0], fila[1], fila[2], fila[3], fila[4], fila[5], "Seleccionar");    
            }
        }

        private SqlCommand createQuery()
        {
            string selectFrom = "SELECT tram_id, puer_id_inicio, P1.puer_ciudad AS Inicio, puer_id_fin, P2.puer_ciudad as Destino, tram_precio " +
                                "FROM [GD1C2019].[CONCORDIA].[tramo] AS T " +
                                    "JOIN [GD1C2019].[CONCORDIA].[puerto] AS P1 " +
                                        "ON T.puer_id_inicio = P1.puer_id " +
                                    "JOIN [GD1C2019].[CONCORDIA].[puerto] AS P2 " +
                                        "ON T.puer_id_fin = P2.puer_id " +
                                "WHERE ";
            if (!string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                selectFrom += "T.tram_precio = @precio ";

                if (!string.IsNullOrWhiteSpace(txtInicio.Text) && !string.IsNullOrWhiteSpace(txtDestino.Text))
                {
                    selectFrom += "AND (P1.puer_ciudad LIKE @inicio AND P2.puer_ciudad LIKE @destino)";
                }
                else if (!string.IsNullOrWhiteSpace(txtInicio.Text))
                {
                    selectFrom += "AND P1.puer_ciudad LIKE @inicio";
                }
                else if (!string.IsNullOrWhiteSpace(txtDestino.Text))
                {
                    selectFrom += "AND P2.puer_ciudad LIKE @destino";
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(txtInicio.Text) && !string.IsNullOrWhiteSpace(txtDestino.Text))
                {
                    selectFrom += "P1.puer_ciudad LIKE @inicio AND P2.puer_ciudad LIKE @destino";
                }
                else if (!string.IsNullOrWhiteSpace(txtInicio.Text))
                {
                    selectFrom += "P1.puer_ciudad LIKE @inicio";
                }
                else if (!string.IsNullOrWhiteSpace(txtDestino.Text))
                {
                    selectFrom += "P2.puer_ciudad LIKE @destino";
                }
            }

            SqlCommand query = Database.createQuery(selectFrom);
            if (!string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                query.Parameters.AddWithValue("@precio", txtPrecio.Text);
            }
            if (!string.IsNullOrWhiteSpace(txtInicio.Text))
            {
                string _inicio = "%" + txtInicio.Text + "%";
                query.Parameters.AddWithValue("@inicio", _inicio);
            }
            if (!string.IsNullOrWhiteSpace(txtDestino.Text))
            {
                string _destino = "%" + txtInicio.Text + "%";
                query.Parameters.AddWithValue("@destino", _destino);
            }
            return query;
        }

        private bool noHayErrores()
        {
            bool hayInicio = !string.IsNullOrWhiteSpace(txtInicio.Text);
            bool hayDestino = !string.IsNullOrWhiteSpace(txtDestino.Text);
            bool hayPrecio = !string.IsNullOrWhiteSpace(txtPrecio.Text);
            return hayInicio || hayDestino || hayPrecio;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.SeleccionarTramo_FormClosed(sender, new FormClosedEventArgs(CloseReason.UserClosing));
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDestino.Text = "";
            txtInicio.Text = "";
            txtPrecio.Text = "";
            lblError.Hide();
            DGVTramos.Rows.Clear();
        }

        private void SeleccionarTramo_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Dispose();
        }
    }
}
