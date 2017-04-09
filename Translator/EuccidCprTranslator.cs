using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;
using Models;

namespace Translator
{
    public class EuccidCprTranslator
    {
        public CPR EuCcidToCpr(EUCCID euccid)
        {
            return new CPR()
            {
                FirstName = euccid.ChristianName,
                Surname = euccid.FamilyName,
                Address1 = $"{euccid.StreetHouseNumber}, {euccid.ApartmentNumber}",
                City = euccid.City,
                CprNumber = GetCprNumberBeginningAndGender(euccid.EuCcid),
                PostalCode = PostalcodeLookupService.Lookup(euccid.StreetHouseNumber, euccid.City,
                     euccid.CurrentCountry)
            };
        }

        public EUCCID CprToEuccid(CPR cpr)
        {
            return new EUCCID()
            {
                ChristianName = cpr.FirstName,
                FamilyName = cpr.Surname,
                ApartmentNumber = GetApartmentNumberFromCprAddress(cpr.Address1),
                StreetHouseNumber = GetAddressWithouthAppartmentNumber(cpr.Address1),
                City = cpr.City,
                EuCcid = GetEuccidNumberBeginning(cpr.CprNumber),
                Gender = GetGenderFromCprNumber(cpr.CprNumber)
            };
        }

        private string GetEuccidNumberBeginning(string cpr)
        {
            var birthDate = cpr.Split('-')[0];
            var dayMonth = birthDate.Substring(0, 4);
            var yearShort = birthDate.Substring(4, 2);
            var yearLong = (Int16.Parse(yearShort[0] + "") > 1 ? "19" : "20") + yearShort;
            return dayMonth + yearLong;
        }

        private string GetCprNumberBeginningAndGender(string euccid)
        {
            return euccid.Substring(0, 4) + euccid.Substring(6, 2);
        }

        private string GetGenderFromCprNumber(string cpr)
        {
            var lastDigit = Int16.Parse(cpr[cpr.Length - 1] + "");
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
            Array.Resize(ref split, split.Length - 1);
            return string.Join(",", split);
        }
    }
}
