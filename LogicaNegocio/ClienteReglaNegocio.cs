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

        public bool CrearCliente(ClienteEntidad clienteEntidad) {

            ClienteAccesoDatos clienteAccesoDatos = new ClienteAccesoDatos();
            return clienteAccesoDatos.CrearCliente(clienteEntidad);
        }

        public ClienteEntidad ObtenerClientePorDocumento(string documento)
        {
            ClienteAccesoDatos clienteAccesoDatos = new ClienteAccesoDatos();
            return clienteAccesoDatos.ObtenerCliente(documento);
        }

        public bool ModificarCliente(ClienteEntidad clienteEntidad)
        {

            ClienteAccesoDatos clienteAccesoDatos = new ClienteAccesoDatos();
            return clienteAccesoDatos.ModificarCliente(clienteEntidad);
        }

        public List<ClienteEntidad> ObtenerClientesActivos()
        {
            ClienteAccesoDatos clienteAccesoDatos = new ClienteAccesoDatos();
            return clienteAccesoDatos.ObtenerClientesActivos();
            
        }
    }
}
