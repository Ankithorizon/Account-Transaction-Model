using Microsoft.Extensions.Logging;
using Service_Transaction.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EFCore_Transaction.Models;


namespace APITransaction.UserProcess
{
    public class UserWorker : IUserWorker
    {
        readonly ILogger<UserWorker> _logger;
        readonly IUserRepository userService;

        public UserWorker(ILogger<UserWorker> logger, IUserRepository userService)
        {
            _logger = logger;
            this.userService = userService;
        }    

        public async Task AddUsers_BK_Worker_Process(CancellationToken cancellationToken)
        {
            bool flag = cancellationToken.IsCancellationRequested;

            int count = 1;

            // while (!cancellationToken.IsCancellationRequested)
            // while (!flag)
            while (count <= 10)
            {
                if (userService.AddUser(new User()
                {
                    Email = "",
                    HomeAddress = " ",
                    MailAddress = " ",
                    Phone = "123-456-7890",
                    UserName = ""
                }) != null)
                {
                    _logger.LogInformation("New User Added To Database Successfully!");
                    await Task.Delay(2 * 1000);
                    // flag = true;
                    count++;
                }
                else
                {
                    // flag = true;

                    // something goes wrong @ user-repository, then stop adding
                    // further user @ db and return back from
                    // AddUser async task here
                    count = 11;
                }
            }
        }
    }
}
