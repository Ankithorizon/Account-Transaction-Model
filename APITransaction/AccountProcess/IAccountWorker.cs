using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APITransaction.AccountProcess
{
    public interface IAccountWorker
    {
        Task AddAccounts_BK_Worker_Process(CancellationToken cancellationToken);
    }
}
