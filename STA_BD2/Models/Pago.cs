using System;
using System.Collections.Generic;

namespace STA_BD2.Models
{
    public partial class Pago
    {
        public int PagoId { get; set; }
        public string CuentaBancoTecnico { get; set; } = null!;
        public int CuentaBancariaId { get; set; }
        public double MontoPagado { get; set; }

        public virtual CuentaBancarium CuentaBancaria { get; set; } = null!;
        public virtual Tecnico CuentaBancoTecnicoNavigation { get; set; } = null!;
    }
}
