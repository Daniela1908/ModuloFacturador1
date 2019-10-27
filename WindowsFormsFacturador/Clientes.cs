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
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
            this.LlenarGridClientes();
        }

        private void LlenarGridClientes() {

            ClienteReglaNegocio clientesReglaNegocio = new ClienteReglaNegocio();
            List<ClienteEntidad> listaClientes = clientesReglaNegocio.ObtenerClientes();

            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.DataSource = listaClientes;
        }
    }
}
