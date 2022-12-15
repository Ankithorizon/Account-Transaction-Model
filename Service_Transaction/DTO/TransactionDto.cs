using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Transaction.DTO
{
    public class TransactionDto
    {
        public int TransactionId { get; set; }
        public int PayeeId { get; set; }
        public string Payee { get; set; }
        public int TransactionType { get; set; } // 0=IN 1=OUT
        public decimal TransactionAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public int TransactionStatus { get; set; } // 0=SUCCESS 1=FAIL 
        public decimal CurrentBalance { get; set; } // for AccountId
        public decimal LastBalance { get; set; } // for AccountId
        public string RefCode { get; set; }
        public int AccountId { get; set; }
        public string Account { get; set; }
    }
}
