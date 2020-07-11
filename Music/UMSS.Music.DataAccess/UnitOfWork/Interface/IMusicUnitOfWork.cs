using System;
using System.Collections.Generic;
using System.Text;
using UMSS.Generic.Repository.Interface;
using UMSS.Music.DataAccess.Repositories.Interface;

namespace UMSS.Music.DataAccess.UnitOfWork.Interface
{
    public interface IMusicUnitOfWork : IUnitOfWork
    {
        IArtistRepository Artists { get; }
        IMusicRepository Musics { get; }
    }
}
