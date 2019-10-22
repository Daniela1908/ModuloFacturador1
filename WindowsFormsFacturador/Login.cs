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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Debe ingresar un usuario y contraseña");
                return;
            }

            //Se definen variables locales para el login del ususario
            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;

            //Se declara objeto entidad y se asignan valores requeridos para el logueo
            LoginEntidad loginEntidad = new LoginEntidad();
            loginEntidad.Correo = usuario;
            loginEntidad.Contrasena = password;

            LoginReglaNegocio loginReglaNegocio = new LoginReglaNegocio();
            LoginEntidad loginExitoso = loginReglaNegocio.IniciarSesion(loginEntidad);

            if (loginExitoso == null)
            {
                MessageBox.Show("Usuario y/o contraseña incorrecta");
                return;
            }

            FormHome formHome = new FormHome(loginExitoso);
            formHome.Show();
            this.Hide();
        }
    }
}
