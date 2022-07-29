using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Specifications
{
    //This is needed to make the GenericRepository more customizable

    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
            /* this empty constructer was needed to allow us to get the BaseSpecification<T> 
            into our ProductsWithTypesAndBrandsSpecification Class*/
        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public System.Linq.Expressions.Expression<Func<T, bool>> Criteria {get; }

        public List<System.Linq.Expressions.Expression<Func<T, object>>> Includes {get; } = 
            new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}