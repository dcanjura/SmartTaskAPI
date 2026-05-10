namespace SmartTaskAPI.DTOs
{
    public record UpdateTaskDTO
    {
        int Id { get; init; }
        DateTime DueDate { get; init; }
        string? Priority { get; init; }
    }
}
