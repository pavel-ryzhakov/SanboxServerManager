using Microsoft.EntityFrameworkCore;
using SanboxServerManager.Core.Entities;

namespace SanboxServerManager.Infrastructure.Repositories
{
    public class SandboxContext : DbContext
    {
        public SandboxContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<Clan> Clans { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerRole> PlayerRoles { get; set; }
    }
}
