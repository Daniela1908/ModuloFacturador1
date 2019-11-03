using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class DetalleFacturaReglaNegocio
    {
        public List<ProductoFacturaEntidad> ObtenerProductosFactura(int numeroFactura)
        {
            DetalleFacturaAccesoDatos detalleFacturaAccesoDatos = new DetalleFacturaAccesoDatos();
            return detalleFacturaAccesoDatos.ObtenerProductosFactura(numeroFactura);            
        }

        public bool CrearDetalleFactura(ProductoFacturaEntidad productoFacturaEntidad)
        {
            DetalleFacturaAccesoDatos detalleFacturaAccesoDatos = new DetalleFacturaAccesoDatos();
            return detalleFacturaAccesoDatos.CrearDetalleFactura(productoFacturaEntidad);                
        }
    }
}
