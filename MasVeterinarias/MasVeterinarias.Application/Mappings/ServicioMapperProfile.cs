using AutoMapper;
using MasVeterinarias.Domain.DTOs;
using MasVeterinarias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasVeterinarias.Application.Mappings
{
    public  class ServicioMapperProfile : Profile
    {
        public ServicioMapperProfile()
        {
            CreateMap<Servicio, ServicioRequestDto>();
            CreateMap<Servicio, ServicioResponseDto>();
            CreateMap<ServicioRequestDto, Servicio>().AfterMap(
            ((source, destination) => {
                destination.CreateAt = DateTime.Now;
                destination.CreatedBy = 3;
                destination.Status = true;
            }));
            CreateMap<ServicioResponseDto, Servicio>();
        }
    }
}
