using EFCore_Transaction.Context;
using EFCore_Transaction.Models;
using Microsoft.EntityFrameworkCore;
using Service_Transaction.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service_Transaction.Services
{
    class PayeeRepository : IPayeeRepository
    {
        private readonly ApplicationDbContext appDbContext;

        public PayeeRepository(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Payee> GetAllPayees()
        {
            List<Payee> payees = new List<Payee>();
            var payeesDb = appDbContext.Payees;
            if (payeesDb != null && payeesDb.Count() > 0)
                return payeesDb;
            else
                return payees;
        }

        public Payee AddPayee(Payee payee)
        {
            var result = appDbContext.Payees.Add(payee);
            appDbContext.SaveChanges();
            return result.Entity;
        }

        public Payee GetPayee(int payeeId)
        {
            return appDbContext.Payees.Where(x => x.PayeeId == payeeId).FirstOrDefault();
        }
      
        public List<string> GetAllPayeeTypes()
        {
            List<string> PayeeTypes = new List<string>();
            foreach (string PayeeType in Enum.GetNames(typeof(PayeeType)))
            {
                PayeeTypes.Add(PayeeType);
            }
            return PayeeTypes;
        }
    }
}