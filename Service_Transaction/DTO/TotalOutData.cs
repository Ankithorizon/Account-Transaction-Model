using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Transaction.DTO
{
    public class TotalOutData
    {
        public string Name { get; set; } // Out
        public List<decimal> OutDatas { get; set; }
    }
}
