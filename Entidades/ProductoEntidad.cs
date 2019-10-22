using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ProductoEntidad
    {
        public string CodigoProducto { get; set; }
        public string Detalle { get; set; }
        public decimal Precio { get; set; }
        public int Existencia { get; set; }
        public bool Activo { get; set; }
    }
}
