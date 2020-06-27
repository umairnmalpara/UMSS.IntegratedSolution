using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UMSS.Core.Generic.Common.Entities.Base;
using UMSS.Core.Generic.Common.Models.Base;
using UMSS.Core.Generic.Common.Specifications.Base;

namespace UMSS.Core.Generic.Common.Repositories.Base
{
    public interface IRepository<TEntity,TModel> where TEntity : BaseEntity where TModel : BaseModel
    {
        Task<IReadOnlyList<TModel>> GetAllAsync();
        Task<TModel> GetByIdAsync(int id);
        Task<TEntity> FindAsync(int id);
        Task<TModel> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IReadOnlyList<TModel>> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IReadOnlyList<TModel>> GetAsync(Expression<Func<TEntity, bool>> predicate = null,
                                        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                        string includeString = null,
                                        bool disableTracking = true);
        Task<IReadOnlyList<TModel>> GetAsync(Expression<Func<TEntity, bool>> predicate = null,
                                        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                        List<Expression<Func<TEntity, object>>> includes = null,
                                        bool disableTracking = true);
        Task<IReadOnlyList<TModel>> GetAsync(ISpecification<TEntity> spec);
        
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        Task<int> CountAsync(ISpecification<TEntity> spec);

    }
}
