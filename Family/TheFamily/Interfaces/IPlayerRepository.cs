using TheFamily.Entities;

namespace TheFamily.Interfaces
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<Player>> GetPlayers();
        Task<IEnumerable<Player>> GetTop3Players();
        Task<Player> GetOnePlayer(int id);
        Task<Player> CreatePlayer(Player spelare);
        Task<Player> UpdatePlayer(Player spelare);
        Task<Player> DeletePlayer(int id);
        Task<Player> GetRandomPlayer();
    }
}
