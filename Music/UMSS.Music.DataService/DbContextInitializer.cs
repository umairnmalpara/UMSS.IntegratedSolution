using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UMSS.Music.DataService
{
    public static class DbContextInitializer
    {
        public static async Task Initialize(MusicDbContext musicDbContext)
        {
            // Check, if db musicDbContext is created
            await musicDbContext.Database.EnsureCreatedAsync();
        }
    }
}
