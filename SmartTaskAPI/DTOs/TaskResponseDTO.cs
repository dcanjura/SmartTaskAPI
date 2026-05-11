namespace SmartTaskAPI.DTOs
{
    public record TaskResponseDTO
    {
        public int Id { get; init; }
        public string Title { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public bool IsCompleted { get; init; } = false;
        public DateTime DueDate { get; init; } // Asegúrate de agregar esta si el servicio la pide
        public string Priority { get; init; } = "Low";
    }
}