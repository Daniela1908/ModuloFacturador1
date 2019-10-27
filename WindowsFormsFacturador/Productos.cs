using Entidades;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsFacturador
{
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
            this.LlenarGridProductos();
        }

        private void LlenarGridProductos() {

            ProductoReglaNegocio productoReglaNegocio = new ProductoReglaNegocio();
            List<ProductoEntidad> listaProductos = productoReglaNegocio.ObtenerProductos();

            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.DataSource = listaProductos;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            GestionProducto gestionProducto = new GestionProducto();
            gestionProducto.ShowDialog();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            LlenarGridProductos();
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dataGridView = sender as DataGridView;

                if (dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 5)
                    {
                        // EDITAR
                        string codigoProducto = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();

                        GestionProducto gestionProducto = new GestionProducto(codigoProducto);
                        gestionProducto.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
