using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;
using Models;

namespace Translator
{
    public class EuccidtoCprTranslator
    {
        public CPR EuCcidToCpr(EUCCID euccid)
        {
            var cpr = new CPR()
            {
                FirstName = euccid.ChristianName,
                Surname = euccid.FamilyName,
                Address1 = $"{euccid.StreetHouseNumber}, {euccid.ApartmentNumber}",
                City = euccid.City,
                PostalCode = PostalcodeLookupService.Lookup(euccid.StreetHouseNumber, euccid.City,
                    euccid.CurrentCountry)
            };

            return cpr;
        }

        public EUCCID CprToEuccid(CPR cpr)
        {
            var euCcid = new EUCCID()
            {
                ChristianName = cpr.FirstName,
                FamilyName = cpr.Surname,
                ApartmentNumber = GetApartmentNumberFromCprAddress(cpr.Address1),
                StreetHouseNumber = GetAddressWithouthAppartmentNumber(cpr.Address1),
                City = cpr.City,
                Gender = GetGenderFromCprNumber(cpr.CprNumber)
            };

            return euCcid;
        }

        private string GetGenderFromCprNumber(string cpr)
        {
            var lastDigit = Int16.Parse(cpr.ToCharArray()[cpr.Length - 1] + "");
            return lastDigit % 2 == 0 ? "female" : "male";
        }
        private string GetApartmentNumberFromCprAddress(string address)
        {
            // each field in CPR address is comma separated
            var split = address.Split(',');
            return split[split.Length - 1];
        }

        private string GetAddressWithouthAppartmentNumber(string address)
        {
            var split = address.Split(',');
            Array.Resize(ref split, split.Length-1);
            return string.Join(",", split);
        }
    }
}
