using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheFamily.Entities;
using TheFamily.Interfaces;

namespace TheFamily.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayersController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayer()
        {
            try
            {
                return Ok(await _playerRepository.GetPlayers());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status404NotFound,
                    "no players were found");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            try
            {
                var result = await _playerRepository.GetOnePlayer(id);
                if(result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"player with id {id} not found.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlayer(int id)
        {
            try
            {
                return Ok(await _playerRepository.DeletePlayer(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"No player with id{id} was found.");
                
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreatePlayer(Player player)
        {
            try
            {
                if(player == null)
                {
                    return BadRequest();
                }
                var newPlayer = await _playerRepository.CreatePlayer(player);
                return CreatedAtAction(nameof(GetPlayer), new { newPlayer = player.Id, Controller = "players" }, newPlayer);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Creation Error");
            }
        }
    }
}
