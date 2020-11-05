using MasVeterinarias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MasVeterinarias.Domain.Interfaces
{
    public  interface IUnitOfWork : IDisposable
    {
        public IRepository<Producto> ProductoRepository { get; }
        public ICitaRepository VentaRepository { get; }
        public IRepository<Cliente> ClienteRepository { get; }
        public IRepository<Cita> CitaRepository { get; }
        public IRepository<Empleado> EmpleadoRepository { get; }
        public IRepository<Veterinaria> VeterinariaRepository { get; }
        public IRepository<Usuario> UsuarioRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
