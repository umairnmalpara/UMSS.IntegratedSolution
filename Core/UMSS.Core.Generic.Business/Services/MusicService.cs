using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using UMSS.Core.Generic.Business.Services.Base;
using UMSS.Core.Generic.Common.Communication.Base;
using UMSS.Core.Generic.Common.Entities;
using UMSS.Core.Generic.Common.Models;
using UMSS.Core.Generic.Common.Repositories.Base;
using UMSS.Core.Generic.Common.Services;

namespace UMSS.Core.Generic.Business.Services
{
    public class MusicService : BaseService<Music,MusicModel> ,IMusicService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<MusicService> _logger;

        public MusicService
        (
            IUnitOfWork unitOfWork
            , ILogger<MusicService> logger
        )
        : base (unitOfWork, unitOfWork.Musics,logger)
        {
            this._logger = logger;
            this._unitOfWork = unitOfWork;
        }

        public override void UpdateEntityFields(Music existingEntity, Music entityToBeUpdated)
        {
            existingEntity.Name = entityToBeUpdated.Name;
            existingEntity.ArtistId = entityToBeUpdated.ArtistId;
        }

        public async Task<Response<MusicModel>> SearchMusicWithPagination()
        {
            try
            {
                var musics = await _unitOfWork.Musics.SearchMusicWithPagination();
                return new Response<MusicModel>(musics);
            }
            catch (Exception ex)
            {
                var exceptionMessage = $"An error occurred when searching musics with pagination: {ex.Message}";
                _logger.LogError(ex, exceptionMessage);
                return new Response<MusicModel>(exceptionMessage);
            }
        }

        public async Task<Response<MusicModel>> GetAllMusicByArtistId(int artistId)
        {
            try
            {
                var musics = await _unitOfWork.Musics.GetAllMusicByArtistIdAsync(artistId);
                return new Response<MusicModel>(musics);
            }
            catch (Exception ex)
            {
                var exceptionMessage = $"An error occurred when getting all musics with artist by artistId: {ex.Message}";
                _logger.LogError(ex, exceptionMessage);
                return new Response<MusicModel>(exceptionMessage);
            }
        }

    }
}
