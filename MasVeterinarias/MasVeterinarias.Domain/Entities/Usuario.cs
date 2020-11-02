using System;
using System.Collections.Generic;
using System.Text;

namespace MasVeterinarias.Domain.Entities
{
    public  class Usuario : BaseEntity
    {
        public string Email { get; set; }        
        public string Password { get; set; }
    }
}
