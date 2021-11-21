using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class Contacto
    {
        public int IdContacto { get; set; }
        public string NombreContacto { get; set; }
        public string ApellidoContacto { get; set; }
        public string CorreoContacto { get; set; }
        public string DireccionContacto { get; set; }
        public string TelefonoContacto { get; set; }
    }
}
