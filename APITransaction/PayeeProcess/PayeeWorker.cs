using APITransaction.Helpers;
using EFCore_Transaction.Models;
using Microsoft.Extensions.Logging;
using Service_Transaction.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APITransaction.PayeeProcess
{
    public class PayeeWorker : IPayeeWorker
    {
        readonly ILogger<PayeeWorker> _logger;
        readonly IPayeeRepository payeeService;
        readonly CreateObjectHelper helper;

        public PayeeWorker(CreateObjectHelper helper, ILogger<PayeeWorker> logger, IPayeeRepository payeeService)
        {
            _logger = logger;
            this.payeeService = payeeService;
            this.helper = helper;
        }

        public async Task AddPayees_BK_Worker_Process(CancellationToken cancellationToken)
        {
            bool flag = cancellationToken.IsCancellationRequested;

            int count = 1;

            // while (!cancellationToken.IsCancellationRequested)
            // while (!flag)
            while (count <= 10)
            {
                if (payeeService.AddPayee(new Payee()
                {
                   PayeeName = helper.GetPayeeNameDesc(10,5),
                    Description = helper.GetPayeeNameDesc(10,5),
                     PayeeACNumber = helper.GetPayeeACNumber(10,5),
                      PayeeType = (int)helper.GetPayeeType(),
                }) != null)
                {
                    _logger.LogInformation("New Payee Added To Database Successfully!");
                    await Task.Delay(2 * 1000);
                    // flag = true;
                    count++;
                }
                else
                {
                    // flag = true;

                    // something goes wrong @ payee-repository, then stop adding
                    // further payee @ db and return back from
                    // AddPayee async task here
                    count = 11;
                }
            }
        }
    }
}
