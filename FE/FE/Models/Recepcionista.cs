using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Models
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
