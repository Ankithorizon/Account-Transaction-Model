using APITransaction.AccountProcess;
using APITransaction.PayeeProcess;
using APITransaction.TransactionProcess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service_Transaction.Contracts;
using Service_Transaction.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITransaction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;

        private readonly TransactionWorkerService _workerService;
        private readonly ITransactionRepository _transactionService;

        public TransactionController(
          ILogger<TransactionController> logger,
          TransactionWorkerService _workerService,
          ITransactionRepository transactionService)
        {
            _logger = logger;
            this._workerService = _workerService;
            _transactionService = transactionService;
        }

        // add 100 transactions to db via background-worker-process
        [HttpGet]
        [Route("add_transactions_to_db")]
        public async Task<IActionResult> Add_Transactions_To_DB_BK_Worker_Process()
        {
            BKProcessResponse response = new BKProcessResponse();

            await _workerService.StartAsync(HttpContext.RequestAborted);
            response.Response = "BackGround Worker Process Done Successfully! Transactions Added To Database Successfully!";

            return Ok(response);
        }

        [HttpGet]
        [Route("get_transactions")]
        public async Task<IActionResult> GetTransactions()
        {
            return Ok(await _transactionService.GetAllTransactions());
        }     
    }
}
