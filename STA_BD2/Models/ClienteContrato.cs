using System;
using System.Collections.Generic;

namespace STA_BD2.Models
{
    public partial class ClienteContrato
    {
        public int ClienteContratoId { get; set; }
        public int ClienteId { get; set; }
        public int PaqueteId { get; set; }
        public int TecnicoId { get; set; }
        public int EstadoServicioId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }

        public virtual Cliente Cliente { get; set; } = null!;
        public virtual EstadoServicio EstadoServicio { get; set; } = null!;
        public virtual Paquete Paquete { get; set; } = null!;
        public virtual Tecnico Tecnico { get; set; } = null!;
    }
}
