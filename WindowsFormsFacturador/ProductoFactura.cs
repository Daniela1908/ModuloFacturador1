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
    public partial class ProductoFactura : Form
    {
        private List<ProductoEntidad> productosActivos;
        int numeroFactura;

        public ProductoFactura(int numeroFactura)
        {
            InitializeComponent();
            LlenarComboProductos();
            this.numeroFactura = numeroFactura;
        }

        private void LlenarComboProductos()
        {
            ProductoReglaNegocio productoReglaNegocio = new ProductoReglaNegocio();
            productosActivos = productoReglaNegocio.ObtenerProductosActivos();

            cbProducto.DataSource = productosActivos;
            cbProducto.DisplayMember = "Detalle";
            cbProducto.ValueMember = "CodigoProducto";
            cbProducto.SelectedIndex = -1;            
        }

        private void cbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductoEntidad productoEntidad = (ProductoEntidad)cbProducto.SelectedItem;

            if (productoEntidad==null)
            {
                txtPrecio.Text = string.Empty;
                return;
            }
            txtPrecio.Text = productoEntidad.Precio.ToString();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                txtTotal.Text = string.Empty;
                return;
            }

            int valorCantidad;
            if (!int.TryParse(txtCantidad.Text, out valorCantidad))
            {
                MessageBox.Show("La cantidad debe ser un número entero");
                return;
            }

            decimal precio= Convert.ToDecimal(txtPrecio.Text);

            txtTotal.Text = (precio * valorCantidad).ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cbProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un producto");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Porfavor ingrese la cantidad");
                return;
            }

            ProductoFacturaEntidad productoFacturaEntidad = new ProductoFacturaEntidad();
            productoFacturaEntidad.Cantidad = Convert.ToInt32(txtCantidad.Text);
            productoFacturaEntidad.Valor = Convert.ToDecimal(txtTotal.Text);
            productoFacturaEntidad.Producto = new ProductoEntidad
            {
                CodigoProducto = cbProducto.SelectedValue.ToString()
            };
            productoFacturaEntidad.Factura = new FacturaEntidad
            {
                NumeroFactura = this.numeroFactura.ToString()
            };

            DetalleFacturaReglaNegocio detalleFacturaReglaNegocio = new DetalleFacturaReglaNegocio();

            if (detalleFacturaReglaNegocio.CrearDetalleFactura(productoFacturaEntidad))
            {
                this.Close();
            }
     
        }
    }
}
