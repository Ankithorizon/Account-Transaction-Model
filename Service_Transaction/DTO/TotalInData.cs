using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Transaction.DTO
{
    public class TotalInData
    {
        public string Name { get; set; } // In
        public List<decimal> InDatas { get; set; }
    }
}
