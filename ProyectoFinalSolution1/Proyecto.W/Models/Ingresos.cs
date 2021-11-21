using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class Ingresos
    {
        public int IdIngreso { get; set; }
        public string FechaIngreso { get; set; }
        public int CodigoDetalle { get; set; }

        public virtual DetalleFactura CodigoDetalleNavigation { get; set; }
    }
}
