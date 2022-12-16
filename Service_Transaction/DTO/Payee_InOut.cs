using EFCore_Transaction.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Transaction.DTO
{
    public class Payee_InOut
    {
        public int PayeeType { get; set; }
        public string Payee { get; set; }
        public decimal TotalIn { get; set; }
        public decimal TotalOut { get; set; }
    }
}
