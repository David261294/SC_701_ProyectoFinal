using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Nombre del Producto")]
        public string NombreProducto { get; set; }
        [DisplayName("Precio del Producto")]
        public string PrecioProducto { get; set; }

        public virtual ICollection<DetalleFactura> DetalleFactura { get; set; }
    }
}
