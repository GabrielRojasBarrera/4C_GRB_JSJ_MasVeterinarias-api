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
    public class VeterinariaController : ControllerBase
    {
        private readonly IVeterinariaService _veterinariaService;
        private readonly IMapper _mapper;
        public VeterinariaController(IVeterinariaService veterinariaService, IMapper mapper)
        {
            this._veterinariaService = veterinariaService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var veterinarias = await _veterinariaService.GetVeterinarias();
            var veterinariasDto = _mapper.Map<IEnumerable<Veterinaria>, IEnumerable<VeterinariaResponseDto>>(veterinarias);
            var response = new ApiResponse<IEnumerable<VeterinariaResponseDto>>(veterinariasDto);
           
            return Ok(veterinariasDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var veterinaria = await _veterinariaService.GetVeterinaria(id);
            var veterinariaDto = _mapper.Map<Veterinaria, VeterinariaResponseDto>(veterinaria);
            var response = new ApiResponse<VeterinariaResponseDto>(veterinariaDto);
            
            return Ok(veterinariaDto);
        }



        [HttpPost]
        public async Task<IActionResult> Post(VeterinariaRequestDto veterinariaRequestDto)
        {
            var veterinaria = _mapper.Map<VeterinariaRequestDto, Veterinaria>(veterinariaRequestDto);
            await _veterinariaService.AddVeterinaria(veterinaria);
            var veterinariaresponseDto = _mapper.Map<Veterinaria, VeterinariaResponseDto>(veterinaria);
            var response = new ApiResponse<VeterinariaResponseDto>(veterinariaresponseDto);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _veterinariaService.DeleteVeterinaria(id);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, VeterinariaRequestDto veterinariaResponse)
        {
            var veterinaria = _mapper.Map<Veterinaria>(veterinariaResponse);
            veterinaria.Id = id;
            veterinaria.UpdateAt = DateTime.Now;
            veterinaria.UpdatedBy = 1;
            await _veterinariaService.UpdateVeterinaria(veterinaria);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }
    }
}
