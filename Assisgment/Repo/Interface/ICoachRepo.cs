using Assisgment.Model;

namespace Assisgment.Repo.Interface
{
    public interface ICoachRepo : IRepo<Coach>
    {
        public Task<List<Coach>> GetAllCoaches();
        public Task<Coach> GetCoachById(int id);
    }
}
