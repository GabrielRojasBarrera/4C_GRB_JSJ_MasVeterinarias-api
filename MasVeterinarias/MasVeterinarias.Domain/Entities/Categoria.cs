using System;
using System.Collections.Generic;

namespace MasVeterinarias.Domain.Entities
{
    public partial class Categoria : BaseEntity

    {
        public Categoria()
        {
            Servicio = new HashSet<Servicio>();
        }

       
        public string Nombre { get; set; }
        

        public virtual ICollection<Servicio> Servicio { get; set; }
    }
}
