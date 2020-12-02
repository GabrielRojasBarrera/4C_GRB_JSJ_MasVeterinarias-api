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
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        private readonly IMapper _mapper;
        public CategoriaController(ICategoriaService categoriaService, IMapper mapper)
        {
            this._categoriaService = categoriaService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categorias = await _categoriaService.GetCategorias();
            var categoriasDto = _mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaResponseDto>>(categorias);
            var response = new ApiResponse<IEnumerable<CategoriaResponseDto>>(categoriasDto);
           
            return Ok(categoriasDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var categoria = await _categoriaService.GetCategoria(id);
            var categoriaDto = _mapper.Map<Categoria, CategoriaResponseDto>(categoria);
            var response = new ApiResponse<CategoriaResponseDto>(categoriaDto);
           
            return Ok(categoriaDto);
        }



        [HttpPost]
        public async Task<IActionResult> Post(CategoriaRequestDto categoriaRequestDto)
        {
            var categoria = _mapper.Map<CategoriaRequestDto, Categoria>(categoriaRequestDto);
            await _categoriaService.AddCategoria(categoria);
            var categoriaresponseDto = _mapper.Map<Categoria, CategoriaResponseDto>(categoria);
            var response = new ApiResponse<CategoriaResponseDto>(categoriaresponseDto);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _categoriaService.DeleteCategoria(id);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, CategoriaResponseDto categoriaResponse)
        {
            var categoria = _mapper.Map<Categoria>(categoriaResponse);
            categoria.Id = id;
            categoria.UpdateAt = DateTime.Now;
            categoria.UpdatedBy = 1;
            await _categoriaService.UpdateCategoria(categoria);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }
    }
}
