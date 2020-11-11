using MasVeterinarias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MasVeterinarias.Domain.Interfaces
{
    public  interface IUsuarioService
    {
        Task AddUsuario(Usuario usuario);
        Task DeleteUsuario(int id);
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario> GetUsuario(int id);
        Task UpdateUsuario(Usuario usuario);
    }
}
