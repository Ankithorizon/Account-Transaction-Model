﻿using EFCore_Transaction.Models;
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

            totalInData.Name = "IN $";
            totalOutData.Name = "OUT $";
            totalInData.InDatas = new List<decimal>();
            totalOutData.OutDatas = new List<decimal>();

            foreach (var rd in returnData)
            {
                totalInData.InDatas.Add(rd.TotalIn);
                totalOutData.OutDatas.Add(rd.TotalOut);
            }

            return chartData;
        }
    }
}
