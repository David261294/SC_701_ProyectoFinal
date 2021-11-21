using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{
    public partial class Dentista
    {
        public Dentista()
        {
            Reunion = new HashSet<Reunion>();
        }

        public int IdDentista { get; set; }
        public string NombreDentista { get; set; }
        public string ApellidoDentista { get; set; }
        public string Contraseña { get; set; }

        public virtual ICollection<Reunion> Reunion { get; set; }
    }
}
