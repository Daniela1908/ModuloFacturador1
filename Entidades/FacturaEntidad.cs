using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class FacturaEntidad
    {
        public string NumeroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public ClienteEntidad Cliente { get; set; }
        public LoginEntidad Usuario { get; set; }
        public EstadosFactura Estado { get; set; }
    }
}
