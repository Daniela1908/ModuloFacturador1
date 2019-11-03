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
    public partial class Factura : Form
    {
        private LoginEntidad usuarioLogueado;

        public Factura(LoginEntidad loginEntidad)
        {
            InitializeComponent();
            this.usuarioLogueado = loginEntidad;
            this.LlenarComboClientes();
            this.cbCliente.SelectedIndex = -1;
        }

        private void mNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();     
            txtUsuario.Text = this.usuarioLogueado.Nombre;
            cbCliente.Enabled = true;
        }

        private void LimpiarCampos()
        {
            txtNumeroFactura.Text = string.Empty;            
            txtEstado.Text = string.Empty;
            txtUsuario.Text = string.Empty;
            txtFecha.Text = string.Empty;
            txtValorTotal.Text = string.Empty;
            cbCliente.SelectedIndex = -1;
        }

        private void LlenarComboClientes()
        {
            ClienteReglaNegocio clienteReglaNegocio = new ClienteReglaNegocio();
            List<ClienteEntidad> clientesActivos = clienteReglaNegocio.ObtenerClientesActivos();

            cbCliente.DataSource = clientesActivos;
            cbCliente.DisplayMember = "Nombre";
            cbCliente.ValueMember = "Documento";


        }

        private void mGuardar_Click(object sender, EventArgs e)
        {
            if (cbCliente.SelectedIndex.Equals(-1))
            {
                MessageBox.Show("Debe seleccionar un cliente");
                return;
            }

            ClienteEntidad clienteEntidad = new ClienteEntidad();
            clienteEntidad.Documento = cbCliente.SelectedValue.ToString();
            clienteEntidad.Nombre = cbCliente.SelectedText;

            FacturaEntidad facturaEntidad = new FacturaEntidad();
            facturaEntidad.Cliente = clienteEntidad;
            facturaEntidad.Usuario = this.usuarioLogueado;

            FacturaReglaNegocio facturaReglaNegocio = new FacturaReglaNegocio();
            facturaReglaNegocio.CrearFactura(facturaEntidad);

            if (string.IsNullOrWhiteSpace(facturaEntidad.NumeroFactura))
            {
                MessageBox.Show("No fue posible crear la factura.");
                return;
            }

            txtNumeroFactura.Text = facturaEntidad.NumeroFactura;
            txtEstado.Text = facturaEntidad.Estado.ToString();
            txtFecha.Text = facturaEntidad.Fecha.ToString();      

        }
    }
}
