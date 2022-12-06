using EFCore_Transaction.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Transaction.Contracts
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> GetAllTransactions();
        Transaction AddTransaction(Transaction transaction);
        Transaction GetTransaction(int transactionId);
    }
}
