using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{
    public partial class Inventario
    {
        public int IdInventario { get; set; }
        public int Cantidad { get; set; }
        public string Descripción { get; set; }
    }
}
