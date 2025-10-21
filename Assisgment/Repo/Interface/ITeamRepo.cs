using Assisgment.Model;

namespace Assisgment.Repo.Interface
{
    public interface ITeamRepo : IRepo<Team>
    {
        public Task<List<Team>> GetTeams();
    }
}
