using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UMSS.Core.Common.Entities;
using UMSS.Core.Common.Models;
using UMSS.Core.Common.Repositories;
using UMSS.Core.Common.Specifications;
using UMSS.Core.DataAccess.DatabaseContext;
using UMSS.Core.DataAccess.Repositories.Base;

namespace UMSS.Core.DataAccess.Repositories
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
