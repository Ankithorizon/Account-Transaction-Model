using APITransaction.AccountProcess;
using APITransaction.PayeeProcess;
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
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;

        private readonly AccountWorkerService _workerService;
        private readonly IAccountRepository _accountService;

        public AccountController(
          ILogger<AccountController> logger,
          AccountWorkerService _workerService,
          IAccountRepository accountService)
        {
            _logger = logger;
            this._workerService = _workerService;
            _accountService = accountService;
        }

        // add 30 accounts to db via background-worker-process
        [HttpGet]
        [Route("add_accounts_to_db")]
        public async Task<IActionResult> Add_Accounts_To_DB_BK_Worker_Process()
        {
            BKProcessResponse response = new BKProcessResponse();

            await _workerService.StartAsync(HttpContext.RequestAborted);
            response.Response = "BackGround Worker Process Done Successfully! Accounts Added To Database Successfully!";

            return Ok(response);
        }

        [HttpGet]
        [Route("get_accounts")]
        public async Task<IActionResult> GetAccounts()
        {
            return Ok(await _accountService.GetAllAccounts());
        }
    }
}
