using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Models
{
    public partial class Ingresos
    {
        public int IdIngreso { get; set; }
        public string FechaIngreso { get; set; }
        public int CodigoDetalle { get; set; }

        public virtual DetalleFactura CodigoDetalleNavigation { get; set; }
    }
}
