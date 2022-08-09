using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery;

            if(spec.Criteria != null)
            {
                query = query.Where(spec.Criteria); //p => p.ProductTypeId = id;
            }

            //below is for the pagination to order them
            if(spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy); //p => p.ProductTypeId = id;
            }
            if(spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending); //p => p.ProductTypeId = id;
            }
            //below is taking our include statements and passing them into our query
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}