namespace Assisgment.Repo.Interface
{
    public interface IRepo<T> where T : class
    {
        public Task CreateAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(T entity);
        public Task<T> GetById(int id);
        public Task<List<T>> GetAllAsync();
        public Task Save();

    }
}
