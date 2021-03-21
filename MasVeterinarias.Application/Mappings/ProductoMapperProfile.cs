using AutoMapper;
using MasVeterinarias.Domain.DTOs;
using MasVeterinarias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasVeterinarias.Application.Mappings
{
    public  class ProductoMapperProfile : Profile
    {
        public ProductoMapperProfile()
        {
            CreateMap<Producto, ProductoRequestDto>();
            CreateMap<Producto, ProductoResponseDto>();
            CreateMap<ProductoRequestDto, Producto>().AfterMap(
            ((source, destination) => {
                destination.CreateAt = DateTime.Now;
                destination.CreatedBy = 3;
                destination.Status = true;
            }));
            CreateMap<ProductoResponseDto, Producto>();
        }
    }
}
