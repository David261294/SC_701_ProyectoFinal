using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE.W.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleFactura = new HashSet<DetalleFactura>();
        }

        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string PrecioProducto { get; set; }

        public virtual ICollection<DetalleFactura> DetalleFactura { get; set; }
    }
}
