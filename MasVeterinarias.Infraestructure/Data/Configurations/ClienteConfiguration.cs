using MasVeterinarias.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasVeterinarias.Infraestructure.Data.Configurations
{
    public  class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.Apellido)
                   .HasMaxLength(50)
                   .IsUnicode(false);

            builder.Property(e => e.CreateAt).HasColumnType("datetime");

            builder.Property(e => e.Direccion)
                .HasMaxLength(75)
                .IsUnicode(false);

            builder.Property(e => e.Nombre)
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.Telefono).HasColumnType("text");

            builder.Property(e => e.UpdateAt).HasColumnType("datetime");

            builder.HasOne(d => d.Usuario)
                .WithMany(p => p.Cliente)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("RefUsuario2");
        }

    }
}
