using APITransaction.UserProcess;
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
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        private readonly UserWorkerService _workerService;        
        private readonly IUserRepository _userService;

        public UserController(
          ILogger<UserController> logger,
          UserWorkerService _workerService,
          IUserRepository userService)
        {
            _logger = logger;
            this._workerService = _workerService;
            _userService = userService;
        }

        // add 10 users to db via background-worker-process
        [HttpGet]
        [Route("add_users_to_db")]
        public async Task<IActionResult> Add_Users_To_DB_BK_Worker_Process()
        {
            BKProcessResponse response = new BKProcessResponse();

            await _workerService.StartAsync(HttpContext.RequestAborted);
            response.Response = "BackGround Worker Process Done Successfully! Users Added To Database Successfully!";

            return Ok(response);
        }

        [HttpGet]
        [Route("get_users")]
        public async Task<IActionResult> GetUsers()
        {         
            return Ok(await _userService.GetAllUsers());
        }

    }
}
