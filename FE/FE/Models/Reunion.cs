using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Models
{
    public partial class Reunion
    {
        public int NumeroReunion { get; set; }
        [DisplayName("Fecha de Reunión")]
        [DataType(DataType.Date)]
        public string Dia { get; set; }
        [DisplayName("Nombre del Dentista")]      
        public int IdDentista { get; set; }
        [DisplayName("Nombre del Recepcionista")]
        public int IdRecepcionista { get; set; }
        [DisplayName("Detalle de la Reunión")]
        public string DetallesReunion { get; set; }
        [DisplayName("Nombre del Dentista")]
        public virtual Dentista IdDentistaNavigation { get; set; }
        [DisplayName("Nombre del Recepcionista")]
        public virtual Recepcionista IdRecepcionistaNavigation { get; set; }
    }
}
