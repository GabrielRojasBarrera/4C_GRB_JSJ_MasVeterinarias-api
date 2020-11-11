using System;
using System.Collections.Generic;
using System.Text;

namespace MasVeterinarias.Domain.DTOs
{
    public  class EmpleadoRequestDto
    {
        public int VeterinariaId { get; set; }
        public string Telefono { get; set; }
        public string Nombre { get; set; }
        public int ServicioId { get; set; }
    }
}
