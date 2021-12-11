using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Models
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
