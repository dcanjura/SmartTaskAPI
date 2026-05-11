namespace SmartTaskAPI.DTOs
{
    public record UpdateTaskDTO
    {
        public int Id { get; init; }
        public DateTime DueDate { get; init; }
        public string? Priority { get; init; }
    }
}
