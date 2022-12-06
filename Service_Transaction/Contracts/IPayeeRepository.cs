using EFCore_Transaction.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Transaction.Contracts
{
    public interface IPayeeRepository
    {
        IEnumerable<Payee> GetAllPayees();
        Payee AddPayee(Payee payee);
        Payee GetPayee(int payeeId);
        List<string> GetAllPayeeTypes();

    }
}
