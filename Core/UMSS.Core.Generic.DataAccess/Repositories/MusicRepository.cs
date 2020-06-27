using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UMSS.Core.Generic.Common.Entities;
using UMSS.Core.Generic.Common.Models;
using UMSS.Core.Generic.Common.Repositories;
using UMSS.Core.Generic.Common.Specifications;
using UMSS.Core.Generic.DataAccess.DatabaseContext;
using UMSS.Core.Generic.DataAccess.Repositories.Base;

namespace UMSS.Core.Generic.DataAccess.Repositories
{
    public class MusicRepository : Repository<Music,MusicModel> , IMusicRepository
    {
        private IntegratedDatabaseContext IntegratedDbContext
        {
            get { return Context as IntegratedDatabaseContext; }
        }

        public MusicRepository(IntegratedDatabaseContext context)
            : base(context)
        { }

        public async Task<IEnumerable<MusicModel>> SearchMusicWithPagination()
        {
            var spec = new MusicSpecification(1, 100, null, null, "Parallel", "Red Hot Chilli Peppers");
            return await GetAsync(spec);
        }

        public async Task<IEnumerable<MusicModel>> GetAllMusicByArtistIdAsync(int artistId)
        {
            var spec = new MusicSpecification(artistId);
            return await GetAsync(spec);
        }

    }
}
