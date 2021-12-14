using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Models
{
    public partial class Review
    {
        public int IdReview { get; set; }
        [DisplayName("Nombre del Paciente")]
        public int IdCitas { get; set; }
        [DisplayName("Verificado por")]
        public string NombrePacienteCita { get; set; }
        public string Comentario { get; set; }
        public string Estrellas { get; set; }
        [DisplayName("Nombre del Paciente")]
        public virtual Citas IdCitasNavigation { get; set; }
    }
}
