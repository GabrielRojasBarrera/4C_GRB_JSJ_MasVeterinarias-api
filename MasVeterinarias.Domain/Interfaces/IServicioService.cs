using MasVeterinarias.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasVeterinarias.Domain.Interfaces
{
    public  interface IServicioService
    {
        Task AddServicio(Servicio servicio);
        Task DeleteServicio(int id);
        Task<IEnumerable<Servicio>> GetServicios();
        Task<Servicio> GetServicio(int id);
        Task UpdateServicio(Servicio servicio);
    }
}
