using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Models
{
    public partial class FacturaPaciente
    {
        public FacturaPaciente()
        {
            DetalleFactura = new HashSet<DetalleFactura>();
        }

        public int CodigoFactura { get; set; }
        [DisplayName("Nombre del Paciente")]
        public int IdPaciente { get; set; }
        [DisplayName("Fecha de Factura")]
        [DataType(DataType.Date)]
        public string FechaFactura { get; set; }
        public string Descuento { get; set; }
        public string Iva { get; set; }
        [DisplayName("Nombre del Paciente")]
        public virtual ExpedientePaciente IdPacienteNavigation { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFactura { get; set; }
    }
}
