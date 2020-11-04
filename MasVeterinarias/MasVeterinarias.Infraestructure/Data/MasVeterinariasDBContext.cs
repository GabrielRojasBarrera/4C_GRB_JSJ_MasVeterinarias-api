using MasVeterinarias.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasVeterinarias.Infraestructure.Data
{
    public  class MasVeterinariasDBContext : DbContext
    {
        public MasVeterinariasDBContext(DbContextOptions<MasVeterinariasDBContext> options) : base(options)
        {
        }

        DbSet<Cita> Cita { get; set; }
        DbSet<Detalles> Detalles { get; set; }
        DbSet<Cliente> Cliente { get; set; }
        DbSet<Empleado> Empleado { get; set; }
        DbSet<Usuario> Usuario { get; set; }
        DbSet<Veterinaria> Veterinaria { get; set; }
        DbSet<Producto> Producto { get; set; }
        DbSet<Servicio> Servicio { get; set; }
        DbSet<Vacacion> Vacacion { get; set; }
       

    }
}
