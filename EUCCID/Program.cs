using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
using Models;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            TestTranslator();
        }

        private static void TestTranslator()
        {
            var cpr = new CPR()
            {
                FirstName = "Firstname",
                Surname = "Surname",
                City = "City",
                Address1 = "Streetname 4, 5",
                PostalCode = 9400,
                CprNumber = "120301-4313"
            };

            var euccit = new Models.EUCCID()
            {
                ChristianName = "Christiano",
                FamilyName = "Jezuino",
                City = "City",
                StreetHouseNumber = "Street 4b",
                ApartmentNumber = "2a",
                CurrentCountry = "Denmark",
                BirthCountry = "Russia",
                EuCcid = "12011991-123456",
                Gender = "Male"
            };


            Console.WriteLine("CPR to EUCCID");
            var trCpr = new Translator.EuccidCprTranslator().CprToEuccid(cpr);
            Console.WriteLine(cpr);
            Console.WriteLine(trCpr);
            Console.WriteLine();

            Console.WriteLine("EUCCID to CPR");
            var trEu = new Translator.EuccidCprTranslator().EuCcidToCpr(euccit);
            Console.WriteLine(euccit);
            Console.WriteLine(trEu);
        }
    }
}
