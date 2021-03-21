using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MasVeterinarias.Api.Responses;
using MasVeterinarias.Domain.DTOs;
using MasVeterinarias.Domain.Entities;
using MasVeterinarias.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasVeterinarias.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly ICitaService  _citaService;
        private readonly IMapper _mapper;
        public CitaController(ICitaService citaService, IMapper mapper)
        {
            this._citaService = citaService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var citas = await _citaService.GetCitas();
            var citasDto = _mapper.Map<IEnumerable<Cita>, IEnumerable<CitaResponseDto>>(citas);
            var response = new ApiResponse<IEnumerable<CitaResponseDto>>(citasDto);
            
            return Ok(citasDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var cita = await _citaService.GetCita(id);
            var citaDto = _mapper.Map<Cita, CitaResponseDto>(cita);
            var response = new ApiResponse<CitaResponseDto>(citaDto);
            
            return Ok(citaDto);
        }



        [HttpPost]
        public async Task<IActionResult> Post(CitaRequestDto citaRequestDto)
        {
            var cita = _mapper.Map<CitaRequestDto, Cita>(citaRequestDto);
            await _citaService.AddCita(cita);
            var citaresponseDto = _mapper.Map<Cita, CitaResponseDto>(cita);
            var response = new ApiResponse<CitaResponseDto>(citaresponseDto);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _citaService.DeleteCita(id);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, CitaResponseDto citaResponse)
        {
            var cita = _mapper.Map<Cita>(citaResponse);
            cita.Id = id;
            cita.UpdateAt = DateTime.Now;
            cita.UpdatedBy = 1;
            await _citaService.UpdateCita(cita);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }

    }
}
