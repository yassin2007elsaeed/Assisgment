using Assisgment.Model;

namespace Assisgment.Repo.Interface
{
    public interface IPlayerRepo : IRepo<Player>
    {
        public Task<List<Player>> GetPlayers();
    }
}
