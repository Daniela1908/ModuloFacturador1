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
        public List<ClienteEntidad> ObtenerClientes()
        {

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

        public bool CrearCliente(ClienteEntidad clienteEntidad)
        {

            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString))
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "CrearCliente";

                SqlParameter sqlParameterDocumento = new SqlParameter("@Documento", SqlDbType.VarChar);
                SqlParameter sqlParameterNombre = new SqlParameter("@Nombre", SqlDbType.VarChar);
                SqlParameter sqlParameterDireccion = new SqlParameter("@Direccion", SqlDbType.VarChar);
                SqlParameter sqlParameterTelefono = new SqlParameter("@Telefono", SqlDbType.VarChar);
                SqlParameter sqlParameterCorreo = new SqlParameter("@Correo", SqlDbType.VarChar);
                SqlParameter sqlParameterActivo = new SqlParameter("@Activo", SqlDbType.Bit);

                sqlParameterDocumento.Value = clienteEntidad.Documento;
                sqlParameterNombre.Value = clienteEntidad.Nombre;
                sqlParameterDireccion.Value = clienteEntidad.Direccion;
                sqlParameterTelefono.Value = clienteEntidad.Telefono;
                sqlParameterCorreo.Value = clienteEntidad.Correo;
                sqlParameterActivo.Value = clienteEntidad.Activo;

                comando.Parameters.Add(sqlParameterDocumento);
                comando.Parameters.Add(sqlParameterNombre);
                comando.Parameters.Add(sqlParameterDireccion);
                comando.Parameters.Add(sqlParameterTelefono);
                comando.Parameters.Add(sqlParameterCorreo);
                comando.Parameters.Add(sqlParameterActivo);

                conexion.Open();

                int resultado = comando.ExecuteNonQuery();

                if (resultado.Equals(1))
                {
                    return true;
                }
            }

            return false;
        }

        public ClienteEntidad ObtenerCliente(string documento) {

            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString))
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "ObtenerClientePorDocumento";

                SqlParameter sqlParameterDocumento = new SqlParameter("@Documento", SqlDbType.VarChar);

                sqlParameterDocumento.Value = documento;

                comando.Parameters.Add(sqlParameterDocumento);

                conexion.Open();

                SqlDataReader sqlDataReader = comando.ExecuteReader();

                sqlDataReader.Read();

                if (sqlDataReader.HasRows)
                {
                    ClienteEntidad clienteConsultado = new ClienteEntidad();
                    clienteConsultado.Documento = sqlDataReader["Documento"].ToString();
                    clienteConsultado.Nombre = sqlDataReader["Nombre"].ToString();
                    clienteConsultado.Direccion = sqlDataReader["Direccion"].ToString();
                    clienteConsultado.Telefono = sqlDataReader["Telefono"].ToString();
                    clienteConsultado.Correo = sqlDataReader["Correo"].ToString();
                    clienteConsultado.Activo = Convert.ToBoolean(sqlDataReader["Activo"]);

                    return clienteConsultado;
                }

                return null;
            }
        }

        public bool ModificarCliente(ClienteEntidad clienteEntidad)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString))
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "ModificarCliente";

                SqlParameter sqlParameterDocumento = new SqlParameter("@Documento", SqlDbType.VarChar);
                SqlParameter sqlParameterNombre = new SqlParameter("@Nombre", SqlDbType.VarChar);
                SqlParameter sqlParameterDireccion = new SqlParameter("@Direccion", SqlDbType.VarChar);
                SqlParameter sqlParameterTelefono = new SqlParameter("@Telefono", SqlDbType.VarChar);
                SqlParameter sqlParameterCorreo = new SqlParameter("@Correo", SqlDbType.VarChar);
                SqlParameter sqlParameterActivo = new SqlParameter("@Activo", SqlDbType.Bit);

                sqlParameterDocumento.Value = clienteEntidad.Documento;
                sqlParameterNombre.Value = clienteEntidad.Nombre;
                sqlParameterDireccion.Value = clienteEntidad.Direccion;
                sqlParameterTelefono.Value = clienteEntidad.Telefono;
                sqlParameterCorreo.Value = clienteEntidad.Correo;
                sqlParameterActivo.Value = clienteEntidad.Activo;

                comando.Parameters.Add(sqlParameterDocumento);
                comando.Parameters.Add(sqlParameterNombre);
                comando.Parameters.Add(sqlParameterDireccion);
                comando.Parameters.Add(sqlParameterTelefono);
                comando.Parameters.Add(sqlParameterCorreo);
                comando.Parameters.Add(sqlParameterActivo);

                conexion.Open();

                int resultado = comando.ExecuteNonQuery();

                if (resultado.Equals(1))
                {
                    return true;
                }
            }

            return false;
        }
    }  
}

