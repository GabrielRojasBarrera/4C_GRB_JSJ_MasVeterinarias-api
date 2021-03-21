using AutoMapper;
using MasVeterinarias.Domain.DTOs;
using MasVeterinarias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasVeterinarias.Application.Mappings
{
    public  class DetallesCitaMapperProfile : Profile
    {
        public DetallesCitaMapperProfile()
        {
            CreateMap<DetallesCita, DetallesCitaRequestDto>();
            CreateMap<DetallesCita, DetallesCitaResponseDto>();
            CreateMap<DetallesCitaRequestDto, DetallesCita>().AfterMap(
            ((source, destination) => {
                destination.CreateAt = DateTime.Now;
                destination.CreatedBy = 3;
                destination.Status = true;
            }));
            CreateMap<DetallesCitaResponseDto, DetallesCita>();
        }
    }
}
