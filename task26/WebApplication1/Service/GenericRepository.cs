namespace WebApplication1.Service;
using WebApplication1.Interfaces;

public class GenericRepository<TEntity>(ApplicationDbContext applicationDbContext) : IGenericRepository<TEntity> where TEntity : class
{
    public void Add(TEntity entity)
    {
        applicationDbContext.Set<TEntity>().Add(entity);
    }

    public void Delete(TEntity entity)
    {
        applicationDbContext.Set<TEntity>().Remove(entity);
    }

    public void Update(TEntity entity)
    {
        applicationDbContext.Set<TEntity>().Update(entity);
    }

    public TEntity? GetById(params object[] keyValues)
    {
        return applicationDbContext.Set<TEntity>().Find(keyValues);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return applicationDbContext.Set<TEntity>().ToList();
    }
}