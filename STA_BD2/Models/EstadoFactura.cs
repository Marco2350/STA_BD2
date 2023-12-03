using System;
using System.Collections.Generic;

namespace STA_BD2.Models
{
    public partial class EstadoFactura
    {
        public EstadoFactura()
        {
            Facturas = new HashSet<Factura>();
        }

        public int EstadoFacturaId { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
