using System;
using System.Collections.Generic;

namespace STA_BD2.Models
{
    public partial class CuentaBancarium
    {
        public CuentaBancarium()
        {
            Facturas = new HashSet<Factura>();
            Pagos = new HashSet<Pago>();
        }

        public int CuentaBancariaId { get; set; }
        public int BancoId { get; set; }
        public string NumeroCuenta { get; set; } = null!;
        public int TipoMonedaId { get; set; }
        public double SaldoInicial { get; set; }
        public int? EstadoCuentaBancaria { get; set; }

        public virtual Banco Banco { get; set; } = null!;
        public virtual EstadoServicio? EstadoCuentaBancariaNavigation { get; set; }
        public virtual TipoMonedum TipoMoneda { get; set; } = null!;
        public virtual ICollection<Factura> Facturas { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
