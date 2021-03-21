using System;
using System.Collections.Generic;
using System.Text;

namespace MasVeterinarias.Domain.DTOs
{
    public  class UsuarioRequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
