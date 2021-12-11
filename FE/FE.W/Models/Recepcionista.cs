using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE.W.Models
{
    public partial class Recepcionista
    {
        public Recepcionista()
        {
            Reunion = new HashSet<Reunion>();
        }

        public int IdRecepcionista { get; set; }
        public string NombreRecepcionista { get; set; }
        public string ApellidoRecepcionista { get; set; }
        public string Contraseña { get; set; }

        public virtual ICollection<Reunion> Reunion { get; set; }
    }
}
