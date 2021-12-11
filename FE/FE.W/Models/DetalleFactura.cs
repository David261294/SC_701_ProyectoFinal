using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE.W.Models
{
    public partial class DetalleFactura
    {
        public DetalleFactura()
        {
            Ingresos = new HashSet<Ingresos>();
        }

        public int CodigoDetalle { get; set; }
        public int CodigoFactura { get; set; }
        public int IdTratamiento { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public string PrecioFinal { get; set; }

        public virtual FacturaPaciente CodigoFacturaNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
        public virtual Tratamiento IdTratamientoNavigation { get; set; }
        public virtual ICollection<Ingresos> Ingresos { get; set; }
    }
}
