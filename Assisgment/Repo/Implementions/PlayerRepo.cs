using Assisgment.DataBase;
using Assisgment.Model;
using Assisgment.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace Assisgment.Repo.Implementions
{
    public class PlayerRepo : Repo<Player>, IPlayerRepo
    {
        public PlayerRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Player>> GetPlayers()
        {
           return await _context.Players.Include(x=> x.Team)
                .ToListAsync();
        }
    }
}
