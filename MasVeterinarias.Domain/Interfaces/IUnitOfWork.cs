using MasVeterinarias.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace MasVeterinarias.Domain.Interfaces
{
    public  interface IUnitOfWork : IDisposable
    {
        public IRepository<Producto> ProductoRepository { get; }       
        public IRepository<Cliente> ClienteRepository { get; }
        public IRepository<Cita> CitaRepository { get; }
        public IRepository<Empleado> EmpleadoRepository { get; }
        public IRepository<Veterinaria> VeterinariaRepository { get; }
        public IRepository<Usuario> UsuarioRepository { get; }
        public IRepository<DetallesCita> DetallesCitaRepository { get; }
        public IRepository<Servicio> ServicioRepository { get; }

        public IRepository<Categoria> CategoriaRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
