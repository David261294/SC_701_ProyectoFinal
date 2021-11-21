using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class Eventos
    {
        public int IdEvento { get; set; }
        public int DíaEvento { get; set; }
        public string MesEvento { get; set; }
        public int AñoEvento { get; set; }
        public string DetallesEvento { get; set; }
    }
}
