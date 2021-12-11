using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Models
{
    public partial class Dentista
    {
        public Dentista()
        {
            Reunion = new HashSet<Reunion>();
        }

        public int IdDentista { get; set; }
        [DisplayName("Nombre")]
        public string NombreDentista { get; set; }
        public string ApellidoDentista { get; set; }
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }

        public virtual ICollection<Reunion> Reunion { get; set; }
    }
}
