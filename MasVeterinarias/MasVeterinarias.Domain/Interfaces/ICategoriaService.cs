using MasVeterinarias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MasVeterinarias.Domain.Interfaces
{
    public  interface ICategoriaService
    {
        Task AddCategoria(Categoria categoria);
        Task DeleteCategoria(int id);
        Task<IEnumerable<Categoria>> GetCategorias();
        Task<Categoria> GetCategoria(int id);
        Task UpdateCategoria(Categoria categoria);
    }
}
