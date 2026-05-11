using SmartTaskAPI.DTOs;

namespace SmartTaskAPI.Services
{
    public interface IAuthService
    {
        Task<UserDTO?> RegisterAsync(string fullName, string email, string password);
        Task<string?> LoginAsync(string email, string password);
        Task<string?> RefreshTokenAsync(string token);
        Task<bool> RevokeTokenAsync(string token);
    }
}
