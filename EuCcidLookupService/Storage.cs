using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace EuCcidLookupService
{
    public class Storage
    {
        public static EUCCID GetUEuccidByNumber(string euccid)
        {
            return new EUCCID()
            {
                ChristianName = "Christiano",
                FamilyName = "Jezuino",
                City = "City",
                StreetHouseNumber = "Street 4b",
                ApartmentNumber = "2a",
                CurrentCountry = "Denmark",
                BirthCountry = "Russia",
                EuCcid = euccid,
                Gender = "Male"
            };
        }
    }
}
