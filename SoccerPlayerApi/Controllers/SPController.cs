using Microsoft.AspNetCore.Mvc;
using SoccerPlayerApi.Data.Interfaces;

namespace SoccerPlayerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SPController : Controller
    {
        public readonly ISPRepository _spRepository;

        public SPController(ISPRepository spRepository)
        {
            _spRepository = spRepository;
        }

        //end point que vai acionar a store procedure
        [HttpGet("GetPlayer")]
        public async Task<Player> GetPlayer(string name, int jerseyNumber)
        {   
            //chamando o método do REPOSITÓRIO criado
            var x = await _spRepository.GetPlayer(name, jerseyNumber);
            return x;
        }

        [HttpGet("GetPlayerList")]
        public async Task<List<Player>> GetPlayerList()
        {
            var x =  await _spRepository.GetPlayersList();

            return x;
        }

        [HttpGet("CreatePlayer")]
        public async Task<int> CreatePlayer(int jerseyNumber, string name, int teamId )
        {
            var x = await _spRepository.CreatePlayer(jerseyNumber, name, teamId);

            return x;
        }

        [HttpGet("UpdatePlayer")]
        public async Task<int> UpdatePlayer(int teamId, int playerId)
        {
            var x = await _spRepository.UpdatePlayer(teamId, playerId);

            return x;
        }
    }
}

