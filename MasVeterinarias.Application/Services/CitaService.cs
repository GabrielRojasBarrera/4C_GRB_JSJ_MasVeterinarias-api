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
    public  class CitaService : ICitaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CitaService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task AddCita(Cita cita)
        {
            Expression<Func<Cita, bool>> expression = item => item.Id == cita.Id;
            var citas = await _unitOfWork.CitaRepository.FindByCondition(expression);
            if (citas.Any(item => item.Id == cita.Id))
                throw new Exception("Esta cita ya ha sido registrada");


            await _unitOfWork.CitaRepository.Add(cita);
        }

        public async Task DeleteCita(int id)
        {
            await _unitOfWork.CitaRepository.Delete(id);
        }

        public async Task<IEnumerable<Cita>> GetCitas()
        {
            return await _unitOfWork.CitaRepository.GetAll();
        }

        public async Task<Cita> GetCita(int id)
        {
            return await _unitOfWork.CitaRepository.GetById(id);
        }

        public async Task UpdateCita(Cita cita)
        {
            await _unitOfWork.CitaRepository.Update(cita);
        }
    }
}
