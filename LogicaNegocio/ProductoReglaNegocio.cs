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
        public List<ProductoEntidad> ObtenerProductos() {

            ProductoAccesoDatos productoAccesoDatos = new ProductoAccesoDatos();
            return productoAccesoDatos.ObtenerProductos();
        }

        public bool CrearProducto(ProductoEntidad productoEntidad) {

            ProductoAccesoDatos productoAccesoDatos = new ProductoAccesoDatos();
            return productoAccesoDatos.CrearProducto(productoEntidad);            
        }

        public ProductoEntidad ObtenerProductoPorCodigo(string codigo) {
            ProductoAccesoDatos productoAccesoDatos = new ProductoAccesoDatos();
            return productoAccesoDatos.ObtenerProducto(codigo);
        }

        public bool ModificarProducto(ProductoEntidad productoEntidad)
        {

            ProductoAccesoDatos productoAccesoDatos = new ProductoAccesoDatos();
            return productoAccesoDatos.ModificarProducto(productoEntidad);
        }

        public List<ProductoEntidad> ObtenerProductosActivos()
        {
            ProductoAccesoDatos productoAccesoDatos = new ProductoAccesoDatos();
            return productoAccesoDatos.ObtenerProductosActivos();
        }
    }
}
