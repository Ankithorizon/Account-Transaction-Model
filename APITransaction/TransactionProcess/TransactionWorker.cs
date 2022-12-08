using APITransaction.Helpers;
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
        readonly IPayeeRepository payeeService;
        readonly IAccountRepository accountService;
        readonly CreateObjectHelper helper;

        public TransactionWorker(CreateObjectHelper helper, 
            ILogger<TransactionWorker> logger, 
            ITransactionRepository transactionService, 
            IPayeeRepository payeeService, 
            IAccountRepository accountService)
        {
            _logger = logger;
            this.transactionService = transactionService;
            this.helper = helper;
            this.payeeService = payeeService;
            this.accountService = accountService;
        }

        public async Task AddTransactions_BK_Worker_Process(CancellationToken cancellationToken)
        {
            bool flag = cancellationToken.IsCancellationRequested;

            int count = 1;

            // while (!cancellationToken.IsCancellationRequested)
            // while (!flag)
            while (count <= 100)
            {
                try
                {
                    Transaction transaction = new Transaction();
                    transaction.PayeeId = payeeService.GetRandomPayeeId();
                    transaction.TransactionType = (int)helper.GetTransactionType(); // IN, OUT
                    transaction.TransactionAmount = helper.GetTransactionAmount();
                    transaction.TransactionDate = helper.GetTransactionDate();

                    var accountBalance = accountService.GetRandomAccountInfo();
                    transaction.AccountId = accountBalance.AccountId;
                    transaction.LastBalance = accountBalance.Balance;

                    if (transaction.TransactionType == (int)TransactionType.IN)
                    {
                        transaction.CurrentBalance = Decimal.Add(transaction.LastBalance,transaction.TransactionAmount);
                        transaction.RefCode = helper.GetRefCode(10);
                        transaction.TransactionStatus = (int)TransactionStatus.SUCCESS;
                    }
                    else
                    {                       
                        if (Decimal.Subtract(transaction.LastBalance,transaction.TransactionAmount) < 0)
                        {
                            transaction.CurrentBalance = transaction.LastBalance;
                            transaction.RefCode = helper.GetRefCode(10);
                            transaction.TransactionStatus = (int)TransactionStatus.FAIL;
                        }
                        else
                        {
                            transaction.CurrentBalance = Decimal.Subtract(transaction.LastBalance,transaction.TransactionAmount);
                            transaction.RefCode = helper.GetRefCode(10);
                            transaction.TransactionStatus = (int)TransactionStatus.SUCCESS;
                        }
                    }

                    accountBalance.Balance = transaction.CurrentBalance;

                    if (transactionService.AddTransaction(transaction, accountBalance) != null)
                    {
                        _logger.LogInformation("New Transaction Added To Database Successfully!");
                        await Task.Delay(1*1000);
                        count++;
                    }
                    else
                    {
                        count = 101;
                    }
                }
                catch(Exception ex)
                {
                    count = 101;
                }            
            }
        }
    }
}
