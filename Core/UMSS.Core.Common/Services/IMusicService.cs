using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UMSS.Core.Common.Communication.Base;
using UMSS.Core.Common.Entities;
using UMSS.Core.Common.Models;
using UMSS.Core.Common.Services.Base;

namespace UMSS.Core.Common.Services
{
    public interface IMusicService : IBaseService<Music,MusicModel>
    {
        Task<Response<MusicModel>> SearchMusicWithPagination();
        Task<Response<MusicModel>> GetAllMusicByArtistId(int artistId);
    }
}
