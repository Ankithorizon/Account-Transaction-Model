using EFCore_Transaction.Models;
using Service_Transaction.Contracts;
using Service_Transaction.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Transaction.Services
{
    public class ChartRepository : IChartRepository
    {
        ITransactionRepository transactionService;
        public ChartRepository(ITransactionRepository transactionService)
        {
            this.transactionService = transactionService;
        }


        public async Task<List<MonthlyTotalInOut>> GetMonthly_Total_InOut_ChartReport(int userId)
        {
            List<MonthlyTotalInOut> returnData = new List<MonthlyTotalInOut>();

            List<Transaction> transactionsByUser = await transactionService.GetTransactionsByUser(userId);

            var results = (from p in transactionsByUser
                           where p.TransactionStatus == (int)TransactionStatus.SUCCESS
                           group p by new
                           {
                               Month = p.TransactionDate.Month,
                               TranType = p.TransactionType
                           } into g
                           select new
                           {
                               Month = g.Key.Month,
                               TranType = g.Key.TranType,
                               Total = g.Sum(x => x.TransactionAmount)
                           }
                          ).AsEnumerable()
                    .Select(g => new
                    {
                        Month = g.Month.ToString(),
                        TranType = g.TranType,
                        Total = g.Total
                    });


            foreach(var data in results)
            {
                returnData.Add(new MonthlyTotalInOut()
                {
                     MonthName = data.Month,
                      TotalIn = data.TranType==(int)TransactionType.IN ? data.Total : 0,
                       TotalOut = data.TranType == (int)TransactionType.OUT ? data.Total : 0
                });
            }

            return returnData;
        }
    }
}
