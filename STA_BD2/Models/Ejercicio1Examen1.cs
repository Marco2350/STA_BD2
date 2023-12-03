using System;
using System.Collections.Generic;

namespace STA_BD2.Models
{
    public partial class Ejercicio1Examen1
    {
        public long? LibroId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public decimal? Nacionales { get; set; }
        public decimal? Internacionales { get; set; }
    }
}
