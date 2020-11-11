using MasVeterinarias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MasVeterinarias.Domain.Interfaces
{
    public  interface IVeterinariaService
    {
        Task AddVeterinaria(Veterinaria veterinaria);
        Task DeleteVeterinaria(int id);
        Task<IEnumerable<Veterinaria>> GetVeterinarias();
        Task<Veterinaria> GetVeterinaria(int id);
        Task UpdateVeterinaria(Veterinaria veterinaria);
    }
}
