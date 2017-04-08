using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
using Models;

namespace EUCCID
{
    class Program
    {
        static void Main(string[] args)
        {
            var cpr = new CPR()
            {
                FirstName = "Firstname",
                Surname = "Surname",
                City = "City",
                Address1 = "Streetname 4, 5",
                PostalCode = 9400,
                CprNumber = "1203454313"
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
                EuCcid = "1231231242423",
                Gender = "Male"
            };

            var trCpr = new Translator.EuccidtoCprTranslator().CprToEuccid(cpr);
            var trEu = new Translator.EuccidtoCprTranslator().EuCcidToCpr(euccit);

            Console.WriteLine(cpr);
            Console.WriteLine(trCpr);
            Console.WriteLine();
            Console.WriteLine(euccit);
            Console.WriteLine(trEu);
        }
    }
}
