using System;
using System.Collections.Generic;

namespace STA_BD2.Models
{
    public partial class Tecnico
    {
        public Tecnico()
        {
            ClienteContratos = new HashSet<ClienteContrato>();
            ClienteServicios = new HashSet<ClienteServicio>();
            Pagos = new HashSet<Pago>();
        }

        public int TecnicoId { get; set; }
        public string PrimerNombre { get; set; } = null!;
        public string SegundoNombre { get; set; } = null!;
        public string PrimerApellido { get; set; } = null!;
        public string SegundoApellido { get; set; } = null!;
        public string CodigoTecnico { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public string? Correo { get; set; }
        public string? Direccion { get; set; }
        public string CuentaBancoTecnico { get; set; } = null!;
        public int EstadoTecnico { get; set; }
        public double Salario { get; set; }

        public virtual EstadoServicio EstadoTecnicoNavigation { get; set; } = null!;
        public virtual ICollection<ClienteContrato> ClienteContratos { get; set; }
        public virtual ICollection<ClienteServicio> ClienteServicios { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
