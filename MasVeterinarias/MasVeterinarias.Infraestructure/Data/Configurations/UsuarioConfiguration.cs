using MasVeterinarias.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasVeterinarias.Infraestructure.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(e => e.CreateAt).HasColumnType("datetime");

            builder.Property(e => e.Email).HasMaxLength(100);

            builder.Property(e => e.Password).HasMaxLength(100);

            builder.Property(e => e.UpdateAt).HasColumnType("datetime");


            builder.Ignore(e => e.CreateAt);
            builder.Ignore(e => e.CreatedBy);
            builder.Ignore(e => e.UpdateAt);
            builder.Ignore(e => e.UpdatedBy);
            builder.Ignore(e => e.Status);





        }

    }
}