using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [DisplayName("Apellido del Paciente")]
        public string ApellidoPacienteCita { get; set; }
        [DisplayName("Dia de la Cita")]
        public int DíaCita { get; set; }
        [DisplayName("Mes de la Cita")]
        public string MesCita { get; set; }
        [DisplayName("Año de la Cita")]
        public int AñoCita { get; set; }
        [DisplayName("Hora de la Cita")]
        //[DataType(DataType.Time)]
        public int HoraCita { get; set; }

        public virtual ICollection<Review> Review { get; set; }
    }
}
