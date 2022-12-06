using EFCore_Transaction.Models;
using Microsoft.Extensions.Logging;
using Service_Transaction.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APITransaction.AccountProcess
{
    public class AccountWorker : IAccountWorker
    {
        readonly ILogger<AccountWorker> _logger;
        readonly IAccountRepository accountService;

        public AccountWorker(ILogger<AccountWorker> logger, IAccountRepository accountService)
        {
            _logger = logger;
            this.accountService = accountService;
        }

        public async Task AddAccounts_BK_Worker_Process(CancellationToken cancellationToken)
        {
            bool flag = cancellationToken.IsCancellationRequested;

            int count = 1;

            // while (!cancellationToken.IsCancellationRequested)
            // while (!flag)
            while (count <= 10)
            {
                if (accountService.AddAccount(new Account()
                {
                    AccountNumber = 0,
                    AccountType = (int)AccountType.Chequing,
                    Balance = 0,
                    UserId = 1,
                }) != null)
                {
                    _logger.LogInformation("New Account Added To Database Successfully!");
                    await Task.Delay(2 * 1000);
                    // flag = true;
                    count++;
                }
                else
                {
                    // flag = true;

                    // something goes wrong @ account-repository, then stop adding
                    // further account @ db and return back from
                    // AddAccount async task here
                    count = 11;
                }
            }
        }
    }
}
