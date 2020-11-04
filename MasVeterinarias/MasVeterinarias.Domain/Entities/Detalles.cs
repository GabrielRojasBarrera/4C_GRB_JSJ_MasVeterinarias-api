using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MasVeterinarias.Domain.Entities
{
    public  class Detalles
    {
  
        public int Estatus { get; set; }

        public Servicio Servicio { get; set; }

        [ForeignKey("Cita")]
        public int CitaId { get; set; }
        [ForeignKey("Servicio")]
        public int ServicioId { get; set; }
    }
}
