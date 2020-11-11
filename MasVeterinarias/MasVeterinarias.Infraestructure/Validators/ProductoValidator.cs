using FluentValidation;
using MasVeterinarias.Domain.DTOs;

namespace MasVeterinarias.Infraestructure.Validators
{
    public  class ProductoValidator : AbstractValidator<ProductoRequestDto>
    {
        public ProductoValidator()
        {
            RuleFor(producto => producto.Descripcion)
                .NotNull()
                .Length(3, 75);
            RuleFor(producto => producto.Marca)
                .NotNull()
                .Length(3, 50);
            RuleFor(producto => producto.Especie)
                .NotNull()
                .Length(3, 50);
            RuleFor(producto => producto.Raza)
               .NotNull()
               .Length(3, 50);
            RuleFor(producto => producto.Etapa)
               .NotNull()
               .Length(3, 50);
            RuleFor(producto => producto.Nombre)
               .NotNull()
               .Length(3, 50);
        }

    }
}
