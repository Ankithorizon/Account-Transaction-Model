using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APITransaction.PayeeProcess
{
    public class PayeeWorkerService : IHostedService
    {
        private readonly IPayeeWorker worker;

        public PayeeWorkerService(IPayeeWorker worker)
        {
            this.worker = worker;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await worker.AddPayees_BK_Worker_Process(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
        }
    }
}