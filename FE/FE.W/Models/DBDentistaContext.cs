using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE.W.Models
{
    public partial class DBDentistaContext : DbContext
    {
        public DBDentistaContext()
        {
        }

        public DBDentistaContext(DbContextOptions<DBDentistaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Citas> Citas { get; set; }
        public virtual DbSet<Contacto> Contacto { get; set; }
        public virtual DbSet<Dentista> Dentista { get; set; }
        public virtual DbSet<DetalleFactura> DetalleFactura { get; set; }
        public virtual DbSet<Eventos> Eventos { get; set; }
        public virtual DbSet<ExpedientePaciente> ExpedientePaciente { get; set; }
        public virtual DbSet<FacturaPaciente> FacturaPaciente { get; set; }
        public virtual DbSet<Ingresos> Ingresos { get; set; }
        public virtual DbSet<Inventario> Inventario { get; set; }
        public virtual DbSet<PacienteNuevo> PacienteNuevo { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Recepcionista> Recepcionista { get; set; }
        public virtual DbSet<Reunion> Reunion { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<Tratamiento> Tratamiento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-H0KQQD2;Database=DBDentista;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Citas>(entity =>
            {
                entity.HasKey(e => e.IdCitas)
                    .HasName("PK__CITAS__376D51DFC8A40A3B");

                entity.ToTable("CITAS");

                entity.Property(e => e.IdCitas).HasColumnName("ID_CITAS");

                entity.Property(e => e.ApellidoPacienteCita)
                    .IsRequired()
                    .HasColumnName("APELLIDO_PACIENTE_CITA")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.AñoCita).HasColumnName("AÑO_CITA");

                entity.Property(e => e.DíaCita).HasColumnName("DÍA_CITA");

                entity.Property(e => e.HoraCita).HasColumnName("HORA_CITA");

                entity.Property(e => e.MesCita)
                    .IsRequired()
                    .HasColumnName("MES_CITA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NombrePacienteCita)
                    .IsRequired()
                    .HasColumnName("NOMBRE_PACIENTE_CITA")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Contacto>(entity =>
            {
                entity.HasKey(e => e.IdContacto)
                    .HasName("PK__CONTACTO__8806CC1F4D354AA0");

                entity.ToTable("CONTACTO");

                entity.Property(e => e.IdContacto).HasColumnName("ID_CONTACTO");

                entity.Property(e => e.ApellidoContacto)
                    .IsRequired()
                    .HasColumnName("APELLIDO_CONTACTO")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoContacto)
                    .IsRequired()
                    .HasColumnName("CORREO_CONTACTO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionContacto)
                    .IsRequired()
                    .HasColumnName("DIRECCION_CONTACTO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreContacto)
                    .IsRequired()
                    .HasColumnName("NOMBRE_CONTACTO")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoContacto)
                    .IsRequired()
                    .HasColumnName("TELEFONO_CONTACTO")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dentista>(entity =>
            {
                entity.HasKey(e => e.IdDentista)
                    .HasName("PK__DENTISTA__AC2706723509684B");

                entity.ToTable("DENTISTA");

                entity.Property(e => e.IdDentista).HasColumnName("ID_DENTISTA");

                entity.Property(e => e.ApellidoDentista)
                    .IsRequired()
                    .HasColumnName("APELLIDO_DENTISTA")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasColumnName("CONTRASEÑA")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.NombreDentista)
                    .IsRequired()
                    .HasColumnName("NOMBRE_DENTISTA")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetalleFactura>(entity =>
            {
                entity.HasKey(e => e.CodigoDetalle)
                    .HasName("PK__DETALLE___C644C59B698D5CC9");

                entity.ToTable("DETALLE_FACTURA");

                entity.Property(e => e.CodigoDetalle).HasColumnName("CODIGO_DETALLE");

                entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");

                entity.Property(e => e.CodigoFactura).HasColumnName("CODIGO_FACTURA");

                entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");

                entity.Property(e => e.IdTratamiento).HasColumnName("ID_TRATAMIENTO");

                entity.Property(e => e.PrecioFinal)
                    .IsRequired()
                    .HasColumnName("PRECIO_FINAL")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoFacturaNavigation)
                    .WithMany(p => p.DetalleFactura)
                    .HasForeignKey(d => d.CodigoFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DETALLE_F__CODIG__34C8D9D1");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetalleFactura)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DETALLE_F__ID_PR__36B12243");

                entity.HasOne(d => d.IdTratamientoNavigation)
                    .WithMany(p => p.DetalleFactura)
                    .HasForeignKey(d => d.IdTratamiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DETALLE_F__ID_TR__35BCFE0A");
            });

            modelBuilder.Entity<Eventos>(entity =>
            {
                entity.HasKey(e => e.IdEvento)
                    .HasName("PK__EVENTOS__748D7F35C07363D0");

                entity.ToTable("EVENTOS");

                entity.Property(e => e.IdEvento).HasColumnName("ID_EVENTO");

                entity.Property(e => e.AñoEvento).HasColumnName("AÑO_EVENTO");

                entity.Property(e => e.DetallesEvento)
                    .IsRequired()
                    .HasColumnName("DETALLES_EVENTO")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.DíaEvento).HasColumnName("DÍA_EVENTO");

                entity.Property(e => e.MesEvento)
                    .IsRequired()
                    .HasColumnName("MES_EVENTO")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExpedientePaciente>(entity =>
            {
                entity.HasKey(e => e.IdPaciente)
                    .HasName("PK__EXPEDIEN__62CD58D7D5FD28DB");

                entity.ToTable("EXPEDIENTE_PACIENTE");

                entity.Property(e => e.IdPaciente).HasColumnName("ID_PACIENTE");

                entity.Property(e => e.ApellidoPaciente)
                    .IsRequired()
                    .HasColumnName("APELLIDO_PACIENTE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula).HasColumnName("CEDULA");

                entity.Property(e => e.Edad).HasColumnName("EDAD");

                entity.Property(e => e.FechaNacimiento)
                    .IsRequired()
                    .HasColumnName("FECHA_NACIMIENTO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombrePaciente)
                    .IsRequired()
                    .HasColumnName("NOMBRE_PACIENTE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Padecimientos)
                    .IsRequired()
                    .HasColumnName("PADECIMIENTOS")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FacturaPaciente>(entity =>
            {
                entity.HasKey(e => e.CodigoFactura)
                    .HasName("PK__FACTURA___73C59E9F2955F0EC");

                entity.ToTable("FACTURA_PACIENTE");

                entity.Property(e => e.CodigoFactura).HasColumnName("CODIGO_FACTURA");

                entity.Property(e => e.Descuento)
                    .IsRequired()
                    .HasColumnName("DESCUENTO")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FechaFactura)
                    .IsRequired()
                    .HasColumnName("FECHA_FACTURA")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IdPaciente).HasColumnName("ID_PACIENTE");

                entity.Property(e => e.Iva)
                    .IsRequired()
                    .HasColumnName("IVA")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.FacturaPaciente)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FACTURA_P__ID_PA__31EC6D26");
            });

            modelBuilder.Entity<Ingresos>(entity =>
            {
                entity.HasKey(e => e.IdIngreso)
                    .HasName("PK__INGRESOS__627D3FC48F6ACC33");

                entity.ToTable("INGRESOS");

                entity.Property(e => e.IdIngreso).HasColumnName("ID_INGRESO");

                entity.Property(e => e.CodigoDetalle).HasColumnName("CODIGO_DETALLE");

                entity.Property(e => e.FechaIngreso)
                    .IsRequired()
                    .HasColumnName("FECHA_INGRESO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoDetalleNavigation)
                    .WithMany(p => p.Ingresos)
                    .HasForeignKey(d => d.CodigoDetalle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__INGRESOS__CODIGO__3B75D760");
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasKey(e => e.IdInventario)
                    .HasName("PK__INVENTAR__C7FDF20694B38F4C");

                entity.ToTable("INVENTARIO");

                entity.Property(e => e.IdInventario).HasColumnName("ID_INVENTARIO");

                entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");

                entity.Property(e => e.Descripción)
                    .IsRequired()
                    .HasColumnName("DESCRIPCIÓN")
                    .HasMaxLength(70)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PacienteNuevo>(entity =>
            {
                entity.HasKey(e => e.IdPacienteNuevo)
                    .HasName("PK__PACIENTE__EBC93A610DEC4505");

                entity.ToTable("PACIENTE_NUEVO");

                entity.Property(e => e.IdPacienteNuevo).HasColumnName("ID_PACIENTE_NUEVO");

                entity.Property(e => e.ApellidoPacienteNuevo)
                    .IsRequired()
                    .HasColumnName("APELLIDO_PACIENTE_NUEVO")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasColumnName("CONTRASEÑA")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.NombrePacienteNuevo)
                    .IsRequired()
                    .HasColumnName("NOMBRE_PACIENTE_NUEVO")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__PRODUCTO__88BD035796F4FBDD");

                entity.ToTable("PRODUCTO");

                entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");

                entity.Property(e => e.NombreProducto)
                    .HasColumnName("NOMBRE_PRODUCTO")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioProducto)
                    .HasColumnName("PRECIO_PRODUCTO")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Recepcionista>(entity =>
            {
                entity.HasKey(e => e.IdRecepcionista)
                    .HasName("PK__RECEPCIO__BB7BCE766FA8E472");

                entity.ToTable("RECEPCIONISTA");

                entity.Property(e => e.IdRecepcionista).HasColumnName("ID_RECEPCIONISTA");

                entity.Property(e => e.ApellidoRecepcionista)
                    .IsRequired()
                    .HasColumnName("APELLIDO_RECEPCIONISTA")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasColumnName("CONTRASEÑA")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.NombreRecepcionista)
                    .IsRequired()
                    .HasColumnName("NOMBRE_RECEPCIONISTA")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reunion>(entity =>
            {
                entity.HasKey(e => e.NumeroReunion)
                    .HasName("PK__REUNION__9434E1AA4F0505E0");

                entity.ToTable("REUNION");

                entity.Property(e => e.NumeroReunion).HasColumnName("NUMERO_REUNION");

                entity.Property(e => e.DetallesReunion)
                    .IsRequired()
                    .HasColumnName("DETALLES_REUNION")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Dia)
                    .IsRequired()
                    .HasColumnName("DIA")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.IdDentista).HasColumnName("ID_DENTISTA");

                entity.Property(e => e.IdRecepcionista).HasColumnName("ID_RECEPCIONISTA");

                entity.HasOne(d => d.IdDentistaNavigation)
                    .WithMany(p => p.Reunion)
                    .HasForeignKey(d => d.IdDentista)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__REUNION__ID_DENT__403A8C7D");

                entity.HasOne(d => d.IdRecepcionistaNavigation)
                    .WithMany(p => p.Reunion)
                    .HasForeignKey(d => d.IdRecepcionista)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__REUNION__ID_RECE__412EB0B6");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => e.IdReview)
                    .HasName("PK__REVIEW__C02ADD2012E73AEF");

                entity.ToTable("REVIEW");

                entity.Property(e => e.IdReview).HasColumnName("ID_REVIEW");

                entity.Property(e => e.Comentario)
                    .IsRequired()
                    .HasColumnName("COMENTARIO")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Estrellas)
                    .IsRequired()
                    .HasColumnName("ESTRELLAS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IdCitas).HasColumnName("ID_CITAS");

                entity.Property(e => e.NombrePacienteCita)
                    .IsRequired()
                    .HasColumnName("NOMBRE_PACIENTE_CITA")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCitasNavigation)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.IdCitas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__REVIEW__ID_CITAS__440B1D61");
            });

            modelBuilder.Entity<Tratamiento>(entity =>
            {
                entity.HasKey(e => e.IdTratamiento)
                    .HasName("PK__TRATAMIE__883645DD221E1571");

                entity.ToTable("TRATAMIENTO");

                entity.Property(e => e.IdTratamiento).HasColumnName("ID_TRATAMIENTO");

                entity.Property(e => e.CostoTratamiento)
                    .HasColumnName("COSTO_TRATAMIENTO")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NombreTratamiento)
                    .IsRequired()
                    .HasColumnName("NOMBRE_TRATAMIENTO")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
