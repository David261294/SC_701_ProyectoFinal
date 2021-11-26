using System;
using System.Collections.Generic;
using System.Text;

namespace API.Models
{
    public partial class Inventario
    {
        public int IdInventario { get; set; }
        public int Cantidad { get; set; }
        public string Descripción { get; set; }
    }
}
