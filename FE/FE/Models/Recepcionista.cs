using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [DisplayName("Nombre del Recepcionista")]
        public string NombreRecepcionista { get; set; }
        [DisplayName("Apellido del Recepcionista")]
        public string ApellidoRecepcionista { get; set; }
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }

        public virtual ICollection<Reunion> Reunion { get; set; }
    }
}
