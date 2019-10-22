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
        public List<ProductoEntidad> ObtenerProductos() {
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
    }
}