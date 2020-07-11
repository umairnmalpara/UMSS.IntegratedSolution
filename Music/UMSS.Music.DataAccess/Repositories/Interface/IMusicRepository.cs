using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UMSS.Generic.Common.Specifications;
using UMSS.Generic.Repository.Interface;
using UMSS.Music.Model;

namespace UMSS.Music.DataAccess.Repositories.Interface
{
    public interface IMusicRepository : IBaseRepository<UMSS.Music.Entity.Music, MusicModel>
    {
        Task<IEnumerable<MusicModel>> SearchMusicWithPagination(ISpecification<UMSS.Music.Entity.Music> spec);
        Task<IEnumerable<MusicModel>> GetAllMusicByArtistIdAsync(ISpecification<UMSS.Music.Entity.Music> spec);
    }
}
