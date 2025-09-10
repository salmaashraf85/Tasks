using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Specification
{
    public class SpecificationEvaluator<T> where T : class
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
        {
            var query = inputQuery;
            if (spec.Criterias.Any())
            {
                query = spec.Criterias.Aggregate(query, (current, criteria) => current.Where(criteria));
            }
            if (spec.Includes.Any())
            {
                query = spec.Includes
                    .Aggregate(query, (current, include) => current.Include(include));
            }
           
            if (spec.OrderBy != null)
                query = query.OrderBy(spec.OrderBy);

            if (spec.OrderByDescending != null)
                query = query.OrderByDescending(spec.OrderByDescending);

            if (spec.IsPagingEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }

                return query;
        }
    }
}
