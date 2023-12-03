using System;
using System.Collections.Generic;

namespace STA_BD2.Models
{
    public partial class EstadoServicio
    {
        public EstadoServicio()
        {
            Bancos = new HashSet<Banco>();
            ClienteContratos = new HashSet<ClienteContrato>();
            ClienteServicios = new HashSet<ClienteServicio>();
            CuentaBancaria = new HashSet<CuentaBancarium>();
            Paquetes = new HashSet<Paquete>();
            Servicios = new HashSet<Servicio>();
            Tecnicos = new HashSet<Tecnico>();
        }

        public int EstadoServicioId { get; set; }
        public string? DescripcionEstadoServicio { get; set; }

        public virtual ICollection<Banco> Bancos { get; set; }
        public virtual ICollection<ClienteContrato> ClienteContratos { get; set; }
        public virtual ICollection<ClienteServicio> ClienteServicios { get; set; }
        public virtual ICollection<CuentaBancarium> CuentaBancaria { get; set; }
        public virtual ICollection<Paquete> Paquetes { get; set; }
        public virtual ICollection<Servicio> Servicios { get; set; }
        public virtual ICollection<Tecnico> Tecnicos { get; set; }
    }
}
