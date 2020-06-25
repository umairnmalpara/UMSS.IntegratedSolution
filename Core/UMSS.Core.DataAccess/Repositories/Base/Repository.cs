using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using UMSS.Core.DataAccess.Mapper;
using UMSS.Core.Common.Models.Base;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using UMSS.Core.Common.Entities.Base;
using UMSS.Core.Common.Repositories.Base;
using UMSS.Core.Common.Specifications.Base;

namespace UMSS.Core.DataAccess.Repositories.Base
{
    public abstract class Repository<TEntity,TModel> : IRepository<TEntity,TModel> where TEntity : BaseEntity where TModel : BaseModel
    {
        protected readonly DbContext Context;
        
        public Repository(DbContext context)
        {
            this.Context = context;
        }

        public async Task<IReadOnlyList<TModel>> GetAllAsync()
        {
            return await Context.Set<TEntity>()
                .ProjectTo<TModel>(ObjectMapper.Mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<TModel> GetByIdAsync(int id)
        {
            //return await Context.Set<TEntity>()
            //    .Where(a => a.Id == id)
            //    .ProjectTo<TModel>(ObjectMapper.Mapper.ConfigurationProvider)
            //    .FirstOrDefaultAsync();

            return await GetFirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<TEntity> FindAsync(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IReadOnlyList<TModel>> GetAsync(ISpecification<TEntity> spec)
        {
            return await ApplySpecification(spec)
                .ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<TEntity> spec)
        {
            return await ApplySpecification(spec)
                .CountAsync();
        }

        private IQueryable<TModel> ApplySpecification(ISpecification<TEntity> spec)
        {
            return SpecificationEvaluator<TEntity, TModel>.GetQuery(Context.Set<TEntity>().AsQueryable(), spec);
        }

        public async Task<TModel> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>()
                .Where(predicate)
                .ProjectTo<TModel>(ObjectMapper.Mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<TModel>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>()
                .Where(predicate)
                .ProjectTo<TModel>(ObjectMapper.Mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<TModel>> GetAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>
            , IOrderedQueryable<TEntity>> orderBy = null, string includeString = null, bool disableTracking = true)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();
            if (disableTracking) query = query.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ProjectTo<TModel>(ObjectMapper.Mapper.ConfigurationProvider).ToListAsync();
            return await query.ProjectTo<TModel>(ObjectMapper.Mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<IReadOnlyList<TModel>> GetAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>
            , IOrderedQueryable<TEntity>> orderBy = null, List<Expression<Func<TEntity, object>>> includes = null
            , bool disableTracking = true)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();
            if (disableTracking) query = query.AsNoTracking();

            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ProjectTo<TModel>(ObjectMapper.Mapper.ConfigurationProvider).ToListAsync();
            return await query.ProjectTo<TModel>(ObjectMapper.Mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

    }
}
