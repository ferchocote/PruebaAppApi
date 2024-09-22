using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PruebaAppApi.DataAccess.Entities;

public partial class PruebaTiendaContext : DbContext
{
    public PruebaTiendaContext()
    {
    }

    public PruebaTiendaContext(DbContextOptions<PruebaTiendaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<DetalleProducto> DetalleProducto { get; set; }

    public virtual DbSet<Producto> Producto { get; set; }

    public virtual DbSet<ProductoDeseado> ProductoDeseado { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IDCategoria);

            entity.Property(e => e.IDCategoria).ValueGeneratedNever();
            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Descripcion).HasMaxLength(50);
        });

        modelBuilder.Entity<DetalleProducto>(entity =>
        {
            entity.HasKey(e => e.IDDetalleProducto);

            entity.Property(e => e.IDDetalleProducto).ValueGeneratedNever();
            entity.Property(e => e.Color).HasMaxLength(15);
            entity.Property(e => e.Precio).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.Talla)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.IDProductoNavigation).WithMany(p => p.DetalleProducto)
                .HasForeignKey(d => d.IDProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleProducto_Producto");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IDProducto);

            entity.Property(e => e.IDProducto).ValueGeneratedNever();
            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Descripcion).HasMaxLength(50);

            entity.HasOne(d => d.IDCategoriaNavigation).WithMany(p => p.Producto)
                .HasForeignKey(d => d.IDCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Producto_Categoria");
        });

        modelBuilder.Entity<ProductoDeseado>(entity =>
        {
            entity.HasKey(e => e.IDProductoDeseado);

            entity.Property(e => e.IDProductoDeseado).ValueGeneratedNever();

            entity.HasOne(d => d.IDProductoNavigation).WithMany(p => p.ProductoDeseado)
                .HasForeignKey(d => d.IDProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductoDeseado_Producto");

            entity.HasOne(d => d.IDUsuarioNavigation).WithMany(p => p.ProductoDeseado)
                .HasForeignKey(d => d.IDUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductoDeseado_Usuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IDUsuario);

            entity.Property(e => e.IDUsuario).ValueGeneratedNever();
            entity.Property(e => e.NumeroDocumento).HasMaxLength(50);
            entity.Property(e => e.PrimerApellido).HasMaxLength(50);
            entity.Property(e => e.PrimerNombre).HasMaxLength(50);
            entity.Property(e => e.SegundoApellido).HasMaxLength(50);
            entity.Property(e => e.SegundoNombre).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
