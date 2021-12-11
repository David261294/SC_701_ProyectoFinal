using System;
using System.Collections.Generic;
using System.Text;

namespace API.Models
{
    public partial class FacturaPaciente
    {
        public FacturaPaciente()
        {
            DetalleFactura = new HashSet<DetalleFactura>();
        }

        public int CodigoFactura { get; set; }
        public int IdPaciente { get; set; }
        public string FechaFactura { get; set; }
        public string Descuento { get; set; }
        public string Iva { get; set; }

        public virtual ExpedientePaciente IdPacienteNavigation { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFactura { get; set; }
    }
}
