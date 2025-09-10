using WebApplication1.Models;
using WebApplication1.Specification;

namespace WebApplication1.Repositories.Interfaces
{
    public interface ICourseRepository :IGenericRepository<CourseEntity>
    {
        Task<List<CourseEntity>> ListAsync(ISpecification<CourseEntity> spec);

    }
}
