using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using UMSS.Core.Generic.Business.Services.Base;
using UMSS.Core.Generic.Common.Communication;
using UMSS.Core.Generic.Common.Communication.Base;
using UMSS.Core.Generic.Common.Entities;
using UMSS.Core.Generic.Common.Models;
using UMSS.Core.Generic.Common.Repositories;
using UMSS.Core.Generic.Common.Repositories.Base;
using UMSS.Core.Generic.Common.Services;

namespace UMSS.Core.Generic.Business.Services
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
