using Assisgment.Dto;
using Assisgment.Model;
using Assisgment.Repo.Implementions;
using Assisgment.Repo.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assisgment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IRepo<Player> _repo;
        private readonly IPlayerRepo _playerRepo;
        private readonly ITeamRepo _teamRepo;

        public PlayerController(IRepo<Player> repo, IPlayerRepo playerRepo, ITeamRepo teamRepo)
        {
            _repo = repo;
            _playerRepo = playerRepo;
            _teamRepo = teamRepo;
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePlayer(int id , PlayerDtoUpdate dto)
        {
            var r = await _repo.GetById(id);
            if( r == null)
            {
                return BadRequest("Not found");
            }
            r.Position = dto.Position;
            await _repo.UpdateAsync(r);
            await _repo.Save();
            return Ok("Updated");
        }
        [HttpGet]
        public async Task<ActionResult> GetAllPlayers()
        {
            var players = await _playerRepo.GetPlayers();

            if (players == null || !players.Any())
            {
                return BadRequest("No players yet");
            }

            var grouped = players
                .GroupBy(p => p.Team.Name) 
                .Select(g => new
                {
                    Team = g.Key,
                     Players = g.Select(p=> new PlayerDtoGet{
                         Id = p.Id,
                         FullName = p.FullName,
                         Position = p.Position,
                         Age = p.Age
                     }).ToList(),
                    YoungestPlayer = g
                        .OrderBy(p => p.Age)
                        .Select(p => new PlayerDtoGet
                        {
                            Id = p.Id,
                            FullName = p.FullName,
                            Position = p.Position,
                            Age = p.Age
                        })
                        .FirstOrDefault()
                });

            return Ok(grouped);
        }

    }
}


