using AutoMapper;
using MasVeterinarias.Domain.DTOs;
using MasVeterinarias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasVeterinarias.Application.Mappings
{
    public  class VeterinariaMapperProfile : Profile
    {
        public VeterinariaMapperProfile()
        {
            CreateMap<Veterinaria, VeterinariaRequestDto>();
            CreateMap<Veterinaria, VeterinariaResponseDto>();
            CreateMap<VeterinariaRequestDto, Veterinaria>().AfterMap(
            ((source, destination) => {
                destination.CreateAt = DateTime.Now;
                destination.CreatedBy = 3;
                destination.Status = true;
            }));
            CreateMap<VeterinariaResponseDto, Veterinaria>();
        }

    }
}
