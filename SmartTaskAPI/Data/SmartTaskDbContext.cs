using Microsoft.EntityFrameworkCore;
using SmartTaskAPI.Models;

namespace SmartTaskAPI.Data
{
    public class SmartTaskDbContext : DbContext
    {
        public SmartTaskDbContext(DbContextOptions<SmartTaskDbContext> options) : base(options)
        {
        }
        public DbSet<Models.TaskItem> TaskItems { get; set; } = null!;

        public DbSet<Models.User> Users { get; set; } = null!;

        public DbSet<Models.RefreshToken> RefreshTokens { get; set; } = null!;
    }
}
