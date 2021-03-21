using MasVeterinarias.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasVeterinarias.Domain.Interfaces
{
    public  interface ICitaService
    {
        Task AddCita(Cita cita);
        Task DeleteCita(int id);
        Task<IEnumerable<Cita>> GetCitas();
        Task<Cita> GetCita(int id);
        Task UpdateCita(Cita cita);
    }
}
