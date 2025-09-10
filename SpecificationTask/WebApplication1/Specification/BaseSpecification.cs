using System.Linq.Expressions;

namespace WebApplication1.Specification
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public List<Expression<Func<T, bool>>> Criterias { get; set; } = new();
        public List<Expression<Func<T, object>>> Includes { get; set; } = new();

        public Expression<Func<T,object>> OrderBy { get; set; }
        public Expression<Func<T,object>> OrderByDescending { get; set; }

        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsPagingEnabled { get; set; }

        public void AddCriteria(Expression<Func<T, bool>> criteria) 
        {
            Criterias.Add(criteria);
        }

        public void AddInclude(Expression<Func<T, object>> include)
        {
            Includes.Add(include);
        }

        public void AddOrderByDescending(Expression<Func<T, object>> orderByDesc)
        {
            OrderByDescending = orderByDesc;
        }

        public void AddOrderBy(Expression<Func<T, object>> orderBy)
        {
            OrderBy = orderBy;
        }

        public void ApplyPagination(int skip,int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;

        }









    }
}
