using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using UMSS.Generic.Service.Implementation;
using UMSS.Music.Business.Services.Interface;
using UMSS.Music.DataAccess.UnitOfWork.Interface;
using UMSS.Music.Entity;
using UMSS.Music.Model;

namespace UMSS.Music.Business.Services.Implementation
{
    public class ArtistService : BaseService<Artist,ArtistModel> , IArtistService
    {
        private readonly IMusicUnitOfWork _unitOfWork;
        private readonly ILogger<ArtistService> _logger;

        public ArtistService 
        (
            IMusicUnitOfWork unitOfWork
            , ILogger<ArtistService> logger
        ) 
        : base(unitOfWork, unitOfWork.Artists, logger)
        {
            this._logger = logger;
            this._unitOfWork = unitOfWork;
        }

        public override void UpdateEntityFields(Artist existingEntity, Artist entityToBeUpdated)
        {
            existingEntity.Name = entityToBeUpdated.Name;
        }

    }
}
