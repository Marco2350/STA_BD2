using System;
using System.Collections.Generic;

namespace STA_BD2.Models
{
    public partial class VwAsigancionesTecnico
    {
        public int TecnicoId { get; set; }
        public string NombreTecnico { get; set; } = null!;
        public int? CantidadContratos { get; set; }
        public int? CantidadServicios { get; set; }
    }
}
