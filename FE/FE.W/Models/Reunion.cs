using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE.W.Models
{
    public partial class Reunion
    {
        public int NumeroReunion { get; set; }
        public string Dia { get; set; }
        public int IdDentista { get; set; }
        public int IdRecepcionista { get; set; }
        public string DetallesReunion { get; set; }

        public virtual Dentista IdDentistaNavigation { get; set; }
        public virtual Recepcionista IdRecepcionistaNavigation { get; set; }
    }
}
