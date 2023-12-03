using System;
using System.Collections.Generic;

namespace STA_BD2.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            ClienteContratos = new HashSet<ClienteContrato>();
            ClienteServicios = new HashSet<ClienteServicio>();
            Facturas = new HashSet<Factura>();
        }

        public int ClienteId { get; set; }
        public string PrimerNombre { get; set; } = null!;
        public string SegundoNombre { get; set; } = null!;
        public string PrimerApellido { get; set; } = null!;
        public string SegundoApellido { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public string? Correo { get; set; }
        public string? Direccion { get; set; }
        public int TipoClienteId { get; set; }
        public int EstadoCliente { get; set; }

        public List<TipoCliente> TiposClientes { get; set; }

        public virtual TipoCliente TipoCliente { get; set; } = null!;
        public virtual ICollection<ClienteContrato> ClienteContratos { get; set; }
        public virtual ICollection<ClienteServicio> ClienteServicios { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
