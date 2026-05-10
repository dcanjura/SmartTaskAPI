namespace SmartTaskAPI.DTOs
{
    public record CreateTaskDTO
    {
        string Title { get; init; } = string.Empty;
        string Description { get; init; } = string.Empty;
        DateTime DueDate { get; init; }
        string Priority { get; init; } = "Low";
    }
}
