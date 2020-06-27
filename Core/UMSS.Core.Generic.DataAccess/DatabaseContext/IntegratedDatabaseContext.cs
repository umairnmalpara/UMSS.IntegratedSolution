using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using UMSS.Core.Generic.Common.Entities;
using UMSS.Core.Generic.DataAccess.Configurations;

namespace UMSS.Core.Generic.DataAccess.DatabaseContext
{
    public class IntegratedDatabaseContext : DbContext
    {
        public DbSet<Music> Musics { get; set; }
        public DbSet<Artist> Artists { get; set; }

        public IntegratedDatabaseContext(DbContextOptions<IntegratedDatabaseContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new MusicConfiguration());

            builder
                .ApplyConfiguration(new ArtistConfiguration());
        }

    }
}
