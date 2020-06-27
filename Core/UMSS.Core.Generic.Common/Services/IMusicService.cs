using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UMSS.Core.Generic.Common.Communication.Base;
using UMSS.Core.Generic.Common.Entities;
using UMSS.Core.Generic.Common.Models;
using UMSS.Core.Generic.Common.Services.Base;

namespace UMSS.Core.Generic.Common.Services
{
    public interface IMusicService : IBaseService<Music,MusicModel>
    {
        Task<Response<MusicModel>> SearchMusicWithPagination();
        Task<Response<MusicModel>> GetAllMusicByArtistId(int artistId);
    }
}
