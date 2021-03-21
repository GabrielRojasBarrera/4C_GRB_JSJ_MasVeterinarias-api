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
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;
        private readonly IMapper _mapper;
        public EmpleadoController(IEmpleadoService empleadoService, IMapper mapper)
        {
            this._empleadoService = empleadoService;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var empleados = await _empleadoService.GetEmpleados();
            var empleadosDto = _mapper.Map<IEnumerable<Empleado>, IEnumerable<EmpleadoResponseDto>>(empleados);
            var response = new ApiResponse<IEnumerable<EmpleadoResponseDto>>(empleadosDto);

            return Ok(empleadosDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var empleado = await _empleadoService.GetEmpleado(id);
            var empleadoDto = _mapper.Map<Empleado, EmpleadoResponseDto>(empleado);
            var response = new ApiResponse<EmpleadoResponseDto>(empleadoDto);

            return Ok(empleadoDto);
        }



        [HttpPost]
        public async Task<IActionResult> Post(EmpleadoRequestDto empleadoRequestDto)
        {
            var empleado = _mapper.Map<EmpleadoRequestDto, Empleado>(empleadoRequestDto);
            await _empleadoService.AddEmpleado(empleado);
            var empleadoresponseDto = _mapper.Map<Empleado, EmpleadoResponseDto>(empleado);
            var response = new ApiResponse<EmpleadoResponseDto>(empleadoresponseDto);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _empleadoService.DeleteEmpleado(id);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, EmpleadoResponseDto empleadoResponse)
        {
            var empleado = _mapper.Map<Empleado>(empleadoResponse);
            empleado.Id = id;
            empleado.UpdateAt = DateTime.Now;
            empleado.UpdatedBy = 1;
            await _empleadoService.UpdateEmpleado(empleado);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }
    }
}
