﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UMSS.Core.Common.Repositories;
using UMSS.Core.Common.Repositories.Base;
using UMSS.Core.DataAccess.DatabaseContext;

namespace UMSS.Core.DataAccess.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IntegratedDatabaseContext _context;
        private MusicRepository _musicRepository;
        private ArtistRepository _artistRepository;

        public UnitOfWork(IntegratedDatabaseContext context)
        {
            this._context = context;
        }

        public IMusicRepository Musics => _musicRepository = _musicRepository ?? new MusicRepository(_context);

        public IArtistRepository Artists => _artistRepository = _artistRepository ?? new ArtistRepository(_context);

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
