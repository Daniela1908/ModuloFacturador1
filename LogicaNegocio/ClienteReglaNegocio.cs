using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class ClienteReglaNegocio
    {
        public List<ClienteEntidad> ObtenerClientes() {

            ClienteAccesoDatos clienteAccesoDatos = new ClienteAccesoDatos();
            return clienteAccesoDatos.ObtenerClientes();
        }
    }
}
