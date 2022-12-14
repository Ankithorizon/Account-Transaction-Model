using EFCore_Transaction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITransaction.Helpers
{
    public class CreateObjectHelper
    {
        private static Random random = new Random();     

        // UserName
        public string GetUserName(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        // Email
        public string GetEmail(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray()) + "@gmail.com";
        }

     
        // Phone
        public string GetPhone(int length)
        {
            if (length > 0)
            {
                var sb = new StringBuilder();

                var rnd = SeedRandom();
                for (int i = 0; i < length; i++)
                {
                    sb.Append(rnd.Next(0, 9).ToString());
                }
                return sb.ToString();
            }
            return string.Empty;
        }
        private static Random SeedRandom()
        {
            return new Random(Guid.NewGuid().GetHashCode());
        }

        // HomeAddress
        // MailAddress
        public string GetStreetNumber(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }        
        public string GetStreetName(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public string GetCityName(string province)
        {
            int num = random.Next(1, 2);

            List<string> citiesON = new List<string>();
            citiesON.Add("Toronto");
            citiesON.Add("London");
            citiesON.Add("Brampton");

            List<string> citiesMB = new List<string>();
            citiesMB.Add("Winnipeg");
            citiesMB.Add("Brandon");
            citiesMB.Add("Selkirk");

            List<string> citiesAB = new List<string>();
            citiesAB.Add("Calgary");
            citiesAB.Add("Edmonton");
            citiesAB.Add("Saint Albert");

            List<string> citiesBC = new List<string>();
            citiesBC.Add("Vancouver");
            citiesBC.Add("Burnaby");
            citiesBC.Add("Armstrong");

            if(province=="MB")
                return citiesMB.ElementAtOrDefault(num);
            else if(province=="AB")
                return citiesAB.ElementAtOrDefault(num);
            else if (province == "BC")
                return citiesBC.ElementAtOrDefault(num);
            else
                return citiesON.ElementAtOrDefault(num);
        }
        public string GetProvinceName()
        {
            int num = random.Next(1, 3);
            List<string> provinces = new List<string>();
            provinces.Add("MB");
            provinces.Add("ON");
            provinces.Add("AB");
            provinces.Add("BC");
            return provinces.ElementAtOrDefault(num);
        }
        public string GetPostalCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        // PayeeName
        // Description
        public string GetPayeeNameDesc(int sLength, int nLength)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string payee1 = new string(Enumerable.Repeat(chars, sLength)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            const string numbers = "0123456789";
            string payee2 = new string(Enumerable.Repeat(numbers, nLength)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            return payee1 + "-" + payee2;
        }

        // PayeeACNumber
        public string GetPayeeACNumber(int sLength, int nLength)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string payee1 = new string(Enumerable.Repeat(chars, sLength)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            const string numbers = "0123456789";
            string payee2 = new string(Enumerable.Repeat(numbers, nLength)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            return payee2 + "-" + payee1;
        }

        // PayeeType
        public PayeeType GetPayeeType()
        {
            Array values = Enum.GetValues(typeof(PayeeType));
            Random random = new Random();
            PayeeType randomPayeeType = (PayeeType)values.GetValue(random.Next(values.Length));
            return randomPayeeType;
        }
    
    
        // AccountNumber
        // 5,3
        public int GetAccountNumber(int lLength, int rLength)
        {
            const string numbers = "0123456789";
            
            string leftNumbers = new string(Enumerable.Repeat(numbers, lLength)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            string rightNumbers = new string(Enumerable.Repeat(numbers, rLength)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            return Convert.ToInt32(leftNumbers + rightNumbers);
        }
        // AccountType
        public AccountType GetAccountType()
        {
            Array values = Enum.GetValues(typeof(AccountType));
            Random random = new Random();
            AccountType randomAccountType = (AccountType)values.GetValue(random.Next(values.Length));
            return randomAccountType;
        }

        // Balance
        public decimal GetBalance()
        {
            return random.Next(5000, 99999);
        }


        // TransactionType
        public TransactionType GetTransactionType()
        {
            Array values = Enum.GetValues(typeof(TransactionType));
            Random random = new Random();
            TransactionType randomTransactionType = (TransactionType)values.GetValue(random.Next(values.Length));
            return randomTransactionType;
        }
        // TransactionAmount
        public decimal GetTransactionAmount()
        {
            return random.Next(1, 99999);
        }
        // TransactionDate
        public DateTime GetTransactionDate()
        {
            int dateOffset = random.Next(-200, 15);
            return DateTime.Now.AddDays(dateOffset);
        }
        // RefCode
        public string GetRefCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
