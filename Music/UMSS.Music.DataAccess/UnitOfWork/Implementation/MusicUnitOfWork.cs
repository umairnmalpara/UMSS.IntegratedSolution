using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UMSS.Music.DataAccess.Repositories.Implementation;
using UMSS.Music.DataAccess.Repositories.Interface;
using UMSS.Music.DataAccess.UnitOfWork.Interface;
using UMSS.Music.DataService;

namespace UMSS.Music.DataAccess.UnitOfWork.Implementation
{
    public class MusicUnitOfWork : IMusicUnitOfWork
    {
        private readonly MusicDbContext _context;
        private ArtistRepository _artistRepository;
        private MusicRepository _musicRepository;

        public MusicUnitOfWork(MusicDbContext context)
        {
            this._context = context;
        }

        public IArtistRepository Artists => _artistRepository = _artistRepository ?? new ArtistRepository(_context);

        public IMusicRepository Musics => _musicRepository = _musicRepository ?? new MusicRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
