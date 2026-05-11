namespace SmartTaskAPI.DTOs
{
    public record CreateTaskDTO
    {
        public string Title { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public DateTime DueDate { get; init; }
        public string Priority { get; init; } = "Low";
    }
}