using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Models
{
    public partial class Citas
    {
        public Citas()
        {
            Review = new HashSet<Review>();
        }
        [DisplayName("ID CITA")]
        public int IdCitas { get; set; }
        [DisplayName("Nombre del Paciente")]
        public string NombrePacienteCita { get; set; }
        public string ApellidoPacienteCita { get; set; }
        public int DíaCita { get; set; }
        public string MesCita { get; set; }
        public int AñoCita { get; set; }
        public int HoraCita { get; set; }

        public virtual ICollection<Review> Review { get; set; }
    }
}
