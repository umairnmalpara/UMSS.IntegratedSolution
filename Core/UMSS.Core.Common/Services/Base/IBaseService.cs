using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UMSS.Core.Common.Communication.Base;
using UMSS.Core.Common.Entities.Base;
using UMSS.Core.Common.Models.Base;

namespace UMSS.Core.Common.Services.Base
{
    public interface IBaseService<TEntity,TModel> where TEntity : BaseEntity where TModel : BaseModel
    {
        Task<Response<TModel>> GetAllEntity();
        Task<Response<TModel>> GetEntityById(int id);
        Task<Response<TEntity>> FindAsync(int id);
        Task<Response<TModel>> CreateEntity(TEntity newEntity);
        Task<Response<TModel>> UpdateEntity(int id, TEntity entityToBeUpdated);
        Task<Response<TModel>> DeleteEntity(int id);
    }
}
