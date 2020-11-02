using FluentValidation;
using MasVeterinarias.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasVeterinarias.Infraestructure.Validators
{
    public  class ServicioValidator : AbstractValidator<ServicioRequestDto>
    {
        public ServicioValidator()
        {
            RuleFor(producto => producto.Descripcion)
                .NotNull()
                .Length(3, 75);
            RuleFor(producto => producto.Especie)
               .NotNull()
               .Length(3, 50);
            RuleFor(producto => producto.Raza)
               .NotNull()
               .Length(3, 50);
            RuleFor(producto => producto.Etapa)
               .NotNull()
               .Length(3, 50);
            RuleFor(producto => producto.Categoria)
               .NotNull()
               .Length(3, 50);
            RuleFor(producto => producto.Estado)
              .NotNull()
              .Length(3, 50);
            RuleFor(producto => producto.Duracion)
              .NotNull()
              .Length(3, 50);
        }

    }
}
