using System;
using System.Collections.Generic;
using System.Text;

namespace MasVeterinarias.Domain.DTOs
{
    public  class CitaResponseDto
    {
        public int Id { get; set; }
        public int VeterinariaId { get; set; }
        public int ClienteId { get; set; }        
        public string NombreMascota { get; set; }
        public string Hora { get; set; }
        public DateTime? Fecha { get; set; }        
        public int ServicioId { get; set; }

        public string Estatus { get; set; }
    }
}
