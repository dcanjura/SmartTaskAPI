namespace SmartTaskAPI.DTOs
{
    public record TaskResponseDTO
    {
        int Id { get; init; }
        string Title { get; init; } = string.Empty;
        string Description { get; init; } = string.Empty;
        bool IsCompleted { get; init; } = false;
        string Priority { get; init; } = "Low";
    }
}
