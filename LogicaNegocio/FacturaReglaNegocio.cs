using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class FacturaReglaNegocio
    {
        public void CrearFactura(FacturaEntidad facturaEntidad)
        {
            FacturaAccesoDatos facturaAccesoDatos = new FacturaAccesoDatos();
            facturaAccesoDatos.CrearFactura(facturaEntidad);
        }
    }
}
