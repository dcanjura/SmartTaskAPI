using Microsoft.EntityFrameworkCore;
using SmartTaskAPI.Data;
using SmartTaskAPI.DTOs;
using SmartTaskAPI.Models;

namespace SmartTaskAPI.Services
{
    public class TaskService : ITaskService
    {
        private readonly SmartTaskDbContext _context;

        public TaskService(SmartTaskDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskResponseDTO>> GetAllByUserAsync(int userId)
        {
            return await _context.TaskItems
                .Where(t => t.UserId == userId)
                .Select(t => new TaskResponseDTO
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    IsCompleted = t.IsCompleted,
                    Priority = t.Priority,
                    DueDate = t.DueDate
                })
                .ToListAsync();
        }

        public async Task<TaskResponseDTO?> GetByIdAsync(int id, int userId)
        {
            var task = await _context.TaskItems
                .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);

            if (task == null) return null;

            return new TaskResponseDTO
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
                Priority = task.Priority,
                DueDate = task.DueDate
            };
        }

        public async Task<TaskResponseDTO> CreateAsync(CreateTaskDTO dto, int userId)
        {
            var task = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                DueDate = dto.DueDate,
                Priority = dto.Priority,
                UserId = userId,
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow
            };

            _context.TaskItems.Add(task);
            await _context.SaveChangesAsync();

            return new TaskResponseDTO
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
                Priority = task.Priority,
                DueDate = task.DueDate
            };
        }

        public async Task<TaskResponseDTO?> UpdateAsync(int id, UpdateTaskDTO dto, int userId)
        {
            var task = await _context.TaskItems
                .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);

            if (task == null) return null;

            task.DueDate = dto.DueDate;
            if (dto.Priority != null) task.Priority = dto.Priority;

            await _context.SaveChangesAsync();

            return new TaskResponseDTO
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
                Priority = task.Priority,
                DueDate = task.DueDate
            };
        }

        public async Task<bool> DeleteAsync(int id, int userId)
        {
            var task = await _context.TaskItems
                .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);

            if (task == null) return false;

            _context.TaskItems.Remove(task);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}