using System;
using System.Collections.Generic;

namespace STA_BD2.Models
{
    public partial class VwFactura
    {
        public int FacturaId { get; set; }
        public string Cliente { get; set; } = null!;
        public string NumeroCuenta { get; set; } = null!;
        public string Nombrebanco { get; set; } = null!;
        public DateTime? FechaLimite { get; set; }
        public string? EstadoFactura { get; set; }
        public string? DescripcionPaquete { get; set; }
        public string? DescripcionServicio { get; set; }
        public double Precio { get; set; }
    }
}
