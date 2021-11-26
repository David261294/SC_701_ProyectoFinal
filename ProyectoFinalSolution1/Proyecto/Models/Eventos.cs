using System;
using System.Collections.Generic;
using System.Text;

namespace API.Models
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
