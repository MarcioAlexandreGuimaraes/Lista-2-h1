using ListaH1.DTOs;
using ListaH1.Services;
using Microsoft.AspNetCore.Mvc;

namespace ListaH1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _service;

        public CursoController(ICursoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var curso = _service.GetById(id);
            if (curso == null) return NotFound();
            return Ok(curso);
        }

        [HttpPost]
        public IActionResult Create(CreateCursoDTO dto)
        {
            var curso = _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = curso.IdCurso }, curso);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CreateCursoDTO dto)
        {
            var curso = _service.Update(id, dto);
            if (curso == null) return NotFound();
            return Ok(curso);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_service.Delete(id)) return NoContent();
            return NotFound();
        }
    }
}
