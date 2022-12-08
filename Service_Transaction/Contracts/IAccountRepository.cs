using EFCore_Transaction.Models;
using Service_Transaction.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service_Transaction.Contracts
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAllAccounts();
        Account AddAccount(Account account);
        Account GetAccount(int accountId);
        List<string> GetAllAccountTypes();
        AccountBalance GetRandomAccountInfo();
        bool UpdateAccountBalance(decimal newBalance, int accountId);
    }
}
