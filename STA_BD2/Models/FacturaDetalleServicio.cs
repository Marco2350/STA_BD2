using System;
using System.Collections.Generic;

namespace STA_BD2.Models
{
    public partial class FacturaDetalleServicio
    {
        public int FacturaDetalleId { get; set; }
        public int? FacturaId { get; set; }
        public int? ServicioId { get; set; }
        public double Precio { get; set; }

        public virtual Factura? Factura { get; set; }
        public virtual Servicio? Servicio { get; set; }
    }
}
