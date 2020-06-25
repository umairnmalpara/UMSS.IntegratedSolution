using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using UMSS.Core.Common.Communication.Base;
using UMSS.Core.Common.Entities.Base;
using UMSS.Core.Common.Models.Base;
using UMSS.Core.Common.Repositories.Base;
using UMSS.Core.Common.Services.Base;

namespace UMSS.Core.Business.Services.Base
{
    public abstract class BaseService<TEntity,TModel> : IBaseService<TEntity,TModel> where TEntity : BaseEntity where TModel : BaseModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TEntity, TModel> _entityRepository;
        private readonly ILogger _logger;
        public BaseService
        (
            IUnitOfWork unitOfWork, IRepository<TEntity, TModel> entityRepository
            , ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _entityRepository = entityRepository;
            _logger = logger;
        }

        public abstract void UpdateEntityFields(TEntity existingEntity,TEntity entityToBeUpdated);

        public async Task<Response<TModel>> GetAllEntity()
        {
            try
            {
                var entity = await _entityRepository.GetAllAsync();
                return new Response<TModel>(entity);
            }
            catch (Exception ex)
            {
                var exceptionMessage = $"An error occurred when getting all {typeof(TEntity).Name} : {ex.Message}";
                _logger.LogError(ex, exceptionMessage);
                return new Response<TModel>(exceptionMessage);
            }
        }

        public async Task<Response<TModel>> GetEntityById(int id)
        {
            try
            {
                var entity = await _entityRepository.GetByIdAsync(id);
                return new Response<TModel>(entity);
            }
            catch (Exception ex)
            {
                var exceptionMessage = $"An error occurred when getting the {typeof(TEntity).Name} by id: {ex.Message}";
                _logger.LogError(ex, exceptionMessage);
                return new Response<TModel>(exceptionMessage);
            }
        }

        public async Task<Response<TEntity>> FindAsync(int id)
        {
            try
            {
                var entity = await _entityRepository.FindAsync(id);
                return new Response<TEntity>(entity);
            }
            catch (Exception ex)
            {
                var exceptionMessage = $"An error occurred when getting the {typeof(TEntity).Name} by id: {ex.Message}";
                _logger.LogError(ex, exceptionMessage);
                return new Response<TEntity>(exceptionMessage);
            }
        }

        public async Task<Response<TModel>> CreateEntity(TEntity newEntity)
        {
            try
            {
                await _entityRepository.AddAsync(newEntity);
                await _unitOfWork.CommitAsync();

                var result = await GetEntityById(newEntity.Id);
                if (!result.Success)
                    return new Response<TModel>(result.Message);

                return new Response<TModel>(result.Entity);
            }
            catch (Exception ex)
            {
                var exceptionMessage = $"An error occurred when creating the {typeof(TEntity).Name}: {ex.Message}";
                _logger.LogError(ex, exceptionMessage);
                return new Response<TModel>(exceptionMessage);
            }
        }

        public async Task<Response<TModel>> UpdateEntity(int id, TEntity entityToBeUpdated)
        {
            var result = await FindAsync(id);
            if (!result.Success)
                return new Response<TModel>(result.Message);

            var existingEntity = result.Entity;

            if (existingEntity == null)
            {
                var informationMesssage = $"{typeof(TEntity).Name} with ID {id} not found.";
                _logger.LogInformation(informationMesssage);
                return new Response<TModel>(informationMesssage);
            }

            UpdateEntityFields(existingEntity, entityToBeUpdated);

            try
            {
                _entityRepository.Update(existingEntity);
                await _unitOfWork.CommitAsync();

                var returnResult = await GetEntityById(id);
                if (!result.Success)
                    return new Response<TModel>(returnResult.Message);

                return new Response<TModel>(returnResult.Entity);
            }
            catch (Exception ex)
            {
                var exceptionMessage = $"An error occurred when updating the artist: {ex.Message}";
                _logger.LogError(ex, exceptionMessage);
                return new Response<TModel>(exceptionMessage);
            }
        }

        public async Task<Response<TModel>> DeleteEntity(int id)
        {
            var result = await FindAsync(id);
            if (!result.Success)
                return new Response<TModel>(result.Message);

            var existingEntity = result.Entity;

            if (existingEntity == null)
            {
                var informationMesssage = $"{typeof(TEntity).Name} with ID {id} not found.";
                _logger.LogInformation(informationMesssage);
                return new Response<TModel>(informationMesssage);
            }

            try
            {
                _entityRepository.Remove(existingEntity);
                await _unitOfWork.CommitAsync();

                return new Response<TModel>();
            }
            catch (Exception ex)
            {
                var exceptionMessage = $"An error occurred when deleting the {typeof(TEntity).Name}: {ex.Message}";
                _logger.LogError(ex, exceptionMessage);
                return new Response<TModel>(exceptionMessage);
            }
        }
    }
}
