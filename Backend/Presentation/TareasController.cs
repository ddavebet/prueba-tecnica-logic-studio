using Backend.Application.Interfaces;
using Backend.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Presentation
{
    [ApiController]
    [Route("api/tareas")]
    [Authorize]
    public class TareasController : Controller
    {
        private readonly ITareaRepository _tareaRepository;

        public TareasController(ITareaRepository tareaRepository)
        {
            _tareaRepository = tareaRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarea>> GetById(int id)
        {
            try
            {
                var tarea = await _tareaRepository.GetByIdAsync(id);
                return Ok(tarea);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Tarea>>> GetAll()
        {
            try
            {
                var tareas = await _tareaRepository.GetAllAsync();
                return Ok(tareas);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add(Tarea tarea)
        {
            try
            {
                await _tareaRepository.AddAsync(tarea);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Tarea tarea)
        {
            try
            {
                await _tareaRepository.UpdateAsync(id, tarea);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _tareaRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
