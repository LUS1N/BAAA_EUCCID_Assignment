using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class EUCCID
    {
        public string ChristianName { get; set; }
        public string FamilyName { get; set; }
        public string EuCcid { get; set; }
        public string Gender { get; set; }
        public string StreetHouseNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string BirthCountry { get; set; }
        public string CurrentCountry { get; set; }

        public override string ToString()
        {
            return $"{nameof(ChristianName)}: {ChristianName},\n {nameof(FamilyName)}: {FamilyName},\n {nameof(EuCcid)}: {EuCcid},\n {nameof(Gender)}: {Gender},\n {nameof(StreetHouseNumber)}: {StreetHouseNumber},\n {nameof(ApartmentNumber)}: {ApartmentNumber},\n {nameof(County)}: {County},\n {nameof(City)}: {City},\n {nameof(BirthCountry)}: {BirthCountry},\n {nameof(CurrentCountry)}: {CurrentCountry}";
        }
    }
}
