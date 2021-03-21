using MasVeterinarias.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasVeterinarias.Infraestructure.Data.Configurations
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>  
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.Property(e => e.CreateAt).HasColumnType("datetime");

            builder.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Detalles)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Especie)
                .HasMaxLength(75)
                .IsUnicode(false);

            builder.Property(e => e.Etapa)
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.Imagen)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Marca)
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Raza)
                .HasMaxLength(75)
                .IsUnicode(false);

            builder.Property(e => e.UpdateAt).HasColumnType("datetime");

            builder.HasOne(d => d.Veterinaria)
                .WithMany(p => p.Producto)
                .HasForeignKey(d => d.VeterinariaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefVeterinaria4");
        }
    }
}
