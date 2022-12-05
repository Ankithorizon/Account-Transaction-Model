using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_Transaction.Models
{
    public class Payee
    {
        [Key]
        [Required (ErrorMessage ="Payee Id Is Required!")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PayeeId { get; set; }

        [Required(ErrorMessage = "Payee Name Is Required!")]
        public string PayeeName { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Payee AC Number Is Required!")]
        public string PayeeACNumber { get; set; }

        [Required(ErrorMessage = "Payee Type Is Required!")]
        public string PayeeType { get; set; }
    }
}
