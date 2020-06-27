using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UMSS.Core.Generic.Common.Entities;
using UMSS.Core.Generic.Common.Models;
using UMSS.Core.Generic.Common.Repositories.Base;

namespace UMSS.Core.Generic.Common.Repositories
{
    public interface IMusicRepository : IRepository<Music,MusicModel>
    {
        Task<IEnumerable<MusicModel>> SearchMusicWithPagination();
        Task<IEnumerable<MusicModel>> GetAllMusicByArtistIdAsync(int artistId);
    }
}
