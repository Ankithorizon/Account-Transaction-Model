using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APITransaction.AccountProcess
{
    public class AccountWorkerService : IHostedService
    {
        private readonly IAccountWorker worker;

        public AccountWorkerService(IAccountWorker worker)
        {
            this.worker = worker;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await worker.AddAccounts_BK_Worker_Process(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
        }
    }
}