using AutoMapper;
using MasVeterinarias.Api.Responses;
using MasVeterinarias.Domain.DTOs;
using MasVeterinarias.Domain.Entities;
using MasVeterinarias.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasVeterinarias.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IServicioService _servicioService;
        private readonly IMapper _mapper;
        public ServicioController(IServicioService servicioService, IMapper mapper)
        {
            this._servicioService = servicioService;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var servicios = await _servicioService.GetServicios();
            var serviciosDto = _mapper.Map<IEnumerable<Servicio>, IEnumerable<ServicioResponseDto>>(servicios);
            var response = new ApiResponse<IEnumerable<ServicioResponseDto>>(serviciosDto);
           
            return Ok(serviciosDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var servicio = await _servicioService.GetServicio(id);
            var servicioDto = _mapper.Map<Servicio, ServicioResponseDto>(servicio);
            var response = new ApiResponse<ServicioResponseDto>(servicioDto);
            
            return Ok(servicioDto);
        }



        [HttpPost]
        public async Task<IActionResult> Post(ServicioRequestDto servicioDto)
        {
            var servicio = _mapper.Map<ServicioRequestDto, Servicio>(servicioDto);
            await _servicioService.AddServicio(servicio);
            var servicioresponseDto = _mapper.Map<Servicio, ServicioResponseDto>(servicio);
            var response = new ApiResponse<ServicioResponseDto>(servicioresponseDto);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _servicioService.DeleteServicio(id);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, ServicioRequestDto ususarioRequest)
        {
            var servicio = _mapper.Map<Servicio>(ususarioRequest);
            servicio.Id = id;
            servicio.UpdateAt = DateTime.Now;
            servicio.UpdatedBy = 1;
            await _servicioService.UpdateServicio(servicio);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }
    }
}
