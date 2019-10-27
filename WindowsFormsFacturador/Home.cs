using Entidades;
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
    public partial class FormHome : Form
    {
        private LoginEntidad usuarioLogueado { get; set; }

        public FormHome(LoginEntidad usuarioLogueado)
        {
            InitializeComponent();
            this.usuarioLogueado = usuarioLogueado;

            lblBienvenido.Text += usuarioLogueado.Nombre + "!";
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            Productos productos = new Productos();
            productos.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Clientes clientes = new Clientes();
            clientes.Show();
        }
    }
}
