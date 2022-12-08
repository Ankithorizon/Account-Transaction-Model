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
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext appDbContext;
        private static Random random = new Random();
        public AccountRepository(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<List<Account>> GetAllAccounts()
        {
            return await appDbContext.Accounts.ToListAsync();
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

        public AccountBalance GetRandomAccountInfo()
        {
            AccountBalance data = new AccountBalance();

            if (appDbContext.Accounts != null && appDbContext.Accounts.Count() > 0)
            {
                int num = random.Next(0, appDbContext.Accounts.Count() - 1);
                var account = appDbContext.Accounts.ToList().ElementAtOrDefault(num);
                if (account != null)
                {
                    data.AccountId = account.AccountId;
                    data.Balance = account.Balance;
                    return data;
                }
                else
                    return null;
            }
            else
                return null;
        }

        public bool UpdateAccountBalance(decimal newBalance, int accountId)
        {
            try
            {
                var account = appDbContext.Accounts
                         .Where(x => x.AccountId == accountId).FirstOrDefault();
                if (account != null)
                {
                    account.Balance = newBalance;
                    appDbContext.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch(Exception ex)
            {
                return false;
            }         
        }
    }
}