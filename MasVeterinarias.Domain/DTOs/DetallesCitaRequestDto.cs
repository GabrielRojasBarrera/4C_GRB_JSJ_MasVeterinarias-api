using System;
using System.Collections.Generic;
using System.Text;

namespace MasVeterinarias.Domain.DTOs
{
    public  class DetallesCitaRequestDto
    {       
        public int CitaId { get; set; }
        public string Estatus { get; set; }
    }
}
