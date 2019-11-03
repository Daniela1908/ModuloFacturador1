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
    public partial class GestionProducto : Form
    {
        private string CodigoProducto { get; set; }
        private bool Creacion { get; set; }

        /// <summary>
        /// Constructor para la creación de un nuevo producto
        /// </summary>
        public GestionProducto()
        {
            InitializeComponent();
            this.chkActivo.Visible = false;
            this.lblActivo.Visible = false;
            this.Creacion = true;
        }

        /// <summary>
        /// Constructor para la modificación de un producto existente
        /// </summary>
        /// <param name="codigoProducto">Código del producto a modificar</param>
        public GestionProducto(string codigoProducto)
        {
            InitializeComponent();
            this.CodigoProducto = codigoProducto;
            this.txtCodigoProducto.Enabled = false;
            ConsultarProducto();
            this.Creacion = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                return;
            }

            ProductoEntidad productoEntidad = new ProductoEntidad();
            productoEntidad.CodigoProducto = txtCodigoProducto.Text;
            productoEntidad.Detalle = txtDetalle.Text;
            productoEntidad.Precio = Convert.ToDecimal(txtPrecio.Text);        
            
            try
            {
                ProductoReglaNegocio productoReglaNegocio = new ProductoReglaNegocio();

                if (this.Creacion)
                {
                    productoEntidad.Activo = true;
                    bool resultado = productoReglaNegocio.CrearProducto(productoEntidad);

                    if (resultado)
                    {
                        MessageBox.Show("Producto creado satisfactoriamente");
                        LimpiarDatos();
                    }
                }
                else
                {
                    productoEntidad.Activo = chkActivo.Checked;
                    bool resultado = productoReglaNegocio.ModificarProducto(productoEntidad);

                    if (resultado)
                    {
                        MessageBox.Show("Producto modificado satisfactoriamente");
                        LimpiarDatos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha generado un error, detalle: " + ex.Message);
            }
        }

        private void LimpiarDatos() {
            txtCodigoProducto.Text = string.Empty;
            txtDetalle.Text = string.Empty;            
            txtPrecio.Text = string.Empty;
        }

        /// <summary>
        /// Metodo para validar que se diligencien todos los campos
        /// </summary>
        /// <returns></returns>
        private bool ValidarDatos() {

            if (string.IsNullOrWhiteSpace(txtCodigoProducto.Text))
            {
                MessageBox.Show("Favor diligenciar el Codigo del producto.");
                txtCodigoProducto.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDetalle.Text))
            {
                MessageBox.Show("Favor diligenciar el Detalle");
                txtDetalle.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("Favor didligenciar el Precio.");
                txtPrecio.Focus();
                return false;
            }

            decimal valorDecimal;

            if (!decimal.TryParse(txtPrecio.Text, out valorDecimal))
            {
                MessageBox.Show("El Precio debe ser un número decimal.");
                txtPrecio.Focus();
                return false;
            }

            if (valorDecimal<=0)
            {
                MessageBox.Show("El precio debe ser mayor que 0.");
                txtPrecio.Focus();
                return false;
            }

            return true;
        }

        public void ConsultarProducto() {

            ProductoReglaNegocio productoReglaNegocio = new ProductoReglaNegocio();
            ProductoEntidad productoConsultado = productoReglaNegocio.ObtenerProductoPorCodigo(CodigoProducto);

            if (productoConsultado==null)
            {
                MessageBox.Show("El producto no existe.");
                return;
            }

            txtCodigoProducto.Text = productoConsultado.CodigoProducto;
            txtDetalle.Text = productoConsultado.Detalle;           
            txtPrecio.Text = productoConsultado.Precio.ToString();
            chkActivo.Checked = productoConsultado.Activo;
        }
    }
}
