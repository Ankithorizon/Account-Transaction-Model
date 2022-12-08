using EFCore_Transaction.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service_Transaction.Contracts
{
    public interface ITransactionRepository
    {
        Task<List<Transaction>> GetAllTransactions();
        Transaction AddTransaction(Transaction transaction);
        Transaction GetTransaction(int transactionId);
        List<string> GetAllTransactionTypes();
    }
}
