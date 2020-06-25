using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UMSS.Core.Common.Repositories.Base
{
    public interface IUnitOfWork : IDisposable
    {
        IMusicRepository Musics { get; }
        IArtistRepository Artists { get; }

        Task<int> CommitAsync();
    }
}
