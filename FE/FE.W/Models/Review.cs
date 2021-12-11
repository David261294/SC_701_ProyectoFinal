using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE.W.Models
{
    public partial class Review
    {
        public int IdReview { get; set; }
        public int IdCitas { get; set; }
        public string NombrePacienteCita { get; set; }
        public string Comentario { get; set; }
        public string Estrellas { get; set; }

        public virtual Citas IdCitasNavigation { get; set; }
    }
}
