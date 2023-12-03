using System;
using System.Collections.Generic;

namespace STA_BD2.Models
{
    public partial class Servicio
    {
        public Servicio()
        {
            ClienteServicios = new HashSet<ClienteServicio>();
            FacturaDetalleServicios = new HashSet<FacturaDetalleServicio>();
            ServicioPaquetes = new HashSet<ServicioPaquete>();
        }

        public int ServicioId { get; set; }
        public string DescripcionServicio { get; set; } = null!;
        public double PrecioServicio { get; set; }
        public int EstadoServicio { get; set; }

        public virtual EstadoServicio EstadoServicioNavigation { get; set; } = null!;
        public virtual ICollection<ClienteServicio> ClienteServicios { get; set; }
        public virtual ICollection<FacturaDetalleServicio> FacturaDetalleServicios { get; set; }
        public virtual ICollection<ServicioPaquete> ServicioPaquetes { get; set; }
    }
}
