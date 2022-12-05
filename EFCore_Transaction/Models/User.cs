using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_Transaction.Models
{
    public class User
    {
        [Key]
        [Required (ErrorMessage ="User Id Is Required!")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required(ErrorMessage ="User Name Is Required!")]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string HomeAddress { get; set; }
        public string MailAddress { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
