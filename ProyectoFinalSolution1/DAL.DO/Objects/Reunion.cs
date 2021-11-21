using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{
    public partial class Reunion
    {
        public int NumeroReunion { get; set; }
        public string Dia { get; set; }
        public int IdDentista { get; set; }
        public int IdRecepcionista { get; set; }
        public string DetallesReunion { get; set; }

        public virtual Dentista IdDentistaNavigation { get; set; }
        public virtual Recepcionista IdRecepcionistaNavigation { get; set; }
    }
}
