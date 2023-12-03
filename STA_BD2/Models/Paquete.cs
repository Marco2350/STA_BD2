using System;
using System.Collections.Generic;

namespace STA_BD2.Models
{
    public partial class Paquete
    {
        public Paquete()
        {
            ClienteContratos = new HashSet<ClienteContrato>();
            FacturaDetallePaquetes = new HashSet<FacturaDetallePaquete>();
            ServicioPaquetes = new HashSet<ServicioPaquete>();
        }
        public int PaqueteId { get; set; }
        public string DescripcionPaquete { get; set; } = null!;
        public int? Duracion { get; set; }
        public int EstadoPaquete { get; set; }

        public virtual EstadoServicio EstadoPaqueteNavigation { get; set; } = null!;
        public virtual ICollection<ClienteContrato> ClienteContratos { get; set; }
        public virtual ICollection<FacturaDetallePaquete> FacturaDetallePaquetes { get; set; }
        public virtual ICollection<ServicioPaquete> ServicioPaquetes { get; set; }
    }
}
