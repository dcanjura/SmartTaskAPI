using Microsoft.AspNetCore.Mvc;
using SmartTaskAPI.DTOs;
using SmartTaskAPI.Services;

namespace SmartTaskAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        private int GetCurrentUserId() => 1;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskResponseDTO>>> GetAll()
        {
            var userId = GetCurrentUserId();
            var tasks = await _taskService.GetAllByUserAsync(userId);
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskResponseDTO>> GetById(int id)
        {
            var userId = GetCurrentUserId();
            var task = await _taskService.GetByIdAsync(id, userId);

            if (task == null) return NotFound(new { message = "Tarea no encontrada" });

            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskResponseDTO>> Create(CreateTaskDTO dto)
        {
            var userId = GetCurrentUserId();
            var newTask = await _taskService.CreateAsync(dto, userId);
            return CreatedAtAction(nameof(GetById), new { id = newTask.Id }, newTask);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTaskDTO dto)
        {
            var userId = GetCurrentUserId();
            var updatedTask = await _taskService.UpdateAsync(id, dto, userId);

            if (updatedTask == null) return NotFound(new { message = "No se pudo actualizar la tarea" });

            return Ok(updatedTask);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = GetCurrentUserId();
            var deleted = await _taskService.DeleteAsync(id, userId);

            if (!deleted) return NotFound(new { message = "No se pudo eliminar la tarea" });

            return NoContent();
        }
    }
}
