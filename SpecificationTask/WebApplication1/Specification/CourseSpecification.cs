using WebApplication1.Models;

namespace WebApplication1.Specification
{
    public class CourseSpecification : BaseSpecification<CourseEntity>
    {
        public CourseSpecification(int id, bool includeStudent = false)
        {
            AddCriteria(c => c.Code == id);

            if (includeStudent)
                AddInclude(c => c.Students);
        }
    }
}
