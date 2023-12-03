using System;
using System.Collections.Generic;

namespace STA_BD2.Models
{
    public partial class ClienteServicio
    {
        public int ClienteServicioId { get; set; }
        public int ClienteId { get; set; }
        public int ServicioId { get; set; }
        public int TecnicoId { get; set; }
        public int EstadoServicioId { get; set; }

        public virtual Cliente Cliente { get; set; } = null!;
        public virtual EstadoServicio EstadoServicio { get; set; } = null!;
        public virtual Servicio Servicio { get; set; } = null!;
        public virtual Tecnico Tecnico { get; set; } = null!;
    }
}
