using WebApplication1.Models;

namespace WebApplication1.Specification
{
    public class StudentSpecification : BaseSpecification<StudentEntity>
    {
        public StudentSpecification(int id, bool includeCourses = false)
        {
            AddCriteria(s => s.SID==id);

            if (includeCourses)
                AddInclude(s => s.Courses); 
        }
    }
}
