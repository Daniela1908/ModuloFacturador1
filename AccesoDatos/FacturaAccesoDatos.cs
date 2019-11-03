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
    public class FacturaAccesoDatos
    {
        public void CrearFactura(FacturaEntidad facturaEntidad)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString))
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "CrearFactura";

                SqlParameter sqlParameterCliente = new SqlParameter("@Cliente", SqlDbType.VarChar);
                sqlParameterCliente.Value = facturaEntidad.Cliente.Documento;
                comando.Parameters.Add(sqlParameterCliente);

                SqlParameter sqlParameterUsuario = new SqlParameter("@Usuario", SqlDbType.VarChar);
                sqlParameterUsuario.Value = facturaEntidad.Usuario.Correo;
                comando.Parameters.Add(sqlParameterUsuario);

                conexion.Open();

                SqlDataReader sqlDataReader = comando.ExecuteReader();

                sqlDataReader.Read();

                if (sqlDataReader.HasRows)
                { 
                    facturaEntidad.NumeroFactura= sqlDataReader["Numerofactura"].ToString();
                    facturaEntidad.Fecha= Convert.ToDateTime(sqlDataReader["Fecha"]);
                    facturaEntidad.Estado= (EstadosFactura)Convert.ToInt32(sqlDataReader["Estado"]);
                }                
            }
        }
    }
}
