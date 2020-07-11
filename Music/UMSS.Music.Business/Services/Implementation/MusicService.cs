using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UMSS.Generic.Common.Communications;
using UMSS.Generic.Service.Implementation;
using UMSS.Music.Business.Services.Interface;
using UMSS.Music.Business.Specifications;
using UMSS.Music.DataAccess.UnitOfWork.Interface;
using UMSS.Music.Model;

namespace UMSS.Music.Business.Services.Implementation
{
    public class MusicService : BaseService<UMSS.Music.Entity.Music, MusicModel>, IMusicService
    {
        private readonly IMusicUnitOfWork _unitOfWork;
        private readonly ILogger<MusicService> _logger;

        public MusicService
        (
            IMusicUnitOfWork unitOfWork
            , ILogger<MusicService> logger
        )
        : base(unitOfWork, unitOfWork.Musics, logger)
        {
            this._logger = logger;
            this._unitOfWork = unitOfWork;
        }

        public override void UpdateEntityFields(UMSS.Music.Entity.Music existingEntity, UMSS.Music.Entity.Music entityToBeUpdated)
        {
            existingEntity.Name = entityToBeUpdated.Name;
            existingEntity.ArtistId = entityToBeUpdated.ArtistId;
        }

        public async Task<Response<MusicModel>> SearchMusicWithPagination()
        {
            try
            {
                var spec = new MusicSpecification(1, 100, null, null, "Parallel", "Red Hot Chilli Peppers");
                var musics = await _unitOfWork.Musics.SearchMusicWithPagination(spec);
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
                var spec = new MusicSpecification(artistId);
                var musics = await _unitOfWork.Musics.GetAllMusicByArtistIdAsync(spec);
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
