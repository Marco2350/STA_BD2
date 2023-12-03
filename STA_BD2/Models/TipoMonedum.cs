using System;
using System.Collections.Generic;

namespace STA_BD2.Models
{
    public partial class TipoMonedum
    {
        public TipoMonedum()
        {
            CuentaBancaria = new HashSet<CuentaBancarium>();
        }

        public int TipoMonedaId { get; set; }
        public string DescripcionMoneda { get; set; } = null!;

        public virtual ICollection<CuentaBancarium> CuentaBancaria { get; set; }
    }
}
