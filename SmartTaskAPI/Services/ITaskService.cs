using SmartTaskAPI.DTOs;
using SmartTaskAPI.Models;

namespace SmartTaskAPI.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskResponseDTO>> GetAllByUserAsync(int userId);
        Task<TaskResponseDTO?> GetByIdAsync(int id, int userId);
        Task<TaskResponseDTO> CreateAsync(CreateTaskDTO dto, int userId);
        Task<TaskResponseDTO?> UpdateAsync(int id, UpdateTaskDTO dto, int userId);
        Task<bool> DeleteAsync(int id, int userId);
    }
}