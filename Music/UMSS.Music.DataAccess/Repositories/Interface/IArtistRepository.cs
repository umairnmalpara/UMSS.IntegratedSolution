using System;
using System.Collections.Generic;
using System.Text;
using UMSS.Generic.Repository.Interface;
using UMSS.Music.Entity;
using UMSS.Music.Model;

namespace UMSS.Music.DataAccess.Repositories.Interface
{
    public interface IArtistRepository : IBaseRepository<Artist, ArtistModel>
    {
    }
}
