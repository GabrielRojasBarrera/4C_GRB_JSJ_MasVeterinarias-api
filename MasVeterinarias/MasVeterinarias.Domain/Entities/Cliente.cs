using System;
using System.Collections.Generic;

namespace MasVeterinarias.Domain.Entities
{
    public class Cliente : BaseEntity
    {              
        
        public DateTime Fecha_Nacimiento { get; set; }
       
        public string Nombre { get; set; }
        
        public string Apellido { get; set; }
        
        public string Direccion { get; set; }
        
        public long Telefono { get; set; }

        //Referencias
        public ICollection<Cita> Cita { get; set; }

        //un cliente tiene una veterinaria
    }
}
