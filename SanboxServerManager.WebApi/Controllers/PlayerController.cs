using Microsoft.AspNetCore.Mvc;
using SanboxServerManager.Application.Services;

namespace SanboxServerManager.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet("players")]
        public async Task<IActionResult> GetAllPlayers()
        {
            try
            {
                var playersResult = await _playerService.GetAllPlayersAsync();

                return Ok(playersResult);
            }

            catch
            {
                return StatusCode(500, "Internal server error");
            }
            
        }

        [HttpGet("admins")]
        public async Task<IActionResult> GetAllAdmins()
        {
            try
            {
                var adminsResult = await _playerService.GetAllAdminsAsync();

                return Ok(adminsResult);
            }

            catch
            {
                return StatusCode(500, "Internal server error");
            }
           
        }
    }
}
