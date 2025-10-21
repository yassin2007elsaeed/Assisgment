using Assisgment.DataBase;
using Assisgment.Model;
using Assisgment.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace Assisgment.Repo.Implementions
{
    public class CoachRepo : Repo<Coach>, ICoachRepo
    {
        public CoachRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Coach>> GetAllCoaches()
        {
            return await _context.Coachs.Include(x=> x.Team).ToListAsync();
        }

        public async Task<Coach> GetCoachById(int id)
        {
            return await _context.Coachs.Include(x => x.Team).ThenInclude(x=> x.Players).FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
