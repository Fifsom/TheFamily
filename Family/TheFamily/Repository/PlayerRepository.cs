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
            var result = await _context.player.FirstOrDefaultAsync(x => x.Id == id);

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

        public async Task<Player> GetRandomPlayer()
        {
            Player randomPlayer = new();
            var random = new Random();
            var availablePlayers = await _context.player.ToListAsync();
            int index = random.Next(availablePlayers.Count);
            randomPlayer = availablePlayers[index];

            return randomPlayer;
        }

        public async Task<IEnumerable<Player>> GetTop3Players()
        {
            var playerList = await _context.player.ToListAsync();
            var top3players = playerList.OrderByDescending(x => x.Wins).Take(3).ToList();

            return top3players;
        }

        public async Task<Player> UpdatePlayer(Player spelare)
        {
            var result = await _context.player.FirstOrDefaultAsync(x => x.Id == spelare.Id);
            if( result != null)
            {
                result.Name = spelare.Name;
                result.FavFood = spelare.FavFood;
                result.ImgName = spelare.ImgName;
                result.Wins = spelare.Wins;
                result.Loses = spelare.Loses;

                _context.SaveChangesAsync();
                return result;                
            }
            return null;
            
        }
    }
}
