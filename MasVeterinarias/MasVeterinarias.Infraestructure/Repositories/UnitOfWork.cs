
using MasVeterinarias.Domain.Entities;
using MasVeterinarias.Domain.Interfaces;
using MasVeterinarias.Infraestructure.Data;
using System.Threading.Tasks;

namespace MasVeterinarias.Infraestructure.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly MasVeterinariasBDContext _context;
        private readonly IRepository<Producto> _productoRepository;
        private readonly IRepository<Cliente> _clienteRepository;
        private readonly IRepository<Cita> _citaRepository;
        private readonly IRepository<Empleado> _empleadoRepository;
        private readonly IRepository<Veterinaria> _veterinariaRepository;
        private readonly IRepository<Usuario> _usuarioRepository;
        private readonly IRepository<DetallesCita> _detallesCitaRepository;
        private readonly IRepository<Servicio> _servicioRepository;
        private readonly IRepository<Categoria> _categoriaRepository;

        public UnitOfWork(MasVeterinariasBDContext context)
        {
            this._context = context;
        }

        public IRepository<Producto> ProductoRepository => _productoRepository ?? new SQLRepository<Producto>(_context);


        public IRepository<Cliente> ClienteRepository => _clienteRepository ?? new SQLRepository<Cliente>(_context);

        public IRepository<Cita> CitaRepository => _citaRepository ?? new SQLRepository<Cita>(_context);

        public IRepository<Empleado> EmpleadoRepository => _empleadoRepository ?? new SQLRepository<Empleado>(_context);

        public IRepository<Veterinaria> VeterinariaRepository => _veterinariaRepository ?? new SQLRepository<Veterinaria>(_context);

        public IRepository<Usuario> UsuarioRepository => _usuarioRepository ?? new SQLRepository<Usuario>(_context);

        public IRepository<DetallesCita> DetallesCitaRepository => _detallesCitaRepository ?? new SQLRepository<DetallesCita>(_context);

        public IRepository<Servicio> ServicioRepository => _servicioRepository ?? new SQLRepository<Servicio>(_context);

        public IRepository<Categoria> CategoriaRepository => _categoriaRepository ?? new SQLRepository<Categoria>(_context);


        public void Dispose()
        {
            if (_context == null)
                _context.Dispose();

        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
