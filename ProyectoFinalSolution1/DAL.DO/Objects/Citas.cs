using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
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
