using MasVeterinarias.Domain.Entities;
using MasVeterinarias.Domain.Interfaces;
using MasVeterinarias.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MasVeterinarias.Infraestructure.Repositories
{
    public  class CitaRepository : SQLRepository<Cita>, ICitaRepository
    {
        public CitaRepository(MasVeterinariasDBContext context) : base(context)
        {

        }
        public async Task CrearCita(Cita cita)
        {
            _context.Add(cita);
            foreach (var detalles in cita.Detalles)
            {
                _context.Add(detalles);

            }
            await _context.SaveChangesAsync();
        }

        public async Task<Cita> VerCita(int id)
        {
            return await _context.Set<Cita>().Include(x => x.Detalles).AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
