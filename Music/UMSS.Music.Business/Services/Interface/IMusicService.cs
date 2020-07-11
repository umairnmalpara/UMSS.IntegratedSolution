using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UMSS.Generic.Common.Communications;
using UMSS.Generic.Service.Interface;
using UMSS.Music.Model;

namespace UMSS.Music.Business.Services.Interface
{
    public interface IMusicService : IBaseService<UMSS.Music.Entity.Music, MusicModel>
    {
        Task<Response<MusicModel>> SearchMusicWithPagination();
        Task<Response<MusicModel>> GetAllMusicByArtistId(int artistId);
    }
}
