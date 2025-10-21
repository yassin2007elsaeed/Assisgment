using Assisgment.Model;

namespace Assisgment.Repo.Interface
{
    public interface ICompetionRepo : IRepo<Competition>
    {
        public Task<List<Competition>> GetAllComp();
    }
}
