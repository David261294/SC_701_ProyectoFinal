using System;
using System.Collections.Generic;
using System.Text;

namespace API.Models
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
