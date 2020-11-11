using System;
using System.Collections.Generic;

namespace MasVeterinarias.Domain.Entities
{
    public partial class DetallesCita : BaseEntity
    {
       
        public int CitaId { get; set; }
       
        public string Estatus { get; set; }
        

        public virtual Cita Cita { get; set; }
    }
}
