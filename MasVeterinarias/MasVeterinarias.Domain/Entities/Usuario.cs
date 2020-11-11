using System;
using System.Collections.Generic;

namespace MasVeterinarias.Domain.Entities
{
    public partial class Usuario : BaseEntity
    {
        public Usuario()
        {
            Cliente = new HashSet<Cliente>();
            Veterinaria = new HashSet<Veterinaria>();
        }

       
        public string Email { get; set; }
        public string Password { get; set; }
      

        public virtual ICollection<Cliente> Cliente { get; set; }
        public virtual ICollection<Veterinaria> Veterinaria { get; set; }
    }
}
