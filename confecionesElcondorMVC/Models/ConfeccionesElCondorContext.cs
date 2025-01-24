using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace confecionesElcondorMVC.Models;

public partial class ConfeccionesElCondorContext : DbContext
{
    public ConfeccionesElCondorContext()
    {
    }

    public ConfeccionesElCondorContext(DbContextOptions<ConfeccionesElCondorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<TiposDocumento> TiposDocumentos { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Server=DESKTOP-B76V0T4\\SQLEXPRESS;Database=ConfeccionesElCondor;Trusted_Connection=SSPI;MultipleActiveResultSets=true;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.IdArea).HasName("PK__Areas__2FC141AA6F22D047");

            entity.HasIndex(e => e.NombreArea, "UQ__Areas__D5E8EEB5F1A53EB6").IsUnique();

            entity.Property(e => e.NombreArea)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__CE6D8B9EB96BCF59");

            entity.HasIndex(e => e.NumeroDocumento, "UQ__Empleado__A420258879201275").IsUnique();

            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PrimerNombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SegundoNombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAreaNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdArea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Empleados__IdAre__628FA481");

            entity.HasOne(d => d.IdTipoDocumentoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdTipoDocumento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Empleados__IdTip__619B8048");
        });

        modelBuilder.Entity<TiposDocumento>(entity =>
        {
            entity.HasKey(e => e.IdTipoDocumento).HasName("PK__TiposDoc__3AB3332F8630851F");

            entity.ToTable("TiposDocumento");

            entity.HasIndex(e => e.NombreTipo, "UQ__TiposDoc__7586661CB3A70736").IsUnique();

            entity.Property(e => e.NombreTipo)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
