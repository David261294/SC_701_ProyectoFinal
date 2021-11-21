using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class Tratamiento
    {
        public Tratamiento()
        {
            DetalleFactura = new HashSet<DetalleFactura>();
        }

        public int IdTratamiento { get; set; }
        public string NombreTratamiento { get; set; }
        public string CostoTratamiento { get; set; }

        public virtual ICollection<DetalleFactura> DetalleFactura { get; set; }
    }
}
