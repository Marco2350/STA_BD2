using System;
using System.Collections.Generic;

namespace STA_BD2.Models
{
    public partial class Factura
    {
        public Factura()
        {
            FacturaDetallePaquetes = new HashSet<FacturaDetallePaquete>();
            FacturaDetalleServicios = new HashSet<FacturaDetalleServicio>();
        }

        public int FacturaId { get; set; }
        public int ClienteId { get; set; }
        public DateTime? FechaFactura { get; set; }
        public DateTime? FechaLimite { get; set; }
        public double? Total { get; set; }
        public int? CuentaBancariaId { get; set; }
        public int EstadoFacturaId { get; set; }

        public virtual Cliente Cliente { get; set; } = null!;
        public virtual CuentaBancarium? CuentaBancaria { get; set; }
        public virtual EstadoFactura EstadoFactura { get; set; } = null!;
        public virtual ICollection<FacturaDetallePaquete> FacturaDetallePaquetes { get; set; }
        public virtual ICollection<FacturaDetalleServicio> FacturaDetalleServicios { get; set; }
    }
}
