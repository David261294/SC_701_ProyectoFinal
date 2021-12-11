using System;
using System.Collections.Generic;
using System.Text;

namespace API.Models
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
