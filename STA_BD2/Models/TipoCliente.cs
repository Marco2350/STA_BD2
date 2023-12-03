using System;
using System.Collections.Generic;

namespace STA_BD2.Models
{
    public partial class TipoCliente
    {
        public TipoCliente()
        {
            Clientes = new HashSet<Cliente>();
        }
        public int TipoClienteId { get; set; }
        public string DescripcionCliente { get; set; } = null!;

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
