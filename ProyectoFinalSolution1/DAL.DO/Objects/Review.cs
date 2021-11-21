using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
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
