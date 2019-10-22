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
            List<ProductoEntidad> listaProductos = productoReglaNegocio.ObtenerProducto();

            BindingSource bindingSource = new BindingSource(listaProductos, "");

            dgvProductos.DataSource = bindingSource;

            DataGridViewButtonColumn dataGridViewButtonColumn = new DataGridViewButtonColumn();
            dataGridViewButtonColumn.Text = "Editar";            
            dgvProductos.Columns.Add(dataGridViewButtonColumn);
        }
    }
}
