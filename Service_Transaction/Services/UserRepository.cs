using EFCore_Transaction.Context;
using EFCore_Transaction.Models;
using Microsoft.EntityFrameworkCore;
using Service_Transaction.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service_Transaction.Services
{
    class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext appDbContext;

        public UserRepository(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            var usersDb = appDbContext.Users.Include(x => x.Accounts);
            if (usersDb != null && usersDb.Count() > 0)
                return usersDb;
            else
                return users;
        }

        public User AddUser(User user)
        {
            var result = appDbContext.Users.Add(user);
            appDbContext.SaveChanges();
            return result.Entity;
        }

        public User GetUser(int userId)
        {
            return appDbContext.Users.Where(x => x.UserId == userId).FirstOrDefault();
        }      
    }
}