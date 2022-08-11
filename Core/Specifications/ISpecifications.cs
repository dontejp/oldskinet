using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria {get; }          
        List<Expression<Func<T, object>>> Includes {get; }
        Expression<Func<T, object>> OrderBy {get;}          //properties for sorting

        Expression<Func<T, object>> OrderByDescending {get;}

        int Take {get;}         //properties for pagination
        int Skip {get;}
        bool IsPagingEnabled {get;}
    }
}