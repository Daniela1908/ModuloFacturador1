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
    public class DetalleFacturaAccesoDatos
    {
        public List<ProductoFacturaEntidad> ObtenerProductosFactura(int numeroFactura)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString))
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "ObtenerProductosFactura";

                SqlParameter sqlParameterNumeroFactura = new SqlParameter("@NumeroFactura", SqlDbType.VarChar);

                sqlParameterNumeroFactura.Value = numeroFactura;

                comando.Parameters.Add(sqlParameterNumeroFactura);

                conexion.Open();

                SqlDataReader sqlDataReader = comando.ExecuteReader();

                List<ProductoFacturaEntidad> productosFactura = new List<ProductoFacturaEntidad>();

                while (sqlDataReader.Read())
                {
                    ProductoFacturaEntidad productoFacturaEntidad = new ProductoFacturaEntidad();
                    productoFacturaEntidad.NumeroDetalle = Convert.ToInt32(sqlDataReader["NumeroDetalle"]);
                    productoFacturaEntidad.Cantidad = Convert.ToInt32(sqlDataReader["Cantidad"]);
                    productoFacturaEntidad.Valor = Convert.ToDecimal(sqlDataReader["Valor"]);
                    productoFacturaEntidad.Producto = new ProductoEntidad {
                        CodigoProducto = sqlDataReader["Codproducto"].ToString(),
                        Detalle = sqlDataReader["Detalle"].ToString()
                    };

                    productoFacturaEntidad.NombreProducto = sqlDataReader["Detalle"].ToString();

                    productosFactura.Add(productoFacturaEntidad);
                }

                return productosFactura;
            }
        }

        public bool CrearDetalleFactura(ProductoFacturaEntidad productoFacturaEntidad)
        {

            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString))
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "CrearDetalleFactura";

                SqlParameter sqlParameterCantidad = new SqlParameter("@Cantidad", SqlDbType.Int);
                SqlParameter sqlParameterValor = new SqlParameter("@Valor", SqlDbType.Decimal);
                SqlParameter sqlParameterCodProducto = new SqlParameter("@CodProducto", SqlDbType.VarChar);
                SqlParameter sqlParameterNumeroFactura = new SqlParameter("@NumeroFactura", SqlDbType.Int);

                sqlParameterCantidad.Value = productoFacturaEntidad.Cantidad;
                sqlParameterValor.Value = productoFacturaEntidad.Valor;
                sqlParameterCodProducto.Value = productoFacturaEntidad.Producto.CodigoProducto;
                sqlParameterNumeroFactura.Value = productoFacturaEntidad.Factura.NumeroFactura;
                
                comando.Parameters.Add(sqlParameterCantidad);
                comando.Parameters.Add(sqlParameterValor);
                comando.Parameters.Add(sqlParameterCodProducto);
                comando.Parameters.Add(sqlParameterNumeroFactura);            

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
