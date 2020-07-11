using Microsoft.EntityFrameworkCore;
using UMSS.Music.DataService.Configurations;
using UMSS.Music.Entity;

namespace UMSS.Music.DataService
{
    public class MusicDbContext : DbContext
    {
        public DbSet<UMSS.Music.Entity.Music> Musics { get; set; }
        public DbSet<Artist> Artists { get; set; }

        public MusicDbContext(DbContextOptions<MusicDbContext> options) : base(options)
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
