using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Modelo;

namespace Repositorio.DBContext;

public partial class DbecommerceSalonComunalContext : DbContext
{
    public DbecommerceSalonComunalContext()
    {
    }

    public DbecommerceSalonComunalContext(DbContextOptions<DbecommerceSalonComunalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<DetalleReserva> DetalleReserva { get; set; }

    public virtual DbSet<Producto> Producto { get; set; }

    public virtual DbSet<Reserva> Reserva { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__A3C02A1013259070");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DetalleReserva>(entity =>
        {
            entity.HasKey(e => e.IdDetalleReserva).HasName("PK__DetalleR__388ACBC7B5B8F3D9");

            entity.ToTable("DetalleReserva");

            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleReservas)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__DetalleRe__IdPro__45F365D3");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.DetalleReservas)
                .HasForeignKey(d => d.IdReserva)
                .HasConstraintName("FK__DetalleRe__IdRes__44FF419A");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__09889210420B7B24");

            entity.ToTable("Producto");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Imagen).IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__Producto__IdCate__3A81B327");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("PK__Reserva__0E49C69DAF18029C");

            entity.ToTable("Reserva");

            entity.Property(e => e.FechaEvento).HasColumnType("date");
            entity.Property(e => e.FechaReserva)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.TotalPagado).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TotalPrecio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Reserva__IdUsuar__412EB0B6");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97AF276791");

            entity.ToTable("Usuario");

            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
