using EFCore_Transaction.Models;
using Service_Transaction.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service_Transaction.Contracts
{
    public interface ITransactionRepository
    {
        Task<List<Transaction>> GetAllTransactions();
        Task<List<TransactionDto>> Get_AllTransactions();
        Transaction AddTransaction(Transaction transaction, AccountBalance accountBalance);
        Transaction GetTransaction(int transactionId);
        List<string> GetAllTransactionTypes();
        Task<List<Transaction>> GetTransactionsByUser(int userId);
    }
}
