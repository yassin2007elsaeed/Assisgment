using Assisgment.DataBase;
using Assisgment.Model;
using Assisgment.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace Assisgment.Repo.Implementions
{
    public class TeamRepo : Repo<Team>, ITeamRepo
    {
        public TeamRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Team>> GetTeams()
        {
            return await _context.Teams.Include(x=> x.Players)
                .Include(x=> x.Competitions)
                .Where(x=> x.Competitions.Count() == 0)
                .OrderByDescending(x=> x.Players.Count())
                .ToListAsync();
        }
    }
}
