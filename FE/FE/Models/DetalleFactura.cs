using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Models
{
    public partial class DetalleFactura
    {
        public DetalleFactura()
        {
            Ingresos = new HashSet<Ingresos>();
        }

        public int CodigoDetalle { get; set; }
        [DisplayName("Código de Factura")]
        public int CodigoFactura { get; set; }
        [DisplayName("Nombre del Tratamiento")]
        public int IdTratamiento { get; set; }
        [DisplayName("Nombre del Producto")]
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        [DisplayName("Precio Final")]
        public string PrecioFinal { get; set; }
        [DisplayName("Código de Factura")]
        public virtual FacturaPaciente CodigoFacturaNavigation { get; set; }
        [DisplayName("Nombre del Producto")]
        public virtual Producto IdProductoNavigation { get; set; }
        [DisplayName("Nombre del Tratamiento")]
        public virtual Tratamiento IdTratamientoNavigation { get; set; }
        public virtual ICollection<Ingresos> Ingresos { get; set; }
    }
}
