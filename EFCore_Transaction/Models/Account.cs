using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_Transaction.Models
{
    public class Account
    {
        [Key]
        [Required(ErrorMessage = "Account Id Is Required!")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "Account Number Is Required!")]
        public int AccountNumber { get; set; }

        [Required(ErrorMessage = "Account Type Is Required!")]
        public int AccountType { get; set;  }

        [Required(ErrorMessage = "Account Balance Is Required!")]
        public decimal Balance { get; set; }

        [Required(ErrorMessage = "User is required")]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
