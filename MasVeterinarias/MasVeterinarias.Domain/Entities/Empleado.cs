using System;
using System.Collections.Generic;

namespace MasVeterinarias.Domain.Entities
{
    public partial class Empleado : BaseEntity
    {
        
        public int VeterinariaId { get; set; }
        public string Telefono { get; set; }
       
        public string Nombre { get; set; }
        
        public int ServicioId { get; set; }

        public virtual Servicio Servicio { get; set; }
        public virtual Veterinaria Veterinaria { get; set; }
    }
}
