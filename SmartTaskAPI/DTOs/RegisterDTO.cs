namespace SmartTaskAPI.DTOs
{
    public record RegisterDTO
    {
        public string FullName { get; init; } = string.Empty;

        public string Email { get; init; } = string.Empty;

        public string Password { get; init; } = string.Empty;
    }
}