using MasVeterinarias.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasVeterinarias.Infraestructure.Data.Configurations
{
    public  class ServicioConfiguration : IEntityTypeConfiguration<Servicio>
    {
        public void Configure(EntityTypeBuilder<Servicio> builder)
        {
            builder.Property(e => e.CreateAt).HasColumnType("datetime");

            builder.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Detalles)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Disponibilidad)
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.Especie)
                .HasMaxLength(75)
                .IsUnicode(false);

            builder.Property(e => e.Imagen)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Raza)
                .HasMaxLength(75)
                .IsUnicode(false);

            builder.Property(e => e.UpdateAt).HasColumnType("datetime");

            builder.HasOne(d => d.Categoria)
                .WithMany(p => p.Servicio)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefCategoria10");

            builder.HasOne(d => d.Veterinaria)
                .WithMany(p => p.Servicio)
                .HasForeignKey(d => d.VeterinariaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefVeterinaria13");
        }

    }
}
