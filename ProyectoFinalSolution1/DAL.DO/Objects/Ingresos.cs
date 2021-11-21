using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{
    public partial class Ingresos
    {
        public int IdIngreso { get; set; }
        public string FechaIngreso { get; set; }
        public int CodigoDetalle { get; set; }

        public virtual DetalleFactura CodigoDetalleNavigation { get; set; }
    }
}
