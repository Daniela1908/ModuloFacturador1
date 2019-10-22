using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class ProductoReglaNegocio
    {
        public List<ProductoEntidad> ObtenerProducto() {

            ProductoAccesoDatos productoAccesoDatos = new ProductoAccesoDatos();
            return productoAccesoDatos.ObtenerProductos();
        }
    }
}
