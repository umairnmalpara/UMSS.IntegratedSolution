using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UMSS.Generic.Common.Specifications;
using UMSS.Generic.Repository.Implementation;
using UMSS.Music.DataAccess.Repositories.Interface;
using UMSS.Music.DataService;
using UMSS.Music.MapperService;
using UMSS.Music.Model;

namespace UMSS.Music.DataAccess.Repositories.Implementation
{
    public class MusicRepository : BaseRepository<UMSS.Music.Entity.Music, MusicModel>, IMusicRepository
    {
        private MusicDbContext IntegratedDbContext
        {
            get { return Context as MusicDbContext; }
        }

        public MusicRepository(MusicDbContext context)
            : base(context)
        { }

        public override IConfigurationProvider Configuration => ObjectMapper.Mapper.ConfigurationProvider;

        public async Task<IEnumerable<MusicModel>> SearchMusicWithPagination(ISpecification<UMSS.Music.Entity.Music> spec)
        {
            //var spec = new MusicSpecification(1, 100, null, null, "Parallel", "Red Hot Chilli Peppers");
            return await GetAsync(spec);
        }

        public async Task<IEnumerable<MusicModel>> GetAllMusicByArtistIdAsync(ISpecification<UMSS.Music.Entity.Music> spec)
        {
            //var spec = new MusicSpecification(artistId);
            return await GetAsync(spec);
        }

    }
}
