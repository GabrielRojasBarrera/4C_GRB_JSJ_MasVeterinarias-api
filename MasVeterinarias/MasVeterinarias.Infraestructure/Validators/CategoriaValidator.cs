using FluentValidation;
using MasVeterinarias.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasVeterinarias.Infraestructure.Validators
{
    public  class CategoriaValidator : AbstractValidator<CategoriaRequestDto>
    {
        public CategoriaValidator()
        {
           
            RuleFor(categoria => categoria.Nombre)
               .NotNull()
               .Length(3, 50);
        }
    }
}
