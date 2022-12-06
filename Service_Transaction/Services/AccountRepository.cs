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
    class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext appDbContext;

        public AccountRepository(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            List<Account> accounts = new List<Account>();
            var accountsDb = appDbContext.Accounts.Include(x => x.Transactions);
            if (accountsDb != null && accountsDb.Count() > 0)
                return accountsDb;
            else
                return accounts;
        }

        public Account AddAccount(Account account)
        {
            try
            {
                var result = appDbContext.Accounts.Add(account);
                appDbContext.SaveChanges();
                return result.Entity;
            }
            catch(Exception ex)
            {
                return null;
            }        
        }

        public Account GetAccount(int accountId)
        {
            return appDbContext.Accounts.Where(x => x.AccountId == accountId).FirstOrDefault();
        }
      
        public List<string> GetAllAccountTypes()
        {
            List<string> accountTypes = new List<string>();
            foreach (string accountType in Enum.GetNames(typeof(AccountType)))
            {
                accountTypes.Add(accountType);
            }
            return accountTypes;
        }
    }
}