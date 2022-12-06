using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APITransaction.TransactionProcess
{
    public class TransactionWorkerService : IHostedService
    {
        private readonly ITransactionWorker worker;

        public TransactionWorkerService(ITransactionWorker worker)
        {
            this.worker = worker;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await worker.AddTransactions_BK_Worker_Process(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
        }
    }
}