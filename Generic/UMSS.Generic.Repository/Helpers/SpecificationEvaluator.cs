﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using UMSS.Generic.Common.Entities;
using UMSS.Generic.Common.Models;
using UMSS.Generic.Common.Specifications;

namespace UMSS.Generic.Repository.Helpers
{
    public class SpecificationEvaluator<TEntity,TModel> where TEntity : BaseEntity where TModel : BaseModel
    {
        public static IQueryable<TModel> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification,IConfigurationProvider configuration)
        {
            var query = inputQuery;

            // modify the IQueryable using the specification's criteria expression
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            // Includes all expression-based includes
            query = specification.Includes.Aggregate(query,
                                    (current, include) => current.Include(include));

            // Include any string-based include statements
            query = specification.IncludeStrings.Aggregate(query,
                                    (current, include) => current.Include(include));

            // Apply ordering if expressions are set
            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            else if (specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            // Apply paging if enabled
            if (specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip)
                             .Take(specification.Take);
            }
            return query.ProjectTo<TModel>(configuration);
        }
    }
}
