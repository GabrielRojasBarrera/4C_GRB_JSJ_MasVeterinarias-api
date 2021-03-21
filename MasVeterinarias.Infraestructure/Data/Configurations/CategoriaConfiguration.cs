using MasVeterinarias.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasVeterinarias.Infraestructure.Data.Configurations
{
    public  class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.Property(e => e.CreateAt).HasColumnType("datetime");

            builder.Property(e => e.Nombre)
                .HasMaxLength(75)
                .IsUnicode(false);

            builder.Property(e => e.UpdateAt).HasColumnType("datetime");
        }
    }
}
