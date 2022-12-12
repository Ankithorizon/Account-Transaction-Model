﻿using Service_Transaction.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service_Transaction.Contracts
{
    public interface IChartRepository
    {
        Task<List<MonthlyTotalInOut>> GetMonthly_Total_InOut_ChartReport(int userId);
    }
}
