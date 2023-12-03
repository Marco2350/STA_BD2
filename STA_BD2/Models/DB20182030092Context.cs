using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace STA_BD2.Models
{
    public partial class DB20182030092Context : DbContext
    {
        public DB20182030092Context()
        {
        }

        public DB20182030092Context(DbContextOptions<DB20182030092Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Banco> Bancos { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<ClienteContrato> ClienteContratos { get; set; } = null!;
        public virtual DbSet<ClienteServicio> ClienteServicios { get; set; } = null!;
        public virtual DbSet<CuentaBancarium> CuentaBancaria { get; set; } = null!;
        public virtual DbSet<Ejercicio1Examen1> Ejercicio1Examen1s { get; set; } = null!;
        public virtual DbSet<EstadoFactura> EstadoFacturas { get; set; } = null!;
        public virtual DbSet<EstadoServicio> EstadoServicios { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<FacturaDetallePaquete> FacturaDetallePaquetes { get; set; } = null!;
        public virtual DbSet<FacturaDetalleServicio> FacturaDetalleServicios { get; set; } = null!;
        public virtual DbSet<Pago> Pagos { get; set; } = null!;
        public virtual DbSet<Paquete> Paquetes { get; set; } = null!;
        public virtual DbSet<Servicio> Servicios { get; set; } = null!;
        public virtual DbSet<ServicioPaquete> ServicioPaquetes { get; set; } = null!;
        public virtual DbSet<Tecnico> Tecnicos { get; set; } = null!;
        public virtual DbSet<TipoCliente> TipoClientes { get; set; } = null!;
        public virtual DbSet<TipoMonedum> TipoMoneda { get; set; } = null!;
        public virtual DbSet<VwAsigancionesTecnico> VwAsigancionesTecnicos { get; set; } = null!;
        public virtual DbSet<VwClientesContrato> VwClientesContratos { get; set; } = null!;
        public virtual DbSet<VwFactura> VwFacturas { get; set; } = null!;
        public virtual DbSet<VwPreciopaquete> VwPreciopaquetes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:3.128.144.165;Database=DB20182030092;User ID=douglas.palma;Password=DP20182030092;TrustServerCertificate=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Banco>(entity =>
            {
                entity.ToTable("banco");

                entity.Property(e => e.BancoId).HasColumnName("bancoID");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.EstadoBanco)
                    .HasColumnName("estadoBanco")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.EstadoBancoNavigation)
                    .WithMany(p => p.Bancos)
                    .HasForeignKey(d => d.EstadoBanco)
                    .HasConstraintName("FK_bancoEstadoTien$estado");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.Property(e => e.ClienteId).HasColumnName("clienteID");

                entity.Property(e => e.Correo)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Direccion)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.EstadoCliente).HasColumnName("estadoCliente");

                entity.Property(e => e.Numero)
                    .IsUnicode(false)
                    .HasColumnName("numero");

                entity.Property(e => e.PrimerApellido)
                    .IsUnicode(false)
                    .HasColumnName("primerApellido");

                entity.Property(e => e.PrimerNombre)
                    .IsUnicode(false)
                    .HasColumnName("primerNombre");

                entity.Property(e => e.SegundoApellido)
                    .IsUnicode(false)
                    .HasColumnName("segundoApellido");

                entity.Property(e => e.SegundoNombre)
                    .IsUnicode(false)
                    .HasColumnName("segundoNombre");

                entity.Property(e => e.TipoClienteId).HasColumnName("tipoClienteID");

                entity.HasOne(d => d.TipoCliente)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.TipoClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cliente_tipoCliente$tipoClienteID");
            });

            modelBuilder.Entity<ClienteContrato>(entity =>
            {
                entity.ToTable("clienteContrato");

                entity.Property(e => e.ClienteContratoId).HasColumnName("clienteContratoID");

                entity.Property(e => e.ClienteId).HasColumnName("clienteID");

                entity.Property(e => e.EstadoServicioId).HasColumnName("estadoServicioID");

                entity.Property(e => e.FechaFinal)
                    .HasColumnType("date")
                    .HasColumnName("fechaFinal");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("fechaInicio");

                entity.Property(e => e.PaqueteId).HasColumnName("paqueteID");

                entity.Property(e => e.TecnicoId).HasColumnName("tecnicoID");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.ClienteContratos)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cliente_clienteContrato$clienteID");

                entity.HasOne(d => d.EstadoServicio)
                    .WithMany(p => p.ClienteContratos)
                    .HasForeignKey(d => d.EstadoServicioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_servicio_clienteContrato$servicioID");

                entity.HasOne(d => d.Paquete)
                    .WithMany(p => p.ClienteContratos)
                    .HasForeignKey(d => d.PaqueteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_paquete_clienteContrato$paqueteID");

                entity.HasOne(d => d.Tecnico)
                    .WithMany(p => p.ClienteContratos)
                    .HasForeignKey(d => d.TecnicoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tecnico_clienteContrato$tecnicoID");
            });

            modelBuilder.Entity<ClienteServicio>(entity =>
            {
                entity.ToTable("clienteServicio");

                entity.Property(e => e.ClienteServicioId).HasColumnName("clienteServicioID");

                entity.Property(e => e.ClienteId).HasColumnName("clienteID");

                entity.Property(e => e.EstadoServicioId).HasColumnName("estadoServicioID");

                entity.Property(e => e.ServicioId).HasColumnName("ServicioID");

                entity.Property(e => e.TecnicoId).HasColumnName("tecnicoID");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.ClienteServicios)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cliente_clienteServicio$clienteID");

                entity.HasOne(d => d.EstadoServicio)
                    .WithMany(p => p.ClienteServicios)
                    .HasForeignKey(d => d.EstadoServicioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_servicio_clienteServicio$estadoServicioID");

                entity.HasOne(d => d.Servicio)
                    .WithMany(p => p.ClienteServicios)
                    .HasForeignKey(d => d.ServicioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Servicio_clienteServicio$ServicioID");

                entity.HasOne(d => d.Tecnico)
                    .WithMany(p => p.ClienteServicios)
                    .HasForeignKey(d => d.TecnicoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tecnico_clienteServicio$tecnicoID");
            });

            modelBuilder.Entity<CuentaBancarium>(entity =>
            {
                entity.HasKey(e => e.CuentaBancariaId)
                    .HasName("pk_cuentaBancaria");

                entity.ToTable("cuentaBancaria");

                entity.Property(e => e.CuentaBancariaId).HasColumnName("cuentaBancariaID");

                entity.Property(e => e.BancoId).HasColumnName("bancoID");

                entity.Property(e => e.EstadoCuentaBancaria).HasColumnName("estadoCuentaBancaria");

                entity.Property(e => e.NumeroCuenta)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("numeroCuenta");

                entity.Property(e => e.SaldoInicial).HasColumnName("saldoInicial");

                entity.Property(e => e.TipoMonedaId).HasColumnName("tipoMonedaID");

                entity.HasOne(d => d.Banco)
                    .WithMany(p => p.CuentaBancaria)
                    .HasForeignKey(d => d.BancoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_banco_cuentaBancaria$bancoID");

                entity.HasOne(d => d.EstadoCuentaBancariaNavigation)
                    .WithMany(p => p.CuentaBancaria)
                    .HasForeignKey(d => d.EstadoCuentaBancaria)
                    .HasConstraintName("FK_cuentaBancariaTiene$un$estado");

                entity.HasOne(d => d.TipoMoneda)
                    .WithMany(p => p.CuentaBancaria)
                    .HasForeignKey(d => d.TipoMonedaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tipoMoneda_cuentaBancaria$tipoMonedaID");
            });

            modelBuilder.Entity<Ejercicio1Examen1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Ejercicio1_Examen1");

                entity.Property(e => e.Internacionales).HasColumnType("money");

                entity.Property(e => e.LibroId).HasColumnName("LibroID");

                entity.Property(e => e.Nacionales).HasColumnType("money");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<EstadoFactura>(entity =>
            {
                entity.ToTable("estadoFactura");

                entity.Property(e => e.EstadoFacturaId).HasColumnName("estadoFacturaID");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<EstadoServicio>(entity =>
            {
                entity.ToTable("estadoServicio");

                entity.Property(e => e.EstadoServicioId).HasColumnName("estadoServicioID");

                entity.Property(e => e.DescripcionEstadoServicio)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcionEstadoServicio");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.ToTable("factura");

                entity.Property(e => e.FacturaId).HasColumnName("facturaID");

                entity.Property(e => e.ClienteId).HasColumnName("clienteID");

                entity.Property(e => e.CuentaBancariaId).HasColumnName("cuentaBancariaID");

                entity.Property(e => e.EstadoFacturaId).HasColumnName("estadoFacturaID");

                entity.Property(e => e.FechaFactura)
                    .HasColumnType("date")
                    .HasColumnName("fechaFactura")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaLimite)
                    .HasColumnType("date")
                    .HasColumnName("fechaLimite")
                    .HasDefaultValueSql("(dateadd(day,(30),getdate()))");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cliente_factura$clienteID");

                entity.HasOne(d => d.CuentaBancaria)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.CuentaBancariaId)
                    .HasConstraintName("fk_cuentaBancaria_factura$cuentaBancariaID");

                entity.HasOne(d => d.EstadoFactura)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.EstadoFacturaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_estadoFactura_factura$estadoFacturaID");
            });

            modelBuilder.Entity<FacturaDetallePaquete>(entity =>
            {
                entity.HasKey(e => e.FacturaDetalleId)
                    .HasName("pk_facturadetallepaquete");

                entity.ToTable("facturaDetallePaquete");

                entity.Property(e => e.FacturaDetalleId).HasColumnName("facturaDetalleID");

                entity.Property(e => e.FacturaId).HasColumnName("facturaID");

                entity.Property(e => e.HorasExtras).HasColumnName("horasExtras");

                entity.Property(e => e.PaqueteId).HasColumnName("paqueteID");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.HasOne(d => d.Factura)
                    .WithMany(p => p.FacturaDetallePaquetes)
                    .HasForeignKey(d => d.FacturaId)
                    .HasConstraintName("fk_factura_facturadetallepaquete$facturaID");

                entity.HasOne(d => d.Paquete)
                    .WithMany(p => p.FacturaDetallePaquetes)
                    .HasForeignKey(d => d.PaqueteId)
                    .HasConstraintName("fk_paquete_facturadetalle$servicioID");
            });

            modelBuilder.Entity<FacturaDetalleServicio>(entity =>
            {
                entity.HasKey(e => e.FacturaDetalleId)
                    .HasName("pk_facturadetalle");

                entity.ToTable("facturaDetalleServicio");

                entity.Property(e => e.FacturaDetalleId).HasColumnName("facturaDetalleID");

                entity.Property(e => e.FacturaId).HasColumnName("facturaID");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.Property(e => e.ServicioId).HasColumnName("servicioID");

                entity.HasOne(d => d.Factura)
                    .WithMany(p => p.FacturaDetalleServicios)
                    .HasForeignKey(d => d.FacturaId)
                    .HasConstraintName("fk_factura_facturadetalle$facturaID");

                entity.HasOne(d => d.Servicio)
                    .WithMany(p => p.FacturaDetalleServicios)
                    .HasForeignKey(d => d.ServicioId)
                    .HasConstraintName("fk_servicio_facturadetalle$servicioID");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.ToTable("pago");

                entity.Property(e => e.PagoId).HasColumnName("pagoID");

                entity.Property(e => e.CuentaBancariaId).HasColumnName("cuentaBancariaID");

                entity.Property(e => e.CuentaBancoTecnico)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cuentaBancoTecnico");

                entity.Property(e => e.MontoPagado).HasColumnName("montoPagado");

                entity.HasOne(d => d.CuentaBancaria)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.CuentaBancariaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cuentaBancaria_pago$cuentaBancariaID");

                entity.HasOne(d => d.CuentaBancoTecnicoNavigation)
                    .WithMany(p => p.Pagos)
                    .HasPrincipalKey(p => p.CuentaBancoTecnico)
                    .HasForeignKey(d => d.CuentaBancoTecnico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tecnico_pago$cuentaBancoTecnico");
            });

            modelBuilder.Entity<Paquete>(entity =>
            {
                entity.ToTable("paquete");

                entity.Property(e => e.PaqueteId).HasColumnName("paqueteID");

                entity.Property(e => e.DescripcionPaquete)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcionPaquete");

                entity.Property(e => e.Duracion)
                    .HasColumnName("duracion")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EstadoPaquete).HasColumnName("estadoPaquete");

                entity.HasOne(d => d.EstadoPaqueteNavigation)
                    .WithMany(p => p.Paquetes)
                    .HasForeignKey(d => d.EstadoPaquete)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_servicio_estadoPaquete$servicioID");
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.ToTable("servicio");

                entity.Property(e => e.ServicioId).HasColumnName("servicioID");

                entity.Property(e => e.DescripcionServicio)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcionServicio");

                entity.Property(e => e.EstadoServicio).HasColumnName("estadoServicio");

                entity.Property(e => e.PrecioServicio).HasColumnName("precioServicio");

                entity.HasOne(d => d.EstadoServicioNavigation)
                    .WithMany(p => p.Servicios)
                    .HasForeignKey(d => d.EstadoServicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_servicio_estadoServicio$servicioID");
            });

            modelBuilder.Entity<ServicioPaquete>(entity =>
            {
                entity.HasKey(e => new { e.ServicioId, e.PaqueteId })
                    .HasName("pk_servicioPaquete");

                entity.ToTable("servicioPaquete");

                entity.Property(e => e.ServicioId).HasColumnName("servicioID");

                entity.Property(e => e.PaqueteId).HasColumnName("paqueteID");

                entity.Property(e => e.EstadoServicioPaquete).HasColumnName("estadoServicioPaquete");

                entity.HasOne(d => d.Paquete)
                    .WithMany(p => p.ServicioPaquetes)
                    .HasForeignKey(d => d.PaqueteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_paquete_serviciopaquete$paqueteID");

                entity.HasOne(d => d.Servicio)
                    .WithMany(p => p.ServicioPaquetes)
                    .HasForeignKey(d => d.ServicioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_servicio_serviciopaquete$servicioID");
            });

            modelBuilder.Entity<Tecnico>(entity =>
            {
                entity.ToTable("tecnico");

                entity.HasIndex(e => e.CodigoTecnico, "uk_codigoTecnico")
                    .IsUnique();

                entity.HasIndex(e => e.CuentaBancoTecnico, "uk_cuentaBancoTecnico")
                    .IsUnique();

                entity.Property(e => e.TecnicoId).HasColumnName("tecnicoID");

                entity.Property(e => e.CodigoTecnico)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigoTecnico");

                entity.Property(e => e.Correo)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.CuentaBancoTecnico)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cuentaBancoTecnico");

                entity.Property(e => e.Direccion)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.EstadoTecnico).HasColumnName("estadoTecnico");

                entity.Property(e => e.Numero)
                    .IsUnicode(false)
                    .HasColumnName("numero");

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("primerApellido");

                entity.Property(e => e.PrimerNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("primerNombre");

                entity.Property(e => e.Salario).HasColumnName("salario");

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("segundoApellido");

                entity.Property(e => e.SegundoNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("segundoNombre");

                entity.HasOne(d => d.EstadoTecnicoNavigation)
                    .WithMany(p => p.Tecnicos)
                    .HasForeignKey(d => d.EstadoTecnico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_estadoServicio_tecnico$estadoTecnicoID");
            });

            modelBuilder.Entity<TipoCliente>(entity =>
            {
                entity.ToTable("tipoCliente");

                entity.Property(e => e.TipoClienteId).HasColumnName("tipoClienteID");

                entity.Property(e => e.DescripcionCliente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcionCliente");
            });

            modelBuilder.Entity<TipoMonedum>(entity =>
            {
                entity.HasKey(e => e.TipoMonedaId)
                    .HasName("pk_tipoMoneda");

                entity.ToTable("tipoMoneda");

                entity.Property(e => e.TipoMonedaId).HasColumnName("tipoMonedaID");

                entity.Property(e => e.DescripcionMoneda)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcionMoneda");
            });

            modelBuilder.Entity<VwAsigancionesTecnico>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_asigancionesTecnico");

                entity.Property(e => e.NombreTecnico)
                    .HasMaxLength(101)
                    .IsUnicode(false);

                entity.Property(e => e.TecnicoId).HasColumnName("tecnicoID");
            });

            modelBuilder.Entity<VwClientesContrato>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_clientesContratos");

                entity.Property(e => e.ClienteContratoId).HasColumnName("clienteContratoID");

                entity.Property(e => e.ClienteId).HasColumnName("clienteID");

                entity.Property(e => e.ClienteNombre)
                    .IsUnicode(false)
                    .HasColumnName("clienteNombre");

                entity.Property(e => e.DescripcionPaquete)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcionPaquete");

                entity.Property(e => e.Duracion).HasColumnName("duracion");

                entity.Property(e => e.FacturaId).HasColumnName("facturaID");
            });

            modelBuilder.Entity<VwFactura>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_Facturas");

                entity.Property(e => e.Cliente)
                    .IsUnicode(false)
                    .HasColumnName("cliente");

                entity.Property(e => e.DescripcionPaquete)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcionPaquete");

                entity.Property(e => e.DescripcionServicio)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcionServicio");

                entity.Property(e => e.EstadoFactura)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FacturaId).HasColumnName("facturaID");

                entity.Property(e => e.FechaLimite)
                    .HasColumnType("date")
                    .HasColumnName("fechaLimite");

                entity.Property(e => e.Nombrebanco)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombrebanco");

                entity.Property(e => e.NumeroCuenta)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("numeroCuenta");

                entity.Property(e => e.Precio).HasColumnName("precio");
            });

            modelBuilder.Entity<VwPreciopaquete>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_preciopaquetes");

                entity.Property(e => e.DescripcionPaquete)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcionPaquete");

                entity.Property(e => e.PaqueteId).HasColumnName("paqueteID");

                entity.Property(e => e.TotalPrecio).HasColumnName("totalPrecio");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
