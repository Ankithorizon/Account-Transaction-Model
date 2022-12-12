using EFCore_Transaction.Context;
using EFCore_Transaction.Models;
using Microsoft.EntityFrameworkCore;
using Service_Transaction.Contracts;
using Service_Transaction.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Transaction.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext appDbContext;
        private static Random random = new Random();

        public UserRepository(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await appDbContext.Users.ToListAsync();
        }

        public User AddUser(User user)
        {
            try
            {
                var result = appDbContext.Users.Add(user);
                appDbContext.SaveChanges();
                return result.Entity;
            }
            catch(Exception ex)
            {
                return null;
            }        
        }

        public User GetUser(int userId)
        {
            return appDbContext.Users.Where(x => x.UserId == userId).FirstOrDefault();
        }    
        
        public int GetRandomUserId()
        {
            if (appDbContext.Users != null && appDbContext.Users.Count() > 0)
            {
                int num = random.Next(0, appDbContext.Users.Count() - 1);  
                return appDbContext.Users.ToList().ElementAtOrDefault(num).UserId;
            }
            else
                return 0;
          
        }

        public async Task<List<UserList>> GetUserList()
        {
            List<UserList> datas = new List<UserList>();
            datas.Add(new UserList()
            {
                 UserId=0,
                  UserName="All-Transactions"
            });

            var users = await appDbContext.Users.ToListAsync();
            if (users != null && users.Count() > 0)
            {
                foreach (var user in users)
                {
                    datas.Add(new UserList()
                    {
                        UserId = user.UserId,
                        UserName = user.UserName
                    });
                }
            }
            return datas;
        }

    }
}