using MasVeterinarias.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasVeterinarias.Infraestructure.Data.Configurations
{
    public  class VeterinariaConfiguration : IEntityTypeConfiguration<Veterinaria>
    {
        public void Configure(EntityTypeBuilder<Veterinaria> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.CreateAt).HasColumnType("datetime");

            builder.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.DiasLaborales)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Direccion)
                .HasMaxLength(75)
                .IsUnicode(false);

            builder.Property(e => e.HoraApertura)
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.HoraCierre)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();

            builder.Property(e => e.Imagen)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Nombre)
                .HasMaxLength(75)
                .IsUnicode(false);

            builder.Property(e => e.Representante)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.Telefono).HasColumnType("text");

            builder.Property(e => e.UpdateAt).HasColumnType("datetime");

            builder.HasOne(d => d.Usuario)
                .WithMany(p => p.Veterinaria)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("RefUsuario3");
        }

    }
}
