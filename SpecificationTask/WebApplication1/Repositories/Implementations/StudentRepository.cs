using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Specification;

namespace WebApplication1.Repositories.Implementations
{
    public class StudentRepository : GenericRepository<StudentEntity>, IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<StudentEntity>> ListAsync(ISpecification<StudentEntity> spec)
        {
            var query = SpecificationEvaluator<StudentEntity>.GetQuery(_context.Students.AsQueryable(), spec);
            return await query.ToListAsync();
        }
    }
}
