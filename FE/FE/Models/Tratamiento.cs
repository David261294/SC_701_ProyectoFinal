﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Models
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
