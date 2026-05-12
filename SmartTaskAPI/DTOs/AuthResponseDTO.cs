namespace SmartTaskAPI.DTOs
{
    public record AuthResponseDTO
    {
        public string Token { get; init; } = string.Empty;

        public string RefreshToken { get; init; } = string.Empty;
    }
}