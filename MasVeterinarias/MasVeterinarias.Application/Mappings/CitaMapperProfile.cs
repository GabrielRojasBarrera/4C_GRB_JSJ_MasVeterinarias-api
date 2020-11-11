using AutoMapper;
using MasVeterinarias.Domain.DTOs;
using MasVeterinarias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasVeterinarias.Application.Mappings
{
    public  class CitaMapperProfile : Profile
    {
        public CitaMapperProfile()
        {
            CreateMap<Cita, CitaRequestDto>();
            CreateMap<Cita, CitaResponseDto>();
            CreateMap<CitaRequestDto, Cita>().AfterMap(
            ((source, destination) => {
                destination.CreateAt = DateTime.Now;
                destination.CreatedBy = 3;
                destination.Status = true;
            }));
            CreateMap<CitaResponseDto, Cita>();
        }
    }
}
