using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ProductoFacturaEntidad
    {
        public int NumeroDetalle { get; set; }
        public int Cantidad { get; set; }
        public decimal Valor { get; set; }
        public ProductoEntidad Producto { get; set; }
        public FacturaEntidad Factura { get; set; }
        public string NombreProducto { get; set; }
    }
}
