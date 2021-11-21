using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class PacienteNuevo
    {
        public int IdPacienteNuevo { get; set; }
        public string NombrePacienteNuevo { get; set; }
        public string ApellidoPacienteNuevo { get; set; }
        public string Contraseña { get; set; }
    }
}
