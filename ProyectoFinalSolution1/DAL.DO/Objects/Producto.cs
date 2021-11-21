using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
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
