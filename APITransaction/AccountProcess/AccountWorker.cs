using APITransaction.Helpers;
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
        readonly IUserRepository userService;
        readonly CreateObjectHelper helper;

        public AccountWorker(CreateObjectHelper helper, ILogger<AccountWorker> logger, IAccountRepository accountService, IUserRepository userService)
        {
            _logger = logger;
            this.accountService = accountService;
            this.helper = helper;
            this.userService = userService;
        }

        public async Task AddAccounts_BK_Worker_Process(CancellationToken cancellationToken)
        {
            bool flag = cancellationToken.IsCancellationRequested;

            int count = 1;

            // while (!cancellationToken.IsCancellationRequested)
            // while (!flag)
            while (count <= 30)
            {
                if (accountService.AddAccount(new Account()
                {
                    AccountNumber = helper.GetAccountNumber(5,3),
                    AccountType = (int)helper.GetAccountType(),
                    Balance = helper.GetBalance(),
                    UserId = userService.GetRandomUserId()
                }) != null)
                {
                    _logger.LogInformation("New Account Added To Database Successfully!");
                    await Task.Delay(1 * 1000);
                    // flag = true;
                    count++;
                }
                else
                {
                    // flag = true;

                    // something goes wrong @ account-repository, then stop adding
                    // further account @ db and return back from
                    // AddAccount async task here
                    count = 31;
                }
            }
        }
    }
}
