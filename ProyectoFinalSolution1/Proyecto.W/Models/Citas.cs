using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class Citas
    {
        public Citas()
        {
            Review = new HashSet<Review>();
        }

        public int IdCitas { get; set; }
        public string NombrePacienteCita { get; set; }
        public string ApellidoPacienteCita { get; set; }
        public int DíaCita { get; set; }
        public string MesCita { get; set; }
        public int AñoCita { get; set; }
        public int HoraCita { get; set; }

        public virtual ICollection<Review> Review { get; set; }
    }
}
