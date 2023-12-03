using System;
using System.Collections.Generic;

namespace STA_BD2.Models
{
    public partial class ServicioPaquete
    {
        public int ServicioId { get; set; }
        public int PaqueteId { get; set; }
        public int EstadoServicioPaquete { get; set; }

        public virtual Paquete Paquete { get; set; } = null!;
        public virtual Servicio Servicio { get; set; } = null!;
    }
}
