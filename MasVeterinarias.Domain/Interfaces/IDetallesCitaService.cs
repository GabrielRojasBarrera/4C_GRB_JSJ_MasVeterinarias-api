using MasVeterinarias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MasVeterinarias.Domain.Interfaces
{
    public  interface IDetallesCitaService
    {
        Task AddDetallesCita(DetallesCita detallesCita);
        Task DeleteDetallesCita(int id);
        Task<IEnumerable<DetallesCita>> GetDetallesCitas();
        Task<DetallesCita> GetDetallesCita(int id);
        Task UpdateDetallesCita(DetallesCita detallesCita);
    }
}
