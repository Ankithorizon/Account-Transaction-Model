using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APITransaction.UserProcess
{
    public class UserWorkerService : IHostedService
    {
        private readonly IUserWorker worker;

        public UserWorkerService(IUserWorker worker)
        {
            this.worker = worker;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await worker.AddUsers_BK_Worker_Process(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {            
        }
    }
}
