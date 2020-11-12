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
    public class DetallesCitaController : ControllerBase
    {
        private readonly IDetallesCitaService _detallesCitaService;
        private readonly IMapper _mapper;
        public DetallesCitaController(IDetallesCitaService usuarioService, IMapper mapper)
        {
            this._detallesCitaService = usuarioService;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var detallesCitas = await _detallesCitaService.GetDetallesCitas();
            var detallesCitasDto = _mapper.Map<IEnumerable<DetallesCita>, IEnumerable<DetallesCitaResponseDto>>(detallesCitas);
            var response = new ApiResponse<IEnumerable<DetallesCitaResponseDto>>(detallesCitasDto);

            return Ok(detallesCitasDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var detallesCita = await _detallesCitaService.GetDetallesCita(id);
            var detallesCitaDto = _mapper.Map<DetallesCita, DetallesCitaResponseDto>(detallesCita);
            var response = new ApiResponse<DetallesCitaResponseDto>(detallesCitaDto);

            return Ok(detallesCitaDto);
        }



        [HttpPost]
        public async Task<IActionResult> Post(DetallesCitaRequestDto detallesCitaRequestDto)
        {
            var detallesCita = _mapper.Map<DetallesCitaRequestDto, DetallesCita>(detallesCitaRequestDto);
            await _detallesCitaService.AddDetallesCita(detallesCita);
            var detallesCitaresponseDto = _mapper.Map<DetallesCita, DetallesCitaResponseDto>(detallesCita);
            var response = new ApiResponse<DetallesCitaResponseDto>(detallesCitaresponseDto);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _detallesCitaService.DeleteDetallesCita(id);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, DetallesCitaResponseDto detallesCitaResponse)
        {
            var detallesCita = _mapper.Map<DetallesCita>(detallesCitaResponse);
            detallesCita.Id = id;
            detallesCita.UpdateAt = DateTime.Now;
            detallesCita.UpdatedBy = 1;
            await _detallesCitaService.UpdateDetallesCita(detallesCita);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }
    }
}
