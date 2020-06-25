using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UMSS.Core.Common.Entities;
using UMSS.Core.Common.Models;
using UMSS.Core.Common.Repositories.Base;

namespace UMSS.Core.Common.Repositories
{
    public interface IMusicRepository : IRepository<Music,MusicModel>
    {
        Task<IEnumerable<MusicModel>> SearchMusicWithPagination();
        Task<IEnumerable<MusicModel>> GetAllMusicByArtistIdAsync(int artistId);
    }
}
