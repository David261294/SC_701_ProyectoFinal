using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE.W.Models
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
