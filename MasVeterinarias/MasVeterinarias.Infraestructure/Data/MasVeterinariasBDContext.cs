using System;
using MasVeterinarias.Domain.Entities;
using MasVeterinarias.Infraestructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MasVeterinarias.Infraestructure.Data
{
    public partial class MasVeterinariasBDContext : DbContext
    {
        public MasVeterinariasBDContext()
        {
        }

        public MasVeterinariasBDContext(DbContextOptions<MasVeterinariasBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Cita> Cita { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<DetallesCita> DetallesCita { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Servicio> Servicio { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Veterinaria> Veterinaria { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Categoria>(new CategoriaConfiguration());
            modelBuilder.ApplyConfiguration<Cita>(new CitaConfiguration());
            modelBuilder.ApplyConfiguration<Cliente>(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration<DetallesCita>(new DetallesCitaConfiguration());
            modelBuilder.ApplyConfiguration<Empleado>(new EmpleadoConfiguration());
            modelBuilder.ApplyConfiguration<Producto>(new ProductoConfiguration());
            modelBuilder.ApplyConfiguration<Usuario>(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration<Servicio>(new ServicioConfiguration());            
            modelBuilder.ApplyConfiguration<Veterinaria>(new VeterinariaConfiguration());
            
        }
       
    }
}
