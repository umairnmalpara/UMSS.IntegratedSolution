using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UMSS.Generic.Common.Communications;
using UMSS.Generic.Common.Entities;
using UMSS.Generic.Common.Models;

namespace UMSS.Generic.Service.Interface
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
