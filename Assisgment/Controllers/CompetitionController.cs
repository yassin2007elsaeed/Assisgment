using Assisgment.Dto;
using Assisgment.Model;
using Assisgment.Repo.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assisgment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionController : ControllerBase
    {
        private readonly IRepo<Competition> _repo;
        private readonly ICompetionRepo _competionRepo;

        public CompetitionController(IRepo<Competition> repo, ICompetionRepo competionRepo)
        {
            _repo = repo;
            _competionRepo = competionRepo;
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCompetition(int id)
        {
            var r = await _repo.GetById(id);
            if (r == null)
            {
                return BadRequest("Not found");
            }
            await _repo.DeleteAsync(r);
            await _repo.Save();
            return Ok("Deleted");
        }
        [HttpGet]
        public async Task<ActionResult> GetAllCompetitions()
        {
            var competitions = await _competionRepo.GetAllComp();

            if (competitions == null || !competitions.Any())
            {
                return BadRequest("No competitions yet");
            }

            var groupedCompetitions = competitions
                .GroupBy(c => c.Location)
                .Select(g => new
                {
                    Location = g.Key,
                    Competitions = g.Select(c => new CompetitonDtoGet
                    {
                        Id = c.Id,
                        Tiitle = c.Tiitle,
                        DateTime = c.DateTime,
                        Location = c.Location,
                        teams = c.Teams.Select(x => new TeamDtoGet
                        {
                            Id = x.Id,
                            Name = x.Name,
                            City = x.City,
                        }).ToList(),
                        TotalnumberOfPlayersInTeam = c.Teams.SelectMany(t => t.Players).Count()
                    }).ToList()
                }).ToList();

            return Ok(groupedCompetitions);
        }
    }
}

