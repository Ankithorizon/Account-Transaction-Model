using EFCore_Transaction.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Transaction.Contracts
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAllAccounts();
        Account AddAccount(Account account);
        Account GetAccount(int accountId);
        List<string> GetAllAccountTypes();

    }
}
