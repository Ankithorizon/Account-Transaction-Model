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
    public class ChartRepository : IChartRepository
    {
        ITransactionRepository transactionService;
        private readonly ApplicationDbContext appDbContext;
        public ChartRepository(ApplicationDbContext appDbContext, ITransactionRepository transactionService)
        {
            this.transactionService = transactionService;
            this.appDbContext = appDbContext;
        }
        public async Task<MonthlyTotalInOutChartData> GetMonthly_Total_InOut_ChartReport(int userId)
        {
            List<MonthlyTotalInOut> returnData = new List<MonthlyTotalInOut>();

            List<Transaction> transactionsByUser = await transactionService.GetTransactionsByUser(userId);


            for(int i = 1; i <= 12; i++)
            {
                var results = transactionsByUser
                                    .Where(x => x.TransactionDate.Month == i && x.TransactionStatus == (int)TransactionStatus.SUCCESS);

                if(results!=null && results.Count() > 0)
                {
                    // in-out-transactions
                    MonthlyTotalInOut data = new MonthlyTotalInOut();
                    data.MonthNumber = i;

                    // in-transactions
                    var totalInTrs = results
                                        .Where(y => y.TransactionType == (int)TransactionType.IN);
                    if(totalInTrs != null && totalInTrs.Count() > 0)
                    {
                        decimal totalIn_ = 0;
                        foreach(var tr in totalInTrs)
                        {
                            totalIn_ += tr.TransactionAmount;
                        }
                        data.TotalIn = totalIn_;
                    }
                    else
                    {
                        data.TotalIn = 0;
                    }


                    // out-transactions
                    var totalOutTrs = results
                                      .Where(y => y.TransactionType == (int)TransactionType.OUT);
                    if (totalOutTrs != null && totalOutTrs.Count() > 0)
                    {
                        decimal totalOut_ = 0;
                        foreach (var tr in totalOutTrs)
                        {
                            totalOut_ += tr.TransactionAmount;
                        }
                        data.TotalOut = totalOut_;
                    }
                    else
                    {
                        data.TotalOut = 0;
                    }

                    returnData.Add(data);
                }
                else
                {
                    returnData.Add(new MonthlyTotalInOut()
                    {
                         MonthNumber = i,
                          TotalIn = 0,
                           TotalOut = 0
                    });
                }       
            }

            MonthlyTotalInOutChartData chartData = new MonthlyTotalInOutChartData();
            TotalInData totalInData = new TotalInData();
            TotalOutData totalOutData = new TotalOutData();

            chartData.TotalInData = totalInData;
            chartData.TotalOutData = totalOutData;

            totalInData.Name = "$ IN";
            totalOutData.Name = "$ OUT";
            totalInData.InDatas = new List<decimal>();
            totalOutData.OutDatas = new List<decimal>();

            foreach (var rd in returnData)
            {
                totalInData.InDatas.Add(rd.TotalIn);
                totalOutData.OutDatas.Add(rd.TotalOut);
            }

            return chartData;
        }
        public async Task<UserMonthTotalInOutData> GetUser_MonthWise_Total_InOut_ChartReport(int userId, Month month)
        {
            UserMonthTotalInOutData chartData = new UserMonthTotalInOutData();
            chartData.MonthNumber = month.MonthNumber;
            chartData.MonthName = month.MonthName;
            chartData.TotalIn = 0;
            chartData.TotalOut = 0;
            chartData.UserName = "N/A";

            var user = await appDbContext.Users.Include(x => x.Accounts)
                         .ThenInclude(ac => ac.Transactions)
                         .Where(x => x.UserId == userId).FirstOrDefaultAsync();

            if (user != null)
            {
                chartData.UserName = user.UserName;
                foreach (var account in user.Accounts)
                {
                    var trs = account.Transactions.Where(x => x.TransactionDate.Month == month.MonthNumber && x.TransactionStatus==(int)TransactionStatus.SUCCESS);
                    if(trs!=null && trs.Count()>0)
                    {
                        chartData.TotalIn += trs.Where(y => y.TransactionType == (int)TransactionType.IN).Sum(z => z.TransactionAmount);
                        chartData.TotalOut += trs.Where(y => y.TransactionType == (int)TransactionType.OUT).Sum(z => z.TransactionAmount);
                    }                 
                }
            }         

            return chartData;
        }
        public List<Month> GetMonths()
        {
            List<Month> months = new List<Month>();
            months.Add(new Month()
            {
                MonthNumber = 1,
                MonthName = "January"
            });

            months.Add(new Month()
            {
                MonthNumber = 2,
                MonthName = "February"
            });

            months.Add(new Month()
            {
                MonthNumber = 3,
                MonthName = "March"
            });

            months.Add(new Month()
            {
                MonthNumber = 4,
                MonthName = "April"
            });

            months.Add(new Month()
            {
                MonthNumber = 5,
                MonthName = "May"
            });

            months.Add(new Month()
            {
                MonthNumber = 6,
                MonthName = "June"
            });

            months.Add(new Month()
            {
                MonthNumber = 7,
                MonthName = "July"
            });

            months.Add(new Month()
            {
                MonthNumber = 8,
                MonthName = "August"
            });

            months.Add(new Month()
            {
                MonthNumber = 9,
                MonthName = "September"
            });

            months.Add(new Month()
            {
                MonthNumber = 10,
                MonthName = "October"
            });

            months.Add(new Month()
            {
                MonthNumber = 11,
                MonthName = "November"
            });

            months.Add(new Month()
            {
                MonthNumber = 12,
                MonthName = "December"
            });

            return months;
        }

    }
}
