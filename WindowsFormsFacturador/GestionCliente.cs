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
    public partial class GestionCliente : Form
    {
        public string Documento { get; set; }
        public bool Creacion { get; set; }

        /// <summary>
        /// Constructor para la cración de un nuevo cliente
        /// </summary>
        public GestionCliente()
        {
            InitializeComponent();
            this.chkActivo.Visible = false;
            this.lblActivo.Visible = false;
            this.Creacion = true;
        }

        public GestionCliente(string documento)
        {
            InitializeComponent();
            this.Documento = documento;
            this.txtDocumento.Enabled = false;
            ConsultarCliente();
            this.Creacion = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                return;
            }

            ClienteEntidad clienteEntidad = new ClienteEntidad();
            clienteEntidad.Documento = txtDocumento.Text;
            clienteEntidad.Nombre = txtNombre.Text;
            clienteEntidad.Direccion = txtDireccion.Text;
            clienteEntidad.Telefono = txtTelefono.Text;
            clienteEntidad.Correo = txtCorreo.Text;

            try
            {
                ClienteReglaNegocio clienteReglaNegocio = new ClienteReglaNegocio();

                if (this.Creacion)
                {
                    clienteEntidad.Activo = true;
                    bool resultado = clienteReglaNegocio.CrearCliente(clienteEntidad);

                    if (resultado)
                    {
                        MessageBox.Show("Cliente creado satisfactoriamente");
                        LimpiarDatos(); 
                    }          
                }
                else
                {
                    clienteEntidad.Activo = chkActivo.Checked;
                    bool resultado = clienteReglaNegocio.ModificarCliente(clienteEntidad);

                    if (resultado)
                    {
                        MessageBox.Show("Cliente modificado satisfactoriamente");
                        LimpiarDatos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha generado un error " + ex.Message);
            }
        }

        private void LimpiarDatos() {
            txtDocumento.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtCorreo.Text = string.Empty;
        }

        /// <summary>
        /// Metodo para validar que se diligencien todos los campos
        /// </summary>
        /// <returns></returns>
        private bool ValidarDatos() {
            if (string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                MessageBox.Show("Favor diligenciar el Documento.");
                txtDocumento.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Favor diligenciar el Nombre.");
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Favor diligenciar la Dirección.");
                txtDireccion.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Favor diligenciar el Teléfono.");
                txtTelefono.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Favor diligenciar el Correo.");
                txtCorreo.Focus();
                return false;
            }

            return true;
        }

        public void ConsultarCliente() {

            ClienteReglaNegocio clienteReglaNegocio = new ClienteReglaNegocio();
            ClienteEntidad clienteConsultado = clienteReglaNegocio.ObtenerClientePorDocumento(Documento);

            if (clienteConsultado==null)
            {
                MessageBox.Show("El Cliente no existe.");
                return;
            }

            txtDocumento.Text = clienteConsultado.Documento;
            txtNombre.Text = clienteConsultado.Nombre;
            txtDireccion.Text = clienteConsultado.Direccion;
            txtTelefono.Text = clienteConsultado.Telefono;
            txtCorreo.Text = clienteConsultado.Correo;
            chkActivo.Checked = clienteConsultado.Activo;
        }
    }
}
