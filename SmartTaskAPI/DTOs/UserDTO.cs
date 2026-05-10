namespace SmartTaskAPI.DTOs
{
    public record UserDTO
    {
        int Id { get; init; }
        string FullName { get; init; } = string.Empty;
        string Email { get; init; } = string.Empty;
    }
}
