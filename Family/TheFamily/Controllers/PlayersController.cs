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
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
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

        [HttpGet("{id}", Name = "getplayer")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            try
            {
                var result = await _playerRepository.GetOnePlayer(id);
                if (result == null) return NotFound();
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
        public async Task<ActionResult> CreatePlayer(Player spelare)
        {
            try
            {
                if (spelare == null)
                {
                    return BadRequest();
                }
                var newPlayer = await _playerRepository.CreatePlayer(spelare);
                return CreatedAtRoute("getplayer", new { id = spelare.Id }, spelare);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Creation Error");
            }
        }

        [HttpGet("Random")]
        public async Task<ActionResult<Player>> GetRandomPlayer()
        {
            try
            {
                var result = await _playerRepository.GetRandomPlayer();
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No players found in the database.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Player>> UpdatePlayer(Player spelare, int id)
        {
            try
            {
                var playertoupdate = await _playerRepository.GetOnePlayer(id);
                if (playertoupdate.Id == null)
                {
                    return NotFound($"no player with id{id} exist in the database.");
                }
                return await _playerRepository.UpdatePlayer(spelare);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error updating data");
            }
        }

        [HttpGet("wins")]
        public async Task<ActionResult<Player>> Gettop3Player()
        {
            try
            {
                return Ok(await _playerRepository.GetTop3Players());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    "no players were found in");
            }
        }
    }
}
