using System;
using System.Collections.Generic;

namespace STA_BD2.Models
{
    public partial class Banco
    {
        public Banco()
        {
            CuentaBancaria = new HashSet<CuentaBancarium>();
        }

        public int BancoId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public int? EstadoBanco { get; set; }

        public virtual EstadoServicio? EstadoBancoNavigation { get; set; }
        public virtual ICollection<CuentaBancarium> CuentaBancaria { get; set; }
    }
}
