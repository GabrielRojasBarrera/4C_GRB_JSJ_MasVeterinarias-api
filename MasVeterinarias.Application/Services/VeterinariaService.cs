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
    public  class VeterinariaService : IVeterinariaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VeterinariaService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task AddVeterinaria(Veterinaria veterinaria)
        {
            Expression<Func<Veterinaria, bool>> expression = item => item.Id == veterinaria.Id;
            var veterinarias = await _unitOfWork.VeterinariaRepository.FindByCondition(expression);
            if (veterinarias.Any(item => item.Id == veterinaria.Id))
                throw new Exception("Este producto ya ha sido registrado");


            await _unitOfWork.VeterinariaRepository.Add(veterinaria);
        }

        public async Task DeleteVeterinaria(int id)
        {
            await _unitOfWork.VeterinariaRepository.Delete(id);
        }

        public async Task<IEnumerable<Veterinaria>> GetVeterinarias()
        {
            return await _unitOfWork.VeterinariaRepository.GetAll();
        }

        public async Task<Veterinaria> GetVeterinaria(int id)
        {
            return await _unitOfWork.VeterinariaRepository.GetById(id);
        }

        public async Task UpdateVeterinaria(Veterinaria veterinaria)
        {
            await _unitOfWork.VeterinariaRepository.Update(veterinaria);
        }

    }
}
