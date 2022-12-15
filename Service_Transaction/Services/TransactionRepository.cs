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
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext appDbContext;

        public TransactionRepository(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<List<Transaction>> GetAllTransactions()
        {
            return await appDbContext.Transactions.OrderByDescending(x=>x.TransactionDate).ToListAsync();
        }

        public async Task<List<TransactionDto>> Get_AllTransactions()
        {
            List<TransactionDto> transactions = new List<TransactionDto>();
            var trs = appDbContext.Transactions
                        .OrderByDescending(x => x.TransactionDate)
                        .Include(x => x.Account);
            if(trs!=null && trs.Count()>0)
            {
                foreach(var tr in trs)
                {
                    var payee = await appDbContext.Payees
                                    .Where(x => x.PayeeId == tr.PayeeId).FirstOrDefaultAsync();
                    if (payee != null)
                    {
                        transactions.Add(new TransactionDto()
                        {
                             Account = tr.Account.AccountId+" - "+ GetAccountTypeAsString(tr.Account.AccountType),
                              AccountId = tr.AccountId,
                               CurrentBalance = tr.CurrentBalance,
                                LastBalance = tr.LastBalance,
                                 Payee = payee.PayeeId+" - "+ GetPayeeTypeAsString(payee.PayeeType),
                                  PayeeId = tr.PayeeId,
                                   RefCode = tr.RefCode,
                                    TransactionAmount = tr.TransactionAmount,
                                     TransactionDate = tr.TransactionDate,
                                      TransactionId = tr.TransactionId,
                                       TransactionStatus = tr.TransactionStatus,
                                        TransactionType = tr.TransactionType
                        });
                    }

                }
            }            
            return transactions;
        }


        public Transaction AddTransaction(Transaction transaction, AccountBalance accountBalance)
        {
            try
            {
                var account = appDbContext.Accounts
                      .Where(x => x.AccountId == accountBalance.AccountId).FirstOrDefault();
                if (account != null)
                {
                    // 1
                    account.Balance = accountBalance.Balance;

                    // 2
                    var result = appDbContext.Transactions.Add(transaction);
                    
                    appDbContext.SaveChanges();
                    return result.Entity;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                return null;
            }     
        }

        public Transaction GetTransaction(int transactionId)
        {
            return appDbContext.Transactions.Where(x => x.TransactionId == transactionId).FirstOrDefault();
        }

        public List<string> GetAllTransactionTypes()
        {
            List<string> transactionTypes = new List<string>();
            foreach (string transactionType in Enum.GetNames(typeof(TransactionType)))
            {
                transactionTypes.Add(transactionType);
            }
            return transactionTypes;
        }


        // this one called by blazor server app directly using 
        // transactions = await transactionService.GetTransactionsByUser(1);
        public async Task<List<Transaction>> GetTransactionsByUser(int userId)
        {            
            List<Transaction> datas = new List<Transaction>();
            try
            {
                var user = await appDbContext.Users.Include(x => x.Accounts)
                          .ThenInclude(ac => ac.Transactions)
                          .Where(x => x.UserId == userId && userId!=0).FirstOrDefaultAsync();
                if (user != null)
                {
                    foreach (var account in user.Accounts)
                    {
                        foreach (var tr in account.Transactions)
                        {
                            datas.Add(tr);
                        }
                    }
                }
                else
                {
                    if (userId == 0)
                    {
                        foreach (var tr in appDbContext.Transactions)
                        {
                            datas.Add(tr);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
            }


            var datas_ = datas.OrderByDescending(x=>x.TransactionDate);

            return datas_.ToList();

            // return datas;
        }
    
    
        private string GetPayeeTypeAsString(int payeeType)
        {
            return (PayeeType)payeeType+"";
        }
        private string GetAccountTypeAsString(int acType)
        {
            return (AccountType)acType + "";
        }

    }
}