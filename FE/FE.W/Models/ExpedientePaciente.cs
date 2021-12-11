using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE.W.Models
{
    public partial class ExpedientePaciente
    {
        public ExpedientePaciente()
        {
            FacturaPaciente = new HashSet<FacturaPaciente>();
        }

        public int IdPaciente { get; set; }
        public int Cedula { get; set; }
        public string NombrePaciente { get; set; }
        public string ApellidoPaciente { get; set; }
        public string FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public string Padecimientos { get; set; }

        public virtual ICollection<FacturaPaciente> FacturaPaciente { get; set; }
    }
}
