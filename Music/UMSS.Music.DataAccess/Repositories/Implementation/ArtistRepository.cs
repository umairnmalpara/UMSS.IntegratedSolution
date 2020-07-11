using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UMSS.Generic.Repository.Implementation;
using UMSS.Music.DataAccess.Repositories.Interface;
using UMSS.Music.DataService;
using UMSS.Music.Entity;
using UMSS.Music.MapperService;
using UMSS.Music.Model;

namespace UMSS.Music.DataAccess.Repositories.Implementation
{
    public class ArtistRepository : BaseRepository<Artist, ArtistModel>, IArtistRepository
    {
        private MusicDbContext MusicDbContext
        {
            get { return Context as MusicDbContext; }
        }

        public ArtistRepository(DbContext context) : base(context)
        {
        }

        public override IConfigurationProvider Configuration => ObjectMapper.Mapper.ConfigurationProvider;

        public async Task<IEnumerable<Artist>> GetAllWithMusicsAsync()
        {
            return await MusicDbContext.Artists
                .Include(a => a.Musics)
                .ToListAsync();
        }

        public async Task<Artist> GetWithMusicsByIdAsync(int id)
        {
            return await MusicDbContext.Artists
                .Include(a => a.Musics)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

    }
}
