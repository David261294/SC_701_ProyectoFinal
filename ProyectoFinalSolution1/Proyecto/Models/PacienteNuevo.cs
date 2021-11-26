using System;
using System.Collections.Generic;
using System.Text;

namespace API.Models
{
    public partial class PacienteNuevo
    {
        public int IdPacienteNuevo { get; set; }
        public string NombrePacienteNuevo { get; set; }
        public string ApellidoPacienteNuevo { get; set; }
        public string Contraseña { get; set; }
    }
}
