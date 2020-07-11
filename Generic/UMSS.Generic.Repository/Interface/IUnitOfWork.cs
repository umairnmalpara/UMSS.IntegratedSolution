using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UMSS.Generic.Repository.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();
    }
}
