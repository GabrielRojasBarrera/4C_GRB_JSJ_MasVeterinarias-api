using AutoMapper;
using MasVeterinarias.Domain.DTOs;
using MasVeterinarias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasVeterinarias.Application.Mappings
{
    public  class CategoriaMapperProfile : Profile
    {
        public CategoriaMapperProfile()
        {
            CreateMap<Categoria, CategoriaRequestDto>();
            CreateMap<Categoria, CategoriaResponseDto>();
            CreateMap<CategoriaRequestDto, Categoria>().AfterMap(
            ((source, destination) => {
                destination.CreateAt = DateTime.Now;
                destination.CreatedBy = 3;
                destination.Status = true;
            }));
            CreateMap<CategoriaResponseDto, Categoria>();
        }

    }
}
