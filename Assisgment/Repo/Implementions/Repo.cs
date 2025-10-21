using Assisgment.DataBase;
using Assisgment.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace Assisgment.Repo.Implementions
{
    public class Repo<T> : IRepo<T> where T : class
    {
        public readonly AppDbContext _context;

        public Repo(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
          await  _context.Set<T>().AddAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
           _context.Set<T>().Remove(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();

        }

        public async Task<T> GetById(int id)
        {
           return await _context.Set<T>().FindAsync(id);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
           _context.Set<T>().Update(entity);
        }
    }
}
