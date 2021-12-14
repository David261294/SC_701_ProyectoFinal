using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Models
{
    public partial class ExpedientePaciente
    {
        public ExpedientePaciente()
        {
            FacturaPaciente = new HashSet<FacturaPaciente>();
        }

        public int IdPaciente { get; set; }
        [DisplayName("Cédula")]
        public int Cedula { get; set; }
        [DisplayName("Nombre del Paciente")]
        public string NombrePaciente { get; set; }
        [DisplayName("Apellido del Paciente")]
        public string ApellidoPaciente { get; set; }
        [DisplayName("Fecha Nacimiento")]
        [DataType(DataType.Date)]
        public string FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public string Padecimientos { get; set; }

        public virtual ICollection<FacturaPaciente> FacturaPaciente { get; set; }
    }
}
