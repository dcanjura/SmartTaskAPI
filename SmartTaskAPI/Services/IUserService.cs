using SmartTaskAPI.DTOs;

namespace SmartTaskAPI.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllAsync();
        Task<UserDTO?> GetByIdAsync(int id);
    }
}