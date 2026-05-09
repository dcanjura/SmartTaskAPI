namespace SmartTaskAPI.Models;

public class RefreshToken
{
    public int Id { get; set; }

    public string Token { get; set; } = string.Empty;

    public DateTime ExpiresAt { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public bool IsRevoked { get; set; } = false;

    // Relación con User
    public int UserId { get; set; }

    public User User { get; set; } = null!;
}