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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
        {
            this._usuarioService = usuarioService;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _usuarioService.GetUsuarios();
            var usuariosDto = _mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioResponseDto>>(usuarios);
            var response = new ApiResponse<IEnumerable<UsuarioResponseDto>>(usuariosDto);
            
            return Ok(usuariosDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var usuario = await _usuarioService.GetUsuario(id);
            var usuarioDto = _mapper.Map<Usuario, UsuarioResponseDto>(usuario);
            var response = new ApiResponse<UsuarioResponseDto>(usuarioDto);
            
            return Ok(usuarioDto);
        }



        [HttpPost]
        public async Task<IActionResult> Post(UsuarioRequestDto usuarioRequestDto)
        {
            var usuario = _mapper.Map<UsuarioRequestDto, Usuario>(usuarioRequestDto);
            await _usuarioService.AddUsuario(usuario);
            var usuarioresponseDto = _mapper.Map<Usuario, UsuarioResponseDto>(usuario);
            var response = new ApiResponse<UsuarioResponseDto>(usuarioresponseDto);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _usuarioService.DeleteUsuario(id);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, UsuarioRequestDto ususarioRequest)
        {
            var usuario = _mapper.Map<Usuario>(ususarioRequest);
            usuario.Id = id;
            usuario.UpdateAt = DateTime.Now;
            usuario.UpdatedBy = 1;
            await _usuarioService.UpdateUsuario(usuario);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }
    }
}
