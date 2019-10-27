using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class ClienteAccesoDatos
    {
        public List<ClienteEntidad> ObtenerClientes() {

            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString))
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "ObtenerClientes";

                conexion.Open();

                SqlDataReader sqlDataReader = comando.ExecuteReader();

                List<ClienteEntidad> listaClientes = new List<ClienteEntidad>();

                while (sqlDataReader.Read())
                {
                    ClienteEntidad cliente = new ClienteEntidad();
                    cliente.Documento = sqlDataReader["Documento"].ToString();
                    cliente.Nombre = sqlDataReader["Nombre"].ToString();
                    cliente.Direccion = sqlDataReader["Direccion"].ToString();
                    cliente.Telefono = sqlDataReader["Telefono"].ToString();
                    cliente.Correo = sqlDataReader["Correo"].ToString();
                    cliente.Activo = Convert.ToBoolean(sqlDataReader["Activo"]);

                    listaClientes.Add(cliente);
                }

                return listaClientes;
            }

        }
    }
}
