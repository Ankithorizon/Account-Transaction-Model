using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APITransaction.UserProcess
{
    public interface IUserWorker
    {
        Task AddUsers_BK_Worker_Process(CancellationToken cancellationToken);                
    }
}
