using System;
using System.Collections.Generic;
using System.Text;

namespace MasVeterinarias.Domain.Entities
{
    public class Vacacion:BaseEntity
    {                       
        public string Nombre { get; set; }
       
        public DateTime Fecha_inicio { get; set; }
       
        public DateTime Fecha_final { get; set; }


    }
}
