using EFCore_Transaction.Models;
using Microsoft.Extensions.Logging;
using Service_Transaction.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APITransaction.TransactionProcess
{
    public class TransactionWorker : ITransactionWorker
    {
        readonly ILogger<TransactionWorker> _logger;
        readonly ITransactionRepository transactionService;

        public TransactionWorker(ILogger<TransactionWorker> logger, ITransactionRepository transactionService)
        {
            _logger = logger;
            this.transactionService = transactionService;
        }

        public async Task AddTransactions_BK_Worker_Process(CancellationToken cancellationToken)
        {
            bool flag = cancellationToken.IsCancellationRequested;

            int count = 1;

            // while (!cancellationToken.IsCancellationRequested)
            // while (!flag)
            while (count <= 10)
            {
                if (transactionService.AddTransaction(new Transaction() { 
                      
                }) != null)
                {
                    _logger.LogInformation("New Transaction Added To Database Successfully!");
                    await Task.Delay(2 * 1000);
                    // flag = true;
                    count++;
                }
                else
                {
                    // flag = true;

                    // something goes wrong @ transaction-repository, then stop adding
                    // further transaction @ db and return back from
                    // AddTransaction async task here
                    count = 11;
                }
            }
        }
    }
}
