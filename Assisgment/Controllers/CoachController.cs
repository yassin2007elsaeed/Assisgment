using Assisgment.Dto;
using Assisgment.Repo.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assisgment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        private readonly ICoachRepo _coachRepo;

        public CoachController(ICoachRepo coachRepo)
        {
            _coachRepo = coachRepo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllCoaches()
        {
            var r = await _coachRepo.GetAllCoaches();
            if(r == null)
            {
                return BadRequest("NO coaches yet");
            }
            //yasso
            var coach = r.Select(x=> new CoachDtoGet
            {
                Id = x.Id,
                ExperinceYears = x.ExperinceYears,
                Name = x.Name,
                Specilzation = x.Specilzation,
                Team = new TeamDtoGet
                {
                    Id = x.Team.Id,
                    Name = x.Team.Name,
                    City = x.Team.City,
                }
            }).ToList();
            var grouped = coach.GroupBy(x=> x.Specilzation).Select(x=> new
            {
                x.Key,
                TeamName = x.Select(x=>x.Team.Name),
                Coaches = x.ToList(),
            }).ToList();
            return Ok(grouped);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCoachById(int id)
        {
            var r = await _coachRepo.GetCoachById(id);
            if(r == null)
            {
                return BadRequest("Not found");
            }
            var coach = new CoachDtoGetByid()
            {
                Id = r.Id,
                ExperinceYears = r.ExperinceYears,
                Name = r.Name,
                Specilzation = r.Specilzation,
                Team = new TeamDtoGet()
                {
                    Id = r.Team.Id,
                    Name = r.Team.Name,
                    City = r.Team.City,
                },
                TotalPlayers = r.Team.Players.Count(),

            };
            return Ok(coach);
        }
    }
}
