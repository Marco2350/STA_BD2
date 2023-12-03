using System;
using System.Collections.Generic;

namespace STA_BD2.Models
{
    public partial class VwPreciopaquete
    {
        public int PaqueteId { get; set; }
        public string DescripcionPaquete { get; set; } = null!;
        public double? TotalPrecio { get; set; }
    }
}
