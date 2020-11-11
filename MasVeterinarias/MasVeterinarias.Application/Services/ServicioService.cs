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
    public  class ServicioService : IServicioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServicioService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task AddServicio(Servicio servicio)
        {
            Expression<Func<Servicio, bool>> expression = item => item.Id == servicio.Id;
            var servicios = await _unitOfWork.ServicioRepository.FindByCondition(expression);
            if (servicios.Any(item => item.Id == servicio.Id))
                throw new Exception("Este producto ya ha sido registrado");


            await _unitOfWork.ServicioRepository.Add(servicio);
        }

        public async Task DeleteServicio(int id)
        {
            await _unitOfWork.ServicioRepository.Delete(id);
        }

        public async Task<IEnumerable<Servicio>> GetServicios()
        {
            return await _unitOfWork.ServicioRepository.GetAll();
        }

        public async Task<Servicio> GetServicio(int id)
        {
            return await _unitOfWork.ServicioRepository.GetById(id);
        }

        public async Task UpdateServicio(Servicio servicio)
        {
            await _unitOfWork.ServicioRepository.Update(servicio);
        }
    }
}
