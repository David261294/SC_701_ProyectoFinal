using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Models
{
    public partial class Ingresos
    {
        public int IdIngreso { get; set; }
        [DisplayName("Fecha Ingreso")]
        [DataType(DataType.Date)]
        public string FechaIngreso { get; set; }
        [DisplayName("Código Detalle Factura")]
        public int CodigoDetalle { get; set; }
        [DisplayName("Código Detalle Factura")]
      
        public virtual DetalleFactura CodigoDetalleNavigation { get; set; }
    }
}
