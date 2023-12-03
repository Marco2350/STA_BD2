using System;
using System.Collections.Generic;

namespace STA_BD2.Models
{
    public partial class FacturaDetallePaquete
    {
        public int FacturaDetalleId { get; set; }
        public int? FacturaId { get; set; }
        public int? PaqueteId { get; set; }
        public double Precio { get; set; }
        public int? HorasExtras { get; set; }

        public virtual Factura? Factura { get; set; }
        public virtual Paquete? Paquete { get; set; }
    }
}
