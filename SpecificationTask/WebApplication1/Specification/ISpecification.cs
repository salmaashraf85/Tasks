using System.Linq.Expressions;

namespace WebApplication1.Specification
{
    public interface ISpecification<T>
    {
        public List<Expression<Func<T, bool>>>? Criterias { get; }
        public List<Expression<Func<T, object>>> Includes { get; }
        public Expression<Func<T, object>>? OrderBy { get; }
        public Expression<Func<T, object>>? OrderByDescending { get; }
        public int Skip { get; }
        public int Take { get; }
        public bool IsPagingEnabled { get; }
    }
}
