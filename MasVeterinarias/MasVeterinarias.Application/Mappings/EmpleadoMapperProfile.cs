using AutoMapper;
using MasVeterinarias.Domain.DTOs;
using MasVeterinarias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasVeterinarias.Application.Mappings
{
    public  class EmpleadoMapperProfile : Profile
    {
        public EmpleadoMapperProfile()
        {
            CreateMap<Empleado, EmpleadoRequestDto>();
            CreateMap<Empleado, EmpleadoResponseDto>();
            CreateMap<EmpleadoRequestDto, Empleado>().AfterMap(
            ((source, destination) => {
                destination.CreateAt = DateTime.Now;
                destination.CreatedBy = 3;
                destination.Status = true;
            }));
            CreateMap<EmpleadoResponseDto, Empleado>();
        }
    }
}
