﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Transaction.DTO
{
    public class MonthlyTotalInOut
    {
        public string MonthName { get; set; }
        public decimal TotalIn { get; set; }
        public decimal TotalOut { get; set; }
    }
}
