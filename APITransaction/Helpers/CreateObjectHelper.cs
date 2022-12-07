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
            int num = random.Next(1, 3);

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
            int num = random.Next(1, 4);
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

    }
}
