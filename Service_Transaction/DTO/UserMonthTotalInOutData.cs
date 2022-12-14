using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Transaction.DTO
{
    public class UserMonthTotalInOutData
    {
        public string UserName { get; set; }
        public string MonthName { get; set; }
        public int MonthNumber { get; set; }
        public decimal TotalIn { get; set; }
        public decimal TotalOut { get; set; }
    }
}
