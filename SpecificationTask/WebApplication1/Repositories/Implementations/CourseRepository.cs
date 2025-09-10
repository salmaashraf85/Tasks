using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Specification;

namespace WebApplication1.Repositories.Implementations
{
    public class CourseRepository : GenericRepository<CourseEntity>, ICourseRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<CourseEntity>> ListAsync(ISpecification<CourseEntity> spec)
        {
            var query = SpecificationEvaluator<CourseEntity>.GetQuery(_context.Courses.AsQueryable(), spec);
            return await query.ToListAsync();
        }

    }
}
