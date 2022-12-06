using EFCore_Transaction.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Transaction.Contracts
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User AddUser(User user);
        User GetUser(int userId);
    }
}
