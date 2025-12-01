using ListaH1.DTOs;
using ListaH1.Services;
using Microsoft.AspNetCore.Mvc;

namespace ListaH1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaService _service;

        public MatriculaController(IMatriculaService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var matricula = _service.GetById(id);
            if (matricula == null) return NotFound();
            return Ok(matricula);
        }

        [HttpPost]
        public IActionResult Create(CreateMatriculaDTO dto)
        {
            var matricula = _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = matricula.IdMatricula }, matricula);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CreateMatriculaDTO dto)
        {
            var matricula = _service.Update(id, dto);
            if (matricula == null) return NotFound();
            return Ok(matricula);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_service.Delete(id)) return NoContent();
            return NotFound();
        }
    }
}
