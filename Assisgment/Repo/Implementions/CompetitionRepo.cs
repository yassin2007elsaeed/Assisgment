using Assisgment.DataBase;
using Assisgment.Model;
using Assisgment.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace Assisgment.Repo.Implementions
{
    public class CompetitionRepo : Repo<Competition>, ICompetionRepo
    {
        public CompetitionRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Competition>> GetAllComp()
        {
            return await _context.Competions.Include(x=> x.Teams)
                .ThenInclude(x=> x.Players)
                .ToListAsync();
        }
    }
}
