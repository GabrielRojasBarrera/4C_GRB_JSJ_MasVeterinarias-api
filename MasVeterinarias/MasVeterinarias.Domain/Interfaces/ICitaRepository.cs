using MasVeterinarias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MasVeterinarias.Domain.Interfaces
{
    public  interface ICitaRepository : IRepository<Cita>
    {
        public Task CrearCita(Cita cita);
        public Task<Cita> VerCita(int id);
    }
}
