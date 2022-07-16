using Microsoft.EntityFrameworkCore;
using TheFamily.Data;
using TheFamily.Entities;
using TheFamily.Interfaces;

namespace TheFamily.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly FamilyDbContext _context;

        public PlayerRepository(FamilyDbContext context)
        {
            _context = context;
        }
        public async Task<Player> CreatePlayer(Player spelare)
        {
            var result = await _context.player.AddAsync(spelare);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Player> DeletePlayer(int id)
        {
            var result = await _context.player.FirstOrDefault(x => x.Id == id);

            if(result != null)
            {
                _context.player.Remove(result);
                _context.SaveChanges();
                return result;
            }
            return null;
        }

        public async Task<Player> GetOnePlayer(int id)
        {
            return await _context.player.FindAsync(id);

        }

        public async Task<IEnumerable<Player>> GetPlayers()
        {
            return await _context.player.ToListAsync();
        }

        public Task<Player> GetRandomPlayer()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Player>> GetTop3Players()
        {
            throw new NotImplementedException();
        }

        public Task<Player> UpdatePlayer(Player spelare)
        {
            throw new NotImplementedException();
        }
    }
}
