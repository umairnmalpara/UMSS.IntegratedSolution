using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UMSS.Core.Generic.Common.Entities;
using UMSS.Core.Generic.Common.Models;
using UMSS.Core.Generic.Common.Repositories;
using UMSS.Core.Generic.DataAccess.DatabaseContext;
using UMSS.Core.Generic.DataAccess.Repositories.Base;

namespace UMSS.Core.Generic.DataAccess.Repositories
{
    public class ArtistRepository : Repository<Artist,ArtistModel>, IArtistRepository
    {
        private IntegratedDatabaseContext IntegratedDbContext
        {
            get { return Context as IntegratedDatabaseContext; }
        }

        public ArtistRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Artist>> GetAllWithMusicsAsync()
        {
            return await IntegratedDbContext.Artists
                .Include(a => a.Musics)
                .ToListAsync();
        }

        public async Task<Artist> GetWithMusicsByIdAsync(int id)
        {
            return await IntegratedDbContext.Artists
                .Include(a => a.Musics)
                .SingleOrDefaultAsync(a => a.Id == id);
        }
    }
}
