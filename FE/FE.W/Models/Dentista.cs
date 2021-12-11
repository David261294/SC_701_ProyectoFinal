using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE.W.Models
{
    public partial class Dentista
    {
        public Dentista()
        {
            Reunion = new HashSet<Reunion>();
        }

        public int IdDentista { get; set; }
        public string NombreDentista { get; set; }
        public string ApellidoDentista { get; set; }
        public string Contraseña { get; set; }

        public virtual ICollection<Reunion> Reunion { get; set; }
    }
}
