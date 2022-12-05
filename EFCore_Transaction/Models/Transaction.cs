using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_Transaction.Models
{
    public class Transaction
    {
        [Key]
        [Required(ErrorMessage = "Transaction Id Is Required!")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }

        [Required(ErrorMessage = "Payee Id Is Required!")]
        public int PayeeId { get; set; }

        [Required(ErrorMessage = "Transaction Type Is Required!")]
        public int TransactionType { get; set; } // 0=IN 1=OUT

        [Required(ErrorMessage = "Transaction Amount Is Required!")]
        public decimal TransactionAmount { get; set; }

        [Required(ErrorMessage = "Transaction Date Is Required!")]
        public DateTime TransactionDate { get; set; }

        [Required(ErrorMessage = "Transaction Status Is Required!")]
        public int TransactionStatus { get; set; } // 0=SUCCESS 1=FAIL     

        [Required(ErrorMessage = "Current Balance Is Required!")]
        public decimal CurrentBalance { get; set; } // for AccountId

        [Required(ErrorMessage = "Last Balance Is Required!")]
        public decimal LastBalance { get; set; } // for AccountId

        [Required(ErrorMessage = "Ref Code Is Required!")]
        public string RefCode { get; set; }


        [ForeignKey(nameof(Account))]
        [Required(ErrorMessage = "Account Id Is Required!")]
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
