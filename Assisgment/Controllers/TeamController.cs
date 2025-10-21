using System.Text.RegularExpressions;
using Assisgment.Dto;
using Assisgment.Model;
using Assisgment.Repo.Implementions;
using Assisgment.Repo.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assisgment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IRepo<Team> _repo;
        private readonly ICoachRepo _coachRepo;
        private readonly ITeamRepo _teamRepo;

        public TeamController(IRepo<Team> repo, ICoachRepo coachRepo, ITeamRepo teamRepo)
        {
            _repo = repo;
            _coachRepo = coachRepo;
            _teamRepo = teamRepo;
        }

        [HttpPost]
       
        public async Task<ActionResult> AddTeam(TeamDtoAdd dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid data");
            }
            var r = await _repo.GetAllAsync();

            if(r.Any(x=> x.Name == dto.Name))
            {
                return BadRequest("Name Team is Alredy found ");
            }
            Team team = new Team
            {
                Name = dto.Name,
                City = dto.City,
                CoachId = dto.CouchId,
            };

            await _repo.CreateAsync(team);
            await _repo.Save();

            return Ok("Added");
        }


        [HttpGet]
        public async Task<ActionResult> GetAllTeams()
        {
            var r = await _teamRepo.GetTeams();
            if(r == null)
            {
                return BadRequest("No Team Yet");
            }
            var Team = r.Select(x=> new TeamDtoGetAll
            {
                Id = x.Id,
                Name = x.Name,
                City = x.City,
                PlayerCount = x.Players.Count(),
            }).ToList();
            return Ok(Team);
        }
    }
}




















