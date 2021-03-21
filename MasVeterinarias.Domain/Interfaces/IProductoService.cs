using MasVeterinarias.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasVeterinarias.Domain.Interfaces
{
    public interface IProductoService
    {
        Task AddProducto(Producto producto);
        Task DeleteProducto(int id);
        Task<IEnumerable<Producto>> GetProductos();
        Task<Producto> GetProducto(int id);
        Task UpdateProducto(Producto producto);
    }
}
