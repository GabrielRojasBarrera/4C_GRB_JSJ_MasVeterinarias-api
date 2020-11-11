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
            RuleFor(servicio => servicio.Descripcion)
                .NotNull()
                .Length(3, 75);
            RuleFor(servicio => servicio.Especie)
               .NotNull()
               .Length(3, 50);
            RuleFor(servicio => servicio.Raza)
               .NotNull()
               .Length(3, 50);
            RuleFor(servicio => servicio.Nombre)
               .NotNull()
               .Length(3, 50);
            RuleFor(servicio => servicio.Disponibilidad)
               .NotNull()
               .Length(3, 50);
           
        }

    }
}
