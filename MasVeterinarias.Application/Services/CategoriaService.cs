using MasVeterinarias.Domain.Entities;
using MasVeterinarias.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MasVeterinarias.Application.Services
{
    public  class CategoriaService : ICategoriaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriaService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task AddCategoria(Categoria categoria)
        {
            Expression<Func<Categoria, bool>> expression = item => item.Id == categoria.Id;
            var categorias = await _unitOfWork.CategoriaRepository.FindByCondition(expression);
            if (categorias.Any(item => item.Id == categoria.Id))
                throw new Exception("Esta cita ya ha sido registrada");


            await _unitOfWork.CategoriaRepository.Add(categoria);
        }

        public async Task DeleteCategoria(int id)
        {
            await _unitOfWork.CategoriaRepository.Delete(id);
        }

        public async Task<IEnumerable<Categoria>> GetCategorias()
        {
            return await _unitOfWork.CategoriaRepository.GetAll();
        }

        public async Task<Categoria> GetCategoria(int id)
        {
            return await _unitOfWork.CategoriaRepository.GetById(id);
        }

        public async Task UpdateCategoria(Categoria categoria)
        {
            await _unitOfWork.CategoriaRepository.Update(categoria);
        }
    }
}
