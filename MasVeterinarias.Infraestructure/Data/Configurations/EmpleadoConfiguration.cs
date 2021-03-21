using MasVeterinarias.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasVeterinarias.Infraestructure.Data.Configurations
{
    public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.Property(e => e.CreateAt).HasColumnType("datetime");

            builder.Property(e => e.Nombre)
                .HasMaxLength(75)
                .IsUnicode(false);

            builder.Property(e => e.Telefono).HasColumnType("text");

            builder.Property(e => e.UpdateAt).HasColumnType("datetime");

            builder.HasOne(d => d.Servicio)
                .WithMany(p => p.Empleado)
                .HasForeignKey(d => d.ServicioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefServicio20");

            builder.HasOne(d => d.Veterinaria)
                .WithMany(p => p.Empleado)
                .HasForeignKey(d => d.VeterinariaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefVeterinaria7");
        }

    }
}
