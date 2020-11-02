using MasVeterinarias.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasVeterinarias.Domain.Interfaces
{
    interface ICitaService
    {
        Task AddEmpleado(Cita empleado);
        Task DeleteEmpleado(int id);
        Task<IEnumerable<Empleado>> GetEmpleados();
        Task<Empleado> GetEmpleado(int id);
        Task UpdateEmpleado(Empleado empleado);
    }
}
