using MasVeterinarias.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasVeterinarias.Infraestructure.Data.Configurations
{
    public  class CitaConfiguration : IEntityTypeConfiguration<Cita>    
    {
        public void Configure(EntityTypeBuilder<Cita> builder)
        {
            builder.Property(e => e.CreateAt).HasColumnType("datetime");

            builder.Property(e => e.Fecha).HasColumnType("date");

            builder.Property(e => e.NombreMascota).HasMaxLength(100);

            builder.Property(e => e.UpdateAt).HasColumnType("datetime");

            builder.Property(e => e.Estatus)
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.Hora)
               .HasMaxLength(10)
               .IsUnicode(false);

            builder.HasOne(d => d.Cliente)
                .WithMany(p => p.Cita)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefCliente6");

            builder.HasOne(d => d.Servicio)
                .WithMany(p => p.Cita)
                .HasForeignKey(d => d.ServicioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefServicio18");

            builder.HasOne(d => d.Veterinaria)
                .WithMany(p => p.Cita)
                .HasForeignKey(d => d.VeterinariaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefVeterinaria5");
        }

    }
}
