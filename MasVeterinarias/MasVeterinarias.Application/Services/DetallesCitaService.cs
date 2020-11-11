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
    public  class DetallesCitaService : IDetallesCitaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DetallesCitaService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task AddDetallesCita(DetallesCita detallesCita)
        {
            Expression<Func<DetallesCita, bool>> expression = item => item.Id == detallesCita.Id;
            var detallesCitas = await _unitOfWork.DetallesCitaRepository.FindByCondition(expression);
            if (detallesCitas.Any(item => item.Id == detallesCita.Id))
            {
                throw new Exception("Este producto ya ha sido registrado");
            }

            await _unitOfWork.DetallesCitaRepository.Add(detallesCita);
        }

        public async Task DeleteDetallesCita(int id)
        {
            await _unitOfWork.DetallesCitaRepository.Delete(id);
        }

        public async Task<IEnumerable<DetallesCita>> GetDetallesCitas()
        {
            return await _unitOfWork.DetallesCitaRepository.GetAll();
        }

        public async Task<DetallesCita> GetDetallesCita(int id)
        {
            return await _unitOfWork.DetallesCitaRepository.GetById(id);
        }

        public async Task UpdateDetallesCita(DetallesCita detallesCita)
        {
            await _unitOfWork.DetallesCitaRepository.Update(detallesCita);
        }
    }
}
