using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APITransaction.PayeeProcess
{
    public interface IPayeeWorker
    {
        Task AddPayees_BK_Worker_Process(CancellationToken cancellationToken);
    }
}
