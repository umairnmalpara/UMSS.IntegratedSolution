using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using UMSS.Core.Business.Services.Base;
using UMSS.Core.Common.Communication;
using UMSS.Core.Common.Communication.Base;
using UMSS.Core.Common.Entities;
using UMSS.Core.Common.Models;
using UMSS.Core.Common.Repositories;
using UMSS.Core.Common.Repositories.Base;
using UMSS.Core.Common.Services;

namespace UMSS.Core.Business.Services
{
    public class ArtistService : BaseService<Artist,ArtistModel> , IArtistService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ArtistService> _logger;

        public ArtistService 
        (
            IUnitOfWork unitOfWork
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
