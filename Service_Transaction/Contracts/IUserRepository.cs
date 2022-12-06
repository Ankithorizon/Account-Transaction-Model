using EFCore_Transaction.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service_Transaction.Contracts
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        User AddUser(User user);
        User GetUser(int userId);
    }
}
