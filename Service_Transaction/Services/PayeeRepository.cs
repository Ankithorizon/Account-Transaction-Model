using EFCore_Transaction.Context;
using EFCore_Transaction.Models;
using Microsoft.EntityFrameworkCore;
using Service_Transaction.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Transaction.Services
{
    public class PayeeRepository : IPayeeRepository
    {
        private readonly ApplicationDbContext appDbContext;
        private static Random random = new Random();

        public PayeeRepository(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<List<Payee>> GetAllPayees()
        {
            return await appDbContext.Payees.ToListAsync();
        }


        public Payee AddPayee(Payee payee)
        {
            try
            {
                var result = appDbContext.Payees.Add(payee);
                appDbContext.SaveChanges();
                return result.Entity;
            }
            catch(Exception ex)
            {
                return null;
            }        
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

        public int GetRandomPayeeId()
        {
            if (appDbContext.Payees != null && appDbContext.Payees.Count() > 0)
            {
                int num = random.Next(0, appDbContext.Payees.Count() - 1);
                return appDbContext.Payees.ToList().ElementAtOrDefault(num).PayeeId;
            }
            else
                return 0;

        }

        public Payee GetRandomPayee()
        {
            if (appDbContext.Payees != null && appDbContext.Payees.Count() > 0)
            {
                int num = random.Next(0, appDbContext.Payees.Count() - 1);
                return appDbContext.Payees.ToList().ElementAtOrDefault(num);
            }
            else
                return null;

        }
    }
}