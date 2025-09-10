using System.Data;

namespace WebApplication1.AppMetaData
{
    public partial class Router
    {
        public class CourseRoute
        {
            private const string Prefix = Rule + "Course";
            public const string Main = Prefix + "/";
            public const string MainId = Prefix + "/{id}";
        }
    }
}
