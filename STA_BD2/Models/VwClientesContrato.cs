using System;
using System.Collections.Generic;

namespace STA_BD2.Models
{
    public partial class VwClientesContrato
    {
        public int ClienteContratoId { get; set; }
        public int ClienteId { get; set; }
        public string ClienteNombre { get; set; } = null!;
        public string DescripcionPaquete { get; set; } = null!;
        public int? Duracion { get; set; }
        public int FacturaId { get; set; }
    }
}
