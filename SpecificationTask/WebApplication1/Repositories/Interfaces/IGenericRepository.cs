using WebApplication1.Models;
using WebApplication1.Specification;

namespace WebApplication1.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public Task Create(TEntity entity);

        public Task<List<TEntity>> GetAll();

        public Task<TEntity> GetById(int id);

        public Task Update(TEntity entity);

        public Task Delete(TEntity entity);

        Task<List<TEntity>> ListAsync(ISpecification<TEntity> spec);
    }
}
