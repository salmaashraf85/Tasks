//using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Interfaces;

public interface IGenericRepository<TEntity> where TEntity : class
{
    public void Add(TEntity entity);
    public void Delete(TEntity entity);
    public void Update(TEntity entity);
    public TEntity? GetById(params object[] keyValues);
    public IEnumerable<TEntity> GetAll();
}