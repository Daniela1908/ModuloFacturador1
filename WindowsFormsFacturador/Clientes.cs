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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            GestionCliente gestionCliente = new GestionCliente();
            gestionCliente.ShowDialog();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            LlenarGridClientes();
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dataGridView = sender as DataGridView;

                if (dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 6)
                    {
                        // EDITAR
                        string documento = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();

                        GestionCliente gestionCliente = new GestionCliente(documento);
                        gestionCliente.ShowDialog();
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
