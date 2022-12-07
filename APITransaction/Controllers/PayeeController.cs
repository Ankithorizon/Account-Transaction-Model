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
    public class PayeeController : ControllerBase
    {
        private readonly ILogger<PayeeController> _logger;

        private readonly PayeeWorkerService _workerService;
        private readonly IPayeeRepository _payeeService;

        public PayeeController(
          ILogger<PayeeController> logger,
          PayeeWorkerService _workerService,
          IPayeeRepository payeeService)
        {
            _logger = logger;
            this._workerService = _workerService;
            _payeeService = payeeService;
        }

        // add 10 payees to db via background-worker-process
        [HttpGet]
        [Route("add_payees_to_db")]
        public async Task<IActionResult> Add_Payees_To_DB_BK_Worker_Process()
        {
            BKProcessResponse response = new BKProcessResponse();

            await _workerService.StartAsync(HttpContext.RequestAborted);
            response.Response = "BackGround Worker Process Done Successfully! Payees Added To Database Successfully!";

            return Ok(response);
        }

        [HttpGet]
        [Route("get_payees")]
        public async Task<IActionResult> GetPayees()
        {
            return Ok(await _payeeService.GetAllPayees());
        }
    }
}
