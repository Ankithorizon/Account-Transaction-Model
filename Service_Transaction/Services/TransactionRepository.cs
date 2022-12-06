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
    class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext appDbContext;

        public TransactionRepository(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            List<Transaction> transactions = new List<Transaction>();
            var transactionsDb = appDbContext.Transactions;
            if (transactionsDb != null && transactionsDb.Count() > 0)
                return transactionsDb;
            else
                return transactions;
        }

        public Transaction AddTransaction(Transaction transaction)
        {
            var result = appDbContext.Transactions.Add(transaction);
            appDbContext.SaveChanges();
            return result.Entity;
        }

        public Transaction GetTransaction(int transactionId)
        {
            return appDbContext.Transactions.Where(x => x.TransactionId == transactionId).FirstOrDefault();
        }      
    }
}