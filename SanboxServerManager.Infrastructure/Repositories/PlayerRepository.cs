using Microsoft.EntityFrameworkCore;
using SanboxServerManager.Core.Entities;
using SanboxServerManager.Core.Interfaces;

namespace SanboxServerManager.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
       
    {
        public PlayerRepository(SandboxContext context)
        {
            _context = context;
        }
        private readonly SandboxContext _context;
        public async Task<IEnumerable<Player>> GetAllPlayersAsync()
        {
            var playerList =  await _context.Players.AsNoTracking()
                .Include(p => p.PlayerRole)
                .Include(p => p.Clan)
                .ToListAsync();
            return playerList;
        }

        public async Task<IEnumerable<Player>> GetAllAdminsAsync()
        {
            var adminList = await _context.Players
                .AsNoTracking()
                .Where(p => p.RoleId == 1)
                .Include(p => p.PlayerRole)
                .Include(p => p.Clan)
                .ToListAsync();
            return adminList;
        }
    }
}
