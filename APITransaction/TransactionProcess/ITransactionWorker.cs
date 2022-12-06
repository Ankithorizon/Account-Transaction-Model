using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APITransaction.TransactionProcess
{
    public interface ITransactionWorker
    {
        Task AddTransactions_BK_Worker_Process(CancellationToken cancellationToken);
    }
}
