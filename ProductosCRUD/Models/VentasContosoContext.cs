using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProductosCRUD.Models;

public partial class VentasContosoContext : DbContext
{
    public VentasContosoContext()
    {
    }

    public VentasContosoContext(DbContextOptions<VentasContosoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorias> Categorias { get; set; }

    public virtual DbSet<Descuentos> Descuentos { get; set; }

    public virtual DbSet<Geograficos> Geograficos { get; set; }

    public virtual DbSet<Productos> Productos { get; set; }

    public virtual DbSet<Subcategorias> Subcategorias { get; set; }

    public virtual DbSet<Tiendas> Tiendas { get; set; }

    public virtual DbSet<Tipo> Tipo { get; set; }

    public virtual DbSet<Ventas> Ventas { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-CU4P7U7\\SQLEXPRESS;Database=VentasContoso;User=sa;Pwd=#klOF20-%=1_ZzXpoqT80/7/?;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorias>(entity =>
        {
            entity.HasKey(e => e.Categoriakey);

            entity.Property(e => e.Categoriakey)
                .ValueGeneratedNever()
                .HasColumnName("CATEGORIAKEY");
            entity.Property(e => e.Categoria)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("CATEGORIA");
        });

        modelBuilder.Entity<Descuentos>(entity =>
        {
            entity.HasKey(e => e.Descuentokey);

            entity.Property(e => e.Descuentokey)
                .ValueGeneratedNever()
                .HasColumnName("DESCUENTOKEY");
            entity.Property(e => e.Etiqueta)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ETIQUETA");
            entity.Property(e => e.Fechafinal)
                .HasColumnType("datetime")
                .HasColumnName("FECHAFINAL");
            entity.Property(e => e.Fechainicial)
                .HasColumnType("datetime")
                .HasColumnName("FECHAINICIAL");
            entity.Property(e => e.Nombredescuento)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("NOMBREDESCUENTO");
            entity.Property(e => e.Porcentaje)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("PORCENTAJE");
        });

        modelBuilder.Entity<Geograficos>(entity =>
        {
            entity.HasKey(e => e.Geograficokey);

            entity.Property(e => e.Geograficokey)
                .ValueGeneratedNever()
                .HasColumnName("GEOGRAFICOKEY");
            entity.Property(e => e.Continente)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("CONTINENTE");
            entity.Property(e => e.Pais)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PAIS");
        });

        modelBuilder.Entity<Productos>(entity =>
        {
            entity.HasKey(e => e.Productokey);

            entity.Property(e => e.Productokey)
                .ValueGeneratedNever()
                .HasColumnName("PRODUCTOKEY");
            entity.Property(e => e.Claseid).HasColumnName("CLASEID");
            entity.Property(e => e.Coloid).HasColumnName("COLOID");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("COLOR");
            entity.Property(e => e.Costo)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("COSTO");
            entity.Property(e => e.Descripción)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCIÓN");
            entity.Property(e => e.Manufactura)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MANUFACTURA");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MARCA");
            entity.Property(e => e.Medida)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MEDIDA");
            entity.Property(e => e.Nombre)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Nombreclase)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("NOMBRECLASE");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("PRECIO");
            entity.Property(e => e.Subcategoriakey).HasColumnName("SUBCATEGORIAKEY");
            entity.Property(e => e.Tamaño)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("TAMAÑO");
        });

        modelBuilder.Entity<Subcategorias>(entity =>
        {
            entity.HasKey(e => e.Subcategoriakey);

            entity.Property(e => e.Subcategoriakey)
                .ValueGeneratedNever()
                .HasColumnName("SUBCATEGORIAKEY");
            entity.Property(e => e.Categoriakey).HasColumnName("CATEGORIAKEY");
            entity.Property(e => e.Subcategoria)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("SUBCATEGORIA");
        });

        modelBuilder.Entity<Tiendas>(entity =>
        {
            entity.HasKey(e => e.Tiendakey);

            entity.Property(e => e.Tiendakey)
                .ValueGeneratedNever()
                .HasColumnName("TIENDAKEY");
            entity.Property(e => e.Cantidadempleados).HasColumnName("CANTIDADEMPLEADOS");
            entity.Property(e => e.Geograficokey).HasColumnName("GEOGRAFICOKEY");
            entity.Property(e => e.Nombretienda)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("NOMBRETIENDA");
            entity.Property(e => e.Tamañoarea).HasColumnName("TAMAÑOAREA");
            entity.Property(e => e.Tipotienda)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("TIPOTIENDA");
        });

        modelBuilder.Entity<Tipo>(entity =>
        {
            entity.HasKey(e => e.Tipokey);

            entity.Property(e => e.Tipokey)
                .ValueGeneratedNever()
                .HasColumnName("TIPOKEY");
            entity.Property(e => e.Tipo1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TIPO");
        });

        modelBuilder.Entity<Ventas>(entity =>
        {
            entity.HasKey(e => e.Ordenid);

            entity.Property(e => e.Ordenid)
                .ValueGeneratedNever()
                .HasColumnName("ORDENID");
            entity.Property(e => e.Cantidaddevoluciones).HasColumnName("CANTIDADDEVOLUCIONES");
            entity.Property(e => e.Cantidadvendida).HasColumnName("CANTIDADVENDIDA");
            entity.Property(e => e.Descuentokey).HasColumnName("DESCUENTOKEY");
            entity.Property(e => e.Fechakey)
                .HasColumnType("datetime")
                .HasColumnName("FECHAKEY");
            entity.Property(e => e.Productokey).HasColumnName("PRODUCTOKEY");
            entity.Property(e => e.Tiendakey).HasColumnName("TIENDAKEY");
            entity.Property(e => e.Tipokey).HasColumnName("TIPOKEY");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
