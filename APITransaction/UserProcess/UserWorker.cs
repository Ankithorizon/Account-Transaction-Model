using Microsoft.Extensions.Logging;
using Service_Transaction.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EFCore_Transaction.Models;
using APITransaction.Helpers;

namespace APITransaction.UserProcess
{
    public class UserWorker : IUserWorker
    {
        readonly ILogger<UserWorker> _logger;
        readonly IUserRepository userService;
        readonly CreateObjectHelper helper;

        public UserWorker(CreateObjectHelper helper, ILogger<UserWorker> logger, IUserRepository userService)
        {
            _logger = logger;
            this.userService = userService;
            this.helper = helper;
        }    

        public async Task AddUsers_BK_Worker_Process(CancellationToken cancellationToken)
        {
            bool flag = cancellationToken.IsCancellationRequested;

            int count = 1;

            // while (!cancellationToken.IsCancellationRequested)
            // while (!flag)
            while (count <= 10)
            {
                var provinceName = helper.GetProvinceName();

                if (userService.AddUser(new User()
                {
                    Email = helper.GetEmail(20),
                    HomeAddress = helper.GetStreetNumber(4)+"-" + helper.GetStreetName(20)+" "+ helper.GetCityName(provinceName) + " " + provinceName + " " + helper.GetPostalCode(6)  ,
                    MailAddress = helper.GetStreetNumber(4) + "-" + helper.GetStreetName(20) + " " + helper.GetCityName(provinceName) + " " + provinceName + " " + helper.GetPostalCode(6),
                    Phone = helper.GetPhone(10),
                    UserName = helper.GetUserName(10)
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
