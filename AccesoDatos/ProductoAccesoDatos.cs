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
    public class ProductoAccesoDatos
    {
        public List<ProductoEntidad> ObtenerProductos()
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString))
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "ObtenerProductos";

                conexion.Open();

                SqlDataReader sqlDataReader = comando.ExecuteReader();

                List<ProductoEntidad> listaProductos = new List<ProductoEntidad>();

                while (sqlDataReader.Read())
                {
                    ProductoEntidad producto = new ProductoEntidad();
                    producto.CodigoProducto = sqlDataReader["Codigoproducto"].ToString();
                    producto.Detalle = sqlDataReader["Detalle"].ToString();
                    producto.Precio = Convert.ToDecimal(sqlDataReader["Precio"]);
                    producto.Existencia = Convert.ToInt32(sqlDataReader["Existencia"]);
                    producto.Activo = Convert.ToBoolean(sqlDataReader["Activo"]);

                    listaProductos.Add(producto);
                }

                return listaProductos;
            }
        }

        public bool CrearProducto(ProductoEntidad productoEntidad)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString))
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "CrearProducto";

                SqlParameter sqlParameterCodigoProducto = new SqlParameter("@CodigoProducto", SqlDbType.VarChar);
                SqlParameter sqlParameterDetalle = new SqlParameter("@Detalle", SqlDbType.VarChar);
                SqlParameter sqlParameterPrecio = new SqlParameter("@Precio", SqlDbType.Decimal);
                SqlParameter sqlParameterExistencia = new SqlParameter("@Existencia", SqlDbType.Int);
                SqlParameter sqlParameterActivo = new SqlParameter("@Activo", SqlDbType.Bit);

                sqlParameterCodigoProducto.Value = productoEntidad.CodigoProducto;
                sqlParameterDetalle.Value = productoEntidad.Detalle;
                sqlParameterPrecio.Value = productoEntidad.Precio;
                sqlParameterExistencia.Value = productoEntidad.Existencia;
                sqlParameterActivo.Value = productoEntidad.Activo;

                comando.Parameters.Add(sqlParameterCodigoProducto);
                comando.Parameters.Add(sqlParameterDetalle);
                comando.Parameters.Add(sqlParameterPrecio);
                comando.Parameters.Add(sqlParameterExistencia);
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

        public ProductoEntidad ObtenerProducto(string codigo)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString))
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "ObtenerProductoPorCodigo";

                SqlParameter sqlParameterCodigoProducto = new SqlParameter("@CodigoProducto", SqlDbType.VarChar);

                sqlParameterCodigoProducto.Value = codigo;

                comando.Parameters.Add(sqlParameterCodigoProducto);

                conexion.Open();

                SqlDataReader sqlDataReader = comando.ExecuteReader();

                sqlDataReader.Read();

                if (sqlDataReader.HasRows)
                {
                    ProductoEntidad productoConsultado = new ProductoEntidad();
                    productoConsultado.CodigoProducto = sqlDataReader["Codigoproducto"].ToString();
                    productoConsultado.Detalle = sqlDataReader["Detalle"].ToString();
                    productoConsultado.Precio = Convert.ToDecimal(sqlDataReader["Precio"]);
                    productoConsultado.Existencia = Convert.ToInt32(sqlDataReader["Existencia"]);
                    productoConsultado.Activo = Convert.ToBoolean(sqlDataReader["Activo"]);

                    return productoConsultado;
                }

                return null;
            }
        }

        public bool ModificarProducto(ProductoEntidad productoEntidad)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString))
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "ModificarProducto";

                SqlParameter sqlParameterCodigoProducto = new SqlParameter("@CodigoProducto", SqlDbType.VarChar);
                SqlParameter sqlParameterDetalle = new SqlParameter("@Detalle", SqlDbType.VarChar);
                SqlParameter sqlParameterPrecio = new SqlParameter("@Precio", SqlDbType.Decimal);
                SqlParameter sqlParameterExistencia = new SqlParameter("@Existencia", SqlDbType.Int);
                SqlParameter sqlParameterActivo = new SqlParameter("@Activo", SqlDbType.Bit);

                sqlParameterCodigoProducto.Value = productoEntidad.CodigoProducto;
                sqlParameterDetalle.Value = productoEntidad.Detalle;
                sqlParameterPrecio.Value = productoEntidad.Precio;
                sqlParameterExistencia.Value = productoEntidad.Existencia;
                sqlParameterActivo.Value = productoEntidad.Activo;

                comando.Parameters.Add(sqlParameterCodigoProducto);
                comando.Parameters.Add(sqlParameterDetalle);
                comando.Parameters.Add(sqlParameterPrecio);
                comando.Parameters.Add(sqlParameterExistencia);
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